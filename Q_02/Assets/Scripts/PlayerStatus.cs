using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public float MoveSpeed;
    //public float MoveSpeed { get; set; }
    /*{
        get => MoveSpeed;
        private set => MoveSpeed = value;
    }
    */
    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        MoveSpeed = 5f;
    }
}
