﻿using CarWashProcessor.Interfaces;
using CarWashProcessor.Models;

namespace CarWashProcessor.Services;

public class AwesomeWashService : IWashService
{
    private readonly ILogger<AwesomeWashService> _logger;

    public EServiceWash WashType => EServiceWash.Awesome;

    public AwesomeWashService(ILogger<AwesomeWashService> logger)
    {
        // Set services
        _logger = logger;
    }

    public async Task DoWashAsync(CarJob carJob)
    {
        // Wait a second
        await Task.Delay(TimeSpan.FromSeconds(1));
        // Log information
        _logger.LogInformation("--> Awesome wash performed for customer {}!", carJob.CustomerId);
    }

}