using System.Collections;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    [SerializeField] private Transform _muzzlePoint; // 총알 발사 위치
    [SerializeField] private CustomObjectPool _bulletPool; // 발사할 총알
    [SerializeField] private float _fireCooltime; // 총알 발사 간격 시간

    private Coroutine _coroutine;
    private WaitForSeconds _wait;

    private void Awake()
    {
        Init();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Fire(other.transform);
        }
    }

    /// <summary>
    /// 플레이어가 범위를 벗어나는 경우 발사 코루틴 멈춤
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StopCoroutine(_coroutine);
        }
    }

    private void Init()
    {
        _coroutine = null;
        _wait = new WaitForSeconds(_fireCooltime); // 총알의 발사 간격 설정
        _bulletPool.CreatePool();
    }

    private IEnumerator FireRoutine(Transform target)
    {
        while (true)
        {
            yield return _wait;

            // 플레이어를 바라보기
            transform.rotation = Quaternion.LookRotation(new Vector3(
                target.position.x,
                0,
                target.position.z)
            );

            PooledBehaviour bullet = _bulletPool.TakeFromPool();
            bullet.transform.position = _muzzlePoint.position;
            bullet.OnTaken(target);

        }
    }

    private void Fire(Transform target)
    {
        _coroutine = StartCoroutine(FireRoutine(target));
    }
}
