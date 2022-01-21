using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_control : MonoBehaviour {
    public enemy_animation z_a_c;
    public string state;
    private int way;
    public RectTransform hp;
    public float HP;
    private Collider2D targetForHp;
    public float superglue = 1;
    private float attack_time = 2f;
    public float loadTime = 1f;
    public float speed;
    public GameObject target;
    private float my_x;
    private float target_x;
    private float mytarget;
    // Use this for initialization
    void Start () {
        target_x = target.transform.position.x;
        z_a_c = this.GetComponent<enemy_animation>();
        state = "walk";
        if (this.transform.position.x > 0)
        {
            way = -1; //右
        }
        else
        {
            way = 1;//左
            this.transform.localScale = new Vector3(-0.3451349f, 0.3451349f, 0.3451349f);
        }
    }
	
	// Update is called once per frame
	void Update () {
        attack_time += Time.deltaTime;
        my_x = this.transform.position.x;
        mytarget = my_x - target_x;
        hp.localScale = new Vector3((0 + 2.963936f * (HP / 500.0f)), 2.963936f, 2.963936f);
        if (HP <= 0)
        {
            z_a_c.dead();
            state = "todead";
            this.transform.GetComponent<Collider2D>().enabled = false;
            this.transform.position -= new Vector3(0,0.05f*Time.deltaTime,0);
            StartCoroutine(dead());
        }
        if (state.Equals("walk"))
        {
            if (mytarget > 0 || mytarget < 0)
            {
                z_a_c.walk();
                speed = 1.0f;
                this.transform.position += new Vector3(way * speed * superglue * Time.deltaTime, 0, 0);

            }
        }

        else if (state.Equals("attack"))
        {
            //Debug.Log(attack_time);
            if (attack_time >= loadTime)
            {
                z_a_c.attack();
                targetForHp.transform.GetComponent<House_state>().HP -= 10;
                attack_time = 0;
            }
        }
        else if (state.Equals("attack_trap"))
        {
            //Debug.Log(attack_time);
            if (attack_time >= loadTime)
            {
                z_a_c.attack();
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
        }
        else if (other.gameObject.CompareTag("trap"))
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
    IEnumerator dead()
    {
        yield return new WaitForSeconds(2f);    //注意等待时间的写法
        Destroy(gameObject);
    }
}
