using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonBehaviour<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;
    public static T Intance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<T>();
                DontDestroyOnLoad(_instance.gameObject);
            }
            return _instance;
        }
    }

    protected void SingletonInit()
    {
        // 싱글톤이므로 하나만 존재해야함
        // 존재하는데, 동일한 오브젝트가 아닌 경우
        if(_instance !=null && _instance != this)
        {
            Destroy(gameObject); // 자기 자신 삭제
        }

        _instance = GetComponent<T>();
        DontDestroyOnLoad(gameObject);
    }
}
