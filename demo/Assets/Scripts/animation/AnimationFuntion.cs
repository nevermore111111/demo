using Lightbug.CharacterControllerPro.Core;
using Lightbug.CharacterControllerPro.Implementation;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mail;
using UnityEngine;

/// <summary>
/// 
/// <summary>

public class AnimationFuntion : Attack
{
    public void GetInput()
    {
        Attack.isAttack = false;
        CharacterActor.Animator.SetBool("nextCombo", false);
    }
    public void AttackOver()
    {
        CharacterActor.Animator.SetBool("nextCombo", true);
        
    }
    public void  CanChangeState()
    {
        Attack.canChangeState = true;
    }

    public void Idle()
    {

    }

    public override void UpdateBehaviour(float dt)
    {
      
    }
}

