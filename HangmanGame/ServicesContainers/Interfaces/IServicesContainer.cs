using CSharpConsoleHangmanGame.Debugging.Interfaces;
using CSharpConsoleHangmanGame.Dialogue.Databases;
using CSharpConsoleHangmanGame.Dialogue.Interfaces;
using CSharpConsoleHangmanGame.GameStates.Interfaces;
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
