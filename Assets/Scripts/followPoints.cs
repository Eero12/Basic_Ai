using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPoints : MonoBehaviour
{
    [SerializeField]
    private Transform[] waypoints;

    [SerializeField]
    private float moveSpeed = 2f;

    public int waypointIndex = 0;

    private void Start()
    {
        transform.position = waypoints[waypointIndex].transform.position;
    }

    // Update is called once per frame
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
        if (waypointIndex == 21)
        {
            waypointIndex = 0;
        }
        if (waypointIndex == waypoints.Length)
        {
            waypointIndex = 0;
        }
    }
}
