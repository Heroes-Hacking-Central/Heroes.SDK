<div align="center">
	<h1>Heroes SDK</h1>
	<strong>🎈 Disassembly in Code 🎈</strong>
    <p>And a fairly easy to use SDK for making mods.</p>
</div>

# About

This is a single unified library providing both, an easy way to manipulate the game at runtime and definitions for many of Sonic Heroes' internal data structures and functions.

It primarily is intended for easier creation of mods with Reloaded II, though it does contain many structures invaluable to creating standalone tools/parsers. There are also some included parsers of its own, allowing for creation/extraction of various game formats.

This SDK is originally pieced together from mods made by [Sewer](https://github.com/Sewer56) and further driven by ~~Donut's disassembly he will release once Half Life 3 releases~~ the [community disassembly](https://github.com/Heroes-Hacking-Central/Heroes-Disassembly).

## Using the API
An easy to use API for manipulating the game at runtime is available in the `Heroes.SDK.API` namespace.

### Examples

#### Execute Code At Start of Every Frame while In-Stage.
```csharp
// Sets a method to execute at the start of a frame.
Event.AfterSleep += AfterSleep;

// Method to execute at the start of a frame.
private void AfterSleep()
{
    if (State.IsInLevel()) 
    {
        /* Do Stuff when in Level */
    }
}
```

#### Control The Camera
```csharp
Camera.IsCameraEnabled = false; // Takes away camera control from the game.
if (State.IsInLevel()) 
{
    /* Do Stuff with Camera */
    ref var camera = ref Camera.Cameras[0];
    camera.MoveBy(new Vector3(1, 0, 0));
}
```

#### Get Controller Inputs
```csharp
ref var PlayerOneInputs = ref State.FinalInputs[0];
if (PlayerOneInputs.ButtonFlags.HasFlag(ButtonFlags.Jump)) 
{
    /* Execute Code when Jump Button Pressed */
}
```

#### Edit Player Physics Realtime
```csharp
if (State.IsInLevel() && Player.GetCharacterCount() > 0) 
{
    ref var speedCharacter = ref Player.PlayerTop[0].AsReference();
    speedCharacter.Physics.GravitationalPull = 9.81F;
}
```

### Advanced Usage
See [Advanced Usage](./Docs/AdvancedUsage.md)

## Using the Library

1. Add this git repository as a submodule.
2. Add `Heroes.SDK` to your solution.
3. Add `Heroes.SDK` as a project reference to your project.

You might need to update the project you are referencing this library from to `netstandard2.1`/`netcoreapp3.0` or newer.

### Adding Reloaded.Hooks

As of 26th of October 2019, the SDK does not ship with `Reloaded.Hooks` anymore to reduce on both mod and program sizes using the SDK.

If you plan to create mods using the SDK, you need to supply the SDK an instance of `IReloadedHooks`.

To do so, download [Reloaded.Hooks](https://github.com/Reloaded-Project/Reloaded.Hooks) from NuGet and call the function `SDK.Init`, passing your instance of `ReloadedHooks` before executing any other SDK code.

```csharp
SDK.Init(new ReloadedHooks());   
```

If you are developing a mod with `Reloaded II`, consider using Shared Libraries as outlined below.

### In Reloaded II Mods

The following are a simple set of heavily recommended guidelines for using the Heroes SDK in conjunction with developing [Reloaded II](https://github.com/Reloaded-Project/Reloaded-II) mods.

- Use the [Reloaded.Hooks Shared Library](https://github.com/Sewer56/Reloaded.SharedLib.Hooks). Why? Please see the [three main reasons](https://github.com/Sewer56/Reloaded.SharedLib.Hooks#fast-startup-times).

```csharp
// In Start() function of a Reloaded II mod, set the ReloadedHooks instance used to the shared one.
_modLoader.GetController<IReloadedHooks>().TryGetTarget(out ReloadedHooks);
SDK.Init(ReloadedHooks);    
```
- If using Reloaded-II's [Inter Mod Communication](https://github.com/Reloaded-Project/Reloaded-II/blob/master/Docs/InterModCommunication.md) to expose interfaces, **DO NOT INCLUDE THE TYPES FROM THE SDK IN YOUR INTERFACES**. 
  - Not only would that force mods to have a copy of the SDK in their output folder but it would force them to use the same version of the SDK as the source mod.
  - If you require to use some structs from the SDK, copy the structs into your interface library from the SDK and cast wherever needed from the copied type to the SDK type. See [Heroes.Controller.Hook](https://github.com/Sewer56/Heroes.Controller.Hook.ReloadedII/tree/master/Heroes.Controller.Hook.Interfaces) if an example is required.


## Submitting Issues

If you are submitting an issue, your issue should include the following:

- A clear, concise description of the problem.
- Steps to reproduce the problem. If you cannot get the problem to happen on-command, it's going to be tough.
- Screenshots and/or video would be appreciated.

## Real-time Assistance & Discussion
The toolkit developer(s) and other community members familiar with it are frequently available at:
- [The Heroes Hacking Central](https://discord.gg/QS9QrgR)
