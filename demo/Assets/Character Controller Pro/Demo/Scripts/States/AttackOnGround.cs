using Lightbug.CharacterControllerPro.Core;
using Lightbug.CharacterControllerPro.Demo;
using Lightbug.CharacterControllerPro.Implementation;
using Lightbug.Utilities;
using PlasticPipe.PlasticProtocol.Messages;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// <summary>
public class AttackOnGround : Attack
{
    //做两种方法，1attack继承normalmove，或者写成一个新的类，都可以试试。

    private string GroundStep = "attackOnGroundStep";
    



    protected override void Awake()
    {
        base.Awake();
    }
    protected override void Start()
    {
        base.Start();
    }



    public void Update()
    {
        if (CharacterActor.IsGrounded)
        {
            if (Input.GetMouseButtonDown(0) && canNextAct)//&和&&都可以用作逻辑与的运算符，表示逻辑与。
                                                         //&&还具有短路的功能，即如果第一个表达式为false，则不再计算第二个表达式
            {
                //canChangeState = false;
                //isAttack = true;
                //combo++;
                //if (combo > 4)
                //{
                //    combo = 1;
                //}
                //CharacterActor.Animator.SetInteger(Step, combo);
                canNextAct = false;
                combo++;
                if(combo>4)
                {
                    combo = 1;
                }
                CharacterActor.Animator.SetInteger(Step, combo);
            }
        }
    }
    /// <summary>
    /// 执行退出条件
    /// </summary>
    public override void CheckExitTransition()
    {
        //执行跳跃的时候立即退出
        //执行方向键的时候，需要等攻击结束之后，才能退出。即本次攻击完成了，移动按键才能生效，否则移动按键会影响攻击的转动方向
        if (!CharacterActor.IsGrounded)
        {
            CharacterStateController.EnqueueTransition<NormalMovement>();
        }
       base.CheckExitTransition();
    }
    /// <summary>
    /// 执行退出
    /// </summary>
    /// <param name="dt"></param>
    /// <param name="toState"></param>
    public override void ExitBehaviour(float dt, CharacterState toState)
    {
      base.ExitBehaviour(dt, toState);
    }

    public override void UpdateBehaviour(float dt)
    {

    }
    public override void EnterBehaviour(float dt, CharacterState fromState)
    {
        CharacterActor.Animator.applyRootMotion = true;

        CharacterActor.SetUpRootMotion(
                                true,
                                PhysicsActor.RootMotionVelocityType.SetVelocity,
                                true, PhysicsActor.RootMotionRotationType.AddRotation);
        Step = GroundStep;
        base.EnterBehaviour(dt, fromState);
    }

}
