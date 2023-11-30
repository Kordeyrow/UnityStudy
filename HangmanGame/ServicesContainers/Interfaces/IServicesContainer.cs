using CSharpConsoleHangmanGame.GameGenericModules.Dialogue.Interfaces;
using CSharpConsoleHangmanGame.GameLogic.GameStates.Interfaces;
using CSharpConsoleHangmanGame.HelperServices.Debugging.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleHangmanGame.ServicesContainers.Interfaces
{
    internal interface IServicesContainer
    {
        IDebugLog DebugLog { get; }
        IDialogueController DialogueController { get; }
        IDialogueOptionsInputKeys DialogueOptionsInputKeys { get; }
        IDialogueDatabase DialogueDatabase { get; }
        IGameState InitialGameState { get; }
        IDialogueUnitKeys DialogueUnitKeys { get; }
        IGameStateManager GameStateManager { get; }
        Task Init();
    }
}
