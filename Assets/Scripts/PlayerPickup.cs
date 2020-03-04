using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    public GameObject sphere;
    private bool pickedup;

    private void Awake()
    {
        pickedup = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Sphere")
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                if(!pickedup)
                {
                    sphere = other.gameObject;
                    pickedup = true;
                }
                else
                {
                    pickedup = false;
                }
            }
        }
    }

    private void FixedUpdate()
    {
        if(pickedup)
        {
            sphere.transform.position = gameObject.transform.position;
        }
    }
}
