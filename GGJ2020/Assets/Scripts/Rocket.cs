using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    private List<GameObject> stages = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in transform)
        {
            stages.Add(child.gameObject);
        }

        InvokeRepeating("GenerateAnomaly", 1, 1);
    }

    void GenerateAnomaly()
    {
        Debug.Log("Generating Anomaly...");
        var randomStage = stages[Random.Range(0, stages.Count - 1)];
        RocketStage ctrl = randomStage.GetComponent<RocketStage>();

        ctrl.CreateRandomAnomaly();
    }

}
