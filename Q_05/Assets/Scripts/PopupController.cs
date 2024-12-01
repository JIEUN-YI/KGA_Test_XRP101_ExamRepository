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
        _wait = new WaitForSecondsRealtime(_deactiveTime); // 현실시간 반영
        //_popupButton = GetComponent<Button>();
    }

    private void OnEnable()
    {
        SubscribeEvent();
    }

    /// <summary>
    ///  팝업 버튼에 OnClick Event를 설정하는 함수
    /// </summary>
    private void SubscribeEvent()
    {
        Debug.Log("1");
        if(_popupButton == null)
        {
            Debug.Log("버튼없음");
        }
        else
        {
            Debug.Log("버튼있음");
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
        yield return _wait; // 디버그를 사용하면 이 부분에서 멈춰있음을 확인 가능
        Deactivate();
    }
}
