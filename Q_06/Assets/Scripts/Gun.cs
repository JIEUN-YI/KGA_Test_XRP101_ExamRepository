using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private float _range;
    [SerializeField] private LayerMask _targetLayer;

    public void Fire(Transform origin)
    {
        Ray ray = new(origin.position, origin.forward);// Vector3.forward);
        RaycastHit hit;

        // ����׷� Ȯ�� �� ������ �Ȱɸ��� ���� Ȯ�� ����
        // Ray�� Debug�� ǥ���Ͽ� ����� Ȯ���ϸ� Ray�� ��ġ�� �����
        // �÷��̾��� �������� �߻���� �ʰ� �������(Vector3.forward)�� �߻�Ǵ� ���� Ȯ����
        // �÷��̾��� �������� �߻�ǵ��� origin.forward�� ����
        if (Physics.Raycast(ray, out hit, _range, _targetLayer))
        {
            Debug.Log($"{hit.transform.name} Hit!!");
        }
    }

}
