using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uidetail : MonoBehaviour {

    public NowYouSelect nowYouSelect;
    public int ID;

    // Use this for initialization
    void Start () {
        ID = gameObject.transform.GetComponent<GridItem>().itemID;
        //nowYouSelect=GameObject.getFind("NowYouSelect");
        Transform[] transforms = transform.parent.parent.parent.GetComponentsInChildren<Transform>();

        for(int i = 0; i < transforms.Length; i++)
        {
            if (nowYouSelect == null)
            {
                if (transforms[i].name == "NowYouSelect")
                {
                    nowYouSelect = transforms[i].GetComponent<NowYouSelect>();
                }
            }
        }


    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void IBePress()
    {
        nowYouSelect.ChangeYourSelect(ID);
    }
}
