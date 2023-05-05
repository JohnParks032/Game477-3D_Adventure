using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Coin : MonoBehaviour, ICollectible
{
    public static event Action OnCoinCollected;
    public void Collect()
    {
        Debug.Log("Coin collected!");
        Destroy(gameObject);
        Game.globalInstance.sndPlayer.PlaySound(SoundType.COIN, GetComponent<AudioSource>());
        OnCoinCollected?.Invoke(); 
    }
}
