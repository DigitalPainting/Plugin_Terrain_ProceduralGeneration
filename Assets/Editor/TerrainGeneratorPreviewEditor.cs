using UnityEngine;
using System.Collections;
using UnityEditor;

namespace WizardsCode.Terrain
{
    [CustomEditor(typeof(TerrainGeneratorPreview))]
    public class TerrainGeneratorPreviewEditor : UnityEditor.Editor
    {
        private string terrainName = "Generated Terrain";
        private int spacing = 10;
        private int resolution = 512;
        int bottomTopRadioSelected = 0;
        static string[] bottomTopRadio = new string[] { "Bottom Up", "Top Down" };
        private float shiftHeight = 0f;
        private Vector3 addTerrain;

        public override void OnInspectorGUI()
        {
            TerrainGeneratorPreview terrainPreview = (TerrainGeneratorPreview)target;


            GUILayout.BeginVertical("box");
            GUILayout.Label("Terrain Generation Settings");
            if (DrawDefaultInspector())
            {
                if (terrainPreview.autoUpdate)
                {
                    terrainPreview.DrawMapInEditor();
                }
            }

            if (GUILayout.Button("Generate Preview"))
            {
                terrainPreview.DrawMapInEditor();
            }
            GUILayout.EndVertical();

            GUILayout.Space(spacing);

            GUILayout.BeginVertical("box");
            GUILayout.Label("Mesh to Terrain Settings");
            resolution = EditorGUILayout.IntField("Resolution", resolution);
            addTerrain = EditorGUILayout.Vector3Field("Add terrain", addTerrain);
            shiftHeight = EditorGUILayout.Slider("Shift height", shiftHeight, -1f, 1f);
            bottomTopRadioSelected = GUILayout.SelectionGrid(bottomTopRadioSelected, bottomTopRadio, bottomTopRadio.Length, EditorStyles.radioButton);


            if (UnityEngine.Terrain.activeTerrain)
            {
                if (GUILayout.Button("Delete Terrain"))
                {
                    DestroyImmediate(UnityEngine.Terrain.activeTerrain.gameObject);
                }
            }
            else
            {
                if (GUILayout.Button("Create Terrain"))
                {
                    CreateTerrain();
                }
            }
            GUILayout.EndHorizontal();
        }

        void CreateTerrain()
        {
            TerrainData data = MeshToTerrain.CreateTerrainData(terrainName, resolution, addTerrain, shiftHeight, bottomTopRadioSelected == 0);

            GameObject terrainObject = UnityEngine.Terrain.CreateTerrainGameObject(data);
            terrainObject.name = terrainName;
        }

        void ShowProgressBar(float progress, float maxProgress)
        {
            float p = progress / maxProgress;
            EditorUtility.DisplayProgressBar("Creating Terrain...", Mathf.RoundToInt(p * 100f) + " %", p);
        }
    }
}