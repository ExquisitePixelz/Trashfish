/**
 * Ardity (Serial Communication for Arduino + Unity)
 * Author: Daniel Wilches <dwilches@gmail.com>
 *
 * This work is released under the Creative Commons Attributions license.
 * https://creativecommons.org/licenses/by/2.0/
 */

using UnityEngine;
using System.Collections;

/**
 * Sample for reading using polling by yourself. In case you are fond of that.
 */
public class SampleUserPolling_JustRead : MonoBehaviour
{
    public SerialController serialController;
    public float speed = 10f;
    private float moveUp;
    private float moveDown;
    private float moveLeft;
    private float moveRight;
    public GameObject goal;

    // Initialization
    void Start()
    {
        serialController = GameObject.Find("SerialController").GetComponent<SerialController>();
	}

    // Executed each frame
    void Update()
    {
        boidCounter boidCounter = goal.GetComponent<boidCounter>();

        moveUp = 1 * Time.deltaTime * speed;
        moveDown = -1 * Time.deltaTime * speed;
        moveLeft = 1 * Time.deltaTime * speed;
        moveRight = -1 * Time.deltaTime * speed;

        string message = serialController.ReadSerialMessage();

        if (message == null)
            return;

        if (message == "w") {
            transform.Translate(0, moveUp, 0);
        }

        if (message == "a")
        {
            transform.Translate(moveLeft, 0, 0);
        }

        if (message == "s")
        {
            transform.Translate(0, moveDown, 0);
        }

        if (message == "d")
        {
            transform.Translate(moveRight, 0, 0);
        }

        if (boidCounter.boidCount >= 250)
        {
            sendL();
        }

        if (boidCounter.boidCount < 250)
        {
            sendN();
        }


        // Check if the message is plain data or a connect/disconnect event.
        if (ReferenceEquals(message, SerialController.SERIAL_DEVICE_CONNECTED))
            Debug.Log("Connection established");
        else if (ReferenceEquals(message, SerialController.SERIAL_DEVICE_DISCONNECTED))
            Debug.Log("Connection attempt failed or disconnection detected");
        //else
           // Debug.Log("Message arrived: " + message);
    }

    public void sendL()
    {
        Debug.Log("Sending L");
        serialController.SendSerialMessage("L");
    }

    public void sendN()
    {
        Debug.Log("Sending N");
        serialController.SendSerialMessage("N");
    }
}
