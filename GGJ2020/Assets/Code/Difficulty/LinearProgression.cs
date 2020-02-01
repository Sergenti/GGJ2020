using UnityEngine;

namespace Code.Difficulty
{
    [CreateAssetMenu(menuName = "Difficulty/LinearProgression")]
    public class LinearProgression : DifficultlyFormula
    {
        [SerializeField] private float increaseCste = 1f;

        public override float IncreaseDifficulty(float initialValue)
        {
            return initialValue + increaseCste;
        }
    }
}