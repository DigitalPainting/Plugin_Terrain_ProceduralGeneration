Generate procedural terrains in Unity.  This is not intended to be a replacement for any of the feature rich terrain generators on the Asset Store. It's intended for easy prototyping. The terrains adequate and, with a bit of work, maybe even useful.

## Getting Started

Open `Scenes/Demo`. You will see a small preview section of terrain, this is intended to give you a feel for what your complete terrain will look like when you enter play mode. 

Select the `Map Generator` in the hierarchy and double click on  the `Height Map Settings` property. This will open a Scriptable Object containing the terrain parameters. Here you can click on the `Update` button to generate the terrain and apply textures, but changing any of the values will also result in the auotgeneration of the terrain. Parameters have tooltip help text, for a full discussion of what all the parameters do see the [video series](https://www.youtube.com/playlist?list=PLFt_AvWsXl0eBW2EiBtl_sxmDtSgZBxB3) from the originating author Sebastian Lague.

This generates a mesh for your terrain, but it's not a Unity terrain yet. To generate a terrain from the mesh select the `Map Preview -> Preview Mesh` then use the menu item `Digital Painting -> Terrain -> Convert preview to Terrain`. Then click `Create Terrain` This will insert a terrain object into your scene. This uses the default terrain shader, you can add textures and paint the terrain. 

## Original Source

This project has its roots in [Sebastian Lague's Procedureal Landmass Generator](https://github.com/SebLague/Procedural-Landmass-Generation) available on GitHub. If you are interested in how it works then you should check out his excellent tutorial [Series Playlist](https://www.youtube.com/playlist?list=PLFt_AvWsXl0eBW2EiBtl_sxmDtSgZBxB3). Check out his other videos too, there is some really good stuff on there.

Thank you Sebastian.

