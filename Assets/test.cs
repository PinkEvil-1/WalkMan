using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {

    public GameObject copy;
    // Use this for initialization
    void Start () {
        /*getme= copy.transform.GetComponent<RectTransform>();
        this.GetComponent<RectTransform>() = getme;
        this.*/
        Component source = copy.GetComponent(typeof(RectTransform));
        System.Type type = source.GetType();
        //Component target = this.gameObject.AddComponent(type);
        System.Reflection.FieldInfo[] fields = type.GetFields(); //使用Reflection取得此type上的所有fields
        foreach (System.Reflection.FieldInfo field in fields)
        {
            field.SetValue(this.transform.GetComponent<RectTransform>(), field.GetValue(source)); //把來源Component上的所有field數值設定到目標Component上
            Debug.Log("finish");
        }

    }
	
	// Update is called once per frame
	void Update () {
		
    }
}
