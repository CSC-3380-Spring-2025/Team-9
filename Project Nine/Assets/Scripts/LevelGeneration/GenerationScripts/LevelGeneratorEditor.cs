using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(LevelGenerator), true)]
public class LevelGeneratorEditor : Editor
{
    LevelGenerator levelGenerator;

    private void Awake()
    {
        levelGenerator = (LevelGenerator)target;
    }
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if(GUILayout.Button("Create Dungeon"))
        {
            levelGenerator.PlaceTiles();
        }
    }
}