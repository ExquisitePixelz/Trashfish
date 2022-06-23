using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class boidCounter : MonoBehaviour
{

    public int boidCount;
    public Text scoreText;
    bool ligthsOn = false;
    private Color goalCompleted;
    private float aFloat;
    private float rFloat;
    private float gFloat;
    private float bFloat;

    private Renderer myRenderer;

    private void Start()
    {
        rFloat = 0f;
        gFloat = 1f;
        bFloat = 0f;
        aFloat = 0.2f;
        boidCount = 0;

        myRenderer = gameObject.GetComponent<Renderer>();
    }

    // Start is called before the first frame update
    private void Update()
    {
        scoreText.text = boidCount.ToString("0");

        goalCompleted = new Color(rFloat, gFloat, bFloat, aFloat);
        myRenderer.material.color = goalCompleted;

        if (boidCount >= 250)
        {
            ligthsOn = true;
        }
        else
        {
            ligthsOn = false;
        }


        if (ligthsOn == true)
        {
            aFloat += 0.01f;
        }
        else
        {
            aFloat = 0.2f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        boidCount++;
        Debug.Log("Entered goal.");
    }

    private void OnTriggerExit(Collider other)
    {
        boidCount--;
        Debug.Log("Exited goal.");
    }
}
