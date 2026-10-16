using UnityEngine;
using UnityEngine.InputSystem.XR;

public class DeadState : StateBase
{
    private PlayerController _controller;
    public DeadState(PlayerController controller)
    {
        _controller = controller;
    }

    public override void Enter()
    {
        Debug.Log("내가 죽고싶은데");
    }

    public override void Update()
    {
        // 공격 했다고 치고
        Debug.Log("...");
    }

    public override void Exit()
    {
    }
}
