using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class list_control : MonoBehaviour {

    public Animator _animator;
    float listCon = -1;
	/*public GameObject Menu;
	public GameObject button;
	bool MenuEnable = false;*/
	// Use this for initialization
	void Start () {
        /*Menu = GameObject.Find ("list");
		button = GameObject.Find ("list_button");
		Menu.SetActive (false);*/
        _animator = this.GetComponent<Animator>();

    }
	
	// Update is called once per frame
	void Update () {
		/*if (Input.GetKeyDown (KeyCode.Z)) {
			MenuEnable = !MenuEnable;
			Menu.SetActive (MenuEnable);
			button.transform.Rotate(new Vector3(0, 180, 0));
		}*/
	}
    public void hideOrShow()
    {
        listCon *= -1;
        if (listCon == 1)
        {
            _animator.SetBool("IsShow", true);
            Debug.Log("11111111111111");
        }
        else if(listCon == -1)
        {
            _animator.SetBool("IsShow", false);
            Debug.Log("-1-1-1-1-1-1-1-1-1-1-1");
        }
    }
}
