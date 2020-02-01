using System.Collections;
using System.Collections.Generic;
using Code.Item;
using UnityEngine;

[CreateAssetMenu(menuName = "stage")]
public class StageType : ScriptableObject
{
   public Sprite stageSprite;
   public RepairMaterial stageMaterial;
}
