using TragicTheReckoning.Models;

namespace TragicTheReckoning.Controllers.Interfaces
{
    public interface IPhase
    {
        void RunPhase(params Player[] players);
    }
}