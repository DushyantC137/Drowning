using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour {
    public static GameManagerScript instance;
    public bool gameOver = false;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    // Use this for initialization
    void Start () {
        //StartGame();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void StartGame()
    {
        UIManager.instance.GameStart();
        ScoreManager.instance.StartScore();
    }
    public void GameOver()
    {
        ScoreManager.instance.StopScore();
        UIManager.instance.GameOver();
        
    }
}
