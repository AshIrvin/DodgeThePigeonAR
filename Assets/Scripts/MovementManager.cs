using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : MonoBehaviour
{
    [Header("Speeds")]
    public float _speed;
    public float _turnSpeed;
    public float _maxTurnSpeed;

    [Header("Health")]
    public int _health;

    [Header("AR centre")]
    public GameObject followObject;

}
