using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public PlayerAttributes playerAttributes;
    public GameObject enemy;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;

    [SerializeField]
    MonoBehaviour factory;
    IFactory Factory { get { return factory as IFactory; } }

    void Start()
    {
        //Mengeksekusi perintah spawn dengan interval spawnTime
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

        //Menduplikasi enemy
        Factory.FactoryMethod(spawnEnemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }
}
