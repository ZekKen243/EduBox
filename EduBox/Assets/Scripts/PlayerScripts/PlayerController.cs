using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Cursor = UnityEngine.UIElements.Cursor;
using Slider = UnityEngine.UI.Slider;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    
    public float speed;
    private Vector2 move;
    public float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;
    public Transform cam;
    
    public float gravity = -10;
    public float jumpHeight = 2;
    private Vector3 velocity;

    // private GameObject dialogueManagerGameObject;
    // private DialogueManager _dialogueManager;

    // void Start()
    // {
    //     dialogueManagerGameObject = GameObject.Find("DialogueManager");
    //     _dialogueManager = dialogueManagerGameObject.GetComponent<DialogueManager>();
    // }

    public void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
    }

    // Update is called once per frame
    void Update()
    {
        movePlayer();
        jumpPlayer();
        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene("TutorialScene");
            Time.timeScale = 1f;
        }
    }

    public void movePlayer()
    {
        // if (DialogueManager.GetInstance().dialogueIsPlaying)
        // {
        //     return;
        // }
        Vector3 direction = new Vector3(move.x, 0f, move.y).normalized;
        Vector3 movement = new Vector3(move.x, 0f, move.y);

        if (movement != Vector3.zero)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity,
                turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
    }

    public void jumpPlayer()
    {
        velocity.y += gravity * Time.deltaTime;
        if (Input.GetButtonDown("Jump") && controller.isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * 2 * -gravity);
        }

        controller.Move(velocity * Time.deltaTime);
    }
}
