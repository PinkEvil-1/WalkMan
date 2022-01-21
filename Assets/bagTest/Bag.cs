using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;
using UnityEngine.UI;

public class Bag : MonoBehaviour {

    public static ItemHaveTest itemhave = ItemHaveTest.getInstance();
    public GameObject grid;
    public GameObject grid_null;
    public int gridNum;

    public List<Grid> gridList = new List<Grid>();
    // Use this for initialization
  
    void Start () {
        InitGrid();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.A)) {
           Debug.Log(gridList[0].Item.itemID);
            /*foreach (KeyValuePair<int, Item> kvp in itemhave.ItemDiction)
            {
                Debug.Log(itemhave.ItemDiction[kvp.Key].ItemName);
            }*/
        }
    }

    void InitGrid() {
        int i = 16;
        foreach (KeyValuePair<int, Item> kvp in itemhave.ItemDiction)
        {
            //Debug.Log(itemhave.ItemDiction[kvp.Key].ItemName);
            int ID = itemhave.ItemDiction[kvp.Key].ID;
            createItem(itemhave.ItemDiction[kvp.Key].ItemName,ID);
            i--;
        }
        while (i!=0) {
            createEmpty();
            i--;
        }
        
    }
    void createItem(string name,int ID)
    {
        GameObject obj = Instantiate(grid);
        obj.transform.parent = transform;
        obj.name = "UI_ItemGrid";
        obj.transform.localScale = Vector3.one;
        Grid creatGrid = obj.AddComponent<Grid>();
        gridList.Add(creatGrid);
        obj.transform.GetChild(0).transform.GetComponent<Image>().sprite = (Sprite)Resources.Load<Sprite>("bag/"+name);
        obj.transform.GetChild(0).transform.GetComponent<GridItem>().itemID = ID;
    }
    void createEmpty()
    {
        GameObject obj = Instantiate(grid_null);
        obj.transform.parent = transform;
        obj.name = "UI_ItemGrid";
        obj.transform.localScale = Vector3.one;
        Grid creatGrid = obj.AddComponent<Grid>();
        gridList.Add(creatGrid);
    }
}
