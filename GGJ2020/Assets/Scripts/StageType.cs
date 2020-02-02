using System.Collections;
using System.Collections.Generic;
using Code.Item;
using UnityEngine;

[CreateAssetMenu(menuName = "stage")]
public class StageType : ScriptableObject
{
   [SerializeField] private List<Sprite> _stageSprite;
   public RepairMaterial stageMaterial;

   public Sprite stageSprite
   {
      get
      {
         int idx = Random.Range(0, _stageSprite.Count);
         return _stageSprite[idx];
      }
      set => _stageSprite.Add(value);
   }
}
