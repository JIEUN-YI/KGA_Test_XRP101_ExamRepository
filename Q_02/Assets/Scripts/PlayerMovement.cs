using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerStatus _status;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        _status = GetComponent<PlayerStatus>();
    }

    private void Update()
    {
        MovePosition();
    }

    private void MovePosition()
    {
        Vector3 direction = Vector3.zero;
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.z = Input.GetAxisRaw("Vertical");

        if (direction == Vector3.zero) return;
        // 벡터의 크기가 커서 대각선이동 시 속도가 빨라지는 현상 수정을 위한 정규화 과정 진행
        if(direction.magnitude > 0)
        {
            direction.Normalize();
        } 
      
        transform.Translate(_status.MoveSpeed * Time.deltaTime * direction);
    }
}
