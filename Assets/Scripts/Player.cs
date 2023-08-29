using UnityEngine;
using UnityEngine.AI;

public class Player : Character
{
    [SerializeField] private LayerMask m_Enemy;
    [SerializeField] private LayerMask m_Ground;

    [SerializeField] Transform moveDebuger;
    //[field:SerializeField] Camera Camera { get; set; }
    // Component
    /*
    private Animator m_Anim;
    private NavMeshAgent m_Agent;
    */
    // Enemy
    [SerializeField] private Transform m_Target;
    Enemy m_enemyTarget;

    protected override void Start()
    {
        base.Start();

    }

    // Update is called once per frame
    private void Update()
    {
        // Left Click on Enemy
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, Mathf.Infinity, m_Enemy))
            {
                m_Target = hit.collider.transform;
                m_Anim.Play(Walk);

                m_Agent.SetDestination(m_Target.position);
                m_Agent.stoppingDistance = 2f;
            }
        }

        // Right Click on Ground
        if(Input.GetMouseButtonDown(1))
        {
            Debug.Log("right clicked");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            //Debug.DrawLine(ray.origin,ray.direction * 100f,Color.white,5f);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, m_Ground))
            {
                moveDebuger.position = hit.point;
                Debug.Log("clicked on ground");
                Debug.Log(hit.transform.name);

                m_Target = null;
                m_Anim.Play(Walk);

                m_Agent.SetDestination(hit.point);
                m_Agent.stoppingDistance = 0f;
            }
        }

        if(m_Agent.remainingDistance < 0.1f)
        {
            m_Anim.Play(Idle);
        }else if(m_Target != null)
        {
            DoAttack(m_enemyTarget);
        }
    }
}