using UnityEngine;
using UnityEngine.AI;
public class navmesh : MonoBehaviour
{
    private NavMeshAgent agent;
    public Transform player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       agent=GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (agent !=null && player != null)
        {
            // Set the destination of the NavMeshAgent to the player's position
            agent.SetDestination(Vector3.Lerp(agent.destination, player.position, Time.deltaTime*2f));
            agent.stoppingDistance = 5f; // Set a stopping distance to avoid colliding with the player
        }
    }
}
