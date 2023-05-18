using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HighScore;

public class GameInit : MonoBehaviour
{
    void Start()
    {
        HS.Init(this, "Danole the Anole and the Harmonic Tree");
    }
}
