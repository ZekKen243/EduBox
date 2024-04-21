using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteractable : MonoBehaviour, IInteractable
{
    //[SerializeField] private DialogueTrigger dialogueTrigger;

    private GameObject playerGameObject;
    private DialogueTrigger _dialogueTrigger;
    
    [SerializeField] private string interactText;
    
    [Header("Ink JSON")] 
    [SerializeField] private TextAsset inkJSON;

    void Start()
    {
        playerGameObject = GameObject.Find("Player");
        _dialogueTrigger = playerGameObject.GetComponent<DialogueTrigger>();
    }
    public void Interact(Transform interactorTransform)
    {
        // DO NPC things
        if (_dialogueTrigger.GetInteractableObject() != null && !DialogueManager.GetInstance().dialogueIsPlaying)
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
