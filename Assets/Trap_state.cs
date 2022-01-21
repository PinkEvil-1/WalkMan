using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap_state : MonoBehaviour {

    public int HP;
    public int ID;
    public string state;
    private Collider2D targetForHp;
    Animator animator;
    private float attack_time = 2f;
    private float loadTime = 3f;
    public int trap_damage = 50;
    // Use this for initialization
    void Start () {
        animator = this.gameObject.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        if (HP <= 0)
        {
            animator.SetBool("dead",true);
            this.transform.position = new Vector3(this.transform.position.x, -4f,0);
            StartCoroutine(dead());
        }
	}

    public float ToAttack(float hp)
    {
        animator.SetTrigger("attack");
        return hp - trap_damage;
    }
    public void safe_trap()
    {
        state = "safe";
    }
    IEnumerator dead()
    {
        yield return new WaitForSeconds(5f);    //注意等待时间的写法
        Destroy(gameObject);
    }
}
