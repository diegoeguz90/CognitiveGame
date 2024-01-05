using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleStorageBox : StorageBox
{
    public override int GetItemsQuantity()
    {
        return itemsQuantity;
    }
}
