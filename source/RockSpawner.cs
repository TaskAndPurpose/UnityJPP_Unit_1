// This class manages the spawning of rocks at predefined positions within a Unity scene.
using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    // Array to hold references to spawn points for rocks.
    public Transform[] _spawnPoints;
    
    // Prefab of the rock object to be spawned.
    public GameObject _rock;
    
    // Delay between each spawn of rocks.
    public float _spawnDelay = 2f;
    
    // This method is called when the object is first created.
    private void Start()
    {
        // Start spawning rocks every '_spawnDelay' seconds.
        InvokeRepeating("SpawnRocks", 2, _spawnDelay);
    }

    // This method is responsible for spawning rocks.
    private void SpawnRocks()
    {
        // Randomly select a spawn point index.
        int randomIndex = Random.Range(0, _spawnPoints.Length);
        // Get the transform of the randomly selected spawn point.
        Transform _spawnPoint = _spawnPoints[randomIndex];

        // Instantiate a rock at the selected spawn point.
        Instantiate(_rock, _spawnPoint.position, Quaternion.identity);
    }
}