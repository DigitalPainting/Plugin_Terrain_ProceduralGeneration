using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using wizardscode.validation;

namespace wizardscode.terrain.validation
{
    [CreateAssetMenu(fileName = "DESCRIPTIVENAME_ProceduralTerrain_PrefabSO",
        menuName = "Wizards Code/Validation/Terrain/Procedural Generation Prefab")]
    public class TerrainGenerator_PrefabSettingSO : PrefabSettingSO
    {
        [Header("Height Map Settings")]
        [Tooltip("Generate a random terrain. Note that if you check this then the `heightMapSeed` will be updated with the new seed.")]
        public bool randomTerrain = false;

        [Tooltip("The seed to use when generating the terrains height map. This allows us to have a predictable terrain. Note that if `Random Terrain` is set to true, this value will be overwritten with the seed generated. If set to 0 then whatever is set in the Terrain Generator prefab will be used.")]
        public int heightMapSeed;
        
        internal override void InstantiatePrefab()
        {
            base.InstantiatePrefab();
            TerrainGeneratorPreview generator = Instance.GetComponent<TerrainGeneratorPreview>();
            if (randomTerrain)
            {
                heightMapSeed = Random.Range(int.MinValue, int.MaxValue);
                generator.heightMapSettings.noiseSettings.seed = heightMapSeed;
            } else
            {
                if (heightMapSeed != 0)
                {
                    generator.heightMapSettings.noiseSettings.seed = heightMapSeed;
                }
            }
        }
    }
}
