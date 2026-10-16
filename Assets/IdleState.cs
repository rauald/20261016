using UnityEngine;
using UnityEngine.InputSystem;

public sealed class IdleState : StateBase
{
    private PlayerController _controller;
    public IdleState(PlayerController controller)
    {
        _controller = controller;
    }

    public override void Enter()
    {
        _controller.AttackInputRef.action.performed += TransitionAttack;
        Debug.Log("<color=blue>Idle 상태 진입</color>");
    }

    public override void Update()
    {
        Debug.Log("<color=blue>Idle 상태</color>");
    }

    public override void Exit() 
    { 
        Debug.Log("<color=blue>Idle 상태 빠져나감</color>");
        _controller.AttackInputRef.action.performed -= TransitionAttack;
    }

    private void TransitionAttack(InputAction.CallbackContext context)
    {
        _controller.SetState(_controller.Attack);
    }
}