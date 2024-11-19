using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �̺�Ʈ �Լ��� ȣ�� ������ �ð� ���� �� ��ġ�� �����ϴ� ������ �ҽ��ڵ� ����
public class CubeManager : MonoBehaviour
{
    // ������ ����� cube ������Ʈ ������
    [SerializeField] private GameObject _cubePrefab;

    // ������ ���� ���� ����
    private CubeController _cubeController;
    private Vector3 _cubeSetPoint;

    private void Awake()
    {
        CreateCube();
        //SetCubePosition(3, 0, 3);
    }

    private void Start()
    {
        //CreateCube();
        SetCubePosition(3, 0, 3);

    }

    private void SetCubePosition(float x, float y, float z)
    {
        _cubeSetPoint = new Vector3(x, y, z);
        _cubeController.SetPosition(_cubeSetPoint);
        /*
        _cubeSetPoint.x = x;
        _cubeSetPoint.y = y;
        _cubeSetPoint.z = z;
        _cubeController.SetPosition();
        */
    }

    private void CreateCube()
    {
        GameObject cube = Instantiate(_cubePrefab);
        _cubeController = cube.GetComponent<CubeController>();
        _cubeSetPoint = _cubeController.SetPoint;
    }
}
