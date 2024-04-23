using System.Collections;
using System.Collections.Generic;
using TMPro;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class SlotToolTip : MonoBehaviour
{
    // TextMeshPro - Text (UI) 컴포넌트에 접근할 변수
    public TextMeshProUGUI textField;

    public string Name;

    public string WeaponType;

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



    // 적 리스폰
    public float AddSpawn;


    // 인접 무기 공속 버프
    public float TogetherItemAttackSpeedBuff;

    // 인접 무기 크확 버프
    public float TogetherItemCriticalChanceBuff;

    // 인접 무기 체력 흡수
    public float TogetherItemLifeStealBuff;

    // 붙어있는 아이템 체크
    public bool TogetherItemCheck;


    // ~초 동안 경험치 획득률 상승
    public float ExpGainLimit;

    // ~초 동안 이동 속도 상승
    public float MoveSpeedLimit;

    // 인벤토리 슬롯 증가
    public bool AddSlotint;

    // 스테이지 시작후 적용되는 소모품의 제한시간
    public int TimeLimit;

    // 소모품 체크
    public bool Potion;


    public float WeaponAttack;
    public float WeaponCriticalChance;
    public float WeaponCriticalDamage;
    public float WeaponSpeed;
    public float WeaponReach;
    public float WeaponKnockBack;
    public float WeaponExp;

    public int Price;

    public void Together()
    {
        if (TogetherItemCheck)
        {
            if (transform.parent != null && transform.parent.gameObject.layer == LayerMask.NameToLayer("Slot"))
            {

            }
        }
    }
    public void text()
    {
        GameObject canvasObject = GameObject.Find("Canvas");
        if (canvasObject != null)
        {
            // Canvas 오브젝트의 자식인 Tooltip 오브젝트를 찾습니다.
            Transform tooltipTransform = canvasObject.transform.Find("Tooltip");

            if (tooltipTransform != null)
            {
                // Tooltip 오브젝트의 자식인 SlotToolTip 오브젝트를 찾습니다.
                Transform slotToolTipTransform = tooltipTransform.Find("SlotToolTip");

                if (slotToolTipTransform != null)
                {
                    // SlotToolTip 오브젝트에 연결된 TextMeshProUGUI 컴포넌트를 가져옵니다.
                    textField = slotToolTipTransform.GetComponent<TextMeshProUGUI>();
                }
            }
        }
        // 텍스트 필드에 표시할 문자열 초기화
        string text = "";
        text += "<size=" + 24 + ">" + Name + "</size>\n";

        text += WeaponType + "\n\n\n";
        // 각 스탯이 0이 아닌 경우 문자열에 추가
        if (HP != 0)
            text += "최대 체력 :  " + HP.ToString() + "\n\n";
        if (NowHP != 0)
            text += "현재 체력 :  " + NowHP.ToString() + "\n\n";

        if (NormalDamage != 0)
            text += "물리 데미지 :  " + NormalDamage.ToString() + "\n\n";
        if (MagicDamage != 0)
            text += "마법 데미지 :  " + MagicDamage.ToString() + "\n\n";

        if (CriticalChance != 0)
            text += "크리티컬 확률 :  " + CriticalChance.ToString() + "\n\n";
        if (CriticalDamage != 0)
            text += "크리티컬 데미지 :  " + CriticalDamage.ToString() + "\n\n";

        if (AttackSpeed != 0)
            text += "공격 속도 :  " + AttackSpeed.ToString() + "\n\n";
        if (MoveSpeed != 0)
            text += "이동 속도 :  " + MoveSpeed.ToString() + "\n\n";

        if (Reach != 0)
            text += "사거리 :  " + Reach.ToString() + "\n\n";
        if (Range != 0)
            text += "범위 :  " + Range.ToString() + "\n\n";
        if (Knockback != 0)
            text += "넉백 :  " + Knockback.ToString() + "\n\n";

        if (LifeSteal != 0)
            text += "체력 흡수 :  " + LifeSteal.ToString() + "\n\n";
        if (healthRegen != 0)
            text += "체력 자연 회복 :  " + healthRegen.ToString() + "\n\n";
        if (Resurrection != 0)
            text += "부활 :  " + Resurrection.ToString() + "\n\n";
        if (Armor != 0)
            text += "방어력 :  " + Armor.ToString() + "\n\n";

        if (Luck != 0)
            text += "행운 :  " + Luck.ToString() + "\n\n";
        if (ExpGainRate != 0)
            text += "경험치 획득률 :  " + ExpGainRate.ToString() + "\n\n";
        if (WeaponExpAdd != 0)
            text += "무기 숙련도 :  " + WeaponExpAdd.ToString() + "\n\n";
        if (GodBlessDropRate != 0)
            text += "신의가호 획득률 :  " + GodBlessDropRate.ToString() + "\n\n";
        if (GoldDropRate != 0)
            text += "골드 획득률 :  " + GoldDropRate.ToString() + "\n\n";

        if (AddLaunch != 0)
            text += "추가 발사체 :  " + AddLaunch.ToString() + "\n\n";
        if (Bounce != 0)
            text += "튕김 :  " + Bounce.ToString() + "\n\n";
        if (Pass != 0)
            text += "관통 :  " + Pass.ToString() + "\n\n";
        if (Magnet != 0)
            text += "아이템 획득 반경 :  " + Magnet.ToString() + "\n\n";

        if (AddSpawn != 0)
            text += "적 스폰 확률 :  " + AddSpawn.ToString() + "%\n\n";


        if (TogetherItemAttackSpeedBuff != 0)
            text += "인접 무기 공격속도 증가 :  " + TogetherItemAttackSpeedBuff.ToString() + "%\n\n";
        if (TogetherItemCriticalChanceBuff != 0)
            text += "인접 무기 크리티컬 확률 증가 :  " + TogetherItemCriticalChanceBuff.ToString() + "%\n\n";
        if (TogetherItemLifeStealBuff != 0)
            text += "인접 무기 체력 흡수 :  " + TogetherItemLifeStealBuff.ToString() + "%\n\n";


        if (ExpGainLimit != 0)
            text += TimeLimit.ToString() + "초 동안 경험치 획득률 " + ExpGainLimit.ToString() + "% 상승\n\n";
        if (MoveSpeedLimit != 0)
            text += TimeLimit.ToString() + "초 동안 이동 속도 " + MoveSpeedLimit.ToString() + "% 상승\n\n";
        if (AddSlotint)
            text += "인벤토리 슬롯 증가 :  +2" + "\n\n";


        if (WeaponAttack != 0)
            text += "공격력 :  " + WeaponAttack.ToString() + "\n\n";
        if (WeaponCriticalChance != 0)
            text += "크리티컬 확률 :  " + WeaponCriticalChance.ToString() + "%\n\n";
        if (WeaponCriticalDamage != 0)
            text += "크리티컬 데미지 :  " + WeaponCriticalDamage.ToString() + "%\n\n";
        if (WeaponSpeed != 0)
            text += "공격 속도 :  " + WeaponSpeed.ToString() + "\n\n";
        if (WeaponReach != 0)
            text += "사거리 :  " + WeaponReach.ToString() + "\n\n";
        if (WeaponKnockBack != 0)
            text += "넉백 :  " + WeaponKnockBack.ToString() + "\n\n\n";
        if (WeaponExp != 0)
            text += "숙련도 :  " + WeaponExp.ToString() + "\n\n";

        if (transform.parent != null)
        {
            if (transform.parent.gameObject.layer == LayerMask.NameToLayer("Store"))
            {
                if (Price != 0)
                    text += "\n구매 가격 :  " + Price;
            }
            else if (transform.parent.gameObject.layer != LayerMask.NameToLayer("Store"))
            {
                if (Price != 0)
                    text += "\n환불 금액 :  " + (int)(Price * 0.7f);
            }
        }

        // 텍스트 필드에 문자열 표시
        if (text.Length > 0)
        {
            textField.text = text;
        }
    }
}
