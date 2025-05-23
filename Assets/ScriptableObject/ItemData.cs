using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum itemType
{
    consumable,
    nature
}

[CreateAssetMenu(fileName = "Item", menuName ="New Item")]
public class ItemData : ScriptableObject
{
    public string itemName;
    public string itemDescription;
    public itemType type;

}
