using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUIManager : MonoBehaviour
{
    [SerializeField] private Button btnStartRun = null;
    [SerializeField] private Button btnShowControls = null;
    [SerializeField] private Button btnEndGame = null;

    private void Start()
    {
        btnStartRun.onClick.AddListener(StartRun);
        btnShowControls.onClick.AddListener(ShowControls);
        btnEndGame.onClick.AddListener(EndGame);
    }

    //--------------------------BUTTON METHODS-----------------------

    private void StartRun()
    {
        SceneManager.LoadScene("Start Run");
    }

    private void ShowControls()
    {
        SceneManager.LoadScene("MenuControls");
    }

    private void EndGame()
    {
        Application.Quit();
    }
}
