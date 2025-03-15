using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(LevelGenerator), true)]
public class LevelGeneratorEditor : Editor
{
    LevelGenerator generator;

    private void Awake()
    {
        generator = (LevelGenerator)target;
    }
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if(GUILayout.Button("Create Dungeon"))
        {
            generator.PlaceTiles();
        }
    }
}
