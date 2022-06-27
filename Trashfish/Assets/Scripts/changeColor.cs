using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeColor : MonoBehaviour
{
    private Color goalCompleted;
    private float aFloat;
    private float rFloat;
    private float gFloat;
    private float bFloat;
    private Renderer myRenderer;

    // Start is called before the first frame update
    void Start()
    {
        myRenderer = gameObject.GetComponent<Renderer>();
    }

    // Update is called once per frame
    public void lightsOn()
    {       
        myRenderer.material.EnableKeyword("_EMISSION");
        Debug.Log("Lights are on!");
    }

    public void lightsOff()
    {
        myRenderer.material.DisableKeyword("_EMISSION");
        Debug.Log("Lights are off, awhhh!");
    }

}
