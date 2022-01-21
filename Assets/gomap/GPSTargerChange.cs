using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GPSTargerChange : MonoBehaviour {

    public GameObject game;
    public GameObject button;

    public static ItemHaveTest itemhave = ItemHaveTest.getInstance();

    public Text targetDistance;
    public Text nowDistance;

    [SerializeField]
    Image myImage;

    public Text name;
    public Text description;
    public Image get;
    public int Get_ID;


    public void close()
    {
        gameObject.SetActive(false);
    }
    

    public void Distance_enought()
    {
        button.SetActive(true);
    }
    public void Distance_not_enought()
    {
        button.SetActive(false);
    }

    public void Get_Id_Item()
    {
        itemhave.getItem(Get_ID, Random.Range(400, 500));
        Debug.Log(itemhave.IDToNumber(Get_ID));
    }
}
