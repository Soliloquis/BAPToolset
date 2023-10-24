using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TerrainMassOperations : EditorWindow
{
    public  Material newMaterial;
    public string newDrawDistance = "";
    public string newPixelError = "";

    [MenuItem("BAP Terrain Tools/Mass Operations Window")]
    static void Init()
    {
        TerrainMassOperations window = (TerrainMassOperations)EditorWindow.GetWindow(typeof(TerrainMassOperations));
        window.Show();
    }

    private void OnInspectorUpdate()
    {
        
    }

    void OnGUI()
    {
        GUILayout.Label("Replace Terrain Material", EditorStyles.boldLabel);
        newMaterial = (Material)EditorGUILayout.ObjectField("New Material", newMaterial, typeof(Material), false);

        if (GUILayout.Button("Replace Material"))
        {
            if (newMaterial == null)
            {
                Debug.LogError("New material is not assigned.");
                return;
            }
            
            GameObject[] terrainObjectsGet = UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects();

            List<Terrain> terrains = new List<Terrain>();

            foreach(GameObject trn in terrainObjectsGet)
            {
                if(trn.GetComponent<Terrain>())
                {
                    terrains.Add(trn.GetComponent<Terrain>());
                }
            }

            if (terrains.Count == 0)
            {
                Debug.LogError("No terrains found in the scene.");
                return;
            }

            foreach (Terrain tnr in terrains)
            {
                tnr.materialTemplate = newMaterial;
            }
        }

        GUILayout.Space(10);

        if (GUILayout.Button("Set Draw Instanced"))
        {
            GameObject[] terrainObjectsGet = UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects();
            List<Terrain> terrains = new List<Terrain>();
            foreach (GameObject trn in terrainObjectsGet)
            {
                if (trn.GetComponent<Terrain>())
                {
                    terrains.Add(trn.GetComponent<Terrain>());
                }
            }

            if (terrains.Count == 0)
            {
                Debug.LogError("No terrains found in the scene.");
                return;
            }

            foreach (Terrain tnr in terrains)
            {
                tnr.drawInstanced = true;
            }
        }


        GUILayout.Space(10);

        newDrawDistance = EditorGUILayout.TextField("Terrain Draw Distance", newDrawDistance);

        if (GUILayout.Button("Set Texture Draw Distance"))
        {
            GameObject[] terrainObjectsGet = UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects();
            List<Terrain> terrains = new List<Terrain>();
            foreach (GameObject trn in terrainObjectsGet)
            {
                if (trn.GetComponent<Terrain>())
                {
                    terrains.Add(trn.GetComponent<Terrain>());
                }
            }
            float numericalValue;
            float.TryParse(newDrawDistance, out numericalValue);

            if (terrains.Count == 0)
            {
                Debug.LogError("No terrains found in the scene.");
                return;
            }

            foreach (Terrain tnr in terrains)
            {
                tnr.basemapDistance = numericalValue;
            }
        }

        GUILayout.Space(10);

        newPixelError = EditorGUILayout.TextField("Set Pixel Error", newPixelError);

        if (GUILayout.Button("Set Pixel Error"))
        {
            GameObject[] terrainObjectsGet = UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects();
            List<Terrain> terrains = new List<Terrain>();
            foreach (GameObject trn in terrainObjectsGet)
            {
                if (trn.GetComponent<Terrain>())
                {
                    terrains.Add(trn.GetComponent<Terrain>());
                }
            }
            float numericalValue;
            float.TryParse(newPixelError, out numericalValue);

            if (terrains.Count == 0)
            {
                Debug.LogError("No terrains found in the scene.");
                return;
            }

            foreach (Terrain tnr in terrains)
            {
                tnr.heightmapPixelError = numericalValue;
            }
        }
    }
}