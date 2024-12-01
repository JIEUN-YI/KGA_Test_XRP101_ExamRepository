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

        /* ����ٴ� ����� ��ġ�� ���� �������� ���ߴ� �Լ�
        // ī�޶� followTarget�� ��ġ�� ȸ���� �̵��� �ʿ� X-> ī�޶� followTarget�� ���󰡾���
        _followTarget.SetPositionAndRotation( // Position�� Rotation�� ���ÿ� ����
            transform.position,
            transform.rotation
            );*/
        // �� ���� ������Ʈ(ī�޶�)�� ��ġ�� followTarget��ġ�� ȸ������ �̵� ����
        transform.SetPositionAndRotation( // Position�� Rotation�� ���ÿ� ����
            _followTarget.position,
            _followTarget.rotation
            );
    }
}
