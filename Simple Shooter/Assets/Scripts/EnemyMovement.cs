using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject player;
    public Rigidbody2D rigidBody;
    public float moveSpeed = 2f;

    Vector2 playerPosition;


    // Update is called once per frame
    void Update()
    {
        playerPosition = player.transform.position;
    }

    private void FixedUpdate()
    {
        // Rotate to player
        float rotationAngle = Mathf.Atan2(playerPosition.y - transform.position.y, playerPosition.x - transform.position.x)
            * Mathf.Rad2Deg - 90f;
        rigidBody.rotation = rotationAngle;

        // Move towers player
        Vector2 moveDirection = (player.transform.position - transform.position).normalized;
        rigidBody.MovePosition(rigidBody.position + moveDirection * moveSpeed * Time.deltaTime);
    }
}
