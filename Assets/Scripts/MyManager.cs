using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyManager : MonoBehaviour {
    // DEPRECATED - I don't think I need this anymore, 4/29/17 sci
    public Vector3 masterUp { get; set; }
    public bool active { get; set; }
    //private Board board;

	// Use this for initialization
	void awake () {
        //board = GameObject.Find("VuMarkBoard").GetComponent<Board>();
        active = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
