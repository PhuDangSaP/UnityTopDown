using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum ItemType
{
    Household,
    Weapon,
    Tool
}
[CreateAssetMenu(fileName ="New Item",menuName ="Item/Create New Item")]


public class Item : ScriptableObject
{
    public int id;
    public string itemName;
    public int value;
    public Sprite icon;
    public ItemType type;
    
}
