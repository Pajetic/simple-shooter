using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FinalScoreText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<TextMeshProUGUI>().text = "You got " + ScoreText.killCount + (ScoreText.killCount == 1 ? " kill!" : " kills!");
    }
}
