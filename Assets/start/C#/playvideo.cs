using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playvideo : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Screen.orientation = ScreenOrientation.LandscapeLeft;
		Screen.fullScreen = true;
		//Handheld.PlayFullScreenMovie("walkman.mp4", Color.black, FullScreenMovieControlMode.CancelOnInput);
		Handheld.PlayFullScreenMovie ("walkman.mp4", Color.black, FullScreenMovieControlMode.Hidden);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
