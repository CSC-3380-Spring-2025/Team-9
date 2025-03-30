using UnityEditor;
using UnityEngine;
[CustomEditor(typeof(DemoLevelGeneration),true)]
public class DemoLevelGenerationEditor : Editor
{
    DemoLevelGeneration demoGenerator;

    private void Awake()
    {
        demoGenerator = (DemoLevelGeneration)target;
    }
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if(GUILayout.Button("Create Dungeon"))
        {
            demoGenerator.PlaceTiles();
        }
    }
}
