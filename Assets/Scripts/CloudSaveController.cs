using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//
using System;
using Unity.Services.Core;
using Unity.Services.Authentication;
using Unity.Services.CloudSave;
using System.Threading.Tasks;
using UnityEngine.Events;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

public class CloudSaveController : Singleton<CloudSaveController>
{
    struct dataToSave
    {
        public int limitT;
        public int nBoxes;
        public int nItems;
        public float score1;
        public float score2;
        public float score3;
        public float score4;
    }
    async void Start()
    {
        // Initialize unity services
        await UnityServices.InitializeAsync();

        // Setup events listeners
        SetupEvents();

        // Unity Login
        await SignInAnonymouslyAsync();
    }

    void SetupEvents()
    {
        AuthenticationService.Instance.SignedIn += () => {
            // Shows how to get a playerID
            Debug.Log($"PlayerID: {AuthenticationService.Instance.PlayerId}");

            // Shows how to get an access token
            Debug.Log($"Access Token: {AuthenticationService.Instance.AccessToken}");
        };

        AuthenticationService.Instance.SignInFailed += (err) => {
            Debug.LogError(err);
        };

        AuthenticationService.Instance.SignedOut += () => {
            Debug.Log("Player signed out.");
        };
    }

    async Task SignInAnonymouslyAsync()
    {
        try
        {
            await AuthenticationService.Instance.SignInAnonymouslyAsync();
            Debug.Log("Sign in anonymously succeeded!");
            UIController.Instance.debugTxt.text = "Sign in anonymously succeeded!";
        }
        catch (Exception ex)
        {
            // Notify the player with the proper error message
            Debug.LogException(ex);
            UIController.Instance.debugTxt.text = ex.Message;
        }
    }

    public async void SaveDataCloud()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;

        dataToSave performance = new();

        performance.limitT = (int)GameManager.Instance.gamePlayDuration;
        performance.nBoxes = GameManager.Instance.nBoxes;
        performance.nItems = GameManager.Instance.numberOfItems;
        performance.score1 = GameManager.Instance.score1;
        performance.score2 = GameManager.Instance.score2;
        performance.score3 = GameManager.Instance.score3;
        performance.score4 = GameManager.Instance.score4;

        // Obtener la fecha y hora actual
        DateTime now = DateTime.Now;
        // Construir el string con el formato deseado
        string key = "Date-" + now.ToString("yyyy-MM-dd") + "-Time-" + now.ToString("HH-mm-ss") + "-Scene" + sceneIndex;

        var data = new Dictionary<string, object> { { key, performance } };
        await CloudSaveService.Instance.Data.Player.SaveAsync(data);
        UIController.Instance.debugTxt.text = "Cloud save success: " + key;
    }
}
