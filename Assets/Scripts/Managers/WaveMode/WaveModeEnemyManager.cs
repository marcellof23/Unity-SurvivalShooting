using UnityEngine;

public class WaveModeEnemyManager : MonoBehaviour
{
    public WaveModeManager waveManager;
    public PlayerAttributes playerAttributes;
    public GameObject enemy;
    public float spawnTime = .5f;
    public Transform[] spawnPoints;

    [SerializeField]
    MonoBehaviour factory;
    IFactory Factory { get { return factory as IFactory; } }

    void Start()
    {
        waveManager = GetComponent<WaveModeManager>();
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }


    void Spawn()
    {
        //Jika player mati maka tidak usah meng-spawn enemy baru
        if (playerAttributes.currentHealth <= 0f)
        {
            return;
        }

        //Mendapatkan nilai random untuk spawn point enemy
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        int spawnEnemy = Random.Range(0, 3);

        if (spawnEnemy == 0)
        {
            if (waveManager.currentWeight + 1 <= waveManager.enemySpawnWeight)
            {
                waveManager.currentWeight += 1;
                waveManager.totalEnemy += 1;
                Factory.FactoryMethod(spawnEnemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
            }
            else
            {
                return;
            }
        }
        else if (spawnEnemy == 1)
        {
            if (waveManager.currentWeight + 2 <= waveManager.enemySpawnWeight)
            {
                waveManager.currentWeight += 2;
                waveManager.totalEnemy += 1;
                Factory.FactoryMethod(spawnEnemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
            }
            else
            {
                return;
            }
        }
        else
        {
            if (waveManager.currentWeight + 3 <= waveManager.enemySpawnWeight)
            {
                waveManager.currentWeight += 3;
                waveManager.totalEnemy += 1;
                Factory.FactoryMethod(spawnEnemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
            }
            else
            {
                return;
            }
        }
    }
}
