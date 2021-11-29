using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreCount : MonoBehaviour {

	public static int score;
	//public static Text scoreText;

	void Start () {
		PlayerPrefs.DeleteAll();
		//scoreText = GetComponent<Text>();
		score = PlayerPrefs.GetInt("scoreData",0);
		UpdateScore(0);
	}
	
	public static void UpdateScore(int value) {
	//	score += value;
	//	PlayerPrefs.SetInt("scoreData", score);
	//	PlayerPrefs.Save();
	//	scoreText.text= "Score: " + score.ToString();
	}
}



