using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class getName : MonoBehaviour
{
    public GameObject gm;
    public TextMeshPro ingameFishName;

    public string fishName;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameController");
    }

    // Update is called once per frame
    void Update()
    {  
        fishName = gm.GetComponent<GameManager1>().fishNameRaw;
        ingameFishName.text = fishName;
    }
}
