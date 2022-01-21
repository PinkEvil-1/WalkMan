using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Press_change : MonoBehaviour {
    public Composite_trapSystem com;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void BePress()
    {
        com.creat_trap(this.transform.GetComponent<Grid>().id,this.transform.parent.gameObject);
    }
}
