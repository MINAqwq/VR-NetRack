# dynamic_line.cs
This script is responsible for drawing the wires between two wire endpoint nodes.

## Start
This function initializes the Wire, getting the LineRenderer Component, and enabling it to be drawn.

## Fixed Update
Fixed Update is run once per frame.
It makes sure that the start and end point of the wire are connected to the start and end nodes each frame.

## Unintended Behavior
For whatever reason, moving the line object that draws the wire from the parent origin (usually, this is the world origin) results in the wire getting distorted and positioned with an offset. As such it's advised to never move the GameObject line from 0,0,0!



# cableBoxScript.cs
This script is responsible for creating a new wire when grabbing from the cable box.

## Fire
This function is triggered when grabbing and pressing the fire key on the cable box object. This results in it creating the specified 



# pluggable.cs
This script is responsible for handling how ports and the ends of wire nodes work.

## Start
This gets current objects Rigidbody component and XRGrabInteractable Component, these are responsible for getting/setting Position and Grabbability of the object.

## resetText
This function is used to reset the Text of the floating label above the wire endpoint to "Unplugged".

## LateUpdate
LateUpdate is run towards the end of a frame.
It is used to check if the wire endpoint is plugged into something. If this is the case, it'll allow it to be grabbable again.
f it is unplugged, we check if it was plugged in previously by checking if an object is still saved inside **pluggedIntoThis**. If this is true, we check if the collider of the object.

### Bugs
- If a plug is plugged into another port within the 60-frame window that is provided, the object reference is overwritten, resulting in it's collider never being enabled again.

### Potential Improvements
- Potential Fix for plug bug: Script inside Port Object that re-enables collision by itself after 60-frame window.
- Changing this from LateUpdate to FixedUpdate, as currently it's tied to the framerate.

## OnTriggerEnter
This function is called when the Port collides with any collider, but it's contents are only executed when the objects tag is equal to "Port" and if it's not plugged into another port.
The pluggedIntoThis is set and the disableAll function is run.

## disableAll
This function disables any and all grabbability, and also sets the plugs position to that of the port it's plugged into. It also disables it's physics to avoid it falling out of the port.

## enableAll
The counter-part of disable all. Re-enables all functionality.


