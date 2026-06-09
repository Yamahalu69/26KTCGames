using UnityEngine;

public class birddrone : MonoBehaviour
{
    public enum State
    {
        Patrol,   // í èÌèÛë‘
        Chase,    // ÉvÉåÉCÉÑÅ[í«ê’
        Stomped,  // ì•Ç‹ÇÍÇΩ
        Sent      // ì]ëó
    }

    [Header("State")]
    public State currentState = State.Patrol;

    [Header("Patrol")]
    [SerializeField] private float amplitude = 2.0f;
    [SerializeField] private float floatSpeed = 1.0f;

    [Header("Chase")]
    [SerializeField] private float detectionRange = 2f;
    [SerializeField] private float chaseSpeed = 4f;

    [Header("Sent")]
    [SerializeField] private float repawnDelay = 3f;

    private Vector3 startPos;
    private Transform player;

    void Start()
    {
        startPos = transform.position;

        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");

        if (playerObj != null)
        {
            player = playerObj.transform;
        }
    }

    void Update()
    {
        switch (currentState)
        {
            case State.Patrol:
                PatrolUpdate();
                break;

            case State.Chase:
                ChaseUpdate();
                break;

            case State.Stomped:
                StompedUpdate();
                break;

            case State.Sent:
                SentUpdate();
                break;
        }
    }

    private void PatrolUpdate()
    {
        float yOffset = Mathf.Sin(Time.time * floatSpeed) * amplitude;

        transform.position = new Vector3(
            startPos.x,
            startPos.y + yOffset,
            startPos.z
        );

        Collider2D[] hits = Physics2D.OverlapCircleAll(
            transform.position,
            detectionRange
        );

        foreach (Collider2D hit in hits)
        {
            if (hit.CompareTag("Player"))
            {
                player = hit.transform;
                ChangeState(State.Chase);
                break;
            }
        }
    }

    private void ChaseUpdate()
    {
        if (player == null)
            return;

        transform.position = Vector2.MoveTowards(
            transform.position,
            player.position,
            chaseSpeed * Time.deltaTime
        );
    }

    private void StompedUpdate()
    {
        // ì•Ç‹ÇÍÇΩéûÇÃèàóù
    }

    private void SentUpdate()
    {
        // ì]ëóèàóù
    }

    public void ChangeState(State newState)
    {
        currentState = newState;

        switch (newState)
        {
            case State.Patrol:
                startPos = transform.position;
                break;

            case State.Chase:
                break;

            case State.Stomped:
                break;

            case State.Sent:
                break;
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}


