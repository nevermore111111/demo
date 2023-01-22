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
    //首先是getinput事件，然后是attackover事件，最后是changestate事件
    public void GetInput()
    {
        
    }
    public void AttackOver()
    {
        isAttack =false;
        CharacterActor.Animator.SetBool("isAttack",false);
    }
    public void  CanChangeState()
    {
        if (!isAttack)
        {
            Attack.canChangeState = true;
        }
    }

    public void Idle()
    {

        if (IsJustEnter)
        {
            Attack.combo = 1;
            IsJustEnter = false;
            CharacterActor.Animator.SetInteger(Step, Attack.combo);
            isAttack = true;
            Debug.Log("shoucijinru ");
        }
        else
        {
            Attack.combo = 0;
            CharacterActor.Animator.SetInteger(Step, Attack.combo);
            Debug.Log("erci");
            isAttack = false;
            canChangeState = false;
        }
    }
    public void ResetCombo()
    {
        isAttack = true;
        canNextAct = true;
        canChangeState=false;
        CharacterActor.Animator.SetBool("isAttack", true);
    }

    public override void UpdateBehaviour(float dt)
    {
      
    }
}

