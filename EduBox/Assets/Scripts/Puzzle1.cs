using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Puzzle1 : MonoBehaviour
{
    public GameObject door;
    public TMP_InputField inputAnswer;

    private void Update()
    {
        CheckAnswer();
    }

    public void CheckAnswer()
    {
        if (inputAnswer.text == "111111")
        {
            inputAnswer.text = "Correct";
            UnityEngine.Cursor.visible = false;
            UnityEngine.Cursor.lockState = CursorLockMode.Locked;
            gameObject.SetActive(false);
            Time.timeScale = 1f;
            door.SetActive(true);
        }
    }
}
