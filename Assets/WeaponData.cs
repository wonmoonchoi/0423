using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponData : MonoBehaviour
{
    public List<GameObject> WeaponList = new List<GameObject>();
    private void Start()
    {
        string objectName = gameObject.name;
        GameObject[] objectsWithSameName = GameObject.FindGameObjectsWithTag(objectName);

        // 같은 이름을 가진 다른 오브젝트가 존재하는지 확인
        foreach (GameObject obj in objectsWithSameName)
        {
            // 자기 자신이 아닌 다른 오브젝트가 있을 경우
            if (obj != gameObject)
            {
                // 자기 자신 파괴
                Destroy(gameObject);
                break; // 파괴 후 더 이상 반복할 필요 없으므로 반복문을 종료합니다.
            }
        }
    }
}
