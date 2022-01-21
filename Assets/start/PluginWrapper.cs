using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using UnityEngine.SceneManagement;

public class PluginWrapper : MonoBehaviour {

	public AndroidJavaClass unityClass;
	public AndroidJavaObject unityActivity;
	public AndroidJavaClass customClass;
	public Text myText;
	private Thread thread;
	public int step = 0;
	public int a = 0;


	// Use this for initialization
	void Start () {
			JavaPlugin.CheckService ();//開始service
	}


	void OnApplicationPause(bool paused)
	{
		if(!paused)
		{
			JavaPlugin.CheckBind();
			}
	}

	// Update is called once per frame
	void Update () {

		step = int.Parse (JavaPlugin.Show());
		myText.text =step.ToString();//顯示步數
	}



	/*private void OnGUI()
	{
		Rect rect = new Rect( 0.0f, 0.0f, 200.0f, 100.0f );
		if ( GUI.Button(rect, "本地推播") )
		{
			//#if UNITY_ANDROID && !UNITY_EDITOR

			//using ( AndroidJavaClass unity = new AndroidJavaClass("com.test.tw.test.LocalNotificationActivity") )
			//{
			//unity.CallStatic( "Add", 5, "這是標題", "這是內文", "icon", 100 );
			//}

			//#endif

			JavaPlugin.Add();

		}

		rect = new Rect( 0.0f, 100.0f, 200.0f, 100.0f );   
		if ( GUI.Button(rect, "取消推播") )   
		{     
			//#if UNITY_ANDROID && !UNITY_EDITOR     
			using ( AndroidJavaClass unity = new AndroidJavaClass("com.test.tw.test.LocalNotificationActivity") )     
			//{       
			//unity.CallStatic( "Cancel", 100 );     
			//}     
			//#endif   

			JavaPlugin.Cancle();
		}
	}*/





		
}




