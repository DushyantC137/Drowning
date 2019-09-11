using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
    public static ScoreManager instance;
    public int score;
    public int HighScore;
    public Text LiveScore;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    // Use this for initialization
    void Start () {
        score = 0;
        PlayerPrefs.SetInt("score", score);
	}
	
	// Update is called once per frame
	public void incrementScore () {
        score += 1;
        LiveScore.text = score.ToString();
     Debug.Log(""+LiveScore.text);
    }
    public void StartScore()
    {
        InvokeRepeating("incrementScore",0.1f,1.0f);
    }
    public void StopScore()
    {
        Debug.Log("YOOGameOverScoreYOO");
        CancelInvoke("incrementScore");
        PlayerPrefs.SetInt("score", score);
        
        



        if (PlayerPrefs.HasKey("HighScore"))
        {
            if (score > PlayerPrefs.GetInt("HighScore"))
                PlayerPrefs.SetInt("HighScore", score);
        }
        else
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }

}
