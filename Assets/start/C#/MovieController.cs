using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class MovieController : MonoBehaviour
{
	private VideoPlayer m_VideoPlayer;

	void Awake () 
	{
		m_VideoPlayer = GetComponent<VideoPlayer>();
		m_VideoPlayer.loopPointReached += OnMovieFinished; // loopPointReached is the event for the end of the video

	}

	void OnMovieFinished(VideoPlayer player)
	{

		if ((ulong)player.frame == player.frameCount)
		{
			//Video Finished
			SceneManager.LoadScene ("sc1");
		}
		SceneManager.LoadScene ("sc1");
		//Debug.Log("Event for movie end called");
		//player.Stop();
		//SceneManager.LoadScene ("sc1");
	}
}