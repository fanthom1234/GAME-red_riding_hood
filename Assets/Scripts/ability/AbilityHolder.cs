using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//for ability lmao
public class AbilityHolder : MonoBehaviour
{
    public Ability ability;
    float cooldownTime;
    float activeTime;

    enum AbilityState
    {
        ready, active, cooldown
    }

    AbilityState state = AbilityState.ready;

    public KeyCode key;
    
    void Update()
    {
        switch (state)
        {
            case AbilityState.ready:
                if (Input.GetKeyDown(key))
                {
                    ability.Activate(gameObject); //whatttt
                    activeTime = ability.activeTime;
                    state = AbilityState.active;
                }
                break;
            case AbilityState.active:
                if (activeTime > 0)
                {
                    activeTime -= Time.deltaTime;
                } else {
                    ability.BeginCooldown(gameObject); //wha
                    state = AbilityState.cooldown;
                    cooldownTime = ability.cooldownTime;
                }
                break;
            case AbilityState.cooldown:
            if (activeTime > 0)
                {
                    activeTime -= Time.deltaTime;
                } else {
                    state = AbilityState.ready;
                }
                break;

        }
    }
}