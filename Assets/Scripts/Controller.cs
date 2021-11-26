using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Controller : MonoBehaviour
{
    Camera cam;
    NavMeshAgent agent;
    Animator anim;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }
    private void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0)) 
        { 
            //a ray from the near plane of the camera to the NavMesh
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            //if the ray hits any object that has NavMesh, Set agent Destination to that point
            if(Physics.Raycast(ray,out RaycastHit hit))
                agent.SetDestination(hit.point);
        }
        //set the Velocity parameter value with respect to the player's velocity
        anim.SetFloat("Velocity", agent.velocity.magnitude);
    }
}
