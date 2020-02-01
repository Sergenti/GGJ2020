using UnityEngine;

namespace Code.Difficulty
{
    public abstract class DifficultlyFormula : ScriptableObject
    {
        public abstract float IncreaseDifficulty(float initialValue);
    }
}