using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    [SerializeField] private StageType stageType;
    [SerializeField] private int size = 2;
    [SerializeField] private GameObject stagePortion;
    [SerializeField] private float spaceBetweenPortion = 2f;
    [SerializeField] private float fallSpeed = 2f;

    private bool _isFalling = false;
    void Start()
    {
        for (int i = 0; i < size; i++)
        {
            GameObject child = Instantiate(stagePortion,transform.position + new Vector3(0f,-i*spaceBetweenPortion,0f),Quaternion.identity);
            child.transform.SetParent(transform);
            child.GetComponentInChildren<StagePortionDisplay>().StageType = stageType;
        }        
    }

    // Update is called once per frame
    void Update()
    {
        if (_isFalling)
        {
            transform.Translate(Vector3.down * Time.deltaTime * fallSpeed);
        }
    }

    public void Fall()
    {
        _isFalling = true;
    }
}
