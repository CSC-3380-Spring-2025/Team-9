using UnityEngine;

public interface IConnection<T>
{
    Vector2 CheckConnectionDirection(T typeObject);

    Vector2 HallAlignmentUp(T typeObject);
    Vector2 HallAlignmentDown(T typeObject);
    Vector2 HallAlignmentLeft(T typeObject);
    Vector2 HallAlignmentRight(T typeObject);

    void GenerateHallTopToBottom(T typeObject);
    void GenerateHallBottomToTop(T typeObject);
    void GenerateHallLeftToRight(T typeObject);
    void GenerateHallRightToLeft(T typeObject);
}
