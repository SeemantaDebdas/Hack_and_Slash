using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;

public class Mover : MonoBehaviour
{
    NavMeshAgent agent;
    Animator anim;
    [SerializeField] Transform targetPointSprite;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateAnimator();
    }

    public void Move(Vector3 destination)
    {
        agent.SetDestination(destination);
    }

    private void UpdateAnimator()
    {
        //set the Velocity parameter value with respect to the player's velocity
        anim.SetFloat("Velocity", agent.velocity.magnitude);
    }

    public void HandleTargetPointSprite(Vector3 destination) 
    {
        targetPointSprite.position = new Vector3(destination.x, destination.y + 0.003f, destination.z);
        targetPointSprite.gameObject.SetActive(new Vector3(transform.position.x, 0, transform.position.z) != destination);
    } 
}
