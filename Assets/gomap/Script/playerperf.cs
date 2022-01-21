using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerperf : MonoBehaviour {
	public Text ScoreText; //宣告一個ScoreText的text
	public int score=0;
	public void change(){
		PlayerPrefs.SetString("Score", "200");
		PlayerPrefs.Save ();
	}
	public void changeView(){
		ScoreText.text =PlayerPrefs.GetString("Score");
	}
}
