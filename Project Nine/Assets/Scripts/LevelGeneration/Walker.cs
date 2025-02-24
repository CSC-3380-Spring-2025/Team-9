using UnityEngine;

public class Walker
{
    public Vector2 Position;
    public Vector2 Direction;
    public float chanceToChange;

    public Walker(Vector2 pos, Vector2 dir, float chance)
    {
        Direction = dir;
        Position = pos;
        chanceToChange = chance;
    }
}