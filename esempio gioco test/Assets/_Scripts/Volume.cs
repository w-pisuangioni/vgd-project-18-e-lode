using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Experimental.UIElements;

public class Volume : MonoBehaviour {

    public AudioMixer audioMixer;
    public float volumeAttuale;

	// Use this for initialization
	void Start () {
        //audioMixer.SetFloat("volume", 1);
	}
	
	// Update is called once per frame
	void Update () {
        audioMixer.GetFloat("volume", out volumeAttuale);
        AudioListener.volume = volumeAttuale;
	}
}
