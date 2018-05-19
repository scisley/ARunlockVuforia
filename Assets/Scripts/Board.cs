using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class Board : MonoBehaviour {

    //private Vector3 masterUp;
    //private MyManager manager;
    public bool Activate = true;

    // True when 3 trackables have been found during the update
    private bool planeFound = false;
    public Plane baseplane = new Plane();

    public bool PlaneFound {
        get {
            if (Activate == false) return false;
            return planeFound;
        }

        set {
            planeFound = value;
        }
    }

    // Use this for initialization
    void Start () {
        //if (masterUp == null) {
        //    masterUp = transform.up;
        //}
        Debug.Log("Script was started");
        //manager = GameObject.Find("ManagerGameObject").GetComponent<MyManager>();
	}
	
    void OnDisable() {
        //Debug.Log("Script was disabled");
        //manager.active = false;
    }

    // Update is called once per frame
    void Update() {
        // Get the Vuforia StateManager
        StateManager sm = TrackerManager.Instance.GetStateManager();
        planeFound = false;
        // Query the StateManager to retrieve the list of
        // currently 'active' trackables 
        //(i.e. the ones currently being tracked by Vuforia)
        IEnumerable<TrackableBehaviour> activeTrackables = sm.GetActiveTrackableBehaviours();

        // Iterate through the list of active trackables
        int count = 0;
        Vector3[] planePoints = new Vector3[4];
        foreach (TrackableBehaviour tb in activeTrackables) {
            Debug.Log("Trackable: " + tb.TrackableName + ", up: " + tb.transform.up + ", pos: " + tb.transform.position);
            planePoints[count] = tb.transform.position;
            count++;
        }

        // This is dumb but my C# isn't skilled enough yet.
        if (count >= 3) {
            Debug.Log("We have 3 trackables! pp0: " + planePoints[0] + " pp1: " + planePoints[1] + " pp2: " + planePoints[2]);
            planeFound = true;

            baseplane.Set3Points(planePoints[0], planePoints[1], planePoints[2]);
            Vector3 baseplane_origin = (planePoints[0] + planePoints[1] + planePoints[2]) / 3;

            Debug.Log("Base origin: " + baseplane_origin + " normal: " + baseplane.normal);
            Debug.DrawRay(baseplane_origin, baseplane.normal * 3, Color.blue);

            // Make sure orientation is positive towards camera
            if (baseplane.GetSide(transform.position) == false) {
                // The plane is defined with positive away from camera, flip it
                baseplane.Flip();
            }
        }

    }
}
