using System;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using YG;

public class GoHome : MonoBehaviour
{
    private int home = 1;
    [SerializeField] private int nextLevelNum;
    [SerializeField] private UnityEvent levelFinish;
    private float[] values = new float[3];
    private Image[] image;

    private int _showFullscreenAd;
    public bool _canGoHome = true;

    private void Awake()
    {
        _showFullscreenAd = PlayerPrefs.GetInt("_showFullscreenAd", 0);
        if (_showFullscreenAd == 0)
        {
            YandexGame.FullscreenShow();
            PlayerPrefs.SetInt("_showFullscreenAd",1);
        }

    }

    public void FullScreenAdActivator()
    {
        PlayerPrefs.SetInt("_showFullscreenAd",0);
    }


    private void Update()
    {
        if (_canGoHome == true)
        {
            if (Input.GetKeyDown(KeyCode.B))
            {
                SceneManager.LoadScene("Lobby");
            }
        }
    }

    private void Start()
    {
        nextLevelNum += 1;
        StartCoroutine(CursorDisableActivator());
    }
    private void OnTriggerEnter(Collider other)
    {

        PlayerPrefs.SetInt("Level" + nextLevelNum, 1);
        levelFinish?.Invoke();

    }
    public void NextLevel()
    {
        ResetHeart();
        ResetPosition();
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(++currentScene);
    }
    public void GoBase()
    {
        ResetHeart();

        SceneManager.LoadScene(home);
    }

    public void ResetHeart()
    {



        PlayerPrefs.SetInt("thisHeart", StaticValue.Heart);
    }
    public void ResetPosition()
    {
        values[0] = 1.453161f;
        values[1] = -4.68f;
        values[2] = -26.86665f;
        PlayerPrefs.SetFloat("value" + 0, values[0]);
        PlayerPrefs.SetFloat("value" + 1, values[1]);
        PlayerPrefs.SetFloat("value" + 2, values[2]);
    }


    private IEnumerator CursorDisableActivator()
    {
        yield return new WaitForSeconds(0.4f);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

    }

}







