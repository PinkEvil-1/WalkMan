using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eatGpsPoint : MonoBehaviour {

    private GameObject player;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Avatar");
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag ("Cube"))
        {
            other.gameObject.SetActive(false);
        }
    }
}
