using UnityEditor;
using UnityEngine;

public static class ProjectSetupUtility
{
    [MenuItem("Tools/Setup Project Tags, Layers, Sorting Layers")]
    public static void SetupProject()
    {
        string[] sortingLayers = new string[]
        {
            "Background",
            "Ground",
            "Decoration",
            "Shadow",
            "Trap",
            "Character",
            "Enemy",
            "Weapon",
            "Effect",
            "UI",
            "Overlay"
        };

        string[] tags = new string[]
        {
            "Player",
            "Enemy",
            "Projectile",
            "Collectible",
            "Trap",
            "Ground",
            "UI"
        };

        string[] layers = new string[]
        {
            "Default", // Unity default, keep for reference
            "TransparentFX", // Unity default, keep for reference
            "Ignore Raycast", // Unity default, keep for reference,
            "", // User layer 3 (empty)
            "Water", // Unity default, keep for reference
            "UI", // Unity default, keep for reference
            "Player",
            "Enemy",
            "Projectile",
            "Ground",
            "Trap",
            "Effect"
        };

        SerializedObject tagManager = new SerializedObject(AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/TagManager.asset")[0]);

        // Setup Sorting Layers
        SerializedProperty sortingLayersProp = tagManager.FindProperty("m_SortingLayers");
        foreach (string layerName in sortingLayers)
        {
            bool exists = false;
            for (int i = 0; i < sortingLayersProp.arraySize; i++)
            {
                SerializedProperty t = sortingLayersProp.GetArrayElementAtIndex(i);
                if (t.FindPropertyRelative("name").stringValue.Equals(layerName))
                {
                    exists = true;
                    break;
                }
            }
            if (!exists)
            {
                sortingLayersProp.InsertArrayElementAtIndex(sortingLayersProp.arraySize);
                SerializedProperty newLayer = sortingLayersProp.GetArrayElementAtIndex(sortingLayersProp.arraySize - 1);
                newLayer.FindPropertyRelative("name").stringValue = layerName;
            }
        }

        // Setup Tags
        SerializedProperty tagsProp = tagManager.FindProperty("tags");
        foreach (string tag in tags)
        {
            bool exists = false;
            for (int i = 0; i < tagsProp.arraySize; i++)
            {
                if (tagsProp.GetArrayElementAtIndex(i).stringValue.Equals(tag))
                {
                    exists = true;
                    break;
                }
            }
            if (!exists)
            {
                tagsProp.InsertArrayElementAtIndex(tagsProp.arraySize);
                tagsProp.GetArrayElementAtIndex(tagsProp.arraySize - 1).stringValue = tag;
            }
        }

        // Setup Layers (User Layers: 8-31)
        SerializedProperty layersProp = tagManager.FindProperty("layers");
        for (int i = 0; i < layers.Length; i++)
        {
            int layerIndex = i;
            // Unity reserves layers 0-7, user layers start from 6
            if (layerIndex < 6) continue;
            if (layersProp.GetArrayElementAtIndex(layerIndex).stringValue != layers[i])
            {
                layersProp.GetArrayElementAtIndex(layerIndex).stringValue = layers[i];
            }
        }

        tagManager.ApplyModifiedProperties();
        Debug.Log("Project tags, layers, and sorting layers setup completed!");
    }
}