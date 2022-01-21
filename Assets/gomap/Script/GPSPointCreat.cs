using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GoShared
{
    public class GPSPointCreat : MonoBehaviour
    {
        public float Latitude;   //經度
        public float Longitude;    //緯度
        public string Supply_station_name;  //補給站名稱
        public string description;            //補給站描述

        public static ItemHaveTest itemhave = ItemHaveTest.getInstance();

        public GameObject button;


        public Text number;
        public int whatCanYouGet;
        public float whatdistance;
        private  float distance;

        private float my_x;
        private float my_y;
        private float main_x;
        private float main_y;


        public GameObject main;
        public GameObject plan_control;
        public GPSTargerChange targetcontrol;

        private void Start()
        {
            targetcontrol=plan_control.transform.transform.GetComponent<GPSTargerChange>();
            whatdistance = 400;
        }
        
        public void SetGpsPosition()
        {
            number.text = "測試用補給點個數:4個";
            gameObject.SetActive(true);
            Coordinates coordinates = new Coordinates(Latitude, Longitude, 7.0f);
            gameObject.transform.localPosition = coordinates.convertCoordinateToVector();
            Debug.Log(Supply_station_name+"......."+ description);
        }
        public void whenButton()
        {
            targetcontrol.name.text = Supply_station_name;
            targetcontrol.description.text = description;
            targetcontrol.get.sprite= (Sprite)Resources.Load<Sprite>("bag/" + itemhave.IDToName(whatCanYouGet));
            targetcontrol.Get_ID = whatCanYouGet;
            plan_control.gameObject.SetActive(true);
            my_x = this.transform.position.x;
            my_y = this.transform.position.y;
            main_x = main.transform.position.x;
            main_y = main.transform.position.y;
            distance = (my_x * my_x) + (my_y * my_y) - (main_x * main_x) - (main_y * main_y);
            if (distance <= whatdistance && distance >= -1 * whatdistance)
            {
                targetcontrol.Distance_enought();
            }
            else
            {
                targetcontrol.Distance_not_enought();
            }
        }
       
    }
}
