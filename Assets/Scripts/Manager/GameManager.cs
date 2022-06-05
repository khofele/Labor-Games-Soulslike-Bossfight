using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private BossController boss = null;
    [SerializeField] private CharController player = null;
    [SerializeField] private bool phaseTwo = false;
    private bool gameRunning = false;

    public bool GameRunning { get => gameRunning; set => gameRunning = value; }

    private void Start()
    {
        //set mouse cursor invisible and lock in game screen
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        //invoke boss phase two
        if (boss.Health <= 2500)    // TODO
        {
            phaseTwo = true;
            boss.ChangeBehavior();
        }

        //if player presses Esc - go back to main menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("Menu");
        }
    }
}
