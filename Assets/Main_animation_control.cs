using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_animation_control : MonoBehaviour {
    private Animator animator;
    // Use this for initialization
    void Start () {
        animator = this.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void set_speed(float speed)
    {
        animator.SetFloat("speed", speed);
    }
    public void attack()
    {
        animator.SetTrigger("attack");
    }
}
