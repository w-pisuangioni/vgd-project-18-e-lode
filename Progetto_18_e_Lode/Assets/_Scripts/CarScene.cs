using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CarScene : MonoBehaviour {
    private float speed = 70;
    public AudioSource drivingSound;
    public AudioSource crashSound;
    public GameObject black;
	// Use this for initialization
	void Start () {
        drivingSound.Play();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.position += transform.forward * speed * Time.deltaTime;
        StartCoroutine(LoadScene());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Stop")
        {
            speed = 0;
            drivingSound.Stop();
            crashSound.Play();
            crashSound.loop = false;
            Instantiate(black);
        } 
    }
    IEnumerator LoadScene() { 
            yield return new WaitForSeconds(22);
            SceneManager.LoadScene("Main");
    }
}
