using kolokwium_pk.DTOs;
using kolokwium_pk.Models;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;

namespace kolokwium_pk.Services
{
    public class FiretruckActionsService : IFiretruckActionsService
    {
        MainDbContext _context;

        public FiretruckActionsService(MainDbContext context)
        {
            this._context = context;
        }

        public FiretruckAction AssignFiretruck(int IdAction, int IdFiretruck)
        {
            var concreteAction = _context.Actions.Find(IdAction);
            var concreteFiretruck = _context.Firetrucks.Find(IdFiretruck);

            if (concreteAction == null || concreteFiretruck == null)
            {
                return null;
            }

            if (concreteAction.NeedSpecialEquipment && concreteFiretruck.SpecialEquipment == false)
            {
                throw new FirefightersException("Firetruck needs special equipment.");
            }

            var concreteFiretruckActions = (from fAction in _context.FiretruckActions
                                            join firetruck in _context.Firetrucks on fAction.IdFiretruck equals firetruck.IdFiretruck
                                            join singleAction in _context.Actions on fAction.IdAction equals singleAction.IdAction
                                            select new
                                            {
                                                IdAction = fAction.IdAction,
                                                EndTime = singleAction.EndTime
                                            });

            var isFiretruckAlreadyAssignedToAction = concreteFiretruckActions
                                                        .Where(action => action.IdAction == IdAction)
                                                        .FirstOrDefault() != null;

            if (isFiretruckAlreadyAssignedToAction)
            {
                throw new FirefightersException("Firetruck is already assigned to this action.");
            }

            var existingNotEndedActions = concreteFiretruckActions
                          .Where(action => action.EndTime == null)
                          .ToList();

            if (existingNotEndedActions.Count > 0)
            {
                throw new FirefightersException("Firetruck is assigned to other actions.");
            }

            var newFiretruckAction = new FiretruckAction()
            {
                IdAction = IdAction,
                IdFiretruck = IdFiretruck,
                AssignmentDate = DateTime.Now
            };

            var result = _context.FiretruckActions.Add(newFiretruckAction);

            _context.SaveChanges();

            return result.Entity;
        }       
    }
}
