using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    public Transform itemPosition;

    private bool isCarrying = false;
    [SerializeField]
    private GameObject collectable;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            Collect();
        }
    }

    private void Collect()
    {
        if(collectable != null)
        {
            collectable.transform.parent = itemPosition;
            collectable.transform.localPosition = Vector3.zero;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Collectable")
        {
            collectable = other.gameObject;
        }
    }
}
