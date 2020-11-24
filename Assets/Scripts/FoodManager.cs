using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodManager : MonoBehaviour
{
    public GameObject[] food;

    private float waitTime = 3;
    //private float t = 3;
    private bool canSpawn = true;
    //private bool timerEnabled = true;

    public float dropHeight = 0.3f;

    private void Update()
    {
        SpawnFood();
    }

    private void SpawnFood()
    {
        if (canSpawn)
        {
            canSpawn = false;
            // get random position
            Vector3 pos = new Vector3(ChooseRandomNumber(-4,4), dropHeight, ChooseRandomNumber(-4, 4));
            // spawn
            Instantiate(food[ChooseRandomNumber(0, food.Length)], pos, Quaternion.identity, transform);

            StartCoroutine(Wait());
        }
    }

    private IEnumerator Wait()
    {

        yield return new WaitForSeconds(waitTime);
        canSpawn = true;
        //t = 3;

    }

    public static int ChooseRandomNumber(int min, int length)
    {
        return Random.Range(min, length);
    }
}
