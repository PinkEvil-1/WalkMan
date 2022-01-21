using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie_Animation_controll : MonoBehaviour {

    // Use this for initialization
    Animator enemyAnimator;

    void Start () {
        enemyAnimator = this.gameObject.GetComponent<Animator>();
    }
	public void attack1()
    {
        stop();
        enemyAnimator.SetTrigger("skill_1");
    }
    public void attack2()
    {
        enemyAnimator.SetTrigger("skill_2");
    }
    public void dead()
    {
        stop();
        enemyAnimator.SetBool("dead",true);
    }
    public void run()
    {
        enemyAnimator.SetFloat("speed",3.0f);
    }
    public void walk()
    {
        enemyAnimator.SetFloat("speed",1.0f);
    }
    public void stop()
    {
        enemyAnimator.SetFloat("speed", 0f);
    }
}
