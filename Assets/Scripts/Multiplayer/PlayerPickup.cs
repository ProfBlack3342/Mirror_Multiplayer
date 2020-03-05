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
        [SerializeField] private GameObject sphere;
        private SphereState sphereS;

        public Transform itemPosition;

        private void Awake()
        {
            sphere.SetActive(false);
        }

        private void Update()
        {
            if(!isLocalPlayer)
            {
                return;
            }
            else
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
        }

        [Command]
        void CmdCollect()
        {
            if (!sphereS.getIsCarried())
            {
                if (pickup != null)
                {
                    sphere.SetActive(true);
                    isCarrying = true;
                    sphereS.SetIsCarried(true);
                    pickup.SetActive(false);
                }
            }
        }

        [Command]
        void CmdDrop()
        {
            if (sphereS.getIsCarried())
            {
                if (pickup != null)
                {
                    sphere.SetActive(false);
                    pickup.SetActive(true);

                    pickup.transform.position = gameObject.transform.position;

                    isCarrying = false;
                    sphereS.SetIsCarried(false);
                    pickup = null;
                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Collectable")
            {
                if (!isCarrying)
                {
                    pickup = other.gameObject;
                    sphereS = pickup.GetComponent<SphereState>();
                }
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
                        sphereS = null;
                    }
                }
            }
        }
    }
}

