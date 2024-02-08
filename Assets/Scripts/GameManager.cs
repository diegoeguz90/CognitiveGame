using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [Header("Game Settings")]
    [SerializeField] public int numberOfItems = 4;
    [SerializeField] public int nBoxes = 4;
    [SerializeField] public float gamePlayDuration = 30;
    
    [Header("Factory parameters")]
    [SerializeField] ItemTypeFactory ItemFactory;
    [SerializeField] GameObject spawnArea;
    private float minimunDistance = 0.3f;
    private List<Transform> spawnedItems = new();
    private Vector3 spawnAreaCenter = new();
    private Vector3 spawnAreaSize = new();

    [Header("Gameplay parameters")]
    [SerializeField] MyTimer gamePlayTimer;

    [Header("Boxes")]
    [SerializeField] List<GameObject> Boxes;

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
        spawnAreaCenter = spawnArea.transform.position;
        spawnAreaSize = spawnArea.transform.localScale;

        gameStates.Initialize(new MainMenu());
    }

    /// <summary>
    /// This function is called at the gameplay state begin
    /// </summary>
    public void InitGame()
    {
        RandomizeSettings();
        ActivateBoxes();
        SpawnItems();
    }

    void RandomizeSettings()
    {
        System.Random random = new();

        numberOfItems = random.Next(4,12+1);
        nBoxes = random.Next(2,4+1);
        gamePlayDuration = (float)random.Next(15, 30 + 1); ;
    }

    /// <summary>
    /// Activate the quantity of boxes  
    /// </summary>
    private void ActivateBoxes()
    {
        switch (nBoxes)
        {
            case 1:
                Boxes[0].SetActive(true);
                break;
            case 2:
                Boxes[0].SetActive(true);
                Boxes[1].SetActive(true);
                break;
            case 3:
                Boxes[0].SetActive(true);
                Boxes[1].SetActive(true);
                Boxes[2].SetActive(true);
                break;
            case 4:
                Boxes[0].SetActive(true);
                Boxes[1].SetActive(true);
                Boxes[2].SetActive(true);
                Boxes[3].SetActive(true);
                break;
        }
    }

    #region SpaiwnItems
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
    #endregion


    /// <summary>
    /// Init the gameplay timer, defines the duration of the game
    /// </summary>
    public void InitTimer()
    {
        gamePlayTimer.StartTimer(gamePlayDuration);
    }

    #region ResultsMethods
    public void CalculateScore()
    {
        ItemType[] itemsType;
        TypeBox[] boxsType;

        int nItemType1 = 0, nItemType2 = 0, nItemType3 = 0, nItemType4 = 0, nBoxItemType1 = 0, 
            nBoxItemType2 = 0, nBoxItemType3 = 0, nBoxItemType4 = 0;
        
        itemsType = FindObjectsOfType<ItemType>();
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

        score1 = ComputeScore(nBoxItemType1, nItemType1);
        score2 = ComputeScore(nBoxItemType2, nItemType2);
        score3 = ComputeScore(nBoxItemType3, nItemType3);
        score4 = ComputeScore(nBoxItemType4, nItemType4);

        UIController.Instance.scoreBoxesTxt[0].text = "Caja 1: " + score1.ToString("F1") + "%";
        UIController.Instance.scoreBoxesTxt[1].text = "Caja 2: " + score2.ToString("F1") + "%";
        UIController.Instance.scoreBoxesTxt[2].text = "Caja 3: " + score3.ToString("F1") + "%";
        UIController.Instance.scoreBoxesTxt[3].text = "Caja 4: " + score4.ToString("F1") + "%";
    }

    private float ComputeScore(int nBoxItemType, int nItemType)
    {
        if (nItemType == 0)
        {
            return 999.0f;
        }
        else
        {
            return ((float)nBoxItemType / (float)nItemType) * 100.0f;
        }
    }
    #endregion
}
