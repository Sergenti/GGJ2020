using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketStage : MonoBehaviour
{
    [SerializeField]
    private GameObject AnomalyEffect;
    private BoxCollider2D AnomalyZone;
    public StageType type;

    private SpriteRenderer _spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        if (_spriteRenderer != null)
        {
            _spriteRenderer.sprite = type.stageSprite;
        }
        AnomalyZone = GetComponent<BoxCollider2D>();
    }

    public void CreateRandomAnomaly()
    {
        Vector3 randomPoint = Utilities.RandomPointInBounds(AnomalyZone.bounds);
        Instantiate(AnomalyEffect, randomPoint, Quaternion.identity);
    }

    
}
