# AutoRefs
Automatic component referencing for Unity.

Simply annotate any reference in your Unity scripts with the [AutoRef] attribute and some target types specifying where the references are expected to be found, and the reference will be automatically set either by selecting the "Set AutoRefs" option in the Unity inspector, pressing the play button or building the project. This makes using GetComponent<> in your scripts obsolete as references can be set and saved before runtime.

The basic example script below is used to get automatic references from the GameObject the script is attached to. It is possible to get references to any built in component or user scripted component easily and quickly.

![Basic Example Script](https://user-images.githubusercontent.com/20816598/35009844-d597cf9a-faf8-11e7-918e-e569d4eb459c.png)

Setting the references in the editor for this script gives the following result:

![Basic Example Editor](https://user-images.githubusercontent.com/20816598/35010451-d01c381a-fafa-11e7-8fbc-86c9d86afaf4.gif)

The advanced example script below shows the use of several different target types being used to specify where the required reference should be found. This demonstrates each of the available target types and combining target types to expand the search for references to multiple targets.

![Advanced Example Script](https://user-images.githubusercontent.com/20816598/35009849-d790f826-faf8-11e7-9675-d3fbd95e8789.png)

Setting the references in the editor for this script gives the following result:

![Advanced Example Editor](https://user-images.githubusercontent.com/20816598/35010457-d2db0860-fafa-11e7-8b2e-a8e39e8f933e.gif)
