using CarWashProcessor.Models;

namespace CarWashProcessor.Interfaces
{

    public interface IAddOnService
    {

        EServiceAddon AddOnType { get; }

        Task DoAddOnAsync(CarJob carJob);

    }

}