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
    public bool Change = false;
    public bool canMove = true;

    private void Start()
    {
        transform.position = waypoints[waypointIndex].transform.position;
    }
    void Update()
    {
        if(canMove)
        {
            if (Change)
            {
                Debug.Log("dsauoida");
                ai.agent.SetDestination(ai.player.position);
            }
            else if(!Change)
            {
                Move();
            }
        }
    }
    void Move()
    {
        Debug.Log(Change);

        if (waypointIndex <= waypoints.Length - 1)
        {
            transform.position = Vector3.MoveTowards(transform.position,
                waypoints[waypointIndex].transform.position,
                moveSpeed * Time.deltaTime);

            if (transform.position == waypoints[waypointIndex].transform.position)
            {
                waypointIndex += 1;
            }
            if (waypointIndex == 4)
            {
                waypointIndex = 0;
            }
        }
    }
}
