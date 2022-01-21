using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loaddingbar : MonoBehaviour {

	private bool loadScene = false;
	public string LoadingSceneName;
	public Text loadingText;
	public Slider silderBar;


	// Use this for initialization
	void Start () {
		silderBar.gameObject.SetActive (false);	
	}
	
	// Update is called once per frame
	void Update () {
		 
		if(loadScene == false)
		{
			loadScene = true;

			silderBar.gameObject.SetActive (true);

			loadingText.text = "Loading...";

			StartCoroutine (LoadNewScene(LoadingSceneName));
		}
	}



	IEnumerator LoadNewScene(string sceneName){

		AsyncOperation async = SceneManager.LoadSceneAsync (sceneName);

		while(!async.isDone){
			float progerss = Mathf.Clamp01 (async.progress / 0.9f);
			silderBar.value = progerss;
			loadingText.text = progerss * 100f + "%";
			yield return null;
		}

	}
}
