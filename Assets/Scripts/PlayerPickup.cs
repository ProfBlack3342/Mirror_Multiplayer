using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    private GameObject sphere;
    private Rigidbody sphereRB;
    public GameObject carryspot;
    private bool pickedup;

    private void Awake()
    {
        pickedup = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(other.tag == "Sphere")
            {
                    PickUp(other.gameObject);
            }
        }
    }

    private void PickUp(GameObject other)
    {
        if (!pickedup)
        {
            sphere = other.gameObject;
            pickedup = true;
            sphereRB = sphere.GetComponent<Rigidbody>();
            sphereRB.useGravity = false;
        }
        else
        {
            LetGo();
        }
    }

    private void LetGo()
    {
        pickedup = false;
        sphereRB.useGravity = true;
    }

    private void FixedUpdate()
    {
        if(pickedup)
        {
            sphere.transform.position = carryspot.transform.position;
        }
    }
}
