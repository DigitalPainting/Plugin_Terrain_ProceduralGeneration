using UnityEngine;
using WizardsCode.editor;
using WizardsCode.Terrain.Validation;

namespace WizardsCode.Plugin.Terrain
{
    [CreateAssetMenu(fileName = "Terrain_ProceduralTerrain_Profile", 
        menuName = "Wizards Code/Terrain/Procedural Generation Profile")]
    public class Terrain_ProceduralTerrain_Profile 
        : AbstractPluginProfile
    {
        [Tooltip("The prefab that provides the necessary components to procedurally generate a terrain.")]
        [Expandable(isRequired: true)]
        public TerrainGenerator_PrefabSettingSO terrainGenerator;
    }
}
