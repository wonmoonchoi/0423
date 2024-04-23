using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats2 : MonoBehaviour
{
    // TextMeshPro - Text (UI) ������Ʈ�� ������ ����
    public TextMeshProUGUI textField;

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
    public float WeaponExpAdd;

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

    public void Start()
    {
        textField.text =
            HP + "\n" +
            NowHP + "\n\n" +

            NormalDamage + "\n" +
            MagicDamage + "\n\n" +

            CriticalChance + "\n" +
            CriticalDamage + "\n\n" +

            AttackSpeed + "\n" +
            MoveSpeed + "\n\n" +

            Reach + "\n" +
            Range + "\n" +
            Knockback + "\n\n" +

            LifeSteal + "\n" +
            healthRegen + "\n" +
            Resurrection + "\n" +
            Armor + "\n\n" +

            Luck + "\n" +
            ExpGainRate + "\n" +
            WeaponExpAdd + "\n" +
            GodBlessDropRate + "\n" +
            GoldDropRate + "\n\n" +

            AddLaunch + "\n" +
            Bounce + "\n" +
            Pass + "\n" +
            Magnet
            .ToString();
    }
    private void OnEnable()
    {
        // SceneManager�� sceneLoaded �̺�Ʈ�� OnSceneLoaded �Լ��� ����մϴ�.
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        // ��ũ��Ʈ�� ��Ȱ��ȭ�Ǹ� �̺�Ʈ�� �����մϴ�.
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // �ε�� ���� �̸��� "INVENTORY"�� ��쿡�� Start �Լ��� ȣ���մϴ�.
        if (scene.name == "INVENTORY")
        {
            SceneLoad();
        }
    }
    void SceneLoad()
    {
        PlayerStatData playerStatData = GameObject.Find("PlayerStatData").GetComponent<PlayerStatData>();
        HP = playerStatData.HP;
        NowHP = playerStatData.NowHP;

        NormalDamage = playerStatData.NormalDamage;
        MagicDamage = playerStatData.MagicDamage;

        CriticalChance = playerStatData.CriticalChance;
        CriticalDamage = playerStatData.CriticalDamage;

        AttackSpeed = playerStatData.AttackSpeed;
        MoveSpeed = playerStatData.MoveSpeed;

        Reach = playerStatData.Reach;
        Range = playerStatData.Range;
        Knockback = playerStatData.Knockback;

        LifeSteal = playerStatData.LifeSteal;
        healthRegen = playerStatData.healthRegen;
        Resurrection = playerStatData.Resurrection;
        Armor = playerStatData.Armor;

        Luck = playerStatData.Luck;
        ExpGainRate = playerStatData.ExpGainRate;
        WeaponExpAdd = playerStatData.WeaponExp;
        GodBlessDropRate = playerStatData.GodBlessDropRate;
        GoldDropRate = playerStatData.GoldDropRate;

        AddLaunch = playerStatData.AddLaunch;
        Bounce = playerStatData.Bounce;
        Pass = playerStatData.Pass;
        Magnet = playerStatData.Magnet;
        Start();
    }
}
