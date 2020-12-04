using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : UnitLife
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Enemy")
        {
            AddScore(); 
            KillUnit();
        }
    }

    void AddScore()
    {
        ScoreText.killCount += 1;
    }
}
