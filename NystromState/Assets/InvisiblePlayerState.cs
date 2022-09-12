using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisiblePlayerState : IPlayerState
{
    Player mPlayer;
    Rigidbody rbPlayer;
    float stealthTime = 2.0f;
    MeshRenderer playMesh;
    
    public void Enter(Player player)
    {
        rbPlayer = player.GetComponent<Rigidbody>();
        playMesh = player.GetComponent<MeshRenderer>();
        playMesh.enabled = false;
        player.mCurrentState = this;
    }

    // Update is called once per frame
    public void Execute(Player player)
    {
        if (Time.time - stealthTime < 2.0f)
        {
            playMesh.enabled = true;
            StandingPlayerState standingState = new StandingPlayerState();
            standingState.Enter(player);
        }
    }
}
