using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class House_state : MonoBehaviour {
    private int[] MaxHP =new int[] { 0, 100, 200, 300, 400, 500, 600, 700, 800, 900, 1000 };
    public int Level = 10;
    public float HP;
    public Image hp;
    public GameObject gameover;
    // Use this for initialization
    void Start () {
        HP = MaxHP[Level];
	}
	
	// Update is called once per frame
	void Update () {
        if (HP <= 0)
        {
            gameover.SetActive(true);
        }
        hp.transform.localPosition = new Vector3((-770 + 770*(HP / MaxHP[Level])),0.0f,0.0f );

    }
}
