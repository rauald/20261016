using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public enum PlayerState
{
    Idle, Attack
}

public class PlayerController : MonoBehaviour
{
    [SerializeField] private InputActionReference _attackInput;
    private PlayerState _state = PlayerState.Idle;

    private void OnEnable()
    {
        _attackInput.action.Enable();
        _attackInput.action.performed += OnAttackInput;
    }

    /* 유한 상태머신
    private void Update()
    {
        switch (_state)
        {
            case PlayerState.Idle:
                IdleExcute();
                break;
            case PlayerState.Attack:
                AttackExcute();
                break;
        }
    }

    private void IdleExcute()
    {
        Debug.Log("헤에~");
    }

    private void AttackExcute()
    {
        Debug.Log("공격");
        _state = PlayerState.Idle;
    }
    */

    private void OnAttackInput(InputAction.CallbackContext context)
    {
        // 상태머신에서 Attack 상태로 변경
        _state = PlayerState.Attack;
    }
}