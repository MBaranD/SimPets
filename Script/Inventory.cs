using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<ShopItem> items;

    private void Awake()
    {
        if (items == null)
        {
            items = new List<ShopItem>();
        }
    }

    public void AddItem(ShopItem item)
    {
        if (items == null)
        {
            items = new List<ShopItem>();
        }

        items.Add(item);
        Debug.Log("Item added: " + item.title);
    }
}
