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
    //������getinput�¼���Ȼ����attackover�¼��������changestate�¼�
    public void GetInput()
    {
        Attack.isAttack = false;
        CharacterActor.Animator.SetBool("nextCombo", false);
        Debug.Log(Attack.combo);
        
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
    public void ResetCombo()
    {
        isAttack = true;
        Attack.combo = 1;
    }

    public override void UpdateBehaviour(float dt)
    {
      
    }
}

