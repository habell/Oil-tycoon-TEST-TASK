using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public GameObject Door;
    public bool btnStatus;
    private float Timer = 5;
    private float oldXpos;

    private void Start()
    {
        oldXpos = transform.position.x;
    }
    private void OnTriggerEnter(Collider other)
    {
        btnStatus = true;
        Door.GetComponent<Door>().OpenDoor();
    }

    private void FixedUpdate()
    {
        if(btnStatus)
        {
            if (Timer <= 0)
            {
                transform.position = new Vector3(oldXpos, transform.position.y, transform.position.z);
                Timer = 5;
                btnStatus = false;
            }
            else
            {
                Timer -= Time.deltaTime;
                transform.position = new Vector3(transform.position.x + Time.deltaTime/10, transform.position.y, transform.position.z);
            }

        }
    }
}
