using System;
using System.Collections;
using Code.EventSystem.Events;
using Code.EventSystem;
using UnityEngine;
using Void = Code.EventSystem.Void;

public class Entrance : MonoBehaviour
{
    [SerializeField] private float duration = 4f;
    [SerializeField] private GameObject objToActivate;

    private void Start()
    {
        StartCoroutine(Wait(duration));
    }

    private IEnumerator Wait(float duration)
    {
        yield return new WaitForSeconds(duration);
        objToActivate.SetActive(true);
        Destroy(gameObject);
    }
}
