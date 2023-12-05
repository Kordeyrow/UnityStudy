
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
    direction LR
    
    state PROGRAM {
    direction LR
        [*] --> AppSettings
        state AppSettings {
            direction LR
            state "LanguageID" as LanguageID
            state "WordsFile" as WordsFile
        }
        AppSettings --> ServiceContainers

        state ServiceContainers {
            [*]
        }
        ServiceContainers --> GameStateManger

        state GameStateManger {
            [*]
        }
        GameStateManger --> [*]
    }

    state "GAME STATES" as GameStates {
        [*] --> Menu
        
        state "Menu" as Menu
        state "GameLoop" as GameLoop
        state "Results" as Results
        state "CloseGame" as CloseGame

        Menu --> GameLoop
        Menu --> CloseGame
        
        GameLoop --> Results

        Results --> GameLoop
        Results --> Menu

        CloseGame --> [*]
    }

    state COMPONENTS {
        state GameObjects {
            state Hangman {
                [*]
            }
            state SecretWord {
                [*]
            }
        }
        --
        state Databases {
            state DialogueDB {
                [*]
            }
            state WordsDB {
                [*]
            }
        }
        --
        state GameSystems {
            state Dialogue {
                direction LR
                state Controller {
                    DisplayText
                }
                state OptionData {
                    Text
                    Action
                }
                
                DialogueUnitKeys
                OptionInputKeys
            }
        }
        --
        state Utils {
            direction LR
            state DebugLog {
                [*]
            }
            state FileReader {
                [*]
            }
            state JsonConverter {
                [*]
            }
            state HttpService {
                [*]
            }
        }
    }
    
classDef Red fill:#994455, stroke:#000000, stroke-width:4px,color:#bbcc66,font-weight:bold 
class GameObjects Red
class GameSystems Red
class ServiceContainers Red

classDef Blue fill:#224455, stroke:#000000, stroke-width:4px,color:#aacc99,font-weight:bold
class GameStateManger Blue
class AppSettings Blue
class Databases Blue
class Utils Blue

classDef RedAction fill:#ff4455, stroke:#000000, stroke-width:4px,color:#000000, font-weight:bold 
class DisplayText RedAction

classDef BlueData fill:#4444ff, stroke:#000000, stroke-width:4px,color:#000000, font-weight:bold 
class Text BlueData
class Action BlueData
```
