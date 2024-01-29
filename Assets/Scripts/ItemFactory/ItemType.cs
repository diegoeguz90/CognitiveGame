using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ItemType : MonoBehaviour, IItem
{
    [SerializeField] public string type = "Simple";

    private Vector3 initPos = new();
    private Quaternion initRotation = new();

    public void Initialize()
    {
        // unique logic to this item
        initPos = this.transform.position;
        initRotation = this.transform .rotation;
    }

    public void RestartPosition()
    {
        this.transform.position = initPos;
        this.transform.rotation = initRotation;
    }
}
