
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

## GameFlow / GameComponents Diagrams

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


### Extra Feature: Reading data from Google Sheets

![image](https://github.com/Kordeyrow/UnityStudy-HangmanGameConsole/assets/23510135/e7d9e3d8-dd7b-4b99-b04b-508adbd3c659)


### User Settings:

![image](https://github.com/Kordeyrow/UnityStudy-HangmanGameConsole/assets/23510135/c06df032-fde4-4bdf-9a3d-da8a7fd19937)

![image](https://github.com/Kordeyrow/UnityStudy-HangmanGameConsole/assets/23510135/aa4499cc-a6a4-4e96-9b7f-bc5c5124582a)

![image](https://github.com/Kordeyrow/UnityStudy-HangmanGameConsole/assets/23510135/385e1c62-cd1e-4ea6-9835-b814d7baee1a)

![image](https://github.com/Kordeyrow/UnityStudy-HangmanGameConsole/assets/23510135/79cf8336-3670-4147-b96e-ca1695255c6a)
