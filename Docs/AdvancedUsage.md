- [Advanced Usage](#advanced-usage)
  - [Namespaces](#namespaces)
  - [Naming Conventions](#naming-conventions)
  - [Advanced Usage Examples](#advanced-usage-examples)
    - [Calling Game Functions](#calling-game-functions)
    - [Hooking/Detouring Game Functions](#hookingdetouring-game-functions)
- [List of Parsers](#list-of-parsers)

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
| -------------------------------------- | -------------------------------- |
| .bin Hint File (in dvdroot/font)       | Heroes.SDK.Parsers.HintFile      |
| Spline Format (for Stage Injector Mod) | Heroes.SDK.Parsers.ManagedSpline |