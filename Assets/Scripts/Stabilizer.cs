using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class Stabilizer : MonoBehaviour {

    public GameObject Manager;
    public GameObject ParentTrackable;
    private Board board;
    //private ImageTargetStatus targetStatus;

	// Use this for initialization
	void Start () {
        board = Manager.GetComponent<Board>();
        //targetStatus = ParentTrackable.GetComponent<ImageTargetStatus>();
        //gameObject.GetComponent<Renderer>().enabled = true;
    }
	
	// Update is called once per frame
	void Update () {
        
        if (ParentTrackable != null) {
            /*
            Debug.Log(targetStatus.Status);
            if (targetStatus.Status == "LOST") {
                gameObject.GetComponent<Renderer>().enabled = false;
            } else {
                gameObject.GetComponent<Renderer>().enabled = true;
            }
            */

            if (board.PlaneFound) {
                // Fix each stabilized object to the board game plane, then rotate each about the boardgame normal
                // based on how rotated the parent trackable is.
                transform.position = board.baseplane.ClosestPointOnPlane(ParentTrackable.transform.position);
                transform.Translate(new Vector3(0, transform.localScale.y / 2, 0));

                transform.rotation = Quaternion.LookRotation(Vector3.ProjectOnPlane(ParentTrackable.transform.forward, board.baseplane.normal), board.baseplane.normal);
                GetComponent<Renderer>().material.color = Color.blue;
            } else {
                // If the game board isn't found, just attach to the parent trackable
                transform.position = ParentTrackable.transform.position;
                transform.Translate(new Vector3(0, transform.localScale.y / 2, 0));

                transform.rotation = ParentTrackable.transform.rotation;
                GetComponent<Renderer>().material.color = Color.white;
            }

            

        }

    }
}
