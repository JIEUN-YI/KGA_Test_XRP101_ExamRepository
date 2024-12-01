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

    /* 보강
     * private float moveSpeed; // 사용가능
     * 
     * private void SetMoveSpeed() // 사용 불가능? Why?
     * {
     *      get => MoveSpeed; // 변수가 아닌 함수이므로 재귀호출이 계속해서 발생하여 overflow가 발생하는 것
     *      private set => MoveSpeed = value;
     * }
     * public float moveSpeed {get; set;} // *******프로퍼티는 함수를 호출해 내는 것***********
     * -> 사용하는 방법을 풀어서 생각하면 
     * public float moveSpeed()
     * {
     *      retrun value;
     * } 
     * 와 같은 형태이기 때문에 재귀적으로 계속 호출되는 것
     * 
     * +  {get; set;} 으로 두는 경우 C#에서는 자동적으로 private 변수를 선언하여 만드나
     *    현재와 같은 상황에서는 get과 set을
     *    get => MoveSpeed;
          private set => MoveSpeed = value;
    *     처럼 자기 자신을 또 다시 설정하고 있는 것으로 재귀함수로 작동함
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
