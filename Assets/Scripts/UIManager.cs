using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class UIManager : MonoBehaviour {
    public GameObject MainPanel;
    public GameObject GameOverPanel;
    public Text Score;
    public Text highscore1;
    public Text highscore2;
    public GameObject StartButton;
   public GameObject RunningScore;
    public GameObject TapText;
    public GameObject Evil;
    public GameObject Slayer;
    public GameObject PlayerMovementController;
    public static UIManager instance;
    public GameObject particle;
      
    //Before Start
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    

	// Use this for initialization
	void Start () {
       // PlayerPrefs.SetInt("HighScore",0);
        highscore1.text = PlayerPrefs.GetInt("HighScore").ToString();
        //GameStart();
    }
    
    public void GameStart()
    {
      
        highscore1.text = PlayerPrefs.GetInt("HighScore").ToString();
        RunningScore.SetActive(true);
        PlayerMovementController.SetActive(true);
        TapText.SetActive(false);
         MainPanel.GetComponent<Animator>().Play("UpPanel");
        StartButton.SetActive(false);
        Evil.SetActive(true);
        FindObjectOfType<AudioMan>().Play("Background");
    }
  
    public void GameOver()
    {
        Score.text = PlayerPrefs.GetInt("score").ToString();
        highscore2.text = PlayerPrefs.GetInt("HighScore").ToString();
        RunningScore.SetActive(false);
        Evil.GetComponent<Shoot2>().StopFire();
        GameOverPanel.SetActive(true);

    }
	public void StartOver()
    {
        SceneManager.LoadScene(0);
    }
    public void KillPlayer()
    {
        Evil.GetComponent<Shoot1>().StopFire();
        UIManager.instance.GameOver();
        Instantiate(particle, transform.position, Quaternion.Euler(90, 0, 0));
        Slayer.SetActive(false);
        Slayer.transform.Translate(0, -15, 0);
    }
    // Update is called once per frame
    void Update () {
		
	}

}
