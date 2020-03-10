using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerDetection : NetworkBehaviour
{
    private NetworkIdentity id;

    private void OnTriggerEnter(Collider other)
    {
        if(!id)
        {
            Debug.Log("Colidiu com " + other.gameObject.name);
        }
        else
        {
            Debug.Log("Colidiu, mas não com outro player");
        }
    }

}
