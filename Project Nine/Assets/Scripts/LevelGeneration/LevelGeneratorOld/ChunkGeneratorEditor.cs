using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ChunkGenerator), true)]
public class ChunkGeneratorEditor : Editor
{
    ChunkGenerator chunkGenerator;
    ChunkPlayerSpawn playerSpawn;

    private void Awake()
    {
        chunkGenerator = (ChunkGenerator)target;
    }
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("Create Dungeon"))
        {
            chunkGenerator.PlaceTiles();
        }
    }
}
