using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class MenuScores : MonoBehaviour {

    String noScore = "Non e' presente alcun salvataggio." +"\n" + "E' tempo di farti una partita!";
    String giocatoreScore = "";
    String punteggioScore = "";
    public Text noScores;
    public Text giocatori;
    public Text punteggi;

    
    void Start()
    {
        SaveAndLoad.LoadScoresEnd();
        int count = 1;
        foreach (int temp in SaveAndLoad.scores)
        {
            giocatori.text += "Partita " + count + "\n";
            punteggi.text += temp.ToString() + "\n";
            count++;
        }
        noScores.text = noScore;
    }

	void Update () {
        UpdateScores();
	}
    
    public void UpdateScores()
    {
        if (!File.Exists("saveScores.bin"))
        {
            noScores.enabled = true;
            punteggi.enabled = false;
            giocatori.enabled = false;
        }
        else
        {
            noScores.enabled = false;
            punteggi.enabled = true;
            giocatori.enabled = true;
        }
    }
        
}
