using UnityEngine;

public interface StateBase
{
    public void Enter(PlayerController playerController);

    public void Exit(PlayerController playerController);
}
