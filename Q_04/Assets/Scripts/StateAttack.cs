using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StateAttack : PlayerState
{
    private float _delay = 2;
    private WaitForSeconds _wait;
    
    public StateAttack(PlayerController controller) : base(controller)
    {
        
    }

    public override void Init()
    {
        _wait = new WaitForSeconds(_delay);
        ThisType = StateType.Attack;
    }

    public override void Enter()
    {
        Controller.StartCoroutine(DelayRoutine(Attack));
    }

    public override void OnUpdate()
    {
        Debug.Log("Attack On Update");
    }
/*
    public override void Exit()
    {
        Debug.Log("idle로 상태전환");
        Machine.ChangeState(StateType.Idle);
    }
*/
    private void Attack()
    {
        Collider[] cols = Physics.OverlapSphere(
            Controller.transform.position,
            Controller.AttackRadius
            );

        IDamagable damagable;
        foreach (Collider col in cols)
        {
            damagable = col.GetComponent<IDamagable>();
            //damagable.TakeHit(Controller.AttackValue);
            // damagable 이 null인지 if문으로 확인할 수 있으나 damagable? (null인지 확인하는 것) 로 확인 가능
            damagable?.TakeHit(Controller.AttackValue); 
            // 변경 후 오버플로우가 발생하는 것을 확인 가능
        }
    }

    public IEnumerator DelayRoutine(Action action)
    {
        yield return _wait;

        Attack(); // 공격 
        // Exit(); // 상태 변화를 위해 Attack에서 빠져나가도록 구현 => 그러나 굳이 Exit() 존재할 필요가 없음
        Machine.ChangeState(StateType.Idle);
    }

}
