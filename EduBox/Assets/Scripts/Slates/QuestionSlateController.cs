using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class QuestionSlateController : MonoBehaviour
{
    [SerializeField] private GameObject _questionSlate;
    [SerializeField] private string _correctAnswer;

    [SerializeField] private GameObject _doorToOpen;
    
    [SerializeField] private TMP_InputField _inputField;
    
    private Scores _scores;

    private void Start()
    {
        GameObject scoresObject = GameObject.Find("ScoreTracker");
        _scores = scoresObject.GetComponent<Scores>();
    }

    public void checkInput()
    {
        string input = _inputField.text;
        if (input == _correctAnswer)
        {
            _questionSlate.SetActive(false);
            _doorToOpen.SetActive(true);
            gameObject.SetActive(false);
            Time.timeScale = 1f;
            _scores.addScore();
        }
    }
}
