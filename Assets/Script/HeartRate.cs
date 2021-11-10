using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartRate : MonoBehaviour
{
    public static Text scoretext;
    public static float heartRate_f = 120f;
    public static int heartRate = 0;
    AudioSource audioSource;
    public AudioClip heartRateSound;
    void Start()
    {
        scoretext = GetComponent<Text>();
        heartRate = PlayerPrefs.GetInt("ScoreData", heartRate);
        Heart();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //change the heart rate per 2 sec 

        //heartRate_f -= Time.deltaTime;
        //heartRate_f = Random.Range(100, 200);
        heartRate = (int)heartRate_f;

        // Debug.Log("Time Left" + sec);
        PlayerPrefs.SetInt("ScoreData", heartRate);
        PlayerPrefs.Save();
        scoretext.text = heartRate.ToString();

    }

    public void Heart() {
        InvokeRepeating("ChangeHeartRate", 2f, 2f);
        InvokeRepeating("heartRateSoundEffect", 1f, 4.9f);
    }

    public void ChangeHeartRate() {
        heartRate_f = Random.Range(20, 200);
        //Debug.Log(heartRate_f);
    }



    public void heartRateSoundEffect()
    {
        audioSource.PlayOneShot(heartRateSound);

    }

    public void gameOver()
    {
        Debug.Log("You failed");
        //ui.GetComponent<State>().setState("Well done he was saved");
    }
   

    public static void timeKeeper(int value)
    {
        heartRate += value;
        PlayerPrefs.SetInt("ScoreData", heartRate);
        PlayerPrefs.Save();
        scoretext.text = heartRate.ToString();
    }

    public static void resetTime()
    {
        heartRate_f = 120f;
    }

}
