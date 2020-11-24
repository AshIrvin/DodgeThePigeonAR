using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TargetObjects
{
    WEST_TARGET,
    NORTH_TARGET,
    EAST_TARGET,
    SOUTH_TARGET
}

public class PedestrianManager : MonoBehaviour
{
    /* random choose from target for start
     * then set opposite target
     * set timer for next spawn
     * lower time every n seconds
     */

    // spawning the prefab peds from here
    [Header("Ped Prefab")]
    public GameObject pedestrian;

    [Header("Ped Prefab")]
    public GameObject[] targets;

    [Header("Ped Prefab")]
    public float waitTime = 15f;

    [Header("List of Spawned")]
    public List<GameObject> spawnedPeds = new List<GameObject>();
    private bool canContinue = true;

    private void Start()
    {
        //Instantiate(pedestrian);

        
    }

    private void Update()
    {
        if (canContinue)
            StartCoroutine(Wait());
    }

    private IEnumerator Wait()
    {
        canContinue = false;
        yield return new WaitForSeconds(WaitTime());
        SpawnPedestrian();
        canContinue = true;
    }

    private void SpawnPedestrian()
    {
        // choose which target to spawn from
        int n = Random.Range(0, targets.Length);
        // set position in volume
        Vector3 startPos = targets[n].transform.position;
        // set rotation
        var rot = SetRotationOfPed(n);


        // spawn
        var newPed = Instantiate(pedestrian, startPos, rot, transform);
        //spawnedPeds.Add(newPed); // needed?

        // get movement componant and assign new target
        var pedMovement = newPed.GetComponent<PedestrianMovement>();
        pedMovement.targetObject = SetOppositeTarget(n);
    }

    private Quaternion SetRotationOfPed(int n)
    {
        Quaternion rot = new Quaternion();


        for (int i = 0; i < targets.Length; i++)
        {
            if (i == n)
            {
                n *= 90;
                rot = Quaternion.Euler(0, n, 0);
                break;
            }
        }

        return rot;
    }

    private GameObject SetOppositeTarget(int n)
    {
        switch (n)
        {
            case (int)TargetObjects.WEST_TARGET:
                return targets[(int)TargetObjects.EAST_TARGET];
            case (int)TargetObjects.NORTH_TARGET:
                return targets[(int)TargetObjects.SOUTH_TARGET];
            case (int)TargetObjects.EAST_TARGET:
                return targets[(int)TargetObjects.WEST_TARGET];
            case (int)TargetObjects.SOUTH_TARGET:
                return targets[(int)TargetObjects.NORTH_TARGET];
            default:
                Debug.LogError("SetOppositeTarget - Ped missing a target?");
                break;
        }

        return null;
    }

    private float WaitTime()
    {
        ReduceWait();

        return waitTime;
    }

    // level up every 15 seconds?
    // so it gets busier and busier
    private void ReduceWait()
    {
        if (waitTime > 2)
            waitTime -= 1f;
    }
}
