using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trap_creat_manager : MonoBehaviour {

    public ItemHaveTest itemhave;
    public List<GameObject> trapList = new List<GameObject>();
    // Use this for initialization
    void Start () {
        itemhave = ItemHaveTest.getInstance();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void trap_creat(Vector2 vec, int ID)
    {
        if (ID-100==1)
        {
            GameObject obj = Instantiate(trapList[0]);
            obj.transform.parent = GameObject.Find("Game").transform;
            obj.name = "nid_trap";
            obj.transform.position = new Vector2(vec.x, -3.89f);
            obj.SetActive(true);
        }
        else if(ID - 100 == 2)
        {
            GameObject obj = Instantiate(trapList[1]);
            obj.transform.parent = GameObject.Find("Game").transform;
            obj.name = "SuperGlue";
            obj.transform.position = new Vector2(vec.x, -3.9f);
            obj.SetActive(true);
        }
    }
}
