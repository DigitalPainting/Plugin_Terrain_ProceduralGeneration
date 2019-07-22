using System;

namespace WizardsCode.Plugin.Terrain
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
            return "WizardsCode.Terrain.TerrainGenerator";
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