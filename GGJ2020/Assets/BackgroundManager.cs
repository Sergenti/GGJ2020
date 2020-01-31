using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    public BoxCollider2D spawnZone;
    public BoxCollider2D despawnZone;

    public GameObject star;

    public void GenerateRandomStar()
    {
        Vector3 spawnPoint = Utilities.RandomPointInBounds(spawnZone.bounds);
        Instantiate(star, spawnPoint, Quaternio.down)

    }
}
