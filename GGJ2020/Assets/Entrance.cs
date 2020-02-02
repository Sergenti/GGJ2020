using System.Collections;
using Code.EventSystem.Events;
using UnityEngine;
using Void = Code.EventSystem.Void;

public class Entrance : MonoBehaviour
{
    [SerializeField] private float duration = 4f;
    [SerializeField] private GameObject objToActivate;
    [SerializeField] private VoidEvent soundOpen;
    [SerializeField] private VoidEvent soundClose;

    private void Start()
    {
        StartCoroutine(Wait(duration));
        soundOpen.Raise(new Void());
    }

    private IEnumerator Wait(float duration)
    {
        yield return new WaitForSeconds(duration);
        soundClose.Raise(new Void());
        objToActivate.SetActive(true);
        Destroy(gameObject);
    }
}
