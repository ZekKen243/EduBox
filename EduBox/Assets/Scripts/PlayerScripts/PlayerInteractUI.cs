using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInteractUI : MonoBehaviour
{
    [SerializeField] private GameObject containerGameObject;
    //[SerializeField] private DialogueTrigger dialogueTrigger;
    [SerializeField] private TextMeshProUGUI interactTextMeshProUGUI;
    
    private GameObject playerGameObject;
    private DialogueTrigger _dialogueTrigger;
    void Start()
    {
        playerGameObject = GameObject.Find("Player");
        _dialogueTrigger = playerGameObject.GetComponent<DialogueTrigger>();
    }
    private void Update()
    {
        if (_dialogueTrigger.GetInteractableObject() != null)
        {
            Show(_dialogueTrigger.GetInteractableObject());
        }
        else
        {
            Hide();
        }
    }

    private void Show(IInteractable interactable)
    {
        containerGameObject.SetActive(true);
        interactTextMeshProUGUI.text = interactable.GetInteractText();
    }

    private void Hide()
    {
        containerGameObject.SetActive(false);
    }
}
