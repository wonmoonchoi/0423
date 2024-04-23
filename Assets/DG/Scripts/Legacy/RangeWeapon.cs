using UnityEngine;

public class RangeWeapon : Search
{
    public Transform player;
    public float distance = 1.0f;
    public float attackSpeed = 2.0f;
    float timer = 0f;
    Vector3 offSet_y = new Vector3(0, 1, 0);

    void Start()
    {
        player = GameObject.Find("Player").transform;

        //_init();
    }

    void FixedUpdate()
    {
        timer += Time.deltaTime;
    }

    void Update()
    {
        SearchSomething();

        FollowToPlayer();

        if (target)
        {
            AttackToEnemy();
        }
    }

    void FollowToPlayer()
    {
        Vector3 targetPosition = player.position - (player.forward * distance) + offSet_y;

        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 4.0f);
    }

    void AttackToEnemy()
    {
        transform.LookAt(target);

        if (timer > attackSpeed)
        {
            GameObject bullet = GameManager.instance.pool.Get(4);
            bullet.transform.rotation = transform.rotation;
            bullet.transform.position = transform.position;

            timer = 0f;
        }
    }
}
