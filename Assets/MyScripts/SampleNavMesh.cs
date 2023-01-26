using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SampleNavMesh : MonoBehaviour
{
    public Transform target;

    public NavMeshAgent agent;
    private void Start()
    {
     //   agent.GetComponent<NavMeshAgent>();
        
    }

    private void Update()
    {
        agent.SetDestination(target.position); 
    }
}
