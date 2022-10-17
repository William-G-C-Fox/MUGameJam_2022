using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob_Spawn : MonoBehaviour
{
    [Header("Spawn Properties")]
    [SerializeField] private float lastSpawn;
    [SerializeField] private float spawnRate;
    [SerializeField] private GameObject mob;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void Spawner()
    {
        if (Time.time > spawnRate + lastSpawn)
        {
            GameObject spawnedMob = Instantiate(mob, transform.position, transform.rotation);
            lastSpawn = Time.time;
        }
    }
}
