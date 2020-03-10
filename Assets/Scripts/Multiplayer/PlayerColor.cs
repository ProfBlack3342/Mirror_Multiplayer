using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerColor : NetworkBehaviour
{
    private Renderer playerRenderer;
    private Color playerColor;

    private void Awake()
    {
        playerRenderer = GetComponent<Renderer>();
    }

    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();
        CmdSetColor();
    }

    [Command]
    private void CmdSetColor()
    {
        RpcSetColor();
    }

    [ClientRpc]
    private void RpcSetColor()
    {
        SetColor(Color.red);
    }

    private void SetColor(Color color)
    {
        playerRenderer.material.color = color;
    }
}
