using UnityEngine;

public class Coin : MonoBehaviour
{
    public float scanRange = 3.0f;
    public LayerMask targetLayer;
    public Transform nearestTarget;
    public float smoothTime = 0.2f;
    public float coinSpeed = 15.0f;
    public int layerMask;

    private Vector3 velocity = Vector3.zero;

    void Start()
    {
        targetLayer = LayerMask.GetMask("PLAYER");

        layerMask = LayerMask.NameToLayer("PLAYER");
    }

    void FixedUpdate()
    {
        Collider[] targets = Physics.OverlapSphere(transform.position, scanRange, targetLayer);
    
        foreach (Collider target in targets)
        {
            if(target.gameObject.layer == layerMask)
            {
                nearestTarget = target.transform;
                break;
            }
        }
    
        if (nearestTarget != null)
        {
            transform.position = Vector3.SmoothDamp(transform.position,
                nearestTarget.position, ref velocity, smoothTime, coinSpeed);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == layerMask)
        {
            GameManager.instance.money += 10;
            this.gameObject.SetActive(false);
        }
    }
}
