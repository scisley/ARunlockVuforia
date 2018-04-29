using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class Stabilizer : MonoBehaviour {

    private MyManager manager;
    private VuforiaManager vuManager;

	// Use this for initialization
	void Start () {
        manager = GameObject.Find("ManagerGameObject").GetComponent<MyManager>();
        //vuManager = TrackerManager.Instance.GetStateManager().get
    }
	
	// Update is called once per frame
	void Update () {



		if (manager.active == true) {
            transform.up = manager.masterUp;
        } else {
            transform.up = transform.parent.transform.up;
        }
	}
}
