using System.Numerics;
using Heroes.SDK.Classes.PseudoNativeClasses;
using Heroes.SDK.Definitions.Enums;
using Heroes.SDK.Definitions.Structures.Input;
using Heroes.SDK.Definitions.Structures.RenderWare;
using Heroes.SDK.Definitions.Structures.State;
using Heroes.SDK.Utilities.Namer;
using Heroes.SDK.Utilities.Tagger;
using Heroes.SDK.Utilities.Tagger.Enums;
using Reloaded.Memory.Pointers;

namespace Heroes.SDK.API
{
    /// <summary>
    /// Contains everything related to the overall "state" of the game.
    /// Current menu, time, game save, stage etc.
    /// </summary>
    public static unsafe class State
    {
        /// <summary>
        /// The stage that is currently being played.
        /// </summary>
        public static ref Definitions.Enums.Stage CurrentStage => ref RefPointer< Definitions.Enums.Stage>.Create((Definitions.Enums.Stage*) 0x008D6720);

        /// <summary>
        /// Describes the state of the game at a given moment in time when the player is inside a stage.
        /// </summary>
        public static ref GameState GameState => ref RefPointer<GameState>.Create((GameState*) 0x008D66F0);

        /// <summary>
        /// Structure type that controls global game state, such as settings and modes currently in play/use.
        /// </summary>
        public static RefPointer<ModeSwitch> ModeSwitch => new RefPointer<ModeSwitch>((ModeSwitch*) 0x00A777E4, 2);

        /// <summary>
        /// Some event related structure.
        /// Allocated when a story event (ingame cutscene) starts playing.
        /// </summary>
        public static RefPointer<int> EventManagerTp { get; } = new RefPointer<int>((int*)0x00A776EC, 2);

        /// <summary>
        /// Stores the current number of victories for each of the players in two player mode.
        /// </summary>
        public static ref VictoryTracker VictoryTracker => ref RefPointer<VictoryTracker>.Create((VictoryTracker*) 0x009DD6BC);

        /// <summary>
        /// Platform specific of inputs from DInput read by the game at the end of the last frame.
        /// Note: Game does not use these inputs directly. They are converted into the structure at <see cref="FinalInputs"/>.
        /// </summary>
        public static RefFixedArrayPtr<HeroesController> Inputs => InputFunctions.Inputs;

        /// <summary>
        /// Platform independent array of inputs used by the game code to control everything.
        /// These inputs are used to control the actual game.
        /// </summary>
        public static RefFixedArrayPtr<SkyPad> FinalInputs => InputFunctions.FinalInputs;

        /// <summary>
        /// Instance of some component RenderWare Graphics Engine.
        /// </summary>
        public static RefPointer<RwEngineInstance> EngineInstance { get; } = new RefPointer<RwEngineInstance>((RwEngineInstance*)0x008E0A4C, 2);

        /// <summary>
        /// Returns true if in main menu, else false.
        /// </summary>
        public static bool IsInMainMenu()
        {
            return GameState == GameState.Menu || GameState == GameState.Null;
        }

        /// <summary>
        /// Returns true if the game is currently in the middle of a level, else false.
        /// </summary>
        public static bool IsInLevel()
        {
            ref var modeSwitch = ref ModeSwitch.TryDereference(out bool success);
            if (! success)
                return false;

            return modeSwitch.SystemMode == SystemMode.InGame && GameState == GameState.InGame;
        }

        /// <summary>
        /// Returns true if the game is currently in multiplayer mode.
        /// </summary>
        public static bool IsMultiplayerMode()
        {
            ref var modeSwitch = ref ModeSwitch.TryDereference(out bool success);
            return success && modeSwitch.Is2PMode;
        }

        /// <summary>
        /// Returns true if the game is currently paused.
        /// </summary>
        public static bool IsPaused()
        {
            GameState gameState = GameState;

            switch (gameState)
            {
                case GameState.InGamePaused:
                case GameState.InGamePausedSettings:
                case GameState.InGamePausedSettingsCamera:
                case GameState.InGamePausedSettingsRebinding:
                    return true;
            }

            return false;
        }

        /// <summary>
        /// True if the player is currently watching an event, else false. 
        /// </summary>
        public static bool IsWatchingIngameEvent()
        {
            var time = World.Time.ToTimeSpan();
            ref var eventManagerTp = ref EventManagerTp.TryDereference(out bool success);

            return ((time.Seconds == 0) && (time.Minutes == 0) &&
                    success && !IsInMainMenu());
        }

        /// <summary>
        /// Obtains a string representation of the current stage name.
        /// </summary>
        public static string GetStageName()
        {
            return Namer.GetStageName(CurrentStage);
        }

        /// <summary>
        /// Returns a set of arbitrary tags that categorize the currently played stage.
        /// </summary>
        public static StageTag GetStageTags()
        {
            return Tagger.GetStageTags(CurrentStage);
        }

        /// <summary>
        /// Obtains the controller port belonging to a given <see cref="HeroesController"/> input structure in memory.
        /// </summary>
        /// <returns>A value between 0 and 3 depending on player port. -1 if not found.</returns>
        public static int GetControllerPort(HeroesController* heroesController)
        {
            var inputs = Inputs;
            for (int x = 0; x < inputs.Count; x++)
            {
                if (heroesController == &inputs.Pointer[x])
                    return x;
            }

            return -1;
        }

        /// <summary>
        /// Obtains the controller port belonging to a given <see cref="SkyPad"/> input structure in memory.
        /// </summary>
        /// <returns>A value between 0 and 3 depending on player port. -1 if not found.</returns>
        public static int GetControllerPort(SkyPad* skyPad)
        {
            var finalInputs = FinalInputs;
            for (int x = 0; x < finalInputs.Count; x++)
            {
                if (skyPad == &finalInputs.Pointer[x])
                    return x;
            }

            return -1;
        }
    }
}
