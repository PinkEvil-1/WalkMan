using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;
using UnityEngine.UI;

public class trap_bag : MonoBehaviour {

    public static ItemHaveTest itemhave = ItemHaveTest.getInstance();
    public GameObject grid;
    public int gridNum;

    public List<Grid> gridList = new List<Grid>();
    // Use this for initialization
    void Start () {
        InitGrid();
    }
	
	// Update is called once per frame
	void LateUpdate () {
		
	}
    void InitGrid()
    {
        foreach (KeyValuePair<int, Item> kvp in itemhave.ItemDiction)
        {
            int ID = itemhave.ItemDiction[kvp.Key].ID;
            if (ID > 100)
            {
                createItem(itemhave.ItemDiction[kvp.Key].ItemName,ID);
            }
        }
    }
    void createItem(string name, int ID)
    {
        GameObject obj = Instantiate(grid);
        obj.transform.parent = transform;
        obj.name = "UI_ItemGrid";
        obj.transform.localScale = Vector3.one;
        Grid creatGrid = obj.AddComponent<Grid>();
        creatGrid.id = ID;
        gridList.Add(creatGrid);
        obj.transform.GetChild(0).transform.GetComponent<Image>().sprite = (Sprite)Resources.Load<Sprite>("bag/" + name);
        obj.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text ="X"+itemhave.IDToNumber(ID).ToString();
    }
}