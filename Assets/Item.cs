using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item {

	public int ID;
	public string ItemName; //物品名稱
	public float Number;	//數量
	public string Description; //物品描述
    public Sprite image;

	public Item(){
	}
	public virtual void Init(){
	}
	public virtual void use(){
	}
    public virtual void build()
    {
    }
}
public class ProbsItem : Item{
		
	public ProbsItem() :　base(){
	}
	public override void use(){
		base.use ();
		Debug.Log ("you use the "+ItemName);
	}
    public override void build()
    {
        base.build();
        Debug.Log("you build the " + ItemName);
    }
}
public class ProbsItem_1 :ProbsItem{
    public ProbsItem_1() : base()
    {
        ID = 1;
        ItemName = "回復藥(小)";
        Description = "回復少量生命";
    }
	public override void use(){
		base.use ();
		Debug.Log ("HP+10");
	}
}
public class ProbsItem_2 :ProbsItem{
	public ProbsItem_2():base(){
		ID = 2;
		ItemName = "回復藥(大)";
        Description = "回復大量生命";
    }
	public override void use(){
		base.use ();
		Debug.Log ("HP+99");
	}
}
public class ProbsItem_3 : ProbsItem
{
    public ProbsItem_3() : base()
    {
        ID = 3;
        ItemName = "木材";
        Description = "四周隨處可見的木材\n作為一般的材料來說十分常見";
    }
    public override void use()
    {
        base.use();
        Debug.Log("我是木頭");
    }
}
public class ProbsItem_4 : ProbsItem
{
    public ProbsItem_4() : base()
    {
        ID = 4;
        ItemName = "鐵";
        Description = "堅硬的鋼鐵\n數量稀少也極為昂貴\n為稀有的材料";
    }
    public override void use()
    {
        base.use();
        Debug.Log("我是鐵");
    }
}
public class ProbsItem_5 : ProbsItem
{
    public ProbsItem_5() : base()
    {
        ID = 5;
        ItemName = "石頭";
        Description = "平淡無奇的石頭\n不起眼但有時候製作需要用到它\n為一般製作材料";
    }
    public override void use()
    {
        base.use();
        Debug.Log("我是石頭");
    }
}
public class ProbsItem_6 : ProbsItem
{
    public ProbsItem_6() : base()
    {
        ID = 6;
        ItemName = "不知名的黏液";
        Description = "商人不知道從哪裡弄來的黏液奇臭無比還很有黏性\n....還是不要問太多比較好";
    }
    public override void use()
    {
        base.use();
        Debug.Log("我是黏液");
    }
}
public class ProbsItem_101 : ProbsItem
{
    public ProbsItem_101() : base()
    {
        ID = 101;
        ItemName = "尖刺陷阱";
        Description = "偽裝成不起眼的土堆，在敵人靠近時會突刺出來，十分陰險";
    }
    public override void build()
    {
        base.use();
    }
}
public class ProbsItem_102 : ProbsItem
{
    public ProbsItem_102() : base()
    {
        ID = 102;
        ItemName = "黏膠陷阱";
        Description = "不知道使用了什麼材料來製作的，黏性極佳，可以有效阻擋敵人前進";
    }
    public override void build()
    {
        base.use();
    }
}
public class ProbsItem_103 : ProbsItem
{
    public ProbsItem_103() : base()
    {
        ID = 103;
        ItemName = "trap_3";
    }
    public override void build()
    {
        base.use();
    }
}