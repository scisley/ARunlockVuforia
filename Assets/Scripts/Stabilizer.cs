using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class Stabilizer : MonoBehaviour {

    public GameObject Manager;
    public GameObject ParentTrackable;

    private Board board;


	// Use this for initialization
	void Start () {
        board = Manager.GetComponent<Board>();
    }
	
	// Update is called once per frame
	void Update () {

        if (ParentTrackable != null) {
            
            if (board.PlaneFound) {
                // Fix each stabilized object to the board game plane, then rotate each about the boardgame normal
                // based on how rotated the parent trackable is.
                transform.position = board.baseplane.ClosestPointOnPlane(ParentTrackable.transform.position);
                transform.Translate(new Vector3(0, transform.localScale.y / 2, 0));

                transform.rotation = Quaternion.LookRotation(Vector3.ProjectOnPlane(ParentTrackable.transform.forward, board.baseplane.normal), board.baseplane.normal);
                GetComponent<Renderer>().material.color = Color.blue;
            } else {
                // If the game board isn't found, just attach to the parent tracable
                transform.position = ParentTrackable.transform.position;
                transform.Translate(new Vector3(0, transform.localScale.y / 2, 0));

                transform.rotation = ParentTrackable.transform.rotation;
                GetComponent<Renderer>().material.color = Color.white;
            }

            

        }

    }
}
