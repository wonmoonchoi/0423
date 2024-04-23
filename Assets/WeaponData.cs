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

        // ���� �̸��� ���� �ٸ� ������Ʈ�� �����ϴ��� Ȯ��
        foreach (GameObject obj in objectsWithSameName)
        {
            // �ڱ� �ڽ��� �ƴ� �ٸ� ������Ʈ�� ���� ���
            if (obj != gameObject)
            {
                // �ڱ� �ڽ� �ı�
                Destroy(gameObject);
                break; // �ı� �� �� �̻� �ݺ��� �ʿ� �����Ƿ� �ݺ����� �����մϴ�.
            }
        }
    }
}
