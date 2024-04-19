using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] private DialogueTrigger dialogueTrigger;
    
    [SerializeField] private string interactText;
    
    [Header("Ink JSON")] 
    [SerializeField] private TextAsset inkJSON;
    
    public void Interact(Transform interactorTransform)
    {
        // DO NPC things
        if (dialogueTrigger.GetInteractableObject() != null && !DialogueManager.GetInstance().dialogueIsPlaying)
        {
            Debug.Log("Interacted!");
            DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
        }
    }

    public string GetInteractText()
    {
        return interactText;
    }

    public Transform GetTransform()
    {
        return transform;
    }
}
