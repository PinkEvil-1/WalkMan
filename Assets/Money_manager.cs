using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money_manager : MonoBehaviour {
    public int Money;
    public Text MoneyText;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        MoneyText.text = Money.ToString();

    }
}
