using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinText : MonoBehaviour
{
    private int coinValue;
    public Text coinText;

    private void Start()
    {
        OnInit();
    }

    private void OnEnable()
    {
        OnInit();
    }

    private void OnInit()
    {
        coinValue = PlayerPrefs.GetInt("Coins", 0);

        coinText.text = coinValue.ToString();
    }
}
