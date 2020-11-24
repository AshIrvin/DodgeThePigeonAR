using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestrianMovement : MovementManager
{
    //private Vector3 target;

    [Header("Target for Ped")]
    public GameObject targetObject;
    public Vector3 targetPos;

    private float time = 12;

    private void Start()
    {
        if (targetObject.name == "WestTarget" || targetObject.name == "EastTarget")
        {
            float x = Random.Range(-7, 7);
            targetPos = new Vector3(x, 0, targetObject.transform.position.z);
        }
        else
        {
            float z = Random.Range(-7, 7);
            targetPos = new Vector3(targetObject.transform.position.x, 0, z);
        }
    }

    private void Update()
    {
        Movement();

        if (time < 0)
            Destroy(gameObject);
    }

    private void Movement()
    {
        var pos = Vector3.MoveTowards(transform.position, targetPos, _speed * Time.deltaTime);
        transform.position = pos;
        time -= Time.deltaTime;

        // rotate to target
        var direction = targetPos - transform.position;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, direction, _turnSpeed, _maxTurnSpeed);
        transform.rotation = Quaternion.LookRotation(newDirection);
    }
}
