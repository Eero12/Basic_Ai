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
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && this.CompareTag("AI"))
        {
            followpoints.Change = true;
            Debug.Log("Osui");           
            //agent.SetDestination(player.position);
    }
    }
}

