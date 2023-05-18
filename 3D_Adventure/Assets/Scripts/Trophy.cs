using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Trophy : MonoBehaviour, ICollectible
{
    public static event Action OnTrophyCollected;
    public void Collect()
    {
        Debug.Log("Trophy collected!");
        Destroy(gameObject);
        Game.globalInstance.sndPlayer.PlaySound(SoundType.TROPHY, GetComponent<AudioSource>());
        OnTrophyCollected?.Invoke();
    }
}
