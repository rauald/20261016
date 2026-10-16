using System;
using UnityEngine;
using UnityEngine.InputSystem;

public enum PlayerState
{
    Idle, Attack
}

public class PlayerController : MonoBehaviour, IStateEvent, IDamageable
{
    [SerializeField] private InputActionReference _attackInput;
    [SerializeField] private InputActionReference _deadInput;
    private StateBase _idle;
    private StateBase _attack;
    private StateBase _dead;

    public Action<StateBase> OnStateChange { get; set; }

    public InputActionReference AttackInputRef => _attackInput;
    public StateBase Idle => _idle;
    public StateBase Attack => _attack;
    public StateBase Dead => _dead;

    private void Awake()
    {
        _idle = new IdleState(this);
        _attack = new AttackState(this);
        _dead = new DeadState(this);
    }

    private void OnEnable()
    {
        _attackInput.action.Enable();
        _deadInput.action.Enable();
        _deadInput.action.performed += OnDamageInput;
    }

    private void Start()
    {
        OnStateChange?.Invoke(_idle);
    }

    public void SetState(StateBase state)
    {
        OnStateChange?.Invoke(state);
    }

    private void OnDamageInput(InputAction.CallbackContext context)
    {
        TakeDamage(1);
    }

    public void TakeDamage(int damage)
    {
        // 원래라면 체력 깎기. 하지만 귀찮은 관계로 바로 죽는다.
        
        // if(체력이 0 이하라면)
        OnStateChange?.Invoke(_dead);
    }

    /* 유한 상태머신
     
    private PlayerState _state = PlayerState.Idle;
      
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

    private void OnAttackInput(InputAction.CallbackContext context)
    {
        // 상태머신에서 Attack 상태로 변경
        _state = PlayerState.Attack;
    }
    */
}