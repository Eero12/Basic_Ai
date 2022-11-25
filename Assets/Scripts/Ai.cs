using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Ai : MonoBehaviour
{
    public followPoints followpoints;
    public NavMeshAgent agent;
    public Transform player;

    private void Start()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }



    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);

        //if (other.gameObject.CompareTag("Player") && this.CompareTag("AI"))
        if (other.gameObject.name == "attackCube")
        {
            followpoints.Change = true;
            Debug.Log("Osui");           
            //agent.SetDestination(player.position);
        }
        if (other.gameObject.name == "stopCube")
        {
            followpoints.canMove = false;
        }
    }
}

