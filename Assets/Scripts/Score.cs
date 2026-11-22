using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [Header("Set these in Inspector")]
    [Tooltip("This is the starting score for the player")] public int score = 0;
    public TextMeshProUGUI scoreText;

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString("#,0");
    }
}
