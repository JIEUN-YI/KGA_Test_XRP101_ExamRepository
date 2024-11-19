using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalMonster : Monsterbase, IDamagable
{
    // [SerializeField] public StateAttack stateAttack;

    private void Awake()
    {
        base.Init();
    }

    /// <summary>
    /// TakeHit()작동 시 Die()함수 => Monsterbase.cs에서 실행
    /// </summary>
    /// <param name="damage"></param>
    public void TakeHit(int damage)
    {
        Debug.Log("NormalMoster.cs의 TakeHit() 실행");
        CurrentHp -= damage;
        Debug.Log($"{CurrentHp}실행");

        if (IsDead)
        {
            Die();
           // stateAttack.Exit();
        }
    }
}
