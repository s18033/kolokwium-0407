using kolokwium_pk.DTOs;
using System.Collections.Generic;

namespace kolokwium_pk.Services
{
    public interface IFirefighterActionsService
    {
        public IEnumerable<FirefighterActionResponseDTO> GetActions(int IdFirefighter);
    }
}