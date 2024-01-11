using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemType : MonoBehaviour, IItem
{
    [SerializeField] public string type = "Simple";
    public void Initialize()
    {
        // unique logic to this item
        
    }
}
