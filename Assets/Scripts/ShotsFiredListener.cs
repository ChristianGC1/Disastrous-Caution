using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace ChrisGuz
{
    public class ShotsFiredListener : MonoBehaviour
    {
        // This will update the UI text object when a tank shoots
        // - We need a reference to a text object
        // - We need to listen for a specific event
        // - We need to track how many shots are fired
        // - We need to update our text object when we hear the event

        [SerializeField] private TextMeshProUGUI shotsFiredText;
        [SerializeField] private int shotsFiredCount = 0;
        [SerializeField] private TextMeshProUGUI enemiesDestroyedText;
        [SerializeField] private int enemiesDestroyedCount = 0;
        [SerializeField] private float accuracy;
        [SerializeField] private TextMeshProUGUI playerAccuracyText;

        private void OnEnable()
        {
            // Subscribe to an event
            Shoot.OnShotFired += IncreaseShotsCounter;
            EnemyPlane.OnDestroyedEnemy += IncreaseEnemiesCounter;
        }
        private void OnDisable()
        {
            // Unsubscribe to an event
            Shoot.OnShotFired -= IncreaseShotsCounter;
            EnemyPlane.OnDestroyedEnemy -= IncreaseEnemiesCounter;
        }
        private void Update()
        {

        }
        private void IncreaseShotsCounter()
        {
            // Increase our counter and update our text object here
            shotsFiredCount++;
            shotsFiredText.text = "Shots Fired: " + shotsFiredCount.ToString();
            UpdateAccuracy();
        }

        private void IncreaseEnemiesCounter()
        {
            // Increase our counter and update our text object here
            enemiesDestroyedCount++;
            enemiesDestroyedText.text = "Enemies Destroyed: " + enemiesDestroyedCount.ToString();
            UpdateAccuracy();
        }

        private void UpdateAccuracy()
        {
            if( enemiesDestroyedCount != 0 && shotsFiredCount != 0)
            {
                accuracy = (float)enemiesDestroyedCount / (float)shotsFiredCount * 100f;
                playerAccuracyText.text = "Accuracy: " + accuracy.ToString("0.00") + "%";
            }
        }
    }
}
