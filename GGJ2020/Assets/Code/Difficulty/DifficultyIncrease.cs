using System;
using UnityEngine;

namespace Code.Difficulty
{
    [CreateAssetMenu(fileName = "New Diff",menuName = "Difficultly/Diff")]
    public class DifficultyIncrease : ScriptableObject
    {
        [SerializeField] private float initialFuel = 10f;
        [SerializeField] private float initialAnomalyApparitionSpeed = 5f;
        [SerializeField] private float initialAnomalyDuration = 5f;
        

        [SerializeField] private DifficultlyFormula fuelFormula, anomalyApparitionFormula, anomalyDurationFormula;

        private float fuel, anomalyApparition, anomalyDuration;


        public float Fuel => fuel;
        public float AnomalyApparition => anomalyApparition;
        public float AnomalyDuration => anomalyDuration;
        
        public void IncreaseDifficulty()
        {
            fuel = fuelFormula.IncreaseDifficulty(fuel);
            anomalyApparition = anomalyApparitionFormula.IncreaseDifficulty(anomalyApparition);
            anomalyDuration = fuelFormula.IncreaseDifficulty(anomalyDuration);
        }

        public void Reset()
        {
            fuel = initialFuel;
            anomalyApparition = initialAnomalyApparitionSpeed;
            anomalyDuration = initialAnomalyDuration;
        }
    }
}