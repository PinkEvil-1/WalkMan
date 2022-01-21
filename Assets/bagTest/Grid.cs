using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour {


    public int id;
    public GridItem Item {
        get {
            return transform.GetComponentInChildren<GridItem>();
        }
    }
    
}
