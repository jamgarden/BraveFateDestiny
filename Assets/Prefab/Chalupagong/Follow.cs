using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Follow : MonoBehaviour
{
    // Start is called before the first frame update
    private NavMeshAgent agent = null;
    public GameObject Player;

    private void Start() {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        FollowTarget();
    }

    private void FollowTarget()
    {
        agent.SetDestination(Player.transform.position);
    }


}
