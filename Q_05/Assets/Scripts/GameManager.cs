using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : SingletonBehaviour<GameManager>
{
    [field: SerializeField] public float Score { get; set; }

    private void Awake()
    {
        /*
        if(gameObject != null)
        {
            Destroy(gameObject);
        }
        */
        SingletonInit();
        Score = 0.1f;
    }

    public void Pause()
    {
        Time.timeScale = 0f;
    }
    public void Run() /////
    {
        Time.timeScale = 1f;
    }

    public void LoadScene(int buildIndex)
    {
        SceneManager.LoadSceneAsync(buildIndex);
    }
}
