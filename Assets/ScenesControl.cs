using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    private void Update()
    {
        
    }

    public void ChangeToGoMap()
    {
        SceneManager.LoadScene("GoMapScene");
    }
    public void ChangeToGame()
    {
        SceneManager.LoadScene("1");
    }
}
