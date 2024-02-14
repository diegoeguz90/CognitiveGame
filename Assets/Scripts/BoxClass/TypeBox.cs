using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeBox : StorageBox
{
    [SerializeField] Sign signBox;
    [SerializeField] public string typeBox = "Simple";

    public int itemsTypeQuantity = 0;
    public int itemsTotalQuantity = 0;

    private void OnTriggerEnter(Collider other)
    {
        ItemType type = other.GetComponent<ItemType>();

        if (type != null)
        {
            if (typeBox == type.type)
            {
                itemsTypeQuantity++;
            }
            itemsTotalQuantity++;
            signBox.SetMessageInSign(itemsTypeQuantity.ToString(), itemsTotalQuantity.ToString());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        ItemType type = other.GetComponent<ItemType>();

        if (type != null)
        {
            if (typeBox == type.type)
            {
                itemsTypeQuantity--;
            }
            itemsTotalQuantity--;
            signBox.SetMessageInSign(itemsTypeQuantity.ToString(), itemsTotalQuantity.ToString());
        }
    }

    public override int GetItemsTypeQuantity()
    {
        return itemsTypeQuantity;
    }
    public override int GetItemsTotalQuantity()
    {
        return itemsTotalQuantity;
    }
}
