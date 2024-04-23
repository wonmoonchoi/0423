using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatData : MonoBehaviour
{
    // �ִ� ü��
    public float HP;

    // ���� ü��
    public float NowHP;

    // ���� ������
    public float NormalDamage;

    // ���� ������
    public float MagicDamage;

    // ũ��Ƽ�� Ȯ��
    public float CriticalChance;

    // ũ��Ƽ�� ������
    public float CriticalDamage;

    // ���� �ӵ�
    public float AttackSpeed;

    // �̵� �ӵ�
    public float MoveSpeed;

    // ��Ÿ�
    public float Reach;

    // ����
    public float Range;

    // �˹�
    public float Knockback;

    // ü�� ���
    public float LifeSteal;

    // ü�� �ڿ� ȸ��
    public float healthRegen;

    // ��Ȱ
    public float Resurrection;

    // ����
    public float Armor;

    // ���
    public float Luck;

    // ����ġ ȹ���
    public float ExpGainRate;

    // ���� ���õ� ȹ���
    public float WeaponExp;

    // ���� ��ȣ �����
    public float GodBlessDropRate;

    // ��� �����
    public float GoldDropRate;

    // �߰� �߻�ü
    public float AddLaunch;

    // ƨ��
    public float Bounce;

    // ����
    public float Pass;

    // ������ ȹ�� �ݰ�
    public float Magnet;

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
