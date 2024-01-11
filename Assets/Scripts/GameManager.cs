using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.XR.Interaction.Toolkit.Inputs.Simulation.XRDeviceSimulator;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] ItemTypeFactory ItemFactory;
    [SerializeField] public int numberOfItems;
    [SerializeField] Vector3 spawnAreaCenter = new();
    [SerializeField] Vector3 spawnAreaSize = new();
    [SerializeField] float minimunDistance = 0.3f;
    private List<Transform> spawnedItems = new();

    public GameStates gameStates = new();

    /// <summary>
    /// Begins the FSM of the game and the sign in the box
    /// </summary>
    void Start()
    {
        gameStates.Initialize(new Gameplay());
    }

    /// <summary>
    /// This function is called at the gameplay state begin
    /// </summary>
    public void InitGame()
    {
        SpawnItems();
    }

    /// <summary>
    /// Create a item in a random position, using the factory
    /// </summary>
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

            IItem item = ItemFactory.InstantiateItem(randomPoint);
        }
    }

    /// <summary>
    /// Generate a random point
    /// </summary>
    /// <returns>Vector3 position</returns>
    private Vector3 GetRandomPointInArea()
    {
        float x = UnityEngine.Random.Range(spawnAreaCenter.x - spawnAreaSize.x / 2, spawnAreaCenter.x + spawnAreaSize.x / 2);
        float y = UnityEngine.Random.Range(spawnAreaCenter.y - spawnAreaSize.y / 2, spawnAreaCenter.y + spawnAreaSize.y / 2);
        float z = UnityEngine.Random.Range(spawnAreaCenter.z - spawnAreaSize.z / 2, spawnAreaCenter.z + spawnAreaSize.z / 2);
        return new Vector3(x, y, z);
    }

    /// <summary>
    /// Test if the random point is occupied by the lastes ocupaid items
    /// </summary>
    /// <param name="point">Vector3 random point</param>
    /// <returns>True if was ocuppied, false if is not</returns>
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
