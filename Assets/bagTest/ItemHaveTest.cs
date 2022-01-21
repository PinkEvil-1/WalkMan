using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHaveTest {

    public static ItemHaveTest ins;
    public Dictionary<int, Item> ItemDiction = new Dictionary<int, Item>();
    // Use this for initialization
    void Init()
    {
        AddItem(new ProbsItem_101());
        AddItem(new ProbsItem_101());
        AddItem(new ProbsItem_101());
        AddItem(new ProbsItem_102());
        AddItem(new ProbsItem_102());
        AddItem(new ProbsItem_102());
        AddItem(new ProbsItem_102());
        AddItem(new ProbsItem_3());
        AddItem(new ProbsItem_4());
        AddItem(new ProbsItem_5());
        AddItem(new ProbsItem_6());
        ItemDiction[3].Number = 500;
        ItemDiction[4].Number = 500;
        ItemDiction[5].Number = 500;
        ItemDiction[6].Number = 500;
        //AddItem(new ProbsItem_103());
    }


    public void AddItem(Item item)
    {         //獲得道具
        if (!ItemDiction.ContainsKey(item.ID))
        {
            ItemDiction.Add(item.ID, item);
            ItemDiction[item.ID].Number++;
            Debug.Log("獲得了" + ItemDiction[item.ID].ItemName + "，目前有:" + ItemDiction[item.ID].Number + "個");
        }
        else
        {
            ItemDiction[item.ID].Number++;
            Debug.Log("獲得了" + ItemDiction[item.ID].ItemName + "，目前有:" + ItemDiction[item.ID].Number + "個");
        }
    }
    public void Use(int id)
    {            //使用道具
        if (id <= 100)
        {
            if (ItemDiction.ContainsKey(id))
            {
                ItemDiction[id].use();
                ItemDiction[id].Number--;
                Debug.Log("使用了" + ItemDiction[id].ItemName + "，目前有:" + ItemDiction[id].Number + "個");
                if (ItemDiction[id].Number == 0)
                {
                    ItemDiction.Remove(id);
                }
            }
        }
        else
        {
            Debug.Log("你使用的是陷阱!id>100");
        }
    }
    public void Build(int id,Vector2 vec)
    {
        if (id > 100)
        {
            ItemDiction[id].build();
            ItemDiction[id].Number--;
            Debug.Log("建造了" + ItemDiction[id].ItemName + "，目前有:" + ItemDiction[id].Number + "個");
            if (ItemDiction[id].Number == 0)
            {
                ItemDiction.Remove(id);
            }

        }
        else
        {
            Debug.Log("你使用的是道具!id<=100");
        }
    }
    public string IDToName(int id) {
        return ItemDiction[id].ItemName;
    }
    public string IDToDescription(int id)
    {
        return ItemDiction[id].Description;
    }
    public float IDToNumber(int id)
    {
        return ItemDiction[id].Number;
    }
    public void getItem(int id,int number)
    {
        ItemDiction[id].Number += number;
    }

    public static ItemHaveTest getInstance(){      //單例
        if (ins == null)
        {
            ins = new ItemHaveTest();
            ins.Init();
        }
        return ins;
    }      
}
