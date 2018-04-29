using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

    LineRenderer line;

	// Use this for initialization
	void Start () {
        line = gameObject.GetComponent<LineRenderer>();
        
	}
	
	// Update is called once per frame
	void Update () {
        StopCoroutine("FireLaser");
        StartCoroutine("FireLaser");
    }

    IEnumerator FireLaser() {
        while (true) {
            
            RaycastHit hit;

            // An empty array to hold our collisions, will dump to a static array later
            List<Vector3> segments = new List<Vector3>();

            // Add the origin point to the segments array (tip of laser)
            Ray ray = new Ray(transform.position, transform.forward);
            segments.Add(ray.origin);

            // Cast laser from base, 20 is maximum number of reflections allowed (need to avoid infinite loop)
            for (int i = 1; i < 20; i++) {
                // Check for a collision
                if (Physics.Raycast(ray, out hit, 10)) {
                    // Save hit point and cast out along reflection, this will be used in next loop
                    segments.Add(hit.point);
                    ray = new Ray(hit.point, Vector3.Reflect(ray.direction, hit.normal));
                } else {
                    // if no collision, extend laser default distance and break
                    segments.Add(ray.GetPoint(10));
                    break;
                }
            }

            line.positionCount = segments.Count;
            line.SetPositions(segments.ToArray());

            yield return null;
        }
    }

}
