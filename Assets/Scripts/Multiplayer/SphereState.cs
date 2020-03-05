using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

namespace Prototipo.Multiplayer
{
    public class SphereState : NetworkBehaviour
    {
        private bool IsCarried = false;

        public bool getIsCarried() { return IsCarried; }
        public void SetIsCarried(bool IsCarried) { this.IsCarried = IsCarried; }
    }
}
