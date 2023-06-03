using TragicTheReckoning.Models;

namespace TragicTheReckoning.Controllers.Interfaces
{
    public interface IPhase
    {
        void RunPhase(int roundNumber, params Player[] players);
    }
}