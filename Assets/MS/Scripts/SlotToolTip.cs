using System.Collections;
using System.Collections.Generic;
using TMPro;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class SlotToolTip : MonoBehaviour
{
    // TextMeshPro - Text (UI) ������Ʈ�� ������ ����
    public TextMeshProUGUI textField;

    public string Name;

    public string WeaponType;

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



    // �� ������
    public float AddSpawn;


    // ���� ���� ���� ����
    public float TogetherItemAttackSpeedBuff;

    // ���� ���� ũȮ ����
    public float TogetherItemCriticalChanceBuff;

    // ���� ���� ü�� ���
    public float TogetherItemLifeStealBuff;

    // �پ��ִ� ������ üũ
    public bool TogetherItemCheck;


    // ~�� ���� ����ġ ȹ��� ���
    public float ExpGainLimit;

    // ~�� ���� �̵� �ӵ� ���
    public float MoveSpeedLimit;

    // �κ��丮 ���� ����
    public bool AddSlotint;

    // �������� ������ ����Ǵ� �Ҹ�ǰ�� ���ѽð�
    public int TimeLimit;

    // �Ҹ�ǰ üũ
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
            // Canvas ������Ʈ�� �ڽ��� Tooltip ������Ʈ�� ã���ϴ�.
            Transform tooltipTransform = canvasObject.transform.Find("Tooltip");

            if (tooltipTransform != null)
            {
                // Tooltip ������Ʈ�� �ڽ��� SlotToolTip ������Ʈ�� ã���ϴ�.
                Transform slotToolTipTransform = tooltipTransform.Find("SlotToolTip");

                if (slotToolTipTransform != null)
                {
                    // SlotToolTip ������Ʈ�� ����� TextMeshProUGUI ������Ʈ�� �����ɴϴ�.
                    textField = slotToolTipTransform.GetComponent<TextMeshProUGUI>();
                }
            }
        }
        // �ؽ�Ʈ �ʵ忡 ǥ���� ���ڿ� �ʱ�ȭ
        string text = "";
        text += "<size=" + 24 + ">" + Name + "</size>\n";

        text += WeaponType + "\n\n\n";
        // �� ������ 0�� �ƴ� ��� ���ڿ��� �߰�
        if (HP != 0)
            text += "�ִ� ü�� :  " + HP.ToString() + "\n\n";
        if (NowHP != 0)
            text += "���� ü�� :  " + NowHP.ToString() + "\n\n";

        if (NormalDamage != 0)
            text += "���� ������ :  " + NormalDamage.ToString() + "\n\n";
        if (MagicDamage != 0)
            text += "���� ������ :  " + MagicDamage.ToString() + "\n\n";

        if (CriticalChance != 0)
            text += "ũ��Ƽ�� Ȯ�� :  " + CriticalChance.ToString() + "\n\n";
        if (CriticalDamage != 0)
            text += "ũ��Ƽ�� ������ :  " + CriticalDamage.ToString() + "\n\n";

        if (AttackSpeed != 0)
            text += "���� �ӵ� :  " + AttackSpeed.ToString() + "\n\n";
        if (MoveSpeed != 0)
            text += "�̵� �ӵ� :  " + MoveSpeed.ToString() + "\n\n";

        if (Reach != 0)
            text += "��Ÿ� :  " + Reach.ToString() + "\n\n";
        if (Range != 0)
            text += "���� :  " + Range.ToString() + "\n\n";
        if (Knockback != 0)
            text += "�˹� :  " + Knockback.ToString() + "\n\n";

        if (LifeSteal != 0)
            text += "ü�� ��� :  " + LifeSteal.ToString() + "\n\n";
        if (healthRegen != 0)
            text += "ü�� �ڿ� ȸ�� :  " + healthRegen.ToString() + "\n\n";
        if (Resurrection != 0)
            text += "��Ȱ :  " + Resurrection.ToString() + "\n\n";
        if (Armor != 0)
            text += "���� :  " + Armor.ToString() + "\n\n";

        if (Luck != 0)
            text += "��� :  " + Luck.ToString() + "\n\n";
        if (ExpGainRate != 0)
            text += "����ġ ȹ��� :  " + ExpGainRate.ToString() + "\n\n";
        if (WeaponExpAdd != 0)
            text += "���� ���õ� :  " + WeaponExpAdd.ToString() + "\n\n";
        if (GodBlessDropRate != 0)
            text += "���ǰ�ȣ ȹ��� :  " + GodBlessDropRate.ToString() + "\n\n";
        if (GoldDropRate != 0)
            text += "��� ȹ��� :  " + GoldDropRate.ToString() + "\n\n";

        if (AddLaunch != 0)
            text += "�߰� �߻�ü :  " + AddLaunch.ToString() + "\n\n";
        if (Bounce != 0)
            text += "ƨ�� :  " + Bounce.ToString() + "\n\n";
        if (Pass != 0)
            text += "���� :  " + Pass.ToString() + "\n\n";
        if (Magnet != 0)
            text += "������ ȹ�� �ݰ� :  " + Magnet.ToString() + "\n\n";

        if (AddSpawn != 0)
            text += "�� ���� Ȯ�� :  " + AddSpawn.ToString() + "%\n\n";


        if (TogetherItemAttackSpeedBuff != 0)
            text += "���� ���� ���ݼӵ� ���� :  " + TogetherItemAttackSpeedBuff.ToString() + "%\n\n";
        if (TogetherItemCriticalChanceBuff != 0)
            text += "���� ���� ũ��Ƽ�� Ȯ�� ���� :  " + TogetherItemCriticalChanceBuff.ToString() + "%\n\n";
        if (TogetherItemLifeStealBuff != 0)
            text += "���� ���� ü�� ��� :  " + TogetherItemLifeStealBuff.ToString() + "%\n\n";


        if (ExpGainLimit != 0)
            text += TimeLimit.ToString() + "�� ���� ����ġ ȹ��� " + ExpGainLimit.ToString() + "% ���\n\n";
        if (MoveSpeedLimit != 0)
            text += TimeLimit.ToString() + "�� ���� �̵� �ӵ� " + MoveSpeedLimit.ToString() + "% ���\n\n";
        if (AddSlotint)
            text += "�κ��丮 ���� ���� :  +2" + "\n\n";


        if (WeaponAttack != 0)
            text += "���ݷ� :  " + WeaponAttack.ToString() + "\n\n";
        if (WeaponCriticalChance != 0)
            text += "ũ��Ƽ�� Ȯ�� :  " + WeaponCriticalChance.ToString() + "%\n\n";
        if (WeaponCriticalDamage != 0)
            text += "ũ��Ƽ�� ������ :  " + WeaponCriticalDamage.ToString() + "%\n\n";
        if (WeaponSpeed != 0)
            text += "���� �ӵ� :  " + WeaponSpeed.ToString() + "\n\n";
        if (WeaponReach != 0)
            text += "��Ÿ� :  " + WeaponReach.ToString() + "\n\n";
        if (WeaponKnockBack != 0)
            text += "�˹� :  " + WeaponKnockBack.ToString() + "\n\n\n";
        if (WeaponExp != 0)
            text += "���õ� :  " + WeaponExp.ToString() + "\n\n";

        if (transform.parent != null)
        {
            if (transform.parent.gameObject.layer == LayerMask.NameToLayer("Store"))
            {
                if (Price != 0)
                    text += "\n���� ���� :  " + Price;
            }
            else if (transform.parent.gameObject.layer != LayerMask.NameToLayer("Store"))
            {
                if (Price != 0)
                    text += "\nȯ�� �ݾ� :  " + (int)(Price * 0.7f);
            }
        }

        // �ؽ�Ʈ �ʵ忡 ���ڿ� ǥ��
        if (text.Length > 0)
        {
            textField.text = text;
        }
    }
}
