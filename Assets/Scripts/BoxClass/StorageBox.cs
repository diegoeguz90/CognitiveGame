using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class StorageBox : MonoBehaviour
{
    public int itemsQuantity = 0;
    public static event Action<int> OnStorageChanged;
    public abstract int GetItemsQuantity();

    private void OnTriggerEnter(Collider other)
    {
        itemsQuantity++;
        OnStorageChanged?.Invoke(itemsQuantity);
    }

    private void OnTriggerExit(Collider other)
    {
        itemsQuantity--;
        OnStorageChanged?.Invoke(itemsQuantity);
    }
}