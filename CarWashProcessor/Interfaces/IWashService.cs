using CarWashProcessor.Models;

namespace CarWashProcessor.Interfaces
{

    public interface IWashService
    {

        EServiceWash WashType { get; }

        Task DoWashAsync(CarJob carJob);

    }

}