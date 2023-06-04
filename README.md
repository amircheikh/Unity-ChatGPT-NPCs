# Unity-ChatGPT-NPCs
This project showcases OpenAI's gpt-3.5-turbo in Unity to create custom characters in video games.\
The API calls are made directly in game by using OkGoDoIt/OpenAI-API-dotnet, a C# OpenAI sdk.
## Showcase video
A video I made showcasing this project: https://www.youtube.com/watch?v=mihnhEf5PVQ
## BunzelTown
BunzelTown is a demo of this project included in this project.\
The goal of the demo is to find the password to the Castle of Bunzel by asking the NPCs around the town.\
Say the password to the guard of the castle and you will be let in!
## Build and Run
1. Open the project folder in Unity (I used editor version 2021.3.5f1 but other versions may work).
2. Create a .openai file with your OpenAI api key and place it in you username's folder (Windows) or in the root directory (Linux). Format is as follows:
```
OPENAI_KEY=XXX
```
Alternatively, you can edit line 56 in OpenAiTextChat.cs from:
```csharp
api = new OpenAIAPI(); //Gets api key from default location. In your username's folder on Windows.
```
To use one of the following methods:
```csharp
OpenAIAPI api = new OpenAIAPI("YOUR_API_KEY"); // shorthand
// or
OpenAIAPI api = new OpenAIAPI(new APIAuthentication("YOUR_API_KEY")); // create object manually
// or
OpenAIAPI api = new OpenAIAPI(APIAuthentication LoadFromEnv()); // use env vars
// or
OpenAIAPI api = new OpenAIAPI(APIAuthentication LoadFromPath()); // use config file (can optionally specify where to look)
```
3. In the "Scenes" folder, load **"MainScene"** to play BunzelTown or **"SampleScene"** for a blank scene with one NPC.
4. Run the game from Unity or build it under File->Build Settings...
## Adding new NPCs to the scene
1. In the "Prefabs" folder, drag the **"TextChatBot"** prefab into the scene.
2. Under the _"Open Ai Text Chat"_ component in the inspector, customize the following:
```
Bot name: The name the NPC will be refered by.
Initial  role: A detailed description of what the NPC will say and how it will act. This will customize the responses of the NPC.
Start string: The initial string shown when the user approaches the NPC.
```
3. Under the _"Bot Idle"_ component in the inspector, change _"Talk Range"_ to an appropriate distance where the NPC is approachable at. Leave _"Conversation Mode"_ as 0.
4. Find the _"Conversation Camera"_ in the children of your TextChatBot and move it to an appropriate position in the scene where the player and NPC can be seen.
5. Run the game and enjoy!
