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
    /// TakeHit()�۵� �� Die()�Լ� => Monsterbase.cs���� ����
    /// </summary>
    /// <param name="damage"></param>
    public void TakeHit(int damage)
    {
        Debug.Log("NormalMoster.cs�� TakeHit() ����");
        CurrentHp -= damage;
        Debug.Log($"{CurrentHp}����");

        if (IsDead)
        {
            Die();
           // stateAttack.Exit();
        }
    }
}
