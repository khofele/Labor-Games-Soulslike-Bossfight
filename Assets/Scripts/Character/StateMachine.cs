using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//basic state machine class which the states use to transition
public class StateMachine : MonoBehaviour
{
    BaseState currentState; //state the character is currently in

    void Start()
    {
        currentState = GetInitialState();
        if (currentState != null)
            currentState.Enter();
    }

    void Update()
    {
        if (currentState != null)
            currentState.UpdateLogic();
    }

    void LateUpdate()
    {
        if (currentState != null)
            currentState.UpdatePhysics();
    }

    public void ChangeState(BaseState newState)
    {
        currentState.Exit();

        currentState = newState;
        currentState.Enter();
    }

    //initialise currentState
    protected virtual BaseState GetInitialState()
    {
        return null;
    }

    //shows in game the current state (if it's not null)
    //TODO: AUSKOMMENTIEREN
    private void OnGUI()
    {
        string content = currentState != null ? currentState.name : "(no current state)";
        GUILayout.Label($"<color='black'><size=40>{content}</size></color>");
    }
}
