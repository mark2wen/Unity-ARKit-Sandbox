# Unity-ARKit-Sandbox
An environment to easily mess around in AR.

## How to use 

1) Clone/Download the repo. Open the project in Unity.
2) Add ARKit-Plugin from the Asset store to the project.
3) Open the test scene from Unity-ARKit-Sandbox/ARKit-Sandbox/Scenes/ARKitSandbox.unity
4) Create prefabs you want to instantiate. They must have an ARObject component attached to their top level GameObject. 
5) Add them to the list "Objects" on the component "ARObjectSelectorUI" on the "UI/MainMenuScrollView" scene object. 
6) Make a build.

![Object Selector UI](http://connorbell.ca/assets/refs/git/objectselector.png "Object Selector UI")

## Using reflection to modify gameobject properties 

1) On any ARObject, click "Add reflection".
2) Drag the object or material into the field containing the property you want to modify.
3) Instantiate the object in a build and use the reflection menu to change the value.

![Reflection Inspector](http://connorbell.ca/assets/refs/git/reflection1.png "Reflection Inspector")

![Reflection In Build](http://connorbell.ca/assets/refs/git/reflection2.png "Reflection In Build")

Note: The reflection classes were generously provided by Cale Bradbury from the Neovisual library we use to VJ with. Check it out [here](https://github.com/netgrind/NeoVisual)!

## Todo
* Uniform scaling
* Select active objects from list
* Reflection support for other types and functions.
* Camera post effects
* ARCore support? I’d like to add I just don’t have a device
