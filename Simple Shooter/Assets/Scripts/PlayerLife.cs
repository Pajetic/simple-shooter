using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : UnitLife
{
    public SceneController sceneController;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            sceneController.EndGame();
        }
    }
}
