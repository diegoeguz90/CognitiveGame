using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class StorageBox : MonoBehaviour
{
    public abstract int GetItemsTypeQuantity();
    public abstract int GetItemsTotalQuantity();
}