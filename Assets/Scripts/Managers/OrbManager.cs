using UnityEngine;

public class OrbManager : MonoBehaviour
{
    public PlayerAttributes playerAttributes;
    public float spawnTime = 12f;
    Vector3[] spawnPoints;

    [SerializeField]
    MonoBehaviour factory;
    IFactory Factory { get { return factory as IFactory; } }

    void Start()
    {
        spawnPoints = new Vector3[4];
        spawnPoints[0] = new Vector3(-5.62f, 1, 21.46f);
        spawnPoints[1] = new Vector3(-21.55f, 1, -5.83f);
        spawnPoints[2] = new Vector3(1.35f, 1, -16.65f);
        spawnPoints[3] = new Vector3(20.15f, 1, -8.2f);
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

        GameObject orb = Factory.FactoryMethod(spawnOrb, spawnPoints[spawnPointIndex], rotation);
    }
}
