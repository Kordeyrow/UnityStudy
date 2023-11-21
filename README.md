
<!-- 
	Shields
-->
[![Downloads][downloads-shield]][downloads-url]

[downloads-shield]: https://img.shields.io/github/downloads/Kordeyrow/UnityStudy-HangmanGameConsole/total?logo=GitHub
[downloads-url]: https://github.com/Kordeyrow/UnityStudy-HangmanGameConsole/graphs/contributors


<!-- 
	Logo
-->
<div align="center">
  <a href="https://github.com/Kordeyrow">
    <img src="Images/logo.png" alt="Logo" width="100" height="100">
  </a>

  <h3 align="center">Hangman Game Console</h3>

  <p align="center">
    A console game to study game programming with C#
  </p>
</div>


<!-- 
	Game flow Diagram
-->

## GameFlow Diagram

```mermaid
stateDiagram-v2

    

    state "GAME FLOW" as GameStatesDetailed {
        direction TB
    
        state "GAME STATES" as GameStatesOverview {
            direction LR
            
            state "Menu" as Menu
            state "GameLoop" as GameLoop
            state "Results" as Results

            Menu --> GameLoop

            Results --> GameLoop 
            Results --> Menu

            GameLoop --> Menu
            GameLoop --> Results
        }

        --
        Start --> Menu_GameState_Start

        state Menu_GameState {

            state "Start" as Menu_GameState_Start
            Menu_GameState_Start --> Menu_GameState_Get_Message
            
            state "Dialogue Database" as Menu_GameState_Dialogue_Database {
                state "Get_Message" as Menu_GameState_Get_Message
                Menu_GameState_Get_Message --> Menu_GameState_IOController.ShowMessage
            }

            state "IOController" as Menu_GameState_IOController {
                direction LR

                state "ShowMessage" as Menu_GameState_IOController.ShowMessage
                Menu_GameState_IOController.ShowMessage --> Menu_GameState_IOController.ReadInput

                state "ReadInput" as Menu_GameState_IOController.ReadInput
                Menu_GameState_IOController.ReadInput --> IsUserAction
            }

            state "Is_UserAction ?" as IsUserAction
            state Menu_GameState_if <<choice>>
            IsUserAction --> Menu_GameState_if

            Menu_GameState_if --> Play
            Menu_GameState_if --> CloseGame

            state "Play" as Play
            Play --> GameLoop_GameState_Start

            state "Close Game" as CloseGame
        }

        state GameLoop_GameState {
            direction LR

            state "Start" as GameLoop_GameState_Start
            GameLoop_GameState_Start --> Get_GetUserInput_IOController.ReadInput
            
            state "Get_GetUserInput" as Get_GetUserInput {
            
                state "IOController" as Get_GetUserInput_IOController {
                    state "ReadInput" as Get_GetUserInput_IOController.ReadInput
                    Get_GetUserInput_IOController.ReadInput --> Is_Letter
                }
                
                state "Is_Letter ?" as Is_Letter 
                state Get_GetUserInput_if <<choice>> 
                Is_Letter --> Get_GetUserInput_if
                
                Get_GetUserInput_if --> SecretWordHas_Letter: YES
                Get_GetUserInput_if --> Get_GetUserInput_IsUserAction: NO

                state "Is_UserAction" as Get_GetUserInput_IsUserAction
                state Get_GetUserInput_if2 <<choice>> 
                Get_GetUserInput_IsUserAction --> Get_GetUserInput_if2

                Get_GetUserInput_if2 --> TogglePause
                Get_GetUserInput_if2 --> ExitToMenu

                state "TogglePause" as TogglePause
                state "ExitToMenu" as ExitToMenu
            }
            
            state "TryUseLetter" as TryUseLetter {

                state "SecretWord.Has_Letter ?" as SecretWordHas_Letter
                    state if <<choice>>  
                    SecretWordHas_Letter --> if
                    if --> Hangman.Add_Part: NO
                    if --> SecretWord.Is_LetterOpen: Yes

                state "SecretWord.Is_LetterOpen ?" as SecretWord.Is_LetterOpen
                    state if2 <<choice>>  
                    SecretWord.Is_LetterOpen --> if2
                    if2 --> SecretWord.Open_Letter: NO
                    if2 --> Restart_GameLoop_GameState_Start: YES

                state "SecretWord.Open_Letter" as SecretWord.Open_Letter
                SecretWord.Open_Letter --> SecretWord.Is_Complete
                
                Hangman.IsComplete --> Lose

                state "SecretWord.Is_Complete ?" as SecretWord.Is_Complete
                    state if3 <<choice>>  
                    SecretWord.Is_Complete --> if3
                    if3 --> Win: YES
                    if3 --> Restart_GameLoop_GameState_Start: NO

                state "Hangman.Add_Part" as Hangman.Add_Part
                Hangman.Add_Part --> Hangman.Draw

                state "Hangman.Draw" as Hangman.Draw
                Hangman.Draw --> Hangman.IsComplete

                state "Hangman.IsComplete ?" as Hangman.IsComplete
                    state Hangman.IsComplete_if <<choice>>  
                    Hangman.Is_Complete --> Hangman.IsComplete_if
                    Hangman.IsComplete_if --> Win: YES
                    Hangman.IsComplete_if --> Restart_GameLoop_GameState_Start: NO
            }
            
            state "GameOver" as GameOver {
                state "Lose" as Lose
                state "Win" as Win
            }

            state "Run State Again" as Restart_GameLoop_GameState_Start
        }

        state Results_GameState {

            state "Start" as Results_GameState_Start
            Results_GameState_Start --> ShowResults
            
            state "ShowResults" as ShowResults
            ShowResults --> RGS_Get_UserChoice
            
            state "Get_UserChoice" as RGS_Get_UserChoice 
                state if4 <<choice>>  
                RGS_Get_UserChoice --> if4
                if4 --> RGS_PlayAgain
                if4 --> RGS_ExitToMenu
            state "PlayAgain" as RGS_PlayAgain
            state "ExitToMenu" as RGS_ExitToMenu
        }
    }
    Lose --> Results_GameState_Start
    Win --> Results_GameState_Start

    state "Interfaces" as Interfaces {
	state IOController {
        direction LR

        state "ReadInput()" as ReadInput
        state "ShowMessage()" as ShowMessage
    }

    state DialogueDatabase {
        direction LR

        state "Get_Message()" as Get_Message
    }

    state UserActions {
        direction LR

        state "Get_Action()" as Get_Action
    }

    state SecretWord {
        direction LR

        state "Has_Letter( letter )" as Has_Letter
        state "Is_LetterOpen( letter )" as Is_LetterOpen 
        state "Open_Letter( letter )" as Open_Letter 
    }

    state Hangman {
        direction LR

        state "Add_Part()" as Add_Part
        state "IsComplete()" as IsComplete
        state "Draw()" as Draw
    }
    }
    
	classDef Red fill:Red, stroke:#000000, stroke-width:3px,color:black,font-weight:bold
	classDef Yellow fill:#ffaa4444, stroke:#000000, stroke-width:3px,color:black,font-weight:bold
	
	class Start Red
	class Menu_GameState_Start Red
	class GameLoop_GameState_Start Red
	class Results_GameState_Start Red
	
	class IOController Yellow
	class Menu_GameState_IOController Yellow
	class Get_GetUserInput_IOController Yellow
```
