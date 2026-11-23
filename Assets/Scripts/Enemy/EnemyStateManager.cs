using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class EnemyStateManager : MonoBehaviour
{
    public AudioClip heyYou;
    public AudioClip Scream;
    public AudioSource Voice;
    public AudioSource Walk;
    public float speed;
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
        speed = 1.1f;
        agent = GetComponent<NavMeshAgent>();
        currentState = idleState;
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
        float viewRadius = 30f;
        float viewAngle = 90f;

        Vector3 dirToPlayer = (Player.transform.position - transform.position).normalized;
        float distToPlayer = Vector3.Distance(transform.position, Player.transform.position);

        bool playerVisible = false;

        if (distToPlayer <= viewRadius && Vector3.Angle(transform.forward, dirToPlayer) < viewAngle / 2f)
        {
            Vector3 eyePos = transform.position + Vector3.up;
            if (!Physics.Linecast(eyePos, Player.transform.position + Vector3.up, out RaycastHit hit) || hit.collider.CompareTag("Player"))
            {
                playerVisible = true;
            }
        }

        if (playerVisible)
        {
            lookCounter += Time.deltaTime;
            if (lookCounter > 1f && currentState != chaseState)
            {
                SwitchState(chaseState);
            }
        }
        else if (lookCounter > 0f)
        {
            lookCounter = Mathf.Max(0f, lookCounter - Time.deltaTime / 2f);
        }
    }

    public void Move(Vector3 target)
    {
        if (target != null)
        {
            agent.SetDestination(target);
        }
        float nearThreshold = 1.0f;

        if (!agent.pathPending && agent.hasPath && agent.remainingDistance <= nearThreshold && currentState != chaseState)
        {
            SwitchState(idleState);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && isChasing)
        {
            mainGame.ClearGame();
        }
        if(other.CompareTag("Projectile"))
        {
            Destroy(other.gameObject);
            SwitchState(incapacitatedState);
        }
    }


}
