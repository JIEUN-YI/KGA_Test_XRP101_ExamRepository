using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotater : MonoBehaviour
{
    private void Update()
    {
        // transform.Rotate(Vector3.up * GameManager.Intance.Score);
        transform.Rotate(Vector3.up * GameManager.Intance.Score * Time.timeScale);
        //     public void Pause() �� �Ǵ� ��쿡 ���ư��� ���ϰ� ���߸� ������ �߻��ϰ� �ǹǷ� Time.timeScale
    }
}
