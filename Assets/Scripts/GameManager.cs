using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private BossController boss = null;
    [SerializeField] private CharController player = null;
    [SerializeField] private bool phaseTwo = false;

    private void Start()
    {
        //set mouse cursor invisible and lock in game screen
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        //invoke boss phase two
        if(boss.Health <= (boss.Health * 0.5f))
        {
            phaseTwo = true;
            boss.ChangeBehavior();
        }
    }
}
