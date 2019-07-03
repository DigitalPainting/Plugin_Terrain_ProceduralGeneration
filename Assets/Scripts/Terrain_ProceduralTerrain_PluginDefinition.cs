using System;

namespace WizardsCode.plugin.terrain
{
    public class Terrain_ProceduralTerrain_PluginDefinition
        : AbstractPluginDefinition
    {
        public override PluginCategory GetCategory()
        {
            return PluginCategory.Terrain;
        }

        public override Type GetManagerType()
        {
            return typeof(Terrain_PluginManager);
        }

        public override string GetPluginImplementationClassName()
        {
            return "wizardscode.terrain.TerrainGenerator";
        }

        public override string GetProfileTypeName()
        {
            return typeof(Terrain_ProceduralTerrain_Profile).ToString();
        }

        public override string GetReadableName()
        {
            return "Procedural Terrain Generator";
        }

        public override string GetURL()
        {
            return "https://github.com/DigitalPainting/Plugin_Terrain_ProceduralGeneration";
        }
    }
}