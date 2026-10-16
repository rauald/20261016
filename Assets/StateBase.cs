using UnityEngine;

public abstract class StateBase
{
    protected PlayerController _controller;

    public StateBase(PlayerController controller)
    {
        _controller = controller;
    }

    public abstract void Enter();
    public abstract void Update();

    public abstract void Exit();
}