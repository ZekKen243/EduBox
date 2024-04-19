using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{ 
    // Update is called once per frame
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
                     Debug.Log("Button pressed!");
                     SceneManager.LoadScene("TutorialScene");
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

