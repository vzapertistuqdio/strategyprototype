using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Controller : MonoBehaviour
{
    public LayerMask whatCanBeClickOn;

    private NavMeshAgent agent;

    private Animator anim;
    private Rigidbody rgb;

    private Vector3 lastPosition;
    private Vector3 currentposition;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        rgb = GetComponent<Rigidbody>();

        lastPosition = transform.position;
    }

    private void Update()
    {
        currentposition = transform.position;
        float velocity;
        velocity = Vector3.Distance(lastPosition, currentposition) / Time.deltaTime;
        if (velocity < 0.4f)
        {
            anim.SetBool("walk", false);
        }
        else anim.SetBool("walk", true);
        lastPosition = currentposition;


    }
    public void Move(float offset)
    {
        Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        if (Physics.Raycast(myRay, out hitInfo, 100, whatCanBeClickOn))
        {
            
            Vector3 targetPosition = new Vector3(hitInfo.point.x+offset , hitInfo.point.y, hitInfo.point.z+offset);

            agent.SetDestination(targetPosition);     
            anim.SetBool("walk", true);
        }
    }
}
