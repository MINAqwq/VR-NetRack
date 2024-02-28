This Document largely covers the function and purpose of the Objects found inside the Project, and how they work together.
Any objects not explicitly explained or detailed here were either forgotten about, or were part of the Unity-provided Assets.

## Ports
Ports are simply colliders of any size that are found under the "Plug" tag.

### Wires/Cables
Wires or Cables are Prefabs which can be found inside the `Prefabs/` folder.
The spawn with two Plug objects and a Line Renderer objects.

#### Plug
Plugs are what makes up the ends of each wire. They also handle most of the code responsible for plugging and unplugging.

## Cable Box
The Cable Box is what's used to spawn more cables. This is accomplished by pressing the Trigger button while grabbing it.