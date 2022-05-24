using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuUIManager : MonoBehaviour
{
    [SerializeField] private Button btnStartRun = null;
    [SerializeField] private Button btnEndGame = null;

    private void Start()
    {
        btnStartRun.onClick.AddListener(StartRun);
        btnEndGame.onClick.AddListener(EndGame);
    }

    private void StartRun()
    {

    }

    private void EndGame()
    {

    }
}
