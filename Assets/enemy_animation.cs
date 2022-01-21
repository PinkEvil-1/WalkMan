using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_animation : MonoBehaviour {

    Animator enemyAnimator;

    void Start()
    {
        enemyAnimator = this.gameObject.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void attack()
    {
        stop();
        enemyAnimator.SetTrigger("attack");
    }
    public void dead()
    {
        stop();
        enemyAnimator.SetBool("dead", true);
    }
    public void walk()
    {
        enemyAnimator.SetFloat("speed", 1.0f);
    }
    public void stop()
    {
        enemyAnimator.SetFloat("speed", 0f);
    }
}
