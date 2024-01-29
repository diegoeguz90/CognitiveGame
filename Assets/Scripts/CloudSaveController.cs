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

public class CloudSaveController : Singleton<CloudSaveController>
{
    struct dataToSave
    {
        public int limitT;
        public int nBoxes;
        public int nItems;

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
        dataToSave performance = new();

        performance.limitT = (int)GameManager.Instance.gamePlayDuration;
        performance.nBoxes = GameManager.Instance.nBoxes;
        performance.nItems = GameManager.Instance.numberOfItems;

        var data = new Dictionary<string, object> { { "performance", performance } };
        await CloudSaveService.Instance.Data.Player.SaveAsync(data);
    }
}
