using UnityEngine;

public class MoveState : StateBase
{
    public void Enter(PlayerController playerController)
    {
        playerController.IdleImage.color = Color.lightGreen;
    }

    public void Exit(PlayerController playerController)
    {
        playerController.IdleImage.color = Color.white;
    }
}
