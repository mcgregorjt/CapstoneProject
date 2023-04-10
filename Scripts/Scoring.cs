using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoring : MonoBehaviour
{
    public float Score = 0;
    public float CurrentScore;
    public Text ScoreBoard;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void UpdateScore(int points) {

        CurrentScore += points;
        ScoreBoard.text = "Score: " + CurrentScore;
    }
    // Update is called once per frame
  
}
