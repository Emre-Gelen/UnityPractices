using UnityEngine;

namespace Assets.Scripts.PowerUps
{


    public class PowerUpRespawner : MonoBehaviour
    {
        [Tooltip("The gun to be added to player.")]
        public PowerUpBase[] powerUps;

        [Header("Spawn Position")]
        [Tooltip("The distance within which powerups can spawn in the X direction")]
        [Min(0)]
        public float spawnRangeX = 10.0f;
        [Tooltip("The distance within which powerups can spawn in the Y direction")]
        [Min(0)]
        public float spawnRangeY = 10.0f;


        [Header("Spawn Variables")]
        [Tooltip("Ignores the max spawn limit if true")]
        public bool spawnInfinite = true;

        [Tooltip("The time delay between spawning powerups")]
        public double spawnDelay = 2.5;

        // The most recent spawn time
        private double lastSpawnTime = Mathf.NegativeInfinity;

        [Tooltip("The object to make projectiles child objects of.")]
        public Transform powerUpHolder = null;
        private void Update()
        {
            CheckSpawnTimer();
        }
        private void CheckSpawnTimer()
        {
            // If it is time for an powerup to be spawned
            if (Time.timeSinceLevelLoad > lastSpawnTime + spawnDelay)
            {
                // Determine spawn location
                Vector3 spawnLocation = GetSpawnLocation();

                // Spawn an powerup
                SpawnPowerUp(spawnLocation);
            }
        }

        private void SpawnPowerUp(Vector3 spawnLocation)
        {
            GameObject powerUp = powerUps[getRandomIndex()].gameObject;
            GameObject gameObject = Instantiate(powerUp, spawnLocation, powerUp.transform.rotation, null);
            if (powerUpHolder != null)
            {
                gameObject.transform.SetParent(powerUpHolder);
            }
            lastSpawnTime = Time.timeSinceLevelLoad;
        }
        private int getRandomIndex()
        {
            return Random.Range(0, powerUps.Length-1);
        }
        protected virtual Vector3 GetSpawnLocation()
        {
            // Get random coordinates
            float x = Random.Range(0 - spawnRangeX, spawnRangeX);
            float y = Random.Range(0 - spawnRangeY, spawnRangeY);
            // Return the coordinates as a vector
            return new Vector3(transform.position.x + x, transform.position.y + y, 0);
        }
    }
}
