using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour {

    //private Vector3 masterUp;
    private MyManager manager;

	// Use this for initialization
	void Start () {
        //if (masterUp == null) {
        //    masterUp = transform.up;
        //}
        Debug.Log("Script was started");
        manager = GameObject.Find("ManagerGameObject").GetComponent<MyManager>();
	}
	
	// Update is called once per frame
	void Update () {
        manager.masterUp = transform.up;
        manager.active = true;
    }

    void OnDisable() {
        //Debug.Log("Script was disabled");
        manager.active = false;
    }
}
