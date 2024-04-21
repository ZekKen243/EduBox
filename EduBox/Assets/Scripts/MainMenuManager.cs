using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [Header("Main Menu Objects")] 
    [SerializeField] private GameObject _loadingBarObject;
    [SerializeField] private Image _loadingBar;
    [SerializeField] private GameObject[] _objectsToHide;

    [Header("Scenes to Load")] 
    [SerializeField] private SceneField _GlobalGameplay;
    [SerializeField] private SceneField _levelScene;

    private List<AsyncOperation> _scenesToLoad = new List<AsyncOperation>();

    private void Awake()
    {
        _loadingBarObject.SetActive(false);
    }

    public void StartGame()
    {
        // Start loading scenes
        HideMenu();
        _scenesToLoad.Add(SceneManager.LoadSceneAsync(_GlobalGameplay));
        _scenesToLoad.Add(SceneManager.LoadSceneAsync(_levelScene, LoadSceneMode.Additive));
        
        _loadingBarObject.SetActive(true);

        StartCoroutine(ProgressLoadingBar());
    }

    private void HideMenu()
    {
        for (int i = 0; i < _objectsToHide.Length; i++)
        {
            _objectsToHide[i].SetActive(false);
        }
    }

    private IEnumerator ProgressLoadingBar()
    {
        float loadProgress = 0f;
        for (int i = 0; i < _scenesToLoad.Count; i++)
        {
            while (!_scenesToLoad[i].isDone)
            {
                loadProgress += _scenesToLoad[i].progress;
                _loadingBar.fillAmount = loadProgress / _scenesToLoad.Count;
                yield return null;
            }
        }
    }
    
    void Update()
    {
        //left click input
        if (Input.GetMouseButtonDown(0))
        {
            //raycast to see if mouse is clicking on button
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
 
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == "StartButton")
                {
                    Debug.Log("Starting Game!");
                    StartGame();
                }
                else if (hit.transform.name == "BedroomButton")
                {
                    Debug.Log("Button pressed!");
                    SceneManager.LoadScene("BedroomScene");
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            //Do code
        }
    }
}
