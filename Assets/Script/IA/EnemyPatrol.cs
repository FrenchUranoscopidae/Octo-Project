using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrol : MonoBehaviour
{
    //Dictates whether the agent waits on each node
    [SerializeField]
    bool patrolWaiting;

    //The total time the agent wait each node
    [SerializeField]
    float totalWaitTime = 3f;

    //The probability of switching direction
    [SerializeField]
    float switchProbability = 0.2f;

    //Private variables for base behaviour 
    NavMeshAgent navMeshAgent;
    ConnectedWaypoint currentWaypoint;
    ConnectedWaypoint previousWaypoint;

    bool travelling;
    bool waiting;
    float waitTimer;
    int waypointsVisited;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = this.GetComponent<NavMeshAgent>();

        if(navMeshAgent == null)
        {
            Debug.LogError("The nav mesh agent component is not attached to" + gameObject.name);
        }
        else
        {
            if(currentWaypoint == null)
            {
                //Grab all waypoint in scene
                GameObject[] allWaypoints = GameObject.FindGameObjectsWithTag("Waypoint");

                if(allWaypoints.Length > 0)
                {
                    while(currentWaypoint == null)
                    {
                        int random = UnityEngine.Random.Range(0, allWaypoints.Length);
                        ConnectedWaypoint startingWaypoint = allWaypoints[random].GetComponent<ConnectedWaypoint>();

                        //We found a waypoint
                        if(startingWaypoint != null)
                        {
                            currentWaypoint = startingWaypoint;
                        }
                    }
                }
            }
            else
            {
                Debug.Log("Failed to find any waypoints for use in the scene.");
            }
        }

        SetDestination();
    }

    private void Update()
    {
        //Check if we'reclose to the destination
        if(travelling && navMeshAgent.remainingDistance <= 1.0f)
        {
            travelling = false;
            waypointsVisited++;

            //If we're going to wait, then wait.
            if(patrolWaiting)
            {
                waiting = true;
                waitTimer = 0f;
            }
            else
            {
                SetDestination();
            }
        }

        //Instead we're waiting
        if(waiting)
        {
            waitTimer += Time.deltaTime;

            if(waitTimer >= totalWaitTime)
            {
                waiting = false;
                SetDestination();
            }
        }
    }

    private void SetDestination()
    {
        if(waypointsVisited > 0)
        {
            ConnectedWaypoint nextWaypoint = currentWaypoint.NextWaypoint(previousWaypoint);
            previousWaypoint = currentWaypoint;
            currentWaypoint = nextWaypoint;
        }

        Vector3 targetVector = currentWaypoint.transform.position;
        navMeshAgent.SetDestination(targetVector);
        travelling = true;
    }
}
