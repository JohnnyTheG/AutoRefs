# AutoRefs
Automatic component referencing for Unity.

Simply annotate any reference in your Unity scripts with the [AutoRef] attribute and the search target you require and the reference will be automatically set either by selecting the "Set AutoRefs" option in the Unity inspector, pressing the play button in the editor or building the project. This makes using GetComponent<> at runtime obsolete as references can be set and saved before runtime.

The example script below is used to get automatic references from the GameObject the script is attached to. It is possible to get references to any built in component or user scripted component easily and quickly.

![alt text](https://user-images.githubusercontent.com/20816598/35009844-d597cf9a-faf8-11e7-918e-e569d4eb459c.png)