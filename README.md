# Hathora-Unity-Lobby-Example

## Overview

This repository hosts a Unity project (version 2021.3.28f1) featuring a server browser built using the Hathora Cloud. The project is an example demonstrating how to list lobbies/rooms in a server browser, with support for the URP pipeline. It's designed primarily for FishNet unity, but most of the code can be adapted for Mirror.

## Installation

### From GitHub

1. Clone or download this repository.
2. Open the project in Unity 2021.3.28f1 or later.

### From Unity Package

If you prefer to use the package rather than downloading the full project, follow these steps:

1. Import `hathora_cloud_Hathora_Cloud_Unity_plugin_latest.unitypackage` into your project.
2. Import the `Hathora-Unity-Lobby-Example` package.

## Features

The project provides an example of how to integrate a lobby listing system with minimal changes to Hathora's original code. Key prefabs and scripts have been modified to support this feature.

### Prefabs

1. **hathoralobbyrow:** Houses the lobby prefab controller script.
2. **customlobbycanvas:** Child of the HathoraManager prefab which holds the lobby prefabs.

### Scripts

Modified scripts include:

- **HathoraClientMgrDemoUI:** Handles the UI for the client manager demo, including new additions for the custom lobby.
- **HathoraFishnetClientMgrDemoUi:** Contains the FishNet-specific client manager demo UI.

## Usage

### Lobby Prefab Controller

The `LobbyPrefabController` class is responsible for handling individual lobby entries. 

### Custom Lobby Canvas

The CustomLobbyCanvas prefab is responsible for holding the lobby prefabs, and is a child of the HathoraManager prefab.

### Modified Methods

The `HathoraClientMgrDemoUI` script includes:

- `OnJoinRoomAsClientBtnClick`: Customized to handle the logic of joining rooms.
- `OnViewLobbies`: Modified to create prefabs and necessary logic to list and create lobbies in the CustomLobbyCanvas.

Feel free to report issues or submit pull requests.
