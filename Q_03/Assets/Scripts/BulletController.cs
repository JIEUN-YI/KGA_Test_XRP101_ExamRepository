using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : PooledBehaviour
{
    [SerializeField] private float _force; // 가해지는 힘
    [SerializeField] private float _deactivateTime; //비활성화시간
    [SerializeField] public int _damageValue; // 데미지

    private Rigidbody _rigidbody;
    private WaitForSeconds _wait;

    [SerializeField] PlayerController _playerController;
    
    private void Awake()
    {
        Init();
    }

    private void OnEnable()
    {
        StartCoroutine(DeactivateRoutine());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            /*
            other
                .GetComponent<PlayerController>()
                .TakeHit(_damageValue);
            */
            _playerController.TakeHit(_damageValue);
            // 충돌한 경우 총알 반환
            ReturnPool();
        }
    }
    private IEnumerator SelectRountine()
    {
        yield return new WaitForSeconds(1f);
    }
    private void Init()
    {
        _wait = new WaitForSeconds(_deactivateTime);
        _rigidbody = GetComponent<Rigidbody>();
    }
    
    private void Fire()
    {
        _rigidbody.AddForce(transform.forward * _force, ForceMode.Impulse);
    }

    private IEnumerator DeactivateRoutine()
    {
        yield return _wait;
        ReturnPool();
    }

    public override void ReturnPool()
    {
        Pool.Push(this);
        gameObject.SetActive(false);
    }

    public override void OnTaken<T>(T t)
    {
        if (!(t is Transform)) return;
        
        transform.LookAt((t as Transform));
        Fire();
    }
}
