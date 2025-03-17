using UnityEngine;

public interface IConnection<T>
{
    Vector2 CheckConnectionDirection(T typeObject);

    void HallAlignmentUp(T typeObject);
    void HallAlignmentDown(T typeObject);
    void HallAlignmentLeft(T typeObject);
    void HallAlignmentRight(T typeObject);

    void GenerateHallTopToBottom(T typeObject);
    void GenerateHallBottomToTop(T typeObject);
    void GenerateHallLeftToRight(T typeObject);
    void GenerateHallRightToLeft(T typeObject);
}
