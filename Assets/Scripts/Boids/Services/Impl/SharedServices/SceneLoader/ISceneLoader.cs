using System;

namespace Boids.Services.Impl.SharedServices.SceneLoader
{
    public interface ISceneLoader : IService
    {
        void Load(string name, bool isAdaptive, Action<string> loadComplete);
        void UnLoad(string name, Action<string> unloadComplete);
    }
}