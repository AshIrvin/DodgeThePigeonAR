using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MovementManager
{
    
    [Header("Scripts")]
    public UiManager uiManager;

    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        var target = followObject.transform.position;
        target.y = transform.position.y;

        var pos = Vector3.MoveTowards(transform.position, target, _speed * Time.deltaTime);

        transform.position = pos;

        // rotate to target
        var direction = target - transform.position;

        // Rotate the forward vector towards the target direction by one step
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, direction, _turnSpeed, _maxTurnSpeed);

        // Calculate a rotation a step closer to the target and applies rotation to this object
        transform.rotation = Quaternion.LookRotation(newDirection);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Food"))
        {
            Destroy(collision.gameObject);
            // add point
            uiManager.AddPoint(1);
        }
    }
}
