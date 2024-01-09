using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public interface IState
{
    public void Enter()
    {
        // code that runs when we first enter state
    }
     public void Update() 
    {
        // per-frame logic, include to transition to a new state
    }

    public void Exit()
    {
        // code that runs when exit the state
    }
}
