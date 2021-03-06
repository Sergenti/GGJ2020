﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StagePortionDisplay : MonoBehaviour
{
    [SerializeField] private StageType _stageType;
    private SpriteRenderer _sprite;

    public StageType StageType
    {
        get => _stageType;
        set => _stageType = value;
    }
    
    void Start()
    {
        _sprite = GetComponent<SpriteRenderer>();
        _sprite.sprite = _stageType.stageSprite;
    }
    

    void Update()
    {
    }
}
