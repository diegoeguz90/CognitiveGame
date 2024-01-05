using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Sign SimpleSignBox;

    [SerializeField] SimpleItemFactory simpleItemFactory;

    // Start is called before the first frame update
    void Start()
    {
        SimpleSignBox.SetMessageInSign("Caja normal", "Mete los items en esta caja");

        Vector3 spawn = new(0.104f, 1.08f, 0.374f);
        IItem item1 = simpleItemFactory.InstantiateItem(spawn);
    }
}
