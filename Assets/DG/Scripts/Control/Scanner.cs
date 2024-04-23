using UnityEngine;

//public class Scanner : MonoBehaviour
//{
//    public float scanRange;
//    public LayerMask targetLayer;
//    //public RaycastHit[] targets;
//    public Collider[] targets;
//    //public Transform nearestTarget;
//
//    //public void FixedUpdate()
//    //{
//    //    Collider[] targets = Physics.OverlapSphere(transform.position, scanRange, targetLayer);
//    //    nearestTarget = GetNearest();
//    //}
//
//    public Transform GetNearest()
//    {
//        Collider[] targets = Physics.OverlapSphere(transform.position, scanRange, targetLayer);
//
//        Transform result = null;
//        float diff = 100;
//
//        foreach(Collider target in targets)
//        {
//            Vector3 myPos = transform.position;
//            Vector3 tragetPos = target.transform.position;
//            float curDiff = Vector3.Distance(myPos, tragetPos);
//
//            if(curDiff < diff)
//            {
//                diff = curDiff;
//                result = target.transform;
//            }
//        }
//        return result;
//    }
//
//    public void Scanner_Init()
//    {
//        scanRange = 10.0f;
//        targetLayer = LayerMask.GetMask("Enemy");
//    }
//}
