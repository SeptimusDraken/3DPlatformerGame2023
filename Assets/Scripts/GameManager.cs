using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GameManager : MonoBehaviour
{
    //Setting parameters
    public static float currentTimer;
    public float startTimer;

    public static int score;

    public TMP_Text scoreText;
    public TMP_Text timerText;
    public TMP_Text highScore;
    public TMP_Text gameOverMessage;
     

    public static bool playing;

    //On start setting values, texts & proposed highscore
    void Start()
    {
        playing = true;
        score = 0;
        currentTimer = startTimer;
        gameOverMessage.text = "";
        highScore.text = "Highscore: " + PlayerPrefs.GetInt("highscore",0);
    }
    
    // Time count down
    // Proposed game over stuff with highscore
    void Update()
    {
        if (currentTimer > 0)
        {
            currentTimer -= Time.deltaTime;
        }
        else if (playing)
        {
            //do gameover stuff
            /*if(score > PlayerPrefs.GetInt("highscore",0))
            {
                highScore.text = "Highscore: " + score;
                gameOverMessage.text = "New Highscore";
                PlayerPrefs.SetInt("Hghscore", score);
            }
            else
            {
                gameOverMessage.text = "Game Over";
            }*/

            gameOverMessage.text = "Game Over";
            playing = false;
        }

        scoreText.text = "Score: " + score;
        timerText.text = "Time: " + Mathf.Round(currentTimer);

        /*if (currentTimer < 0)
        {
            gameOverMessage.text = "Game Over";
        }*/
    }
}
