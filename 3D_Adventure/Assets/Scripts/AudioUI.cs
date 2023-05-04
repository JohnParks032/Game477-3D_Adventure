using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioUI : MonoBehaviour
{
   public void btnClick()
    {
        Game.globalInstance.sndPlayer.PlaySound(SoundType.UI_SELECT, GetComponent<AudioSource>());
    }
}
