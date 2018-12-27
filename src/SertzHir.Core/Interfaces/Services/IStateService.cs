using SertzHir.Core.Models;

namespace SertzHir.Core.Interfaces.Services
{
    public interface IStateService
    {
        Result AddState(StateModel stateModel);
        Result UpdateState(StateModel stateModel);
        Result GetStates();
    }
}