using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Ai : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;

    private void Start()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && this.CompareTag("AI"))
        {
            Debug.Log("Osui");           
            agent.SetDestination(player.position);
        }
    }
}
