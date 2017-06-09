﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combo : MonoBehaviour
{
    private InputManager inputManager;
    private PlayerAnim anim;
    private Player player;
    
    private void Awake()
    {
        inputManager = GetComponent<InputManager>();
        anim = GetComponent<PlayerAnim>();
        player = GetComponent<Player>();
    }
    void Update ()
    {
        Attack();
        Block();
    }
    
    private void Attack()
    {
        if (player.isHyped && inputManager.AttackButtonDown(player.ID))
            anim.AttackIsHyped(true);
        if (inputManager.AttackButtonDown(player.ID) )
            anim.IsAttacking();
    }

    private void Block()
    {
        if (player.IsGrounded)
        {
            if (inputManager.DefendButton(player.ID))
                anim.IsBlocking(true);
            else if (!inputManager.DefendButton(player.ID))
                anim.IsBlocking(false);
        }
    }
}
