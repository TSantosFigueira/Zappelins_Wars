﻿using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class CustomNetworkManager : NetworkManager
{

    public void StartUpHost()
    {
        SetPort();
        NetworkManager.singleton.StartHost();
    }

    private void SetPort()
    {
        NetworkManager.singleton.networkPort = 7777;
    }

    public void JoinGame()
    {
        SetIPAddress();
        NetworkManager.singleton.StartClient();
    }

    private void SetIPAddress()
    {
        string IpAddress = GameObject.Find("IpAddressText").transform.FindChild("Text").GetComponent<Text>().text;
        NetworkManager.singleton.networkAddress = IpAddress;
    }

    public void OnLevelLoaded (int level)
    {
        if (level == 1)
            SetupMenuSceneButtons();
        else
            SetupOtherSceneButtons();
    }

    private void SetupOtherSceneButtons()
    {
        GameObject.Find("DisconnectButton").GetComponent<Button>().onClick.RemoveAllListeners();
        GameObject.Find("DisconnectButton").GetComponent<Button>().onClick.AddListener(NetworkManager.singleton.StopHost);
    }

    private void SetupMenuSceneButtons()
    {
        GameObject.Find("StartHostButton").GetComponent<Button>().onClick.RemoveAllListeners();
        GameObject.Find("StartHostButton").GetComponent<Button>().onClick.AddListener(StartUpHost);

        GameObject.Find("JoinGameButton").GetComponent<Button>().onClick.RemoveAllListeners();
        GameObject.Find("JoinGameButton").GetComponent<Button>().onClick.AddListener(JoinGame);
    }
}