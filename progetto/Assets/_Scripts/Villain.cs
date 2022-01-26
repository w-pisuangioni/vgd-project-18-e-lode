using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Villain : MonoBehaviour {
	public float speed = 0;
	/*public float health = 3;
	public RawImage hearth;*/
	private Rigidbody rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		//updateLife ();
	}

	/*void OnCollisionEnter (Collision other){
		if (other.gameObject.CompareTag ("Player")) {
			--health;
			updateLife ();
			if(health == 0)	
				other.gameObject.SetActive (false);
		}
	}*/
	// Update is called once per frame
	void FixedUpdate () {
		float movementHorizontal = Random.Range(-100.0f,100.0f);
		float movementVertical = Random.Range(-1.0f,1.0f);

		Vector3 movement = new Vector3(movementHorizontal, 0.0f, movementVertical);

		rb.AddForce(movement * speed);
	}

	/*void updateLife(){
		hearth.uvRect = new Rect (0, 0, health / 5, 1);
		hearth.SetNativeSize();
	}*/

}