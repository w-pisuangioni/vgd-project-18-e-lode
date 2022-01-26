using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
    public int score;
    static private int scoreEnd;
    static private float time = 0.0f;
    Text testoScore;

	// Use this for initialization
	void Start () {
        score = 0;
        testoScore = GetComponent<Text>(); //prendo il component Text
        InvokeRepeating("DecreaseScorePerSecond", 1f, 1f);  //decrementa lo score di 1 ogni secondo
    }

    // Update is called once per frame
    void Update () {
        testoScore.text = "Score: " + score;
        scoreEnd = score;
        time += Time.deltaTime;
	}
    public void IncreaseScore(int amount)//Aumenta punteggio di un tot
    {
        score += amount;
    }
    public void DecreaseScore(int amount)//Diminuisce punteggio di un tot
    {
        if (score > 0)
        {
            score -= amount;
            if (score < 0)
                score = 0;
        }
    }
    public void DecreaseScorePerSecond()//Diminuisce punteggio di 1 (-1 score per secondo)
    {
        DecreaseScore(1);
    }
    static public int GetEndScore()
    {
        return scoreEnd;
    }
    static public float GetTime()
    {
        return time;
    }
}
