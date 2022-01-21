using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainBehavior : MonoBehaviour {
    public float speed;
    public float x;
    private Collider2D targetForHp;
    private Main_animation_control animator;
    private string state;
    public float power = 20;
    private float attack_time = 2f;
    public float loadTime = 1f;

    private int target = 1;
    private int now_way = 1;
    // Use this for initialization
    void Start () {
        x = this.transform.position.x;
        animator = this.GetComponent<Main_animation_control>();
        state = "walk_right";
    }
	
	// Update is called once per frame
	void Update () {
        x = this.transform.position.x;
        attack_time += Time.deltaTime;
        if (state.Equals("attack")){
            speed = 0;
            animator.set_speed(speed);
            if (attack_time >= loadTime)
            {
                targetForHp.transform.GetComponent<Zombie_controll>().HP -= power;
                animator.attack();
                attack_time = 0;
                if(targetForHp.transform.GetComponent<Zombie_controll>().HP <= 0)
                {
                    this.transform.GetComponent<Collider2D>().enabled = false;
                    this.transform.GetComponent<Collider2D>().enabled = true;
                    state = "walk_leafe";
                }
            }
        }
        else if (state.Equals("attack_w"))
        {
            speed = 0;
            animator.set_speed(speed);
            if (attack_time >= loadTime)
            {
                targetForHp.transform.GetComponent<enemy_control>().HP -= power;
                animator.attack();
                attack_time = 0;
                if (targetForHp.transform.GetComponent<enemy_control>().HP <= 0)
                {
                    this.transform.GetComponent<Collider2D>().enabled = false;
                    this.transform.GetComponent<Collider2D>().enabled = true;
                    state = "walk_leafe";
                }
            }
        }
        else if(state.Equals("walk_leafe"))
        {
            if (this.transform.position.x <=- 3)
            {
                state = "walk_right";
            }
            speed = 1;
            animator.set_speed(speed);
            this.transform.localScale = new Vector3(0.2128537f, 0.2128537f, 0.2128537f);
            this.transform.position = new Vector3(this.transform.position.x - (speed * Time.deltaTime), -3.23f, 0);
            
            
        }else if (state.Equals("walk_right"))
        {
            if (this.transform.position.x >= 3)
            {
                state = "walk_leafe";
            }
            speed = 1;
            animator.set_speed(speed);
            this.transform.position = new Vector3(this.transform.position.x + (speed * Time.deltaTime), -3.23f, 0);
            this.transform.localScale = new Vector3(-0.2128537f, 0.2128537f, 0.2128537f);
            
        }
	}
    public void GotoZombie()
    {

    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("enemy"))
        {
            targetForHp = other;
            state = "attack";
        }else if (other.gameObject.CompareTag("enemy_w"))
        {
            targetForHp = other;
            state = "attack_w";
        }
    }
}
