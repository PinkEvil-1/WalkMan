using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class startbtn : MonoBehaviour {
	//public Text UIText;
	public Image UIImage;
	private float timer;
	// Use this for initialization
	void Start () {
		timer = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime * 2;

		if (timer % 2 > 1.0f)

		{

			UIImage.enabled = false;

		}

		else {

			UIImage.enabled = true;

		}
	}
}
