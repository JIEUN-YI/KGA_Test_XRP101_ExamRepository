using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupController : MonoBehaviour
{
    [SerializeField] private float _deactiveTime;
    //private WaitForSeconds _wait;
    private WaitForSecondsRealtime _wait;
   [SerializeField] Button _popupButton;

    [SerializeField] private GameObject _popup;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        //_wait = new WaitForSeconds(_deactiveTime);
        _wait = new WaitForSecondsRealtime(_deactiveTime); // ���ǽð� �ݿ�
        //_popupButton = GetComponent<Button>();
    }

    private void OnEnable()
    {
        SubscribeEvent();
    }

    /// <summary>
    ///  �˾� ��ư�� OnClick Event�� �����ϴ� �Լ�
    /// </summary>
    private void SubscribeEvent()
    {
        Debug.Log("1");
        if(_popupButton == null)
        {
            Debug.Log("��ư����");
        }
        else
        {
            Debug.Log("��ư����");
        }
        _popupButton.onClick.AddListener(Activate);
        Debug.Log("2");
    }

    private void Activate()
    {
        _popup.gameObject.SetActive(true);
        GameManager.Intance.Pause();
        StartCoroutine(DeactivateRoutine());
    }

    private void Deactivate()
    {
        _popup.gameObject.SetActive(false);
        GameManager.Intance.Run();
    }

    private IEnumerator DeactivateRoutine()
    {
        yield return _wait; // ����׸� ����ϸ� �� �κп��� ���������� Ȯ�� ����
        Deactivate();
    }
}
