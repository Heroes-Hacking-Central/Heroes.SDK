<div align="center">
	<h1>Heroes SDK</h1>
	<strong>🎈 Disassembly in Code 🎈</strong>
    <p>And a fairly easy to use SDK for making mods.</p>
</div>

# About

This is a single unified library providing both, an easy way to manipulate the game at runtime and definitions for many of Sonic Heroes' internal data structures and functions.

It primarily is intended for easier creation of mods with Reloaded II, though it does contain many structures invaluable to creating standalone tools/parsers. There are also some inclu ded parsers of its own, allowing for creation/extraction of various game formats.

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
	ref var speedCharacter = ref Player.PlayerTop[0];
	speedCharacter.Physics.GravitationalPull = 9.81F;
}
```

## Advanced Usage

Using the API is nice, but for more complex mods you will probably need to get your hands dirty with game code. The easy to use API only provides a very limited subset of functionality, focusing on mostly useful functions in order to keep it easy to use.

### Namespaces

| Heroes.SDK.Definitions                 | Contains a huge collection of various enums, structs and other complex types, used all over game code. |
| -------------------------------------- | ------------------------------------------------------------ |
| Heroes.SDK.Classes.NativeClasses       | Contains partial and/or complete representation of the game's native C++ classes. |
| Heroes.SDK.Classes.PseudoNativeClasses | Contains classes which provide a listing of game's C methods. Methods are split into classes by category/library e.g. CStandardLibrary has functions from the C Standard Library. |
| Heroes.SDK.Parsers                     | Contains parsers and writers for various file formats used by the game. All parsers in this namespace support reading files from game memory. |
| Heroes.SDK.Utility                     | Miscellaneous Utility Classes                                |

Functions which are either not known which C++ class they belong to or are not confirmed to be C code can be found at `Heroes.SDK.Classes.Uncategorized`.

### Naming Conventions

The following naming conventions concern the classes contained in the `Heroes.SDK.NativeClasses` and `Heroes.SDK.PseudoNativeClasses` namespaces.

- Delegates of native game functions are prefixed with `Native_`.
For example, the `free` function of the C standard library would have a delegate called `Native_Free`.

- Declarations of game functions should be prefixed with `Fun_`
Example:
```csharp
public static Function<Native_Destructor> Fun_Destructor = new Function<Native_Destructor>(0x0042D1E0, ReloadedHooks.Instance);
```

### Advanced Usage Examples

For more information, check out the underlying Hook/Detour Library; [Reloaded.Hooks](https://github.com/Reloaded-Project/Reloaded.Hooks).

#### Calling Game Functions
```csharp
// Call game function that converts inputs in heroesController to skyPad.
GamePeri.Fun_ConvertPadData.GetWrapper()(heroesController, skyPad);
```

#### Hooking/Detouring Game Functions

```csharp
// _convertPadData is defined as `private IHook<GamePeri.Native_ConvertPadData> _convertPadData;`
_convertPadData = GamePeri.Fun_ConvertPadData.Hook(ConvertPadData).Activate();

// Function to replace original with.
private unsafe SkyPad* ConvertPadData(HeroesController* heroesController, SkyPad* skyPad)
{
	/* Insert code to hijack controller inputs here. */
}
```

## List of Parsers

| .ONE Archive                           | Heroes.SDK.Parsers.OneArchive    |
|----------------------------------------|----------------------------------|
| .bin Hint File (in dvdroot/font)       | Heroes.SDK.Parsers.HintFile      |
| Spline Format (for Stage Injector Mod) | Heroes.SDK.Parsers.ManagedSpline |

## Using the Library

1. Add this git repository as a submodule.
2. Add `Heroes.SDK` to your solution.
3. Add `Heroes.SDK` as a project reference to your project.

## Submitting Issues

If you are submitting an issue, your issue should include the following:

- A clear, concise description of the problem.
- Steps to reproduce the problem. If you cannot get the problem to happen on-command, it's going to be tough.
- Screenshots and/or video would be appreciated.

## Real-time Assistance & Discussion
The toolkit developer(s) and other community members familiar with it are frequently available at:
- [The Heroes Hacking Central](https://discord.gg/QS9QrgR)
