using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(RoomGenerator), true)]
public class RoomGeneratorEditor : Editor
{
    RoomGenerator roomGenerator;

    private void Awake()
    {
        roomGenerator = (RoomGenerator)target;
    }
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("Create Dungeon"))
        {
            roomGenerator.PlaceTiles();
        }
    }
}