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

    /* ����
     * private float moveSpeed; // ��밡��
     * 
     * private void SetMoveSpeed() // ��� �Ұ���? Why?
     * {
     *      get => MoveSpeed; // ������ �ƴ� �Լ��̹Ƿ� ���ȣ���� ����ؼ� �߻��Ͽ� overflow�� �߻��ϴ� ��
     *      private set => MoveSpeed = value;
     * }
     * public float moveSpeed {get; set;} // *******������Ƽ�� �Լ��� ȣ���� ���� ��***********
     * -> ����ϴ� ����� Ǯ� �����ϸ� 
     * public float moveSpeed()
     * {
     *      retrun value;
     * } 
     * �� ���� �����̱� ������ ��������� ��� ȣ��Ǵ� ��
     * 
     * +  {get; set;} ���� �δ� ��� C#������ �ڵ������� private ������ �����Ͽ� ���峪
     *    ����� ���� ��Ȳ������ get�� set��
     *    get => MoveSpeed;
          private set => MoveSpeed = value;
    *     ó�� �ڱ� �ڽ��� �� �ٽ� �����ϰ� �ִ� ������ ����Լ��� �۵���
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
