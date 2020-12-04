using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    public Camera mainCam;
    public float moveSpeed = 5;

    Vector2 mousePosition;
    Vector2 moveDirection;

    // Update is called once per frame
    void Update()
    {
        // Get mouse position and movement vector
        mousePosition = mainCam.ScreenToWorldPoint(Input.mousePosition);
        moveDirection.x = Input.GetAxisRaw("Horizontal");
        moveDirection.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        // Rotate to mouse
        Vector2 mouseDir = mousePosition - rigidBody.position;
        float rotationAngle = Mathf.Atan2(mousePosition.y - rigidBody.position.y, mousePosition.x - rigidBody.position.x) 
            * Mathf.Rad2Deg - 90f;
        rigidBody.rotation = rotationAngle;

        // Move the player
        rigidBody.MovePosition(rigidBody.position + moveDirection * moveSpeed * Time.deltaTime);
    }
}
