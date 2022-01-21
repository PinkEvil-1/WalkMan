using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChan2D_MoveControll : MonoBehaviour {

    private UnityChan2D_AnimateControll unitychan2D_animatecontroll;
    float m_speed = 2f;
    int state = 1;
    int nowstate=1000000;
    int timer_i = 0;
    int time_runtime = 0;
    float time_runf = 0f;
    int randomRunTime = 0;
	// Use this for initialization
	void Start () {
        unitychan2D_animatecontroll = this.GetComponent<UnityChan2D_AnimateControll>();
        InvokeRepeating("RandomState",2f,5f);
        randomRunTime = Random.Range(2,4);
    }
	
	// Update is called once per frame
	void Update () {
        /*if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) //左
        {
            this.transform.Translate(Vector2.right * -m_speed * Time.deltaTime);
            unitychan2D_animatecontroll.SetRunLeft();
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) //右
        {
            this.transform.Translate(Vector2.right * m_speed * Time.deltaTime);
            unitychan2D_animatecontroll.SetRunRight();
        }
        else
        {
            unitychan2D_animatecontroll.SetIdle();
        }*/
        time_runf += 1;
        time_runtime = (int)time_runf;
        switch (state)
        {
            case 0:
                Runleft();
                unitychan2D_animatecontroll.SetRunLeft();
                break;
            case 1:
                RunRight();
                unitychan2D_animatecontroll.SetRunRight();
                break;
            default:
                unitychan2D_animatecontroll.SetIdle();
                break;

        }
    }
    void RandomState()
    {
        timer_i += 1;
        state = Random.Range(0, 5);
        if(nowstate == state)
        {
            RandomState();
        }
        else
        {
            nowstate = state;
        }
        /*if(transform.position.x <= -8.2f || transform.position.x >= 8.2f)
        {
            RandomState();
        }*/
    }
    void Runleft()
    {
        if (transform.position.x <= -8.2f)
        {
            state = 2;
        }
        else if (randomRunTime % time_runtime == 0)
        {
            state = 2;
        }
        else
        {
            //this.transform.Translate(Vector2.right * -m_speed * Time.deltaTime);
            this.transform.position = new Vector3(Mathf.Clamp(transform.position.x + -0.05f , -8.2f, 8.2f), transform.position.y, 0);
        }
    }
    void RunRight()
    {
        if (transform.position.x >= 8.2f)
        {
            state = 2;
        }
        else if (randomRunTime % time_runtime == 0)
        {
            state = 2;
        }
        else
        {
            this.transform.position= new Vector3(Mathf.Clamp(transform.position.x + 0.05f, -8.2f, 8.2f), transform.position.y, 0);
            //Mathf.Clamp(transform.position.x + movement, minPosX, maxPosX), transform.position.y, transform.position.z
        }
    }
}
