using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirino : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Input.mousePosition;
        Cursor.visible = false;
    }
}
