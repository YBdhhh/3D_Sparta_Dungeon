using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    public ItemData itemData;

    public string ItemInfo()
    {
        string str = $"{itemData.itemName}\n{itemData.itemDescription}";
        return str;
    }
}
