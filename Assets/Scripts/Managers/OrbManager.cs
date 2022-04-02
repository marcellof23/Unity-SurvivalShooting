using UnityEngine;

public class OrbManager : MonoBehaviour
{
    public PlayerAttributes playerAttributes;
    public float spawnTime = 3f;
    Vector3[] spawnPoints;

    [SerializeField]
    MonoBehaviour factory;
    IFactory Factory { get { return factory as IFactory; } }

    void Start()
    {
        spawnPoints = new Vector3[4];
        spawnPoints[0] = new Vector3(0, 0, 0);
        spawnPoints[1] = new Vector3(0, 0, 0);
        spawnPoints[2] = new Vector3(0, 0, 0);
        spawnPoints[3] = new Vector3(0, 0, 0);
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }


    void Spawn()
    {
        if (playerAttributes.currentHealth <= 0f)
        {
            return;
        }

        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        int spawnOrb = Random.Range(0, 3);

        Quaternion rotation = new Quaternion();

        Factory.FactoryMethod(spawnOrb, spawnPoints[spawnPointIndex], rotation);
    }
}
