using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace WizardsCode.terrain
{
    public class MeshToTerrain
    {

        /// <summary>
        /// Convert a mesh to a Terrain Data. Store the Terrain Data in the Asset database.
        /// </summary>
        /// <param name="name">The name of the terrain data.</param>
        /// <param name="resolution">The resolution of the terrain.</param>
        /// <param name="addTerrain">Additional terrain to add around the mesh terrain.</param>
        /// <param name="shiftHeight">Shift the height of the terrain up/down by this amount.</param>
        /// <param name="bottomToTop"></param>
        /// <returns></returns>
        public static TerrainData CreateTerrainData(string name, int resolution, Vector3 addTerrain, float shiftHeight, bool bottomToTop = true)
        {
            Debug.Log("Bottom to top " + bottomToTop);
            TerrainData terrainData = new TerrainData();

            terrainData.heightmapResolution = resolution;
            
            GameObject preview = GameObject.Find("Preview Mesh");
            MeshCollider collider = preview.GetComponent<MeshCollider>();
            CleanUp cleanUp = null;

            //Add a collider to our source object if it does not exist.
            //Otherwise raycasting doesn't work.
            if (!collider)
            {
                collider = preview.AddComponent<MeshCollider>();
                cleanUp = () => GameObject.DestroyImmediate(collider);
            }

            Bounds bounds = collider.bounds;
            float sizeFactor = collider.bounds.size.y / (collider.bounds.size.y + addTerrain.y);
            terrainData.size = collider.bounds.size + addTerrain;
            bounds.size = new Vector3(terrainData.size.x, collider.bounds.size.y, terrainData.size.z);

            // Do raycasting samples over the object to see what terrain heights should be
            float[,] heights = new float[terrainData.heightmapWidth, terrainData.heightmapHeight];
            Ray ray = new Ray(new Vector3(bounds.min.x, bounds.max.y + bounds.size.y, bounds.min.z), -Vector3.up);
            RaycastHit hit = new RaycastHit();
            float meshHeightInverse = 1 / bounds.size.y;
            Vector3 rayOrigin = ray.origin;

            int maxHeight = heights.GetLength(0);
            int maxLength = heights.GetLength(1);

            Vector2 stepXZ = new Vector2(bounds.size.x / maxLength, bounds.size.z / maxHeight);

            for (int zCount = 0; zCount < maxHeight; zCount++)
            {
                for (int xCount = 0; xCount < maxLength; xCount++)
                {

                    float height = 0.0f;

                    if (collider.Raycast(ray, out hit, bounds.size.y * 3))
                    {

                        height = (hit.point.y - bounds.min.y) * meshHeightInverse;
                        height += shiftHeight;

                        //bottom up
                        if (bottomToTop)
                        {

                            height *= sizeFactor;
                        }

                        //clamp
                        if (height < 0)
                        {
                            height = 0;
                        }
                    }

                    heights[zCount, xCount] = height;
                    rayOrigin.x += stepXZ[0];
                    ray.origin = rayOrigin;
                }

                rayOrigin.z += stepXZ[1];
                rayOrigin.x = bounds.min.x;
                ray.origin = rayOrigin;
            }

            terrainData.SetHeights(0, 0, heights);

            if (cleanUp != null)
            {
                cleanUp();
            }

            if (!AssetDatabase.IsValidFolder("Assets/Terrain"))
            {
                AssetDatabase.CreateFolder("Assets", "Terrain");
            }
            AssetDatabase.CreateAsset(terrainData, "Assets/Terrain/" + name + ".asset");

            return terrainData;
        }
    }

    delegate void CleanUp();
}
