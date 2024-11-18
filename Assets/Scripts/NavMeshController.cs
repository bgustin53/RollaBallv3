using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshController : MonoBehaviour
{
    [SerializeField] private Transform[] target;
    [SerializeField] private float speed;
    private NavMeshAgent agent;
    private int targetIndex;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        speed = agent.speed;
    }

    // Update is called once per frame
    void Update()
    {
        SetDestination();
    }

    private void SetDestination()
    {
        agent.SetDestination(target[targetIndex].position);

        if (agent.remainingDistance < agent.stoppingDistance && target.Length > 1)
        {
            targetIndex = ++targetIndex % target.Length;
            Debug.Log(targetIndex);
        }


    }
}
