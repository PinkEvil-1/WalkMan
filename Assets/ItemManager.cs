using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour {

    public static ItemManager itemManager;
    public Dictionary<int,Item> ItemDiction = new Dictionary<int,Item> ();

	// Use this for initialization
	void Start () {
        if (itemManager == null)
        {
            itemManager = this;
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.LeftArrow)) //左
        {
            AddItem(new ProbsItem_1());
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            Use(1);
        }

    }

	public void AddItem(Item item){         //獲得道具
		if (!ItemDiction.ContainsKey (item.ID)) {
			ItemDiction.Add (item.ID,item);
            ItemDiction[item.ID].Number++;
            Debug.Log("獲得了"+ ItemDiction[item.ID].ItemName + "，目前有:"+ ItemDiction[item.ID].Number + "個");
        }
        else
        {
            ItemDiction[item.ID].Number++;
            Debug.Log("獲得了" + ItemDiction[item.ID].ItemName + "，目前有:" + ItemDiction[item.ID].Number + "個");
        }
	}
	public void Use(int id){            //使用道具
		if (ItemDiction.ContainsKey (id)) {
			ItemDiction[id].use();
            ItemDiction[id].Number--;
            Debug.Log("使用了" + ItemDiction[id].ItemName + "，目前有:" + ItemDiction[id].Number + "個");
            if (ItemDiction[id].Number == 0)
            {
                ItemDiction.Remove(id);
            }
        }
	}
}