using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LowHp : MonoBehaviour {

    private GameObject player;
    private Image blood;

    private float tempCall = 0f;
    /*private float sendRate = 0.1f;
    private float tempTime;*/
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        blood = this.gameObject.GetComponentInChildren<Image>();
	}
	
	// Update is called once per frame
	void Update () {
        Destroyer();
       /* tempTime += Time.deltaTime;
        if (tempTime > sendRate)
        {
            tempTime -= sendRate;
            Saturation();
        }*/
	}

    void Destroyer()
    {
        if (player.GetComponent<Player>().getcurHealth() > 20)
            Destroy(this.gameObject, 0.1f);
    }

    void Saturation()
    {
        if (tempCall <= 0.63f)
        {
            blood.color = Color.HSVToRGB(blood.color.r, blood.color.g - 0.07f, blood.color.b - 0.07f);
            tempCall += 0.07f;
        }
        else
            if (tempCall > 0.63f)
                blood.color = Color.HSVToRGB(blood.color.r, blood.color.g + 0.07f, blood.color.b + 0.07f);
            if(tempCall >= 1.26f)
                tempCall = 0f;

    }
}
