using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private float _range;
    [SerializeField] private LayerMask _targetLayer;

    public void Fire(Transform origin)
    {
        Ray ray = new(origin.position, origin.forward);// Vector3.forward);
        RaycastHit hit;

        // 디버그로 확인 시 조건이 안걸리는 것을 확인 가능
        // Ray를 Debug로 표현하여 기즈모를 확인하면 Ray의 위치가 제대로
        // 플레이어의 방향으로 발사되지 않고 세계기준(Vector3.forward)로 발사되는 것을 확인함
        // 플레이어의 방향으로 발사되도록 origin.forward로 사용됨
        if (Physics.Raycast(ray, out hit, _range, _targetLayer))
        {
            Debug.Log($"{hit.transform.name} Hit!!");
        }
    }

}
