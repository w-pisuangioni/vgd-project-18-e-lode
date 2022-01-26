using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntensityLight : MonoBehaviour {
    Light lightObject;

	// Use this for initialization
	void Start () {
        lightObject = gameObject.GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
        if(lightObject.intensity < 2)
            lightObject.intensity += 0.35f * Time.deltaTime;
	}
}
