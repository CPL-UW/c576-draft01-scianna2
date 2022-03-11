using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PhNarwahl {
    public class WavesSpawner : MonoBehaviour {

        public Transform enemyprefab;

        public Transform spawnPoint;

        private float countdown = 2f;
        private int waveNumber = 1;

        void Update ()
        {
            if (countdown <= 0f)
            {
                SpawnWave();
                countdown = LevelData.timeBetweenWaves;
            }

            countdown -= Time.deltaTime; 
        }
        void SpawnWave()
        {
            if(waveNumber > LevelData.totalWaves) {
                Debug.Log("No more waves");
                return;
            }
            for (int i = 0; i < waveNumber; i++)
            {
                spawnEnemy ();

            }
            waveNumber++;

            Debug.Log("Wave Incoming");
        }

        void spawnEnemy ()
        {
            Instantiate(enemyprefab, spawnPoint.position, spawnPoint.rotation);
        }

    }
}
