using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ItemType : MonoBehaviour, IItem
{
    [SerializeField] public string type = "Simple";

    private Vector3 initPos = new();
    private Quaternion initRotation = new();

    private Vector3 marginType1 = new(0, 0.0788f, 0);
    private Vector3 marginType2 = new(0, 0.0767f, 0);
    private Vector3 marginType3 = new(0, 0.0783f, 0);
    private Vector3 marginType4 = new(0, 0.0371f, 0);
    private Vector3 marginBigShape = new(0, 0.2f, 0);

    public void Initialize()
    {
        // unique logic
        Vector3 marginPos = new();
        switch (type)
        {
            case "Type1":
                marginPos = marginType1;
                break;
            case "Type2":
                marginPos = marginType2;
                break;
            case "Type3":
                marginPos = marginType3;
                break;
            case "Type4":
                marginPos = marginType4;
                break;
            default:
                marginPos = marginBigShape;
                break;
        }

        transform.position = transform.position + marginPos;

        initPos = transform.position;
        initRotation = transform .rotation;
    }

    public void RestartPosition()
    {
        transform.position = initPos;
        transform.rotation = initRotation;
    }
}
