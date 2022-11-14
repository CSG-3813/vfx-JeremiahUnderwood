using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimationController : MonoBehaviour
{

    private NavMeshAgent thisAgent;
    private Animator thisAnimator;

    public float runVelocity = 0.1f;
    public string runParameter;
    public string speedParameter;
    private float maxSpeed;

    private void Awake()
    {
        thisAgent = this.gameObject.GetComponent<NavMeshAgent>();
        thisAnimator = this.gameObject.GetComponent<Animator>();
        maxSpeed = thisAgent.speed;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //thisAnimator.SetBool(runParameter, thisAgent.velocity.magnitude > runVelocity);
        thisAnimator.SetFloat(speedParameter, thisAgent.velocity.magnitude / maxSpeed);
    }
}
