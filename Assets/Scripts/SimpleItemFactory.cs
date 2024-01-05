using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleItemFactory : ItemFactory
{
    [SerializeField] SimpleItem simpleItem;

    public override IItem InstantiateItem(Vector3 position)
    {
        GameObject instance = Instantiate(simpleItem.gameObject, position, Quaternion.identity);

        SimpleItem newSimpleItem = instance.GetComponent<SimpleItem>();

        newSimpleItem.Initialize();

        return newSimpleItem;
    }
}
