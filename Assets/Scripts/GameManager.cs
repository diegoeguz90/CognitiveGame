using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [Header("Factory parameters")]
    [SerializeField] ItemTypeFactory ItemFactory;
    [SerializeField] public int numberOfItems;
    [SerializeField] Vector3 spawnAreaCenter = new();
    [SerializeField] Vector3 spawnAreaSize = new();
    [SerializeField] float minimunDistance = 0.3f;
    private List<Transform> spawnedItems = new();

    [Header("Gameplay parameters")]
    [SerializeField] MyTimer gamePlayTimer;
    [SerializeField] float gamePlayDuration;

    /// <summary>
    /// Variable that manages the game states
    /// </summary>
    public GameStates gameStates = new();

    /// <summary>
    /// stores the score by item type
    /// </summary>
    public float score1 { get; private set; }
    public float score2 { get; private set; }
    public float score3 { get; private set; }
    public float score4 { get; private set; }

    /// <summary>
    /// Begins the FSM of the game and the sign in the box
    /// </summary>
    void Start()
    {
        gameStates.Initialize(new MainMenu());
    }

    #region GameplayMethods
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

    /// <summary>
    /// Init the gameplay timer, defines the duration of the game
    /// </summary>
    public void InitTimer()
    {
        gamePlayTimer.StartTimer(gamePlayDuration);
    }
    #endregion

    #region ResultsMethods
    public void CalculateScore()
    {
        ItemType[] itemsType;
        TypeBox[] boxsType;

        int nItemType1, nItemType2, nItemType3, nItemType4;
        int nBoxItemType1, nBoxItemType2, nBoxItemType3, nBoxItemType4;
        
        itemsType = FindObjectsOfType<ItemType>();

        nItemType1 = 0;
        nItemType2 = 0;
        nItemType3 = 0;
        nItemType4 = 0;

        foreach (ItemType item in itemsType)
        {
            if (item.type == "Type1")
            {
                nItemType1++;
            }
            else if(item.type == "Type2")
            {
                nItemType2++;
            }
            else if(item.type == "Type3")
            {
                nItemType3++;
            }
            else if(item.type == "Type4")
            {
                nItemType4++;
            }
            else
            {

            }
        }

        boxsType = FindObjectsOfType<TypeBox>();

        nBoxItemType1 = 0;
        nBoxItemType2 = 0;
        nBoxItemType3 = 0;
        nBoxItemType4 = 0;

        foreach (TypeBox box in boxsType)
        {
            if (box.typeBox == "Type1")
            {
                nBoxItemType1 = box.GetItemsTypeQuantity();
            }
            else if (box.typeBox == "Type2")
            {
                nBoxItemType2 = box.GetItemsTypeQuantity();
            }
            else if (box.typeBox == "Type3")
            {
                nBoxItemType3 = box.GetItemsTypeQuantity();
            }
            else if (box.typeBox == "Type4")
            {
                nBoxItemType4 = box.GetItemsTypeQuantity();
            }
            else
            {

            }
        }

        score1 = ((float)nBoxItemType1 / (float)nItemType1) * 100.0f;
        score2 = ((float)nBoxItemType2 / (float)nItemType2) * 100.0f;
        score3 = ((float)nBoxItemType3 / (float)nItemType3) * 100.0f;
        score4 = ((float)nBoxItemType4 / (float)nItemType4) * 100.0f;

        UIController.Instance.scoreBox1Txt.text = "Caja 1: " + score1.ToString() + "%";
        UIController.Instance.scoreBox2Txt.text = "Caja 2: " + score2.ToString() + "%";
        UIController.Instance.scoreBox3Txt.text = "Caja 3: " + score3.ToString() + "%";
        UIController.Instance.scoreBox4Txt.text = "Caja 4: " + score4.ToString() + "%";
    }
    #endregion
}
