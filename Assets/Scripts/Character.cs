using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Character : MonoBehaviour
{
    protected static readonly int Idle = Animator.StringToHash("Idle");
    protected static readonly int Walk = Animator.StringToHash("Walk");
    protected static readonly int Attack = Animator.StringToHash("Attack");
    protected static readonly int Die = Animator.StringToHash("Die");

    protected Animator m_Anim;
    protected NavMeshAgent m_Agent;

    [SerializeField]protected int maxHp = 100;
    [SerializeField]protected int atk = 10;
    [SerializeField]protected int attackRange = 2;
    [SerializeField]protected float speed = 3f;

    int currentHp;
    int CurrentHp
    {
        get => currentHp;
        set
        {
            currentHp = value;
            if(CurrentHp <= 0)
            {
                OnDie();
            }
        }
    }

    IdleState idleState;

    IState state;
    public IState State
    {
        get => state;
        set
        {
            State.ExitState();
            state = value;
            State.StartState();
        }
    }

    protected virtual void Start()
    {
        m_Anim = GetComponent<Animator>();
        m_Agent = GetComponent<NavMeshAgent>();

        idleState = new IdleState(this);

        State = idleState;

        CurrentHp = maxHp;
    }

    protected void DoAttack(Character target) {
        StartCoroutine(AttackRoutine(target));
    }

    protected IEnumerator AttackRoutine(Character target)
    {
        m_Anim.Play(Attack);
        yield return new WaitForSeconds(1);
        target.currentHp -= atk;
    }

    protected void OnDie() { 
        // game end
    }

    public void SetAnim(int anim)
    {

    }
}
