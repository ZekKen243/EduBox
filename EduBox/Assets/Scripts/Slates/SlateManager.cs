using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlateManager : MonoBehaviour
{
    [SerializeField] private int slateNumber;
    [SerializeField] private GameObject canvasPair;
    private bool _isColliding = false;

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canvasPair.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
