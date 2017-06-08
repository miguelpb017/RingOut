﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour {

   private Animator anim;
    private int attackCounter;
    [SerializeField]
    private int maxHitCount;
   
    private void Start()
    {
        anim = GetComponent<Animator>();
        
    }
    public void FreeFallAnimation(bool truefalse)
    {
        anim.SetBool("isGrounded", truefalse);
    }
    public void WalkAnimation(bool truefalse)
    {
        anim.SetBool("isWalking", truefalse);
    }
    
    /// <summary>
    /// Takes an animation trigger or Set or Reset
    /// </summary>
    /// <param name="trigger"></param>
    public void JumpAnimation(AnimationTrigger trigger)
    {
        
        if (trigger == AnimationTrigger.set)
            anim.SetTrigger("Jump");
        else if (trigger == AnimationTrigger.reset)
            anim.ResetTrigger("Jump");
    }
    public void PlayBlock(bool truefalse)
    {
        anim.SetBool("isBlocking", truefalse);
    }
    public void PlayAttack(bool truefalse)
    {
        anim.SetBool("isAttacking", truefalse);
        
    }
    public void StopAttack()
    {
        anim.SetBool("isAttacking", false);
    }
    public void PlayHypeAttack(bool truefalse)
    {
        anim.SetBool("isAttacking", truefalse);
    }
    public void HitAnimation(bool truefalse)
    {
        anim.SetBool("isHit", truefalse);
    }
}
public enum AnimationTrigger
{
    set,
    reset
}

