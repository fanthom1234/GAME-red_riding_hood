using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DashAbility : Ability
{
    public float oldRunVelocity;
    public float runVelocity;
    public override void Activate(GameObject parent)
    {
        PlayerMovement playerMovement = parent.GetComponent<PlayerMovement>();
        oldRunVelocity = playerMovement.runSpeed;
        playerMovement.runSpeed = runVelocity;
        Debug.Log("ayo speedyboii");
    }
    public override void BeginCooldown(GameObject parent)
    {
        PlayerMovement playerMovement = parent.GetComponent<PlayerMovement>();
        playerMovement.runSpeed = oldRunVelocity;
        Debug.Log("ayo NOOspeedyboii");
    }

}
