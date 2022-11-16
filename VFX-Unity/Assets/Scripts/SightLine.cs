/***
 * 
 * Created by Jeremiah Underwood November 16 2022
 * Last edited by Jeremiah Underwood November 16 2022
 * Sight lines
 * 
***/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SightLine : MonoBehaviour
{

    public Transform eyePoint;
    public string targetTag = "Player";
    public float fieldOfView = 45f;
    public bool IsTargetInSight { get; set; } = false;
    public Vector3 lastKnownSighting { get; set; } = Vector3.zero;

    private SphereCollider thisCollider;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            UpdateSight(other.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            IsTargetInSight = false;
        }
    }

    private void Awake()
    {
        thisCollider = GetComponent<SphereCollider>();
        lastKnownSighting = transform.position;
    }

    private bool TargetinFOV(Transform target)
    {
        Vector3 DirToTarget = target.position = eyePoint.position;
        float angle = Vector3.Angle(eyePoint.forward, DirToTarget);

        if (angle <= fieldOfView)
        {
            return true;
        }

        return false;
    }

    private bool ClearLineOfSight(Transform target)
    {
        RaycastHit hit;
        Vector3 dirToTarget = (target.position - eyePoint.position).normalized;
        if(Physics.Raycast(eyePoint.position, dirToTarget, out hit, thisCollider.radius))
        {
            if (hit.transform.CompareTag(targetTag))
            {
                return true;
            }
        }
        return false;
    }


    private void UpdateSight(Transform target)
    {
        IsTargetInSight = TargetinFOV(target) && ClearLineOfSight(target);
        if (IsTargetInSight)
        {
            lastKnownSighting = target.position;
        }
    }
}
