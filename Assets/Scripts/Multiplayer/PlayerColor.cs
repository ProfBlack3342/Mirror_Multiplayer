using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerColor : NetworkBehaviour
{
    private Renderer playerRenderer;
    private Material playerMaterial;
    private Color playerColor;

    private void Awake()
    {
        playerRenderer = GetComponent<Renderer>();
        playerMaterial = GetComponent<Material>();
    }

    public override void OnStartClient()
    {
        base.OnStartClient();
    }
}
