using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class DebugRay : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Debug.DrawRay(transform.position, transform.up * 3, Color.red);
    }


}
