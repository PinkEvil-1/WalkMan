using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JavaPlugin : MonoBehaviour {
	private static  AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
	private static  AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("currentActivity");
	public static void CheckBind()
	{
		jo.Call ("bindStepService");
		//jo.Call("bindStepService");
	}

	public static void CheckService(){
		jo.Call("startStepService");//呼叫開始service
	}
	public static string Show(){
		return jo.Call<string> ("show");//呼叫顯示步數
	}
	public static void reset(){
		jo.Call("resetStep");//呼叫重新開始步數計算
	}

	public static void Add(){
		jo.CallStatic( "Add", 5, "這是標題", "這是內文", "icon", 100 );//呼叫本地通知
	}

	public static void Cancle(){
		jo.CallStatic( "Cancel", 100 );
	}
		
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
