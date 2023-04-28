using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abilities : MonoBehaviour
{
    public GameObject DubbleJump;
    private int DubbleVal = 0;
    
    private void onCollisionEnter(Collision collision){
        if (collision.gameObject.CompareTag("DJAbility")){
            Destroy(DubbleJump);
            DubbleVal++;
            print("DubbleVal is " + DubbleVal);
        }
    }
}
