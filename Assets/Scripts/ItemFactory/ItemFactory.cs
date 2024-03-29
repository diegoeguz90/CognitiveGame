using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemFactory : MonoBehaviour
{
    public abstract IItem InstantiateItem(Vector3 position);

    // shared methods with all factories
    // ...
}
