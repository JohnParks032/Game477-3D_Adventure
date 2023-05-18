using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinText : MonoBehaviour
{
    public TextMeshProUGUI coinText;
    int coinCount;
    public void OnEnable()
    {
        Coin.OnCoinCollected += IncrementCoinCount;
    }
    public void OnDisable()
    {
        Coin.OnCoinCollected -= IncrementCoinCount;
    }

    public void IncrementCoinCount()
    {
        coinCount++;
        coinText.text = $"Acorns: {coinCount} / 300";
    }
}
