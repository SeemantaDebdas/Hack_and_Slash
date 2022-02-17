using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    Camera cam;
    Mover mover;
    RaycastHit hit;
    bool hasHit;

    private void Awake()
    {
        mover = GetComponent<Mover>();
    }

    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
            ShootRay();
    }

    private void LateUpdate()
    {
        if (hasHit) mover.HandleTargetPointSprite(hit.point);
    }

    public void ShootRay()
    {
        //a ray from the near plane of the camera to the NavMesh
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        hasHit = Physics.Raycast(ray, out hit);
        //if the ray hits any object that has NavMesh, Set agent Destination to that point
        if (hasHit)
        {
            mover.Move(hit.point);
        }
            
    }
}
