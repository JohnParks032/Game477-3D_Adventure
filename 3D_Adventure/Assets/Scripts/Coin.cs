using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Coin : MonoBehaviour, ICollectible
{
    public static event Action OnCoinCollected;
    private int coinValue = 0;
    public void Collect()
    {
        coinValue++;
        Debug.Log("Coins: " + coinValue);
        Destroy(gameObject);
        Game.globalInstance.sndPlayer.PlaySound(SoundType.COIN, GetComponent<AudioSource>());
        OnCoinCollected?.Invoke(); 
    }
}
