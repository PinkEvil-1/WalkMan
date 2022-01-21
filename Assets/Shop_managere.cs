using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop_managere : MonoBehaviour {
    public Image Item_Image;
    public Text Item_Name;
    public Text Item_descrip;
    public Text Item_cost;
    public Text Item_have;
    public GameObject now_select;

    public int Now_ID;

    public static ItemHaveTest itemhave = ItemHaveTest.getInstance();
    public Money_manager money;

    private int Cost;
    // Use this for initialization
    void Start () {
        setDetail(3, 500);

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void setDetail(int ID,int cost,GameObject parent)
    {
        money.MoneyText.color = Color.black;
        now_select.transform.parent=parent.transform;
        now_select.transform.localPosition = new Vector3(now_select.transform.localPosition.x, 0.0f, 0.0f);
        Cost = cost;
        Now_ID = ID;
        Item_cost.text = Cost.ToString();
        Item_Name.text = itemhave.IDToName(ID);
        Item_descrip.text = itemhave.IDToDescription(ID);
        Item_have.text = itemhave.IDToNumber(ID).ToString() + "個";
        Item_Image.sprite = (Sprite)Resources.Load<Sprite>("bag/" + itemhave.IDToName(ID));
    }
    public void setDetail(int ID, int cost)
    {
        money.MoneyText.color = Color.black;
        Now_ID = ID;
        Cost = cost;
        Item_cost.text = Cost.ToString();
        Item_Name.text = itemhave.IDToName(ID);
        Item_descrip.text = itemhave.IDToDescription(ID);
        Item_have.text = itemhave.IDToNumber(ID).ToString()+"個";
        Item_Image.sprite = (Sprite)Resources.Load<Sprite>("bag/" + itemhave.IDToName(ID));
    }
    public void Shop_button()
    {
        if (money.Money>= Cost)
        {
            money.Money -= Cost;
            itemhave.ItemDiction[Now_ID].Number++;
            setDetail(Now_ID, Cost);
        }
        else
        {
            money.MoneyText.color = Color.red;
        }
    }
}
