using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    public BoxCollider2D spawnZone;
    public BoxCollider2D despawnZone;

    public GameObject star;

    void Start()
    {
        InvokeRepeating("GenerateRandomStar", 0, 1);
    }

    public void GenerateRandomStar()
    {
        // select random spawn point in the spawning zone
        Vector3 spawnPoint = Utilities.RandomPointInBounds(spawnZone.bounds);
        // create star
        Instantiate(star, spawnPoint, Quaternion.identity);

    }
}
