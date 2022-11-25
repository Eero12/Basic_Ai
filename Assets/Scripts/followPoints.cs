using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPoints : MonoBehaviour
{
    public Ai ai;
    [SerializeField]
    private Transform[] waypoints;
    [SerializeField]
    private float moveSpeed = 2f;
    public int waypointIndex = 0;
    public bool Change;
    private void Start()
    {
        transform.position = waypoints[waypointIndex].transform.position;
    }
    private void Update()
    {
        Move();
    }
    private void Move()
    {
         transform.position = Vector3.MoveTowards(transform.position,
         waypoints[waypointIndex].transform.position,
         moveSpeed * Time.deltaTime);
        if (transform.position == waypoints[waypointIndex].transform.position)
        {
           waypointIndex += 1;
        }
        else if (waypointIndex == 21)
        {
            waypointIndex = 0;
        }
        else if (waypointIndex == waypoints.Length)
        {
            waypointIndex = 0;
        }
        else if (Change == true)
        {
            Debug.Log("dsauoida");
            ai.agent.SetDestination(ai.player.position);
        }

    }
}
