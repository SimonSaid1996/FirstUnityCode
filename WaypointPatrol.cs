using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaypointPatrol : MonoBehaviour
{   
    public NavMeshAgent navMeshAgent;
    public Transform[] waypoints;           //initialize the way how the ghost patrols
    int m_CurrentWaypointIndex;

    void Start()
    {
        navMeshAgent.SetDestination(waypoints[0].position);
    }

    void Update()
    {
        if(navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance){ //to check if the nevash agent has arrive the destination or not
            m_CurrentWaypointIndex = (m_CurrentWaypointIndex +1) % waypoints.Length;        //circular divider so that result will be withing waypoints.length
            navMeshAgent.SetDestination(waypoints[ m_CurrentWaypointIndex].position);
        }
    }
}
