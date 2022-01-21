using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChan2D_AnimateControll : MonoBehaviour {
    private Animator animator;
    private Transform transform;

    // Use this for initialization
    void Start () {
        animator = this.GetComponent<Animator>();
        transform = this.GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void SetRunLeft()
    {
        transform.localScale = new Vector3(-1, 1, 1);
        animator.SetFloat("speed",5f);
    }
    public void SetRunRight()
    {
        transform.localScale = new Vector3(1, 1, 1);
        animator.SetFloat("speed", 5f);
    }
    public void SetIdle()
    {
        animator.SetFloat("speed", 0f);
    }
}
