using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeightWayPoint : MonoBehaviour {
    private float distance;
    private float heightD = 6.0f;
    private RaycastHit hit = new RaycastHit();
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        DistanceHeight();
        HeightFix();
	}

    private void DistanceHeight()
    {

        if (Physics.Raycast(this.transform.position, -Vector3.up, out hit))
        {
            distance = hit.distance;
        }
    }

    private void HeightFix()
    {
        if (distance != heightD)
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - distance + heightD, this.transform.position.z);
        }   
    }
}
