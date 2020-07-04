using kolokwium_pk.DTOs;
using kolokwium_pk.Models;
using System.Collections.Generic;

namespace kolokwium_pk.Services
{
    public interface IFiretruckActionsService
    {
        public FiretruckAction AssignFiretruck(int IdAction, int IdFiretruck);
    }
}