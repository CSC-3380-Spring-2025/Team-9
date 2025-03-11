using UnityEngine;

/*
 * The walker class is simply an object given three parameters to manipulate for the creation of rooms
 */
public class Walker
{
    public Vector2 Position;
    public Vector2 Direction;
    public float chanceToChange;

    /*
     * An object of the class
     * @param pos {Vector2} sets the position of the walker
     * @param dir {Vector2} sets the initial direction of the walker
     * @param chance {float} will determine the odds for the walker to perform a function
     */
    public Walker(Vector2 pos, Vector2 dir, float chance)
    {
        Direction = dir;
        Position = pos;
        chanceToChange = chance;
    }
}