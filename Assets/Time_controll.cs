using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Time_controll : MonoBehaviour {
   static float timer_f;
   static long timer_i;
   static long nowTime;
    // Use this for initialization
    static void Start () {
        nowTime = -1;

    }

    // Update is called once per frame
    static void Update () {
        timer_f = Time.time;
        timer_i = (long)timer_f;
        /*if(nowTime != timer_i)
        {
            Debug.Log(timer_i);
            nowTime = timer_i;
        }*/
	}
   
}
