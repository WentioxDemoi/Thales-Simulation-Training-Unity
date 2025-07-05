# Thales-Simulation-Training-Unity

## Description

This Unity project implements a real-time multiplayer chat system using Photon Unity Networking (PUN) allowing users to communicate through an online chat with an intuitive user interface.

## Features

- **Real-time multiplayer chat** : Instant communication between users
- **Adaptive user interface** : Messages of different sizes based on content length
- **Nickname system** : Each user can set their username
- **Automatic connection** : Automatically join a chat room or create a new one
- **Responsive interface** : Messages adapted based on whether they come from the user or other participants

## Prerequisites

- **Unity 2021.3.28f1** or compatible version
- **Photon account** : Required for network connectivity
- **Internet connection** : For real-time communication

## Installation

1. **Clone the repository**
   ```bash
   git clone [REPO_URL]
   cd Thales-Simulation-Training-Unity
   ```

2. **Open the project in Unity**
   - Launch Unity Hub
   - Click "Open" and select the "My project" folder
   - Wait for Unity to import all assets

3. **Photon configuration** (if needed)
   - The project already uses Photon Unity Networking
   - Make sure your Photon settings are configured in `Assets/Photon/PhotonRealtime/Code/Unity/PhotonAppSettings.cs`
   - bb4f543b-49ef-4440-bd1c-d01bb85021f3 Photon App ID

## Project Structure

```
My project/
├── Assets/
│   ├── Script/           # Main scripts
│   │   ├── ChatManager.cs    # Main chat manager
│   │   └── Chat.cs           # Individual message component
│   ├── Scenes/          # Unity scenes
│   │   └── SampleScene.unity # Main scene
│   ├── Resources/       # Resource assets
│   │   ├── Chat.prefab      # Chat prefab
│   │   ├── Prefabs/         # Message prefabs
│   │   └── Images/          # Interface images
│   ├── Photon/          # Photon Unity Networking SDK
│   └── TextMesh Pro/    # Advanced text system
├── ProjectSettings/     # Unity project configuration
└── Packages/           # Unity dependencies
```

## Usage

1. **Launch the application**
   - Open the `SampleScene` in Unity
   - Press Play or build the application

2. **Connection**
   - The application automatically connects to Photon
   - Enter your nickname in the provided field
   - Press Enter or click to validate

3. **Chat**
   - Type your message in the input field
   - Press Enter to send
   - Messages appear in real-time for all connected users

## Main Dependencies

- **Photon Unity Networking (PUN)** : Multiplayer networking system
- **TextMesh Pro** : Advanced text rendering system
- **Unity UI** : User interface

## Development

### Main Scripts

- **ChatManager.cs** : Manages Photon connection, messages and user interface
- **Chat.cs** : Component for displaying individual messages

### Technical Features

- Automatic Photon connection
- Join a random room or create a new one
- RPC system for message synchronization
- Adaptive interface based on message length
