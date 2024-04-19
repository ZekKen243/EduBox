using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bobbing : MonoBehaviour
{
    public float bobbingHeight = 1f; // The height of the bobbing motion
    public float bobbingSpeed = 1f; // The speed of the bobbing motion

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position; // Store the initial position
    }

    void Update()
    {
        // Calculate the vertical offset using the sine function
        float yOffset = Mathf.Sin(Time.time * bobbingSpeed) * bobbingHeight;

        // Update the position of the GameObject
        transform.position = startPosition + new Vector3(0f, yOffset, 0f);
    }
}
