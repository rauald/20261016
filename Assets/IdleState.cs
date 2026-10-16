using UnityEngine;

public sealed class IdleState : StateBase
{
    public IdleState(PlayerController controller) : base(controller) { }

    public override void Enter()
    {
        Debug.Log("<color=blue>Idle 상태 진입</color>");
    }

    public override void Update()
    {
        Debug.Log("<color=blue>Idle 상태</color>");
    }

    public override void Exit() 
    { 
        Debug.Log("<color=blue>Idle 상태 빠져나감</color>");
    }
}