using kolokwium_pk.DTOs;
using kolokwium_pk.Models;
using Microsoft.EntityFrameworkCore.Internal;
using System.Collections.Generic;
using System.Linq;

namespace kolokwium_pk.Services
{
    public class FirefighterActionsService : IFirefighterActionsService
    {
        MainDbContext _context;

        public FirefighterActionsService(MainDbContext context)
        {
            this._context = context;
        }

        public IEnumerable<FirefighterActionResponseDTO> GetActions(int IdFirefighter)
        {
            var concreteFirefighter = _context.Firefighters.Find(IdFirefighter);

            if (concreteFirefighter == null)
            {
                return null;
            }

            var firefighterActions = _context.FirefighterActions.Where(singleAction => singleAction.IdFirefighter == IdFirefighter);

            var actions = (from fAction in firefighterActions
                          join action in _context.Actions on fAction.IdAction equals action.IdAction
                          select new FirefighterActionResponseDTO
                          {
                              IdAction = action.IdAction,
                              Start = action.StartTime,
                              End = action.EndTime
                          }).OrderByDescending(item => item.End).ToList();

            return actions;
        }       
    }
}
