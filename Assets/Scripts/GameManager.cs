using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.XR.Interaction.Toolkit.Inputs.Simulation.XRDeviceSimulator;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] Sign SimpleSignBox;

    [SerializeField] SimpleItemFactory simpleItemFactory;
    [SerializeField] public int numberOfItems = 4;
    [SerializeField] Vector3 spawnAreaCenter = new(0.7f, 1.08f, 0.6f);
    [SerializeField] Vector3 spawnAreaSize = new(1.25f, 0f, 1f);
    [SerializeField] float minimunDistance = 1.5f;
    private List<Transform> spawnedItems = new();

    public GameStates gameStates = new();

    // Start is called before the first frame update
    void Start()
    {
        SimpleSignBox.SetMessageInSign("Caja normal", "Mete los items en esta caja");
        gameStates.Initialize(new MainMenu());
    }

    public void InitGame()
    {
        SpawnItems();
    }

    private void SpawnItems()
    {
        for(int i = 0; i < numberOfItems; i++)
        {
            Vector3 randomPoint = GetRandomPointInArea();
            // verify superposition
            while (IsPointOccupied(randomPoint))
            {
                randomPoint = GetRandomPointInArea();
            }

            IItem item1 = simpleItemFactory.InstantiateItem(randomPoint);
        }
    }

    private Vector3 GetRandomPointInArea()
    {
        float x = UnityEngine.Random.Range(spawnAreaCenter.x - spawnAreaSize.x / 2, spawnAreaCenter.x + spawnAreaSize.x / 2);
        float y = UnityEngine.Random.Range(spawnAreaCenter.y - spawnAreaSize.y / 2, spawnAreaCenter.y + spawnAreaSize.y / 2);
        float z = UnityEngine.Random.Range(spawnAreaCenter.z - spawnAreaSize.z / 2, spawnAreaCenter.z + spawnAreaSize.z / 2);
        return new Vector3(x, y, z);
    }

    private bool IsPointOccupied(Vector3 point)
    {
        foreach(Transform spawnedItem in spawnedItems)
        {
            float distance = Vector3.Distance(point, spawnedItem.position);
            if(distance < minimunDistance)
            {
                return true;
            }
        }
        return false;
    }

}
