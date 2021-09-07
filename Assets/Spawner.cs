using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    public float timeBetweenSpawns = 3;

    void Start()
    {
        StartCoroutine(KeepSpawning());
    }

    IEnumerator KeepSpawning()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeBetweenSpawns);
            Instantiate(objectToSpawn, transform.position, transform.rotation);
        }
    }
}
