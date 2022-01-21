using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperGlue : MonoBehaviour {
    public int HP;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (HP <= 0)
        {
            StartCoroutine(dead());
        }
    }

    IEnumerator dead()
    {
        yield return new WaitForSeconds(5f);    //注意等待时间的写法
        Destroy(gameObject);
    }
}
