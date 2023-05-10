using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteractable : MonoBehaviour
{
    public Dialogue dialogue;
    public void Interact()
    {
        Debug.Log("interact!");
        dialogue.StartDialogue();
    }
}
