using UnityEngine;

public interface IConnection<T>
{
    Vector2Int HallAlignmentUp(T typeObject);
    Vector2Int HallAlignmentDown(T typeObject);
    Vector2Int HallAlignmentLeft(T typeObject);
    Vector2Int HallAlignmentRight(T typeObject);

    void GenerateHallTopToBottom(T typeObject);
    void GenerateHallBottomToTop(T typeObject);
    void GenerateHallLeftToRight(T typeObject);
    void GenerateHallRightToLeft(T typeObject);
}
