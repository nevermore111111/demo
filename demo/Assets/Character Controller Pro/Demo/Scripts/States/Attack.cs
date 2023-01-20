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
public class Attack : CharacterState
{
    //�����ַ�����1attack�̳�normalmove������д��һ���µ��࣬���������ԡ�
    public string AttackName;
    [Tooltip("�����ϵļ�¼���������Ĳ�������")]
    public string OnGroundStep = "attackOnGroundStep";
    [Tooltip("�������ù������")]
    public float interval=2;
    [Tooltip("����������")]
    protected static int combo  = 1 ;
    public float timer;
    public static bool isAttack = false;//��ʼ��ȡ����
    public static string isRealAttack ="nextCombo";//��ʼ������һ�׶�
    protected  static bool canChangeState = false;

    protected override void Awake()
    {
        base.Awake();
    }
    protected override void Start()
    {
        base.Start();
    }



    public  void Update()
    {
        if (CharacterActor.IsGrounded)
        {
            if (Input.GetMouseButtonDown(0) && !isAttack)//&��&&�����������߼�������������ʾ�߼��롣
                                                         //&&�����ж�·�Ĺ��ܣ��������һ�����ʽΪfalse�����ټ���ڶ������ʽ
            {
                canChangeState = false;
                isAttack = true;
                combo++;
                if (combo > 4)
                {
                    combo = 1;
                }
                timer = interval;
                CharacterActor.Animator.SetInteger(OnGroundStep, combo);

            }
            if (timer != 0)
            {
                timer -= Time.deltaTime;
                if (timer <= 0)
                {
                    combo = 0;
                    isAttack = false;
                    timer = 0;
                    CharacterActor.Animator.SetInteger(OnGroundStep, combo);
                }
            }
        }
    }
    /// <summary>
    /// ִ���˳�����
    /// </summary>
    public override void CheckExitTransition()
    {
        //ִ����Ծ��ʱ�������˳�
        //ִ�з������ʱ����Ҫ�ȹ�������֮�󣬲����˳��������ι�������ˣ��ƶ�����������Ч�������ƶ�������Ӱ�칥����ת������

        if(CharacterActions.jump.Started)
        {
            CharacterStateController.EnqueueTransition<NormalMovement>();
        }
        if (CharacterActions.movement.value != Vector2.zero & canChangeState)
        {
            CharacterStateController.EnqueueTransition<NormalMovement>();
        }
    }
    /// <summary>
    /// ִ���˳�
    /// </summary>
    /// <param name="dt"></param>
    /// <param name="toState"></param>
    public override void ExitBehaviour(float dt, CharacterState toState)
    {
        isAttack = false;
        combo = 0;
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

    }
}
