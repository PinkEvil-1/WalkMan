using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NowYouSelect : MonoBehaviour {

    public Image Item_Image;
    public Text description;

    public static ItemHaveTest itemhave = ItemHaveTest.getInstance();

    public int id;
    // Use this for initialization
    void Start()
    {
        foreach (KeyValuePair<int, Item> kvp in itemhave.ItemDiction)
        {
            //Debug.Log(itemhave.ItemDiction[kvp.Key].ItemName);
            ChangeYourSelect(itemhave.ItemDiction[kvp.Key].ID);
            break;
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
    public void ChangeYourSelect(int ID)
    {
        //this.gameObject.SetActive(true);
        id = ID;
        Item_Image.sprite = (Sprite)Resources.Load<Sprite>("bag/" + itemhave.IDToName(ID));
        description.text = itemhave.IDToDescription(ID);
    }
    public void useItemButton()
    {
        itemhave.Use(id);
    }
}
