using System.Transactions;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private InputActionReference _moveInput;
    [field : SerializeField] public Image IdleImage { get; private set; }
    [field : SerializeField] public Image MoveImage { get; private set; }

    private IdleState _idleState;
    private MoveState _moveState;
    private StateBase _currentState;

    private void Awake()
    {
        _idleState = new IdleState();
        _moveState = new MoveState();
    }

    private void Start()
    {
        SetState(_idleState);
    }

    private void OnEnable()
    {
        _moveInput.action.Enable();

        _moveInput.action.performed += OnMove;
        _moveInput.action.canceled += OnMoveStop;
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        ChangeState(_moveState);
    }
    private void OnMoveStop(InputAction.CallbackContext context)
    {
        ChangeState(_idleState);
    }

    private void SetState(StateBase state)
    {
        if(_currentState != null)
        {
            _currentState.Exit(this);
        }

        _currentState = state;
        _currentState.Enter(this);
    }

    private void ChangeState(StateBase state)
    {
        if (_currentState != state)
        {
            _currentState.Exit(this);
            _currentState = state;
            _currentState.Enter(this);
        }
    }
}