using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
    void StartState();
    void UpdateState();
    void ExitState();
}

public class IdleState : IState
{
    Character StateActor { get; set; }
    public IdleState(Character character)
    {
        StateActor = character;
    }


    public void StartState() {
        StateActor.SetAnim(Animator.StringToHash("Idle"));
    }

    public void UpdateState() { }
    public void ExitState(){}
}

public class MoveState : IState
{
    Character StateActor { get; set; }
    public MoveState(Character character)
    {
        StateActor = character;
    }


    public void StartState()
    {
        StateActor.SetAnim(Animator.StringToHash("Move"));
    }

    public void UpdateState() { }
    public void ExitState() { }
}
