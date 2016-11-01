﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Networking;

public class CharacterSelection : MonoBehaviour {

    public Image characterPortrait;
    public GameObject[] players;
    public Sprite[] pictures;

    public void SetCharacter(int num)
    {
        switch (num)
        {
            case 1:
                characterPortrait.sprite = pictures[0];
                //Quantum
                break;
            case 2:
                characterPortrait.sprite = pictures[1];
                break;
          /*  case 3:
                characterPortrait.sprite = characters[2];
                break;
            case 4:
                characterPortrait.sprite = characters[3];
                break; */
        }
    }
}
