using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableBlocks : MonoBehaviour
{
    void OnTriggerEnter(Collider collider){
        if (collider.transform.CompareTag("Shockwave")){
            Game.globalInstance.sndPlayer.PlayOnce(SoundType.ROCK_BREAK, GetComponent<AudioSource>());
            Destroy(gameObject);
        }
    }
}
