using UnityEngine;

public class Detection : MonoBehaviour
{
    public Transform player;
    public float detectionRange = 10.0f;
    public float chaseRange = 20.0f;
    private UnityEngine.AI.NavMeshAgent agent;
    private bool isChasing = false;

    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer < detectionRange)
        {
            isChasing = true;
            agent.destination = player.position;
        }
        else if (isChasing && distanceToPlayer > chaseRange)
        {
            isChasing = false;
            GetComponent<Patrol>().GotoNextPoint();
        }
    }
}