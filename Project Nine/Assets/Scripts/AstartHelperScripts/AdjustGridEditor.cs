using UnityEditor;
using UnityEngine;
[CustomEditor(typeof(GridAdjuster),true)]
public class AdjustGridEditor : Editor
{
    GridAdjuster gridBoundsObject;

    private void Awake()
    {
        gridBoundsObject = (GridAdjuster)target;
    }
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if(GUILayout.Button("Adjust Grid"))
        {
            gridBoundsObject.AdjustGridPositon();
        }
    }
}
