using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class AEDMode : MonoBehaviour
{
    public static Text scoretext;
    public static float sec_f = 300f;
    public static int sec = 0;
    public Text ui;
    public bool timerIsRunning = true;
    float StartTime = 61f;

    void Start()
    {
        scoretext = GetComponent<Text>();
        sec = PlayerPrefs.GetInt("ScoreData", sec);
    }

    void Update()
    {
        
        DisplayTime(sec_f);
        if (timerIsRunning)
        {

            if (sec_f > 0)
            {
                sec_f -= Time.deltaTime;
            }
            else
            {
                Debug.Log("Time has run out!");
                sec_f = 0;
                timerIsRunning = false;
            }
        }
            
        
    }


    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        scoretext.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }



    public void gameOver()
    {
        Debug.Log("You failed");
        //ui.GetComponent<State>().setState("Well done he was saved");
    }


    public static void timeKeeper(int value)
    {
        sec += value;
        PlayerPrefs.SetInt("ScoreData", sec);
        PlayerPrefs.Save();
        scoretext.text = sec.ToString();
    }

    public static void resetTime()
    {
        sec_f = 120f;
    }


    //menu
    //
    //the time is counting

    //the heart rate is 0 

    //


}
