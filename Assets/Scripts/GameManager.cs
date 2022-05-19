using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if (boss.Health <= 2500)
        {
            phaseTwo = true;
            boss.ChangeBehavior();
        }
    }
}
