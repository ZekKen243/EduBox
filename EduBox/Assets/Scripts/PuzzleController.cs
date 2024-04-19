using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleController : MonoBehaviour
{
    public GameObject puzzleScreen;

    public void OpenPuzzle(GameObject puzzleNum)
    {
        Debug.Log("Opened " + puzzleNum);
        puzzleScreen.SetActive(true);
        UnityEngine.Cursor.visible = true;
        UnityEngine.Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;

    }
}
