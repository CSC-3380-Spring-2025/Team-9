using System.Reflection.Emit;
using UnityEngine;
using UnityEngine.Tilemaps;


// adjust position and size of GridGraph to match randomly generated tilemap
public class GridAdjuster : MonoBehaviour
{

    public Tilemap level;


    public void AdjustGridPositon()
    {

        Bounds Localb = level.localBounds;
        Vector3 maximum = Localb.max;
        Vector3 minimum = Localb.min;
        Vector3 toWorldSpaceMin = level.LocalToWorld(minimum); // lower left corner
        Vector3 toWorldSpaceMax = level.LocalToWorld(maximum); // upper right corner

        Debug.Log("world coord for maximum : " + toWorldSpaceMax.ToString()); 
        Debug.Log("world coord for minimum : " + toWorldSpaceMin.ToString());

        // get midpoints of x and y to get where i should center the graph
        float xMid = (toWorldSpaceMax.x + toWorldSpaceMin.x) / 2;
        float yMid = (toWorldSpaceMax.y + toWorldSpaceMin.y) / 2;

        // get length of x and y
        float xLength = toWorldSpaceMax.x - toWorldSpaceMin.x;
        float yLength = toWorldSpaceMax.y - toWorldSpaceMin.y;


        var gg = AstarPath.active.data.gridGraph;
        float nodeSize = 0.3f; 
        int offset = 2; // to ensure the whole tilemap is covered 
        // since node size is not 1 i need to divide by it to get the real widdth in world space i need
        int width = (int) (xLength / nodeSize) + offset;
        int depth = (int) (yLength / nodeSize) + offset;
     

        gg.center = new Vector3(xMid, yMid, 0);

        gg.SetDimensions(width, depth, nodeSize);

// Recalculate the graph
        AstarPath.active.Scan();
        
    }

   
}
