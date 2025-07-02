using CarWashProcessor.Interfaces;
using CarWashProcessor.Models;

namespace CarWashProcessor.Services;

public class CarJobProcessorService
{

    private readonly IEnumerable<IWashService> _washServices;
    private readonly IEnumerable<IAddOnService> _addOnServices;

    public CarJobProcessorService(
        IEnumerable<IWashService> washServices,
        IEnumerable<IAddOnService> addOnServices
    )
    {
        // Set services
        _washServices = washServices;
        _addOnServices = addOnServices;
    }

    public async Task ProcessCarJobAsync(CarJob carJob)
    {
        IWashService washService =
            _washServices
            .FirstOrDefault(washService => washService.WashType == carJob.ServiceWash) ??
            throw new InvalidOperationException($"Wash service ({carJob.ServiceWash}) not recognized.");
        await washService.DoWashAsync(carJob);

        foreach (var addonService in carJob.ServiceAddons)
        {
            IAddOnService _addOnService =
                _addOnServices
                .FirstOrDefault(addOnService => addOnService.AddOnType == addonService) ??
                throw new InvalidOperationException($"AddOn service ({addonService}) not recognized.");
            await _addOnService.DoAddOnAsync(carJob);
        }
    }

}