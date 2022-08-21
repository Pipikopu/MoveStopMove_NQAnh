using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BotStateMachine : Character, IHit, ITarget
{
    public BotStateMachine bot;

    // StateMachine
    BotBaseState currentState;
    public BotStartState StartState = new BotStartState();
    public BotIdleState IdleState = new BotIdleState();
    public BotMoveState MoveState = new BotMoveState();
    public BotAttackState AttackState = new BotAttackState();
    public BotDeathState DeathState = new BotDeathState();

    // Bot Variables
    [Header("Bot Setting")]
    public Transform botTransform;
    public Transform botModel;
    public GameObject underUI;

    // NavMeshAgent
    [Header("Nav Mesh Agent")]
    public NavMeshAgent agent;
    [Range(0, 100)] public float speedAgent;
    [Range(1, 500)] public float walkRadius;
    public float rotateSpeed;

    internal Vector3 directionVec;
    internal float angleToRotate;

    // Animator
    [Header("Animator")]
    public Animator botAnimator;

    // Character Boundary
    [Header("Boundary")]
    public CharacterBoundary charBound;

    // Weapon
    [Header("Weapon")]
    public Weapon weapon;

    // Time
    [Header("Time Setting")]
    public float timeIdle;
    public float timeAttack;
    public float timeDeath;

    private void OnEnable()
    {
        Init();
    }

    public void Init()
    {
        currentState = MoveState;
        currentState.EnterState(bot);
    }

    private void Update()
    {
        currentState.UpdateState(bot);
    }

    public void SwitchState(BotBaseState state)
    {
        currentState.ExitState(bot);
        currentState = state;
        currentState.EnterState(bot);
    }

    public override void Death()
    {
        SwitchState(DeathState);
    }

    public bool CanBeTargeted()
    {
        if (currentState != DeathState)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void DisableLockTarget()
    {
        underUI.gameObject.SetActive(false);
    }

    public void EnableLockTarget()
    {
        underUI.gameObject.SetActive(true);
    }
}
