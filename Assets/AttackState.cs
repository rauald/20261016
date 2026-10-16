using UnityEngine;

public sealed class AttackState : StateBase
{
    public AttackState(PlayerController controller) : base(controller) { }

    public override void Enter()
    {
        Debug.Log("<color=green>Attack 상태 진입</color>");
    }

    public override void Update()
    {
        Debug.Log("<color=green>Attack 상태</color>");
    }

    public override void Exit()
    {
        Debug.Log("<color=green>Attack 상태 빠져나감</color>");
    }
}
