using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTypeFactory : ItemFactory
{
    [SerializeField] List<ItemType> itemType;

    public override IItem InstantiateItem(Vector3 position)
    {
        System.Random random = new System.Random();
        //int index = random.Next(itemType.Count);
        int index = random.Next(GameManager.Instance.nBoxes);

        GameObject instance = Instantiate(itemType[index].gameObject, position, Quaternion.identity);

        ItemType newItem = instance.GetComponent<ItemType>();

        newItem.Initialize();

        return newItem;
    }
}
