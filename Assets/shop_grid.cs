using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shop_grid : MonoBehaviour {
    public Shop_managere shop;
    private int id;
    public string Item_name;
    public int cost;
    private Image Item_image;
    public Text Item_name_1;
    public Text Item_cost;
	// Use this for initialization
	void Start () {
        id = this.transform.GetComponent<Grid>().id;
        Item_image = this.transform.GetComponent<Image>();
        Item_name_1.text = Item_name;
        Item_cost.text = "$"+cost.ToString();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void BePress()
    {
        Debug.Log(this.transform.parent.name);
        shop.setDetail(id, cost, this.transform.parent.gameObject);
    }
}
