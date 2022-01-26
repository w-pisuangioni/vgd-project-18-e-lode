using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour{
    //Lo script gestisce i cuori nell'HUD in base alla vita attuale del player.

    public Sprite[] HeartSprites; //array che gestisce i frammenti dell'immagine Hearts
    public Image HeartsUI; //gestisce l'immagine intera dei cuori
    private Player player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
        HeartsUI.sprite = HeartSprites[player.curHealth];
	}
}
