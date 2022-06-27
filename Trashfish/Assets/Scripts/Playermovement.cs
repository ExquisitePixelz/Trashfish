using UnityEngine;
using System.Collections;



public class Playermovement : MonoBehaviour
{
    // This is a reference to the Rigidbody component called "rb"
    public Rigidbody rb;
    public GameObject player;

    
    public float SidewaysForce = 0f;
    public float Yforce = 0f;
   

    // We marked this as "fixed"Update because we 
    // are using it to mess with the physics
    void Update()
    {
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        SidewaysForce = SidewaysForce + Input.GetAxis("Mouse X");
        Yforce = Yforce + Input.GetAxis("Mouse Y");
  
    
        if (Input.GetAxis("Mouse X") > 0)
        {
            rb.AddForce(SidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetAxis("Mouse X") < 0)
        {
            rb.AddForce(-SidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetAxis("Mouse Y") > 0)
        {
            rb.AddForce(Yforce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetAxis("Mouse Y") < 0)
        {
            rb.AddForce(-Yforce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
    }
}
