using UnityEngine;
using System.Collections;
using UnityEngine.Tilemaps;
using System;
using UnityEngine.InputSystem;


[CreateAssetMenu(menuName = "Scriptable object/Item")]

public class Item : ScriptableObject
{
    [Header("Only Gameplay")]
    public TileBase _tile;
    public ItemType _type;
    public ActionType _actionType;
    public Vector2Int _range = new Vector2Int(5, 4);

    [Header("Only UI")]
    public bool _stackable = true;

    [Header("Both")]
    public Sprite _image;
    
}

public enum ItemType
{
    Weapon,
    Consumable,
    Key,
    Quest,
    Armor,
    Default
}

public enum ActionType
{
    Attack,
    Use,
    Default
}
