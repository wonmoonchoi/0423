using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform target;
    public Transform[] spawnPoint;

    void Awake()
    {
        spawnPoint = GetComponentsInChildren<Transform>();

        var objs = FindObjectsOfType<Spawner>();
        if (objs.Length > 1)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    void FixedUpdate()
    {
        if (target == null)
        {
            GameObject playerObject = GameObject.Find("Player");
            if (playerObject != null)
            {
                target = playerObject.transform;
            }
            else
            {
                Debug.Log("Player 가 없습니다. Spwner");
            }
        }

        if (GameManager.instance.isPlay == true)
        {
            transform.position = target.transform.position;
        }
    }

    public void Spawn0()
    {
        GameObject enemy = GameManager.instance.pool.Get(1);

        enemy.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].position;
    }

    public void Spawn1()
    {
        GameObject enemy = GameManager.instance.pool.Get(1);

        enemy.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].position;
    }

    public void Spawn2()
    {
        GameObject enemy = GameManager.instance.pool.Get(1);

        enemy.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].position;
    }
}
