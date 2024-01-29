using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppedArea : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        ItemType itemType = other.GetComponent<ItemType>();
        itemType.RestartPosition();
    }
}
