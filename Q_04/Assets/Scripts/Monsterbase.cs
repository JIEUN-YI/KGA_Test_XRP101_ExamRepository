using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Monsterbase : MonoBehaviour
{
    [field: SerializeField] public int MaxHp { get; protected set; }
    [field: SerializeField] public int CurrentHp { get; protected set; }
    public bool IsDead { get => CurrentHp <= 0; }


    public virtual void Init()
    {
        CurrentHp = MaxHp;
    }

     public void Die() => Destroy(gameObject);

}
