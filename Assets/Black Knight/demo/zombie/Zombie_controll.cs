using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie_controll : MonoBehaviour {
    public GameObject target;
    public Zombie_Animation_controll z_a_c;
    public string state;
    float target_x;
    public float MaxHP = 1000;
    public float HP;
    public float run_dis=3.0f;
    private float my_x;
    private float mytarget;
    private float speed = 1.0f;
    public int way;
    private Collider2D targetForHp;
    private float attack_time=2f;
    public float loadTime=1f;
    public RectTransform hp;
    public float superglue = 1;
    // Use this for initialization
    void Start () {
        target_x = target.transform.position.x;
        z_a_c = this.GetComponent<Zombie_Animation_controll>();
        state = "walk";
        if (this.transform.position.x > 0)
        {
            way = -1; //右
        }
        else
        {
            way = 1;//左
            this.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
        }
    }
	
	// Update is called once per frame
	void Update () {
        hp.localScale = new Vector3((0 + 100 * (HP / 100.0f)), 100f, 100f);
        my_x = this.transform.position.x;
        mytarget = my_x - target_x;
        attack_time += Time.deltaTime;
        if (HP<=0)
        {
            z_a_c.dead();
            state = "todead";
            this.transform.GetComponent<Collider2D>().enabled = false;
            StartCoroutine(dead());
        }
        if (state.Equals("walk"))
        {
            if (mytarget > 0 || mytarget < 0)
            {
                if (Math.Abs(mytarget) > Math.Abs(run_dis))
                {
                    z_a_c.walk();
                    speed = 1.0f;
                    this.transform.position += new Vector3(way * speed * superglue* Time.deltaTime, 0, 0);
                }
                else
                {
                    z_a_c.attack2();
                    warring();
                    state = "war";
                }
            }
        }
        else if (state.Equals("run"))
        {
            z_a_c.run();
            speed = 3.0f;
            this.transform.position += new Vector3(way * speed * superglue*Time.deltaTime, 0, 0); 
        }
        else if (state.Equals("attack"))
        {
            //Debug.Log(attack_time);
            if(attack_time >= loadTime)
            {
                z_a_c.attack1();
                targetForHp.transform.GetComponent<House_state>().HP -= 10;
                attack_time = 0;
            }
        }
        else if (state.Equals("attack_trap"))
        {
            //Debug.Log(attack_time);
            if (attack_time >= loadTime)
            {
                z_a_c.attack1();
                targetForHp.transform.GetComponent<Trap_state>().HP -= 10;
                if (targetForHp.transform.GetComponent<Trap_state>().HP <= 0)
                {
 
                    state = "walk";
                }
                else
                {
                    HP = targetForHp.transform.GetComponent<Trap_state>().ToAttack(HP);
                }
                attack_time = 0;
            }
        }
        
	}
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("house"))
        {
            
            state = "attack";
            targetForHp = other;
        }else if (other.gameObject.CompareTag("trap"))
        {
            state = "attack_trap";
            targetForHp = other;
        }
        else if (other.gameObject.CompareTag("superglue"))
        {
            superglue = 0.5f;
            other.transform.GetComponent<SuperGlue>().HP -= 10;
        }
    }
    /*public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            Debug.Log("#######");
            Physics.IgnoreCollision(this.GetComponent<Collider>(), collision.gameObject.GetComponent<Collider>());
        }
    }*/
    public void warring()
    {
          z_a_c.stop();
          StartCoroutine(load());
    }
    IEnumerator load()
    {
        yield return new WaitForSeconds(1f);    //注意等待时间的写法
        state = "run";
    }
    IEnumerator dead()
    {
        yield return new WaitForSeconds(5f);    //注意等待时间的写法
        Destroy(gameObject);
    }
}
