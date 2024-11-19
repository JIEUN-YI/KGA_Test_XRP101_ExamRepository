using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 이벤트 함수의 호출 순서에 맡게 생성 후 위치를 지정하는 것으로 소스코드 수정
public class CubeManager : MonoBehaviour
{
    // 생성에 사용할 cube 오브젝트 프리팹
    [SerializeField] private GameObject _cubePrefab;

    // 생성을 위한 정보 연동
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
