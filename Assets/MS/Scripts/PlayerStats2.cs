using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats2 : MonoBehaviour
{
    // TextMeshPro - Text (UI) 컴포넌트에 접근할 변수
    public TextMeshProUGUI textField;

    // 최대 체력
    public float HP;

    // 현재 체력
    public float NowHP;

    // 물리 데미지
    public float NormalDamage;

    // 마법 데미지
    public float MagicDamage;

    // 크리티컬 확률
    public float CriticalChance;

    // 크리티컬 데미지
    public float CriticalDamage;

    // 공격 속도
    public float AttackSpeed;

    // 이동 속도
    public float MoveSpeed;

    // 사거리
    public float Reach;

    // 범위
    public float Range;

    // 넉백
    public float Knockback;

    // 체력 흡수
    public float LifeSteal;

    // 체력 자연 회복
    public float healthRegen;

    // 부활
    public float Resurrection;

    // 방어력
    public float Armor;

    // 행운
    public float Luck;

    // 경험치 획득률
    public float ExpGainRate;

    // 무기 숙련도 획득률
    public float WeaponExpAdd;

    // 신의 가호 드랍률
    public float GodBlessDropRate;

    // 골드 드랍률
    public float GoldDropRate;

    // 추가 발사체
    public float AddLaunch;

    // 튕김
    public float Bounce;

    // 관통
    public float Pass;

    // 아이템 획득 반경
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
        // SceneManager의 sceneLoaded 이벤트에 OnSceneLoaded 함수를 등록합니다.
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        // 스크립트가 비활성화되면 이벤트를 해제합니다.
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // 로드된 씬의 이름이 "INVENTORY"인 경우에만 Start 함수를 호출합니다.
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
