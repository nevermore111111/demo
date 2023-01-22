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
    public static string  Step;
    //�����ַ�����1attack�̳�normalmove������д��һ���µ��࣬���������ԡ�
    protected static bool  IsJustEnter;
    [Tooltip("�������ù������")]
    public float interval=2;
    [Tooltip("����������")]
    protected static int combo  = 0 ;
    public float timer;
    public static bool isAttack = false;//��ʼ��ȡ����
    //��ʼ������һ�׶�
    protected  static bool canChangeState = false;
    protected static bool canNextAct;

    protected override void Awake()
    {
        base.Awake();
    }
    protected override void Start()
    {
        base.Start();
    }



    
    /// <summary>
    /// ִ���˳�����
    /// </summary>
    public override void CheckExitTransition()
    {
        //ִ����Ծ��ʱ�������˳�
        //ִ�з������ʱ����Ҫ�ȹ�������֮�󣬲����˳��������ι�������ˣ��ƶ�����������Ч�������ƶ�������Ӱ�칥����ת������
        if(!isAttack)
        {
            if (CharacterActions.movement.value != Vector2.zero & canChangeState)
            {
                CharacterStateController.EnqueueTransition<NormalMovement>();
            }
        }
        if(CharacterActions.jump.Started)
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
        IsJustEnter =true;
        canChangeState = false;
    }

    public override void UpdateBehaviour(float dt)
    {
       
    }
    public override void EnterBehaviour(float dt, CharacterState fromState)
    {
        IsJustEnter = true;
    }
}
