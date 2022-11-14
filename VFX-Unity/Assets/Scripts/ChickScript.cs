/***
 * 
 * Created by Jeremiah Underwood on November 14 2022
 * Last edited by Jeremiah Underwood on November 14 2022
 * Makes chick object move to the destination location
 * 
***/



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChickScript : MonoBehaviour
{

    private NavMeshAgent thisAgent;
    public Transform destination;

    public void Awake()
    {
        thisAgent = this.gameObject.GetComponent<NavMeshAgent>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        thisAgent.SetDestination(destination.position);
    }
}
