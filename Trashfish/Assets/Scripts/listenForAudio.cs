using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class listenForAudio : MonoBehaviour
{
    AudioSource audioData;
    public AudioClip audioClip;

    private void Start()
    {
        audioData = GetComponent<AudioSource>();
    }
    public void OnTriggerEnter(Collider other) 
    { 
        if (other.gameObject.CompareTag("trash"))
        {
            Debug.Log("Something hit the water");
            audioData.pitch = Random.Range(0.9f, 1.1f);
            audioData.PlayOneShot(audioClip, Random.Range(0.7f, 1f));
        }
    }
}
