using UnityEngine;

namespace Code.Difficulty
{
    [CreateAssetMenu(menuName = "Difficulty/Multipl")]
    public class ConstantMutliplication : DifficultlyFormula
    {
        [SerializeField] private float multiplcator = 0.8f;

        public override float IncreaseDifficulty(float initialValue)
        {
            return initialValue * multiplcator;
        }
    }
}
