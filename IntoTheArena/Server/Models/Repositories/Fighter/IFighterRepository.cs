using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntoTheArena.Server.Models.Repositories.Fighter
{
    public interface IFighterRepository
    {
        List<IntoTheArena.Shared.Fighter> GetAll(string playerEmail);
    }
}
