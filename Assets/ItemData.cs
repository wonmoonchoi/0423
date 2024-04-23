using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemData : MonoBehaviour
{

    public float WeaponAttack;
    public float WeaponCriticalChance;
    public float WeaponCriticalDamage;
    public float WeaponSpeed;
    public float WeaponReach;
    public float WeaponKnockBack;
    public float WeaponExp;

    public void itemdata(GameObject obj)
    {
        SlotToolTip slottooltip = obj.transform.GetComponent<SlotToolTip>();
        PickUpDown pickupdown = obj.transform.GetComponent<PickUpDown>();
        if (slottooltip != null && slottooltip.Name == "나무 도끼" && pickupdown != null)
        {
            if (pickupdown.Upgrade == 2)
            {
                slottooltip.WeaponAttack = 14;
                slottooltip.WeaponCriticalChance = 10;
                slottooltip.WeaponCriticalDamage = 80;
                slottooltip.WeaponSpeed = 1;
                slottooltip.WeaponReach = 100;
                slottooltip.WeaponKnockBack = 3;
            }
            if (pickupdown.Upgrade == 3)
            {
                slottooltip.WeaponAttack = 20;
                slottooltip.WeaponCriticalChance = 10;
                slottooltip.WeaponCriticalDamage = 80;
                slottooltip.WeaponSpeed = 1.2f;
                slottooltip.WeaponReach = 100;
                slottooltip.WeaponKnockBack = 3;
            }
            if (pickupdown.Upgrade == 4)
            {
                slottooltip.WeaponAttack = 25;
                slottooltip.WeaponCriticalChance = 10;
                slottooltip.WeaponCriticalDamage = 80;
                slottooltip.WeaponSpeed = 1.5f;
                slottooltip.WeaponReach = 100;
                slottooltip.WeaponKnockBack = 3;
            }
            if (pickupdown.Upgrade == 5)
            {
                slottooltip.WeaponAttack = 50;
                slottooltip.WeaponCriticalChance = 20;
                slottooltip.WeaponCriticalDamage = 120;
                slottooltip.WeaponSpeed = 1.8f;
                slottooltip.WeaponReach = 150;
                slottooltip.WeaponKnockBack = 4;
            }
        }

        ///////////////////////////////////////////////

        if (slottooltip != null && slottooltip.Name == "나무 활" && pickupdown != null)
        {
            if (pickupdown.Upgrade == 2)
            {
                slottooltip.WeaponAttack = 8;
                slottooltip.WeaponCriticalChance = 10;
                slottooltip.WeaponCriticalDamage = 80;
                slottooltip.WeaponSpeed = 0.8f;
                slottooltip.WeaponReach = 250;
                slottooltip.WeaponKnockBack = 1;
            }
            if (pickupdown.Upgrade == 3)
            {
                slottooltip.WeaponAttack = 10;
                slottooltip.WeaponCriticalChance = 10;
                slottooltip.WeaponCriticalDamage = 80;
                slottooltip.WeaponSpeed = 1f;
                slottooltip.WeaponReach = 250;
                slottooltip.WeaponKnockBack = 1;
            }
            if (pickupdown.Upgrade == 4)
            {
                slottooltip.WeaponAttack = 15;
                slottooltip.WeaponCriticalChance = 10;
                slottooltip.WeaponCriticalDamage = 80;
                slottooltip.WeaponSpeed = 1.2f;
                slottooltip.WeaponReach = 250;
                slottooltip.WeaponKnockBack = 1;
            }
            if (pickupdown.Upgrade == 5)
            {
                slottooltip.WeaponAttack = 20;
                slottooltip.WeaponCriticalChance = 15;
                slottooltip.WeaponCriticalDamage = 120;
                slottooltip.WeaponSpeed = 1.5f;
                slottooltip.WeaponReach = 300;
                slottooltip.WeaponKnockBack = 2;
            }
        }

        ///////////////////////////////////////////////

        if (slottooltip != null && slottooltip.Name == "나무 단검" && pickupdown != null)
        {
            if (pickupdown.Upgrade == 2)
            {
                slottooltip.WeaponAttack = 10;
                slottooltip.WeaponCriticalChance = 20;
                slottooltip.WeaponCriticalDamage = 120;
                slottooltip.WeaponSpeed = 1.2f;
                slottooltip.WeaponReach = 200;
                slottooltip.WeaponKnockBack = 1;
            }
            if (pickupdown.Upgrade == 3)
            {
                slottooltip.WeaponAttack = 12;
                slottooltip.WeaponCriticalChance = 20;
                slottooltip.WeaponCriticalDamage = 120;
                slottooltip.WeaponSpeed = 1.5f;
                slottooltip.WeaponReach = 200;
                slottooltip.WeaponKnockBack = 1;
            }
            if (pickupdown.Upgrade == 4)
            {
                slottooltip.WeaponAttack = 15;
                slottooltip.WeaponCriticalChance = 20;
                slottooltip.WeaponCriticalDamage = 120;
                slottooltip.WeaponSpeed = 2;
                slottooltip.WeaponReach = 200;
                slottooltip.WeaponKnockBack = 1;
            }
            if (pickupdown.Upgrade == 5)
            {
                slottooltip.WeaponAttack = 20;
                slottooltip.WeaponCriticalChance = 25;
                slottooltip.WeaponCriticalDamage = 150;
                slottooltip.WeaponSpeed = 2;
                slottooltip.WeaponReach = 250;
                slottooltip.WeaponKnockBack = 2;
            }
        }

        ///////////////////////////////////////////////

        if (slottooltip != null && slottooltip.Name == "나무 쌍검" && pickupdown != null)
        {
            if (pickupdown.Upgrade == 2)
            {
                slottooltip.WeaponAttack = 16;
                slottooltip.WeaponCriticalChance = 30;
                slottooltip.WeaponCriticalDamage = 120;
                slottooltip.WeaponSpeed = 1.6f;
                slottooltip.WeaponReach = 100;
                slottooltip.WeaponKnockBack = 2;
            }
            if (pickupdown.Upgrade == 3)
            {
                slottooltip.WeaponAttack = 20;
                slottooltip.WeaponCriticalChance = 30;
                slottooltip.WeaponCriticalDamage = 120;
                slottooltip.WeaponSpeed = 1.8f;
                slottooltip.WeaponReach = 100;
                slottooltip.WeaponKnockBack = 2;
            }
            if (pickupdown.Upgrade == 4)
            {
                slottooltip.WeaponAttack = 30;
                slottooltip.WeaponCriticalChance = 30;
                slottooltip.WeaponCriticalDamage = 120;
                slottooltip.WeaponSpeed = 1.8f;
                slottooltip.WeaponReach = 100;
                slottooltip.WeaponKnockBack = 2;
            }
            if (pickupdown.Upgrade == 5)
            {
                slottooltip.WeaponAttack = 50;
                slottooltip.WeaponCriticalChance = 30;
                slottooltip.WeaponCriticalDamage = 160;
                slottooltip.WeaponSpeed = 2;
                slottooltip.WeaponReach = 150;
                slottooltip.WeaponKnockBack = 3;
            }
        }
        ///////////////////////////////////////////////

        if (slottooltip != null && slottooltip.Name == "나무 망치" && pickupdown != null)
        {
            if (pickupdown.Upgrade == 2)
            {
                slottooltip.WeaponAttack = 20;
                slottooltip.WeaponCriticalChance = 10;
                slottooltip.WeaponCriticalDamage = 100;
                slottooltip.WeaponSpeed = 1;
                slottooltip.WeaponReach = 150;
                slottooltip.WeaponKnockBack = 3;
            }
            if (pickupdown.Upgrade == 3)
            {
                slottooltip.WeaponAttack = 28;
                slottooltip.WeaponCriticalChance = 10;
                slottooltip.WeaponCriticalDamage = 10;
                slottooltip.WeaponSpeed = 1.2f;
                slottooltip.WeaponReach = 150;
                slottooltip.WeaponKnockBack = 3;
            }
            if (pickupdown.Upgrade == 4)
            {
                slottooltip.WeaponAttack = 38;
                slottooltip.WeaponCriticalChance = 10;
                slottooltip.WeaponCriticalDamage = 100;
                slottooltip.WeaponSpeed = 1.5f;
                slottooltip.WeaponReach = 150;
                slottooltip.WeaponKnockBack = 3;
            }
            if (pickupdown.Upgrade == 5)
            {
                slottooltip.WeaponAttack = 45;
                slottooltip.WeaponCriticalChance = 15;
                slottooltip.WeaponCriticalDamage = 120;
                slottooltip.WeaponSpeed = 1.8f;
                slottooltip.WeaponReach = 200;
                slottooltip.WeaponKnockBack = 4;
            }
        }
        ///////////////////////////////////////////////

        if (slottooltip != null && slottooltip.Name == "나무 곤봉" && pickupdown != null)
        {
            if (pickupdown.Upgrade == 2)
            {
                slottooltip.WeaponAttack = 12;
                slottooltip.WeaponCriticalChance = 15;
                slottooltip.WeaponCriticalDamage = 60;
                slottooltip.WeaponSpeed = 0.8f;
                slottooltip.WeaponReach = 200;
                slottooltip.WeaponKnockBack = 5;
            }
            if (pickupdown.Upgrade == 3)
            {
                slottooltip.WeaponAttack = 16;
                slottooltip.WeaponCriticalChance = 15;
                slottooltip.WeaponCriticalDamage = 60;
                slottooltip.WeaponSpeed = 1;
                slottooltip.WeaponReach = 200;
                slottooltip.WeaponKnockBack = 5;
            }
            if (pickupdown.Upgrade == 4)
            {
                slottooltip.WeaponAttack = 25;
                slottooltip.WeaponCriticalChance = 15;
                slottooltip.WeaponCriticalDamage = 60;
                slottooltip.WeaponSpeed = 1.2f;
                slottooltip.WeaponReach = 200;
                slottooltip.WeaponKnockBack = 5;
            }
            if (pickupdown.Upgrade == 5)
            {
                slottooltip.WeaponAttack = 30;
                slottooltip.WeaponCriticalChance = 20;
                slottooltip.WeaponCriticalDamage = 100;
                slottooltip.WeaponSpeed = 1.5f;
                slottooltip.WeaponReach = 250;
                slottooltip.WeaponKnockBack = 7;
            }
        }
        ///////////////////////////////////////////////

        if (slottooltip != null && slottooltip.Name == "나무 방패" && pickupdown != null)
        {
            if (pickupdown.Upgrade == 2)
            {
                slottooltip.WeaponAttack = 2;
                slottooltip.WeaponCriticalChance = 0;
                slottooltip.WeaponCriticalDamage = 0;
                slottooltip.WeaponSpeed = 0.8f;
                slottooltip.WeaponReach = 80;
                slottooltip.WeaponKnockBack = 6;
            }
            if (pickupdown.Upgrade == 3)
            {
                slottooltip.WeaponAttack = 3;
                slottooltip.WeaponCriticalChance = 0;
                slottooltip.WeaponCriticalDamage = 0;
                slottooltip.WeaponSpeed = 1;
                slottooltip.WeaponReach = 80;
                slottooltip.WeaponKnockBack = 6;
            }
            if (pickupdown.Upgrade == 4)
            {
                slottooltip.WeaponAttack = 4;
                slottooltip.WeaponCriticalChance = 0;
                slottooltip.WeaponCriticalDamage = 0;
                slottooltip.WeaponSpeed = 1.5f;
                slottooltip.WeaponReach = 80;
                slottooltip.WeaponKnockBack = 6;
            }
            if (pickupdown.Upgrade == 5)
            {
                slottooltip.WeaponAttack = 5;
                slottooltip.WeaponCriticalChance = 0;
                slottooltip.WeaponCriticalDamage = 0;
                slottooltip.WeaponSpeed = 1.5f;
                slottooltip.WeaponReach = 100;
                slottooltip.WeaponKnockBack = 8;
            }
        }
        ///////////////////////////////////////////////

        if (slottooltip != null && slottooltip.Name == "목검" && pickupdown != null)
        {
            if (pickupdown.Upgrade == 2)
            {
                slottooltip.WeaponAttack = 12;
                slottooltip.WeaponCriticalChance = 20;
                slottooltip.WeaponCriticalDamage = 80;
                slottooltip.WeaponSpeed = 1.2f;
                slottooltip.WeaponReach = 125;
                slottooltip.WeaponKnockBack = 2;
            }
            if (pickupdown.Upgrade == 3)
            {
                slottooltip.WeaponAttack = 16;
                slottooltip.WeaponCriticalChance = 20;
                slottooltip.WeaponCriticalDamage = 80;
                slottooltip.WeaponSpeed = 1.5f;
                slottooltip.WeaponReach = 125;
                slottooltip.WeaponKnockBack = 2;
            }
            if (pickupdown.Upgrade == 4)
            {
                slottooltip.WeaponAttack = 25;
                slottooltip.WeaponCriticalChance = 20;
                slottooltip.WeaponCriticalDamage = 80;
                slottooltip.WeaponSpeed = 2;
                slottooltip.WeaponReach = 125;
                slottooltip.WeaponKnockBack = 2;
            }
            if (pickupdown.Upgrade == 5)
            {
                slottooltip.WeaponAttack = 30;
                slottooltip.WeaponCriticalChance = 20;
                slottooltip.WeaponCriticalDamage = 120;
                slottooltip.WeaponSpeed = 2;
                slottooltip.WeaponReach = 150;
                slottooltip.WeaponKnockBack = 3;
            }
        }
    }
}
