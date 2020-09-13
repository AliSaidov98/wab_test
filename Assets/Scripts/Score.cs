using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private float score;
    
    public void ScoreUp()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
