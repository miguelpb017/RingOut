﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HypeAttackTrigger : TriggerManager
{

    protected override void ActivateTriggers(Collider hitbox)
    {
        if(hitbox.name == opponentsHitbox)
        {
            if (!player.Opponent.IsDefending)
            {
                if (player.IsHyped)
                    player.Opponent.IsHypeHit = true;
            }
        }

    }
}
