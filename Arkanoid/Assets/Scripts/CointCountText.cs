using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CointCountText : MonoBehaviour
{
    [SerializeField] private Text textCurrentCoins;

    public int CurrentNumberCoins
    {
        get { return Convert.ToInt32(textCurrentCoins.text); }
        set
        {
            PlayerPrefs.SetInt("Coins", CurrentNumberCoins);
            textCurrentCoins.text = value.ToString();
        }
    }

    private void Awake() {

    }

    void Start() {
        textCurrentCoins.text = PlayerPrefs.GetInt("Coins").ToString();
    }

    public void AddCoins() {
        CurrentNumberCoins++;
    }
    public void RemoveCoins() {
        CurrentNumberCoins--;
    }
}
