﻿namespace Boids.Services
{
    public interface IServiceLocator
    {
        T GetService<T>() where T : IService;
    }
}