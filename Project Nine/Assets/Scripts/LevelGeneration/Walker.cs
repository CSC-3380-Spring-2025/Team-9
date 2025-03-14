using UnityEngine;

public class Walker
{
    //Position var is created to keep track of the location of the walker in walkerAlg
    public Vector2 Position;
    //Direction var is created to arbitrate where the walker will move
    public Vector2 Direction;
    //chanceToChange is created to determine if the walker will be removed or if the walker will be duplicated
    public float chanceToChange;

    /*
     * Constructor method that creates the Walker obj
     * 
     * @param Vector2 pos sets Position
     * @param Vector2 dir sets Direction
     * @param float chance sets chanceToChange
     */
    public Walker(Vector2 pos, Vector2 dir, float chance)
    {
        Direction = dir;
        Position = pos;
        chanceToChange = chance;
    }
}