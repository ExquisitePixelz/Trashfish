using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHitWater : MonoBehaviour
{
    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("water"))
        {
            this.GetComponent<Rigidbody>().drag = 5f;
            this.GetComponent<Rigidbody>().mass = 0.01f;
            this.GetComponent<Rigidbody>().angularDrag = 5f;
        }
    }
}
