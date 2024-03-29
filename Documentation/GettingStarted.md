This project was built ontop of the Unity-provided OpenXR Sample Project, as such many of the Assets and Scripts this Template utilize remain but are largely unused.

# Programs
This application was created using the following Programs. You will need these or later versions to use the project files.

## Unity 2022.3.10f1
Unity was chosen for it's compatibility with Oculus headsets, as well as thorough Documentation. Because the project uses Unity, C# is used for its scripts.

It can be downloaded from the [Unity Website](https://unity.com/), alongside the Unity Hub.

Please refer to the [Unity Documentation](https://docs.unity.com/) for more information.

## Visual Studio 2022
This program is created using Visual Studio 2022, which offers native compatibility with Unity. It is used to open and edit the .cs files, which are C#-Script files.

These are found in both `Assets/` and `Assets/Scripts/`, although putting future Scripts into the latter is advised.

Visual Studio is a Program by Microsoft, and can be downloaded from the [Visual Studio Website](https://visualstudio.microsoft.com/).

## Blender 4.0
Blender is a 3D-Modelling Software by the Blender Foundation. It can be downloaded from the [Blender Website](https://www.blender.org/).

Blender is used to open the .blend Project files found inside `BlenderFiles/`.

These are then exported as .fbx-files into the `Assets/RackObjects/` folder for Unity to recognize.

## Aesprite
Aesprite is open-source, but must be compiled from source to be used for free, pre-compiled binaries are paid. It's source code can be found on the [Aesprite GitHub Repository](https://github.com/aseprite/aseprite).

Aesprite is used to open .ase files, which are the project files for the 2D Texture creation. As the textures are very simple, any image editor can be used to simply edit the exported .png files directly.

Any and all textures are to be placed in `Assets/Textures/`.

## Git/GitHub Desktop
Git/GitHub Desktop was used for version control.

More on it can found in the [Git Section](Git.md).

Git can be acquired from many sources, so it's best to search it up yourself. If one chooses to use GitHub Desktop instead, it can be downloaded on the [GitHub Desktop Download Page](https://desktop.github.com/).

# Libraries
This project exclusively utilizes Unity-provided Libraries, including Unity's OpenXR Framework.

Please refer to the [Unity Documentation](https://docs.unity.com/) on how to use these and what functionality they provide.

# Getting Started
## Opening the Project
Open up Unity Hub and open the VR-NetRack folder with it. This should automatically start opening the Project, if the appropriate version of the Unity-Editor is present.

By default, GitHub Desktop puts it's repositories inside the Documents folder on Windows, so the path to the folder might look something like
```
C:\Users\UserName123\Documents\GitHub\VR-NetRack
```

## Opening the correct Room
Use the bottom Context Menu to open the mainRoom scene, found inside the Scenes folder.
```
Scenes/mainRoom
```

## XR Simulation Mode
You can choose between testing the game with an XR Simulator through Unity by checking or unchecking the option found inside
```
Edit > Project Settings > XR Interaction Toolkit > VR Device Simulator Settings
```
The Option is labelled as `Use XR Device Simulator in scenes`.

# Understanding the Project
For a more in-depth explanation, please see the [Project Structure](ProjectStructure.md).

## Difference between the Updates
### Update and LateUpdate
Update is called at the start of a frame.
LateUpdate is called towards the end of a frame.
They are tied to the framerate, and thus unsuitable for physics-related calculations.

### FixedUpdate
FixedUpdate runs independent of framerate, and is thus most commonly used for physics calculations. This update rate is usually set to 50 times per second.