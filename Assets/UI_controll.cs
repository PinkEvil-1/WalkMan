using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_controll : MonoBehaviour {

    public GameObject BagSystem;
    private bool bagsystem = true;

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void BagSystem_see()
    {
        Debug.Log("0000");
        if (bagsystem)
        {
            BagSystem.SetActive(false);
            bagsystem = false;
        }
        else
        {
            BagSystem.SetActive(true);
            bagsystem = true;
        }
    }
}
