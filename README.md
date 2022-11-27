# BOIDS UNITY MVP FRAMEWORK
## About
Boids - an MVP *(ModelViewPresenter)* framework, that allows to
build fast and expandable games and apps with unity elements.

**Note:** this framework is only for building on unity-based elements, and doesn't completly override unity functionality. It is not purpose of this framework, but it is possible to extend this framework to new level and separate unity logics.

## Usage
### Instalization
* Copy repository or download .unitypackage from release files.
* Open unity <ins>2021.3.8f1</ins> [UnityHub download](unityhub://2021.3.8f1/b30333d56e81) 
* Run <ins>Splash</ins> Scene

### Worlds
Framework separates all worlds logics between different assemblies. Your working project path per world should look like this: `Scripts/Impl/Worlds/%worldname%/`

### Entity
Entity *(IEntity)* - is just a container with [uid](#uid), that contains fields:
(TM)Model, (TV)View, (TP)Presenter, (int)Uid;

You can't code any logics inside of this. use Presenter

### World
World contains features for containing, updating, and managing entities inside of this world.
Fields:
* [ServiceLocator](#ServiceLocator);
* [LifeCycle](#WorldLifeCycle)
* [Entities](#WorldLifeCycle)
* RequestSwitch (Requests World Switch) 
* IsEnabled (Is world enabled)

## Dictionary

### uid
Uid - int, unique identifier. Usually used for entity.
#### Usage:
```csharp
var uidGenerator = _world.ServiceLocator.GetService<IUidGenerator>();
var uid = uidGenerator.Next(); // int
```
-----------------------------------------------
### ServiceLocator
Contains services. Usually, you can access this through IWorld. Also contains ISettingsLocator
#### Usage:
```csharp
var someService = _world.ServiceLocator.GetService<ISomeService>();
someService.DoSomething();
```
-----------------------------------------------
### WorldLifeCycle
Gives ability to subscribe and unsubscribe to update events in world.
#### Usage:
```csharp
// add IUpdateListener
public class SomePresenter : APresenter, IUpdateListener
{
    private readonly IWorld _world;

    public CameraPresenter(IWorld world)
    {
        _world = world;
        
        _world.LifeCycle.AddUpdateListener(this); // now you can subscribe self to update
    }
}
```
-----------------------------------------------
### WorldLifeCycle
IWorldEntityCollection. Has entities. You can add entities manually (not recommended).
#### Usage:
```csharp
_world.Entities.Get<SomeModel, SomeView, SomePresenter>(10) // get by uid ands casts to your M, V, P
_world.Entities.GetByTag("tag") // returns collection of entities by tag
```

## Contribution
Framework is open-source and this is my first open-source project. Use separate branch and merge requests / pull request.
Here is some good behaviours:
* Every commit should be named understandable and in English
* Every commit should start with: `DEV - for main devs`, `CTR - for public contributors`, `EX - for example & showcases branches`;
* Before pull request, **Pull** changes from `main`.
* Create merge request and wait for merge or comments
#### Contacts:
* [Discord](https://discord.gg/EkS3SjqZfd)
* [Website](https://cyberfrogg.com/)
* [Official Repository](https://github.com/cyberfrogg/boids-unity)