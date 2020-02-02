using UnityEngine;
using UnityEngine.UI;

namespace Code.Difficulty
{
    [CreateAssetMenu(menuName = "Difficulty/ConstantSubstraction")]
    public class LinearSubstraction : DifficultlyFormula
    {

        [SerializeField] private float linearProgression = 1f;

        public override float IncreaseDifficulty(float initialValue)
        {
            return initialValue - linearProgression;
        }
    }
}
