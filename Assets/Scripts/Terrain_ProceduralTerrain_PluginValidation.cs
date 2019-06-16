using UnityEngine;
using wizardscode.plugin;
using wizardscode.plugin.terrain;
using wizardscode.terrain;

namespace wizardscode.validation
{
    public class Terrain_ProceduralTerrain_PluginValidation : ValidationTest<Terrain_PluginManager>
    {
        public override ValidationTest<Terrain_PluginManager> Instance => new Terrain_ProceduralTerrain_PluginValidation();

        internal override string ProfileType => typeof(Terrain_ProceduralTerrain_Profile).ToString();
        
        internal override void PostFieldCustomValidations() {
            ValidationResult result;
            if (Terrain.activeTerrain)
            {
                result = GetPassResult("Terrain is required.", 
                    "There is a terrain in the scene.", 
                    this.GetType().Name);
                ResultCollection.AddOrUpdate(result, this.GetType().Name);
                return;
            }
            else
            {
                result = GetErrorResult("Terrain is required.", 
                    "There is no terrain in the scene.", 
                    this.GetType().Name);
                ProfileCallback callback = new ProfileCallback(GenerateTerrain);
                result.AddCallback(new ResolutionCallback(callback));
                ResultCollection.AddOrUpdate(result, this.GetType().Name);
                return;
            }
        }

        private void GenerateTerrain()
        {
            bool destroyPreview = false;
            string terrainName = "Generated Terrain";

            TerrainGeneratorPreview terrainPreview = GameObject.FindObjectOfType<TerrainGeneratorPreview>();
            if (terrainPreview == null)
            {
                destroyPreview = true;
                Terrain_PluginManager manager = GameObject.FindObjectOfType<Terrain_PluginManager>();
                Terrain_ProceduralTerrain_Profile profile = (Terrain_ProceduralTerrain_Profile)manager.Profile;
                profile.terrainGenerator.InstantiatePrefab();
                terrainPreview = profile.terrainGenerator.Instance.GetComponent< TerrainGeneratorPreview>();
            }

            terrainPreview.DrawMapInEditor();

            TerrainData data = MeshToTerrain.CreateTerrainData(terrainName, 512, Vector3.zero, 0);
            GameObject terrainObject = Terrain.CreateTerrainGameObject(data);
            terrainObject.name = terrainName;

            if (destroyPreview)
            {
                GameObject.DestroyImmediate(terrainPreview.gameObject);
            }
        }
    }
}
