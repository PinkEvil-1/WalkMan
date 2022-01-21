using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creat_enemy : MonoBehaviour {

    public GameObject zombie;
    public GameObject enemy;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void creat_en()
    {
        GameObject obj_1 = Instantiate(zombie);
        obj_1.transform.parent = transform;
        obj_1.transform.localScale = new Vector3(-0.009999999f, 0.009999999f, 0.009999999f);
        obj_1.transform.localPosition = new Vector3(-36.6f, -5.7f,0);
        obj_1.SetActive(true);
        GameObject obj = Instantiate(enemy);
        obj.transform.parent = transform;
        obj.transform.localScale = new Vector3(0.3451348f, 0.3451348f, 0.3451348f);
        obj.transform.localPosition = new Vector3(36.09f, -4.6f, 0);
        obj.SetActive(true);
    }
}
