using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotater : MonoBehaviour
{
    private void Update()
    {
        // transform.Rotate(Vector3.up * GameManager.Intance.Score);
        transform.Rotate(Vector3.up * GameManager.Intance.Score * Time.timeScale);
        //     public void Pause() 가 되는 경우에 돌아가지 못하고 멈추며 에러가 발생하게 되므로 Time.timeScale
    }
}
