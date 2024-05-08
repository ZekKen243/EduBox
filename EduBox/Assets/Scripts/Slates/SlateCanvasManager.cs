using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlateCanvasManager : MonoBehaviour
{
    public void CloseCanvas()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
}
