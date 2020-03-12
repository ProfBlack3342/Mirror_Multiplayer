using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerColor : NetworkBehaviour
{
    private Renderer playerRenderer;

    [SyncVar(hook = SetColor)]
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
        RpcSetColor(Color.red);
    }

    [ClientRpc]
    private void RpcSetColor(Color color)
    {
        SetColor(playerColor, color);
    }

    private void SetColor(Color oldcolor, Color newcolor)
    {
        playerRenderer.material.color = newcolor;
    }

    public void ChangeColor()
    {

    }
}
