using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode()]
public class ProgressBar : MonoBehaviour
{
    public int maximum;
    public int current;
    public Image mask;
    public GameObject goal;
    public AudioSource source;
    public AudioClip tadah;
    public AudioClip awh;
    public GameObject lightBulb;
    private bool madeItTotwoHundred;
    private bool playedOnce = true;


    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();    
    }

    // Update is called once per frame
    void Update()
    {
        GetCurrenFill();
        boidCounter boidCounter = goal.GetComponent<boidCounter>();
        changeColor changeColor = lightBulb.GetComponent<changeColor>();

        current = boidCounter.boidCount;

        if (current > 250 && playedOnce == true)
        {
            source.PlayOneShot(tadah);
            madeItTotwoHundred = true;
            playedOnce = false;
            changeColor.lightsOn();
        }

        if (current < 250 && madeItTotwoHundred == true)
        {
            source.PlayOneShot(awh);
            madeItTotwoHundred = false;
            playedOnce = true;
            changeColor.lightsOff();
        }
    }

    private void GetCurrenFill()
    {
        float fillAmount = (float)current / (float)maximum;
        mask.fillAmount = fillAmount;
    }
}
