using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class EnemyStateManager : MonoBehaviour
{
    public Main mainGame;
    public bool isChasing = false;
    public float lookCounter;
    public GameObject Player;
    public int targetIndex;
    public GameObject Enemy;
    public NavMeshAgent agent;
    public EnemyStateBase currentState;
    public IdleState idleState = new IdleState();
    public ChaseState chaseState = new ChaseState();
    public PatrolState patrolState = new PatrolState();
    public IncapacitatedState incapacitatedState = new IncapacitatedState();
    public GameObject[] targets;

    public Animator animator;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        currentState = patrolState;
        currentState.EnterState(this);
    }
    void Update()
    {
        currentState?.UpdateState(this);
    }
    public void SwitchState(EnemyStateBase newState)
    {
        currentState?.ExitState(this);
        currentState = newState;
        currentState?.EnterState(this);
    }
    public void Looking()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        RaycastHit hit;
        float radius = 0.76f;
        float maxDistance = 20f;  

        if (Physics.SphereCast(transform.position, radius, transform.forward, out hit, maxDistance))
        {
            if(lookCounter > .5f)
            {
                SwitchState(chaseState);
                return;
            }
            if(hit.collider.CompareTag("Player"))
            {
                lookCounter+= Time.deltaTime;
            }

            if(lookCounter > 0 && lookCounter <= 1)
            {
                lookCounter -= Time.deltaTime/2;
            }

            
        }
    }
    public void move(Vector3 target)
    {
        if (target != null)
        {
            agent.SetDestination(target);
        }
        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
           SwitchState(idleState);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")&& isChasing)
        {
            mainGame.ClearGame();
        }
        if(other.CompareTag("Projectile"))
        {
            SwitchState(incapacitatedState);
        }
    }


}
