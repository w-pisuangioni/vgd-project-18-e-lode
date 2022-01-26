using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndingLevel : MonoBehaviour {
    public Text score;
    public Text time;
    //public Text EndLevel;
    public float timer;
    private string minutes;
    private string seconds;
    /*public AudioSource boomSound;
    public Animator myAnimator;
    /*private float timeOfAnimation;
    private AnimatorClipInfo[] myAnimatorClip;
    private AnimatorStateInfo animationState;*/
    // Use this for initialization
    void Start () {


    }

    // Update is called once per frame
    void Update () {
        /*animationState = myAnimator.GetCurrentAnimatorStateInfo(0);
        myAnimatorClip = myAnimator.GetCurrentAnimatorClipInfo(0);
        timeOfAnimation = myAnimatorClip[0].clip.length * animationState.normalizedTime;*/
        ScoreText();
        TimeText();
        //PlayBoomSound();
	}
  

    /*public void PlayBoomSound()
    {
        //if (EndLevel.IsActive() == true)
        if (timeOfAnimation == 1.0f)
            boomSound.Play();
    }*/

    public void ScoreText()
    {
        score.text = Score.GetEndScore().ToString();
    }

    public void TimeText()
    {
        timer = Score.GetTime();
        minutes = Mathf.Floor(timer / 60).ToString("00");
        seconds = (timer % 60).ToString("00");
        time.text = (minutes + ":" + seconds);
    }
}
