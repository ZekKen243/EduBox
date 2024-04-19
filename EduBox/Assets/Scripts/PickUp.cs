using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] private PuzzleController puzzleController;

    public void OnCollisionEnter(Collision other)
    {
        gameObject.SetActive(false);
        //Destroy(gameObject);
        puzzleController.OpenPuzzle(gameObject);
    }
}
