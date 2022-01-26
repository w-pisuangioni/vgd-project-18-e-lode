using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    //Lo script gestisce i cuori nell'HUD in base alla vita attuale del player.

    public Player player;//gestisce player
    public Text healthText;//gestisce testo "ValueHP
    public Image greenHealth;//gestisce immagine "GreenBar"    -> content
    public float currentValueHP;//gestisce valore "GreenBar"
    public float lerpSpeed; //velocità decremento/aumento barra
    public Color fullColor;//prende il colore verde
    public Color lowColor;//prende il colore rosso


    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();//assegna player
        greenHealth = GameObject.Find("GreenBar").GetComponent<Image>();//assegna barra hp corrent
        healthText = gameObject.GetComponentInChildren<Text>();
        healthText.color = Color.white;//setta il colore di base del testo a white
        fullColor = greenHealth.color;//prende colore green bar
        lowColor = GameObject.Find("RedBar").GetComponent<Image>().color;//prende colore red bar
        lerpSpeed = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        HandleBar();
    }

    public void HandleBar()//gestisce la barra HP
    {
        currentValueHP = Map(player.getcurHealth(), 0, player.getMaxHealth(), 0, 1);//gestisco valore hp
        greenHealth.fillAmount = Mathf.Lerp(greenHealth.fillAmount, currentValueHP, Time.deltaTime * lerpSpeed);
        greenHealth.color = Color.Lerp(lowColor, fullColor, greenHealth.fillAmount);//all'aumento/decremento il colore della barra si mescola (tra rosso e verde)
        healthText.text = player.getcurHealth().ToString();//stampo valore hp
    }
    public float Map(float value, float inMin, float inMax, float outMin, float outMax)
    {
        return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
        //example: 
        //  (80 - 0) * (1 - 0) / (100 - 0) + 0
        //  80 * 1 / 100 = 0,8 HP
    }
}