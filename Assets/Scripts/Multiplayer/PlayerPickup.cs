using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

namespace Prototipo.Multiplayer
{
    public class PlayerPickup : NetworkBehaviour
    {
        private bool isCarrying = false;

        [SerializeField] private GameObject pickup;

        public Transform itemPosition;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (!isCarrying) //isCarrying == false
                {
                    CmdCollect();
                }
                else
                {
                    CmdDrop();
                }
            }
        }

        [Command]
        void CmdCollect()
        {
            if (pickup != null)
            {
                pickup.transform.parent = itemPosition;
                pickup.transform.localPosition = Vector3.zero;

                isCarrying = true;
            }
        }

        [Command]
        void CmdDrop()
        {
            if (pickup != null)
            {
                pickup.transform.parent = null;
                pickup.transform.position = transform.position;

                isCarrying = false;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Collectable")
            {
                if (!isCarrying)
                    pickup = other.gameObject;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.tag == "Collectable")
            {
                if (pickup != null && pickup == other.gameObject)
                {
                    if (!isCarrying)
                    {
                        pickup = null;
                    }
                }
            }
        }
    }
}
