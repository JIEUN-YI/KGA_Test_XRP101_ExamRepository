using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private bool _hasFollowTarget;
    private Transform _followTarget;
    public Transform FollowTarget
    {
        get => _followTarget;
        set
        {
            _followTarget = value;
            if (_followTarget != null) _hasFollowTarget = true;
            else _hasFollowTarget = false;
        }
    }

    private void LateUpdate() => SetTransform();

    private void SetTransform()
    {
        if (!_hasFollowTarget) return;

        /* 따라다닐 대상의 위치를 현재 기준으로 맞추는 함수
        // 카메라가 followTarget의 위치나 회전을 이동할 필요 X-> 카메라가 followTarget을 따라가야함
        _followTarget.SetPositionAndRotation( // Position과 Rotation을 동시에 지정
            transform.position,
            transform.rotation
            );*/
        // 즉 현재 오브젝트(카메라)의 위치를 followTarget위치와 회전으로 이동 설정
        transform.SetPositionAndRotation( // Position과 Rotation을 동시에 지정
            _followTarget.position,
            _followTarget.rotation
            );
    }
}
