using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesChange : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            SceneManager.LoadScene("INVENTORY");
        }
    }
    private void Start()
    {
        // WeaponData ������Ʈ�� WeaponData ��ũ��Ʈ�� ����
        WeaponData weaponData = FindObjectOfType<WeaponData>();

        // ��ũ��Ʈ�� �����ϴ��� Ȯ�� �� �۾� ����
        if (weaponData != null)
        {
         //   foreach(GameObject weapon in weaponData.WeaponList)
        }
    }
}
