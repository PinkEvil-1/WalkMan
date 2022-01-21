using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Composite_trapSystem : MonoBehaviour {
    public Image trap_image;
    public Image material_1_image;
    public Text material_1_have_text;
    public Image material_2_image;
    public Text material_2_have_text;
    public GameObject now_select;

    public static ItemHaveTest itemhave = ItemHaveTest.getInstance();

    private int myID;
    private int material_1;
    private float material_1_have;
    private int material_1_need;
    private int material_2;
    private float material_2_have;
    private int material_2_need;

    // Use this for initialization
    void Start () {
        creat_trap(101);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void creat_trap(int ID,GameObject parent)
    {
        if(ID == 101)
        {
            myID = ID;
            material_1 = 3;
            material_2 = 4;
            material_1_need = 50;
            material_2_need = 25;
        }else if(ID == 102)
        {
            myID = ID;
            material_1 = 5;
            material_2 = 6;
            material_1_need = 30;
            material_2_need = 20;
        }
        now_select.transform.parent = parent.transform;
        now_select.transform.localPosition = new Vector3(now_select.transform.localPosition.x, 0.0f,0.0f);
        trap_image.sprite = (Sprite)Resources.Load<Sprite>("bag/" + itemhave.IDToName(ID));
        material_1_image.sprite = (Sprite)Resources.Load<Sprite>("bag/" + itemhave.IDToName(material_1));
        material_2_image.sprite = (Sprite)Resources.Load<Sprite>("bag/" + itemhave.IDToName(material_2));
        material_1_have = itemhave.IDToNumber(material_1);
        if(material_1_need > material_1_have)
        {
            material_1_have_text.color = Color.red;
        }
        else
        {
            material_1_have_text.color = Color.black;
        }
        if(material_2_need > material_2_have)
        {
            material_2_have_text.color = Color.red;
        }
        else
        {
            material_2_have_text.color = Color.black;
        }
        material_2_have = itemhave.IDToNumber(material_2);
        material_1_have_text.text = material_1_have.ToString()+ "/" + material_1_need.ToString();
        material_2_have_text.text = material_2_have.ToString()+"/" + material_2_need.ToString();
    }
    public void creat_trap(int ID)
    {
        if (ID == 101)
        {
            myID = ID;
            material_1 = 3;
            material_2 = 4;
            material_1_need = 50;
            material_2_need = 25;
        }
        else if (ID == 102)
        {
            myID = ID;
            material_1 = 5;
            material_2 = 6;
            material_1_need = 30;
            material_2_need = 20;
        }
        trap_image.sprite = (Sprite)Resources.Load<Sprite>("bag/" + itemhave.IDToName(ID));
        material_1_image.sprite = (Sprite)Resources.Load<Sprite>("bag/" + itemhave.IDToName(material_1));
        material_2_image.sprite = (Sprite)Resources.Load<Sprite>("bag/" + itemhave.IDToName(material_2));
        material_1_have = itemhave.IDToNumber(material_1);
        material_2_have = itemhave.IDToNumber(material_2);
        if (material_1_need > material_1_have)
        {
            material_1_have_text.color = Color.red;
        }
        else
        {
            material_1_have_text.color = Color.black;
        }
        if (material_2_need > material_2_have)
        {
            material_2_have_text.color = Color.red;
        }
        else
        {
            material_2_have_text.color = Color.black;
        }
        material_1_have_text.text = material_1_have.ToString() + "/" + material_1_need.ToString();
        material_2_have_text.text = material_2_have.ToString() + "/" + material_2_need.ToString();
    }
    public void Composite_sure()
    {
        if(material_1_need <= material_1_have)
        {
            if(material_2_need <= material_2_have)
            {
                itemhave.ItemDiction[material_1].Number-= material_1_need;
                itemhave.ItemDiction[material_2].Number -= material_2_need;
                itemhave.ItemDiction[myID].Number ++;
                creat_trap(myID);
            }
        }
    }
}
