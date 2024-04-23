using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatData : MonoBehaviour
{
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
    public float WeaponExp;

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
