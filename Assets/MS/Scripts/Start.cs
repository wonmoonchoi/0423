using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Start : MonoBehaviour
{
    public WeaponData WeaponData;
    public PlayerStatData PlayerStatData;
    public PlayerStats2 PlayerStats2;
    public GameObject[] Slot;
    public void OnClickButton()
    {
        if(WeaponData == null)
        {
            WeaponData = GameObject.Find("WeaponData").GetComponent<WeaponData>();
        }
        if(PlayerStatData == null)
        {
            PlayerStatData = GameObject.Find("PlayerStatData").GetComponent<PlayerStatData>();
        }
        if(PlayerStats2 == null)
        {
            GameObject Canvas = GameObject.Find("Canvas");
            UnityEngine.Transform PlayerStatsTransform = Canvas.transform.Find("PlayerStats");
            UnityEngine.Transform PlayerStats2Transform = PlayerStatsTransform.Find("Stats");
            PlayerStats2 = PlayerStats2Transform.gameObject.GetComponent<PlayerStats2>();
        }
        WeaponData.WeaponList.Clear();
        Slot = GameObject.FindObjectsOfType<GameObject>().Where(obj => obj.layer == LayerMask.NameToLayer("Slot")).ToArray();

        foreach (GameObject obj in Slot)
        {
            if (obj.transform.childCount > 0)
            {
                if (obj.transform.GetChild(0).gameObject.layer == LayerMask.NameToLayer("Weapon"))
                {
                    WeaponData.WeaponList.Add(obj.transform.GetChild(0).gameObject);
                }
            }
            DontDestroyOnLoad(obj);
        }
        PlayerStatData.HP = PlayerStats2.HP;
        PlayerStatData.NowHP = PlayerStats2.NowHP;

        PlayerStatData.NormalDamage = PlayerStats2.NormalDamage;
        PlayerStatData.MagicDamage = PlayerStats2.MagicDamage;

        PlayerStatData.CriticalChance = PlayerStats2.CriticalChance;
        PlayerStatData.CriticalDamage = PlayerStats2.CriticalDamage;

        PlayerStatData.AttackSpeed = PlayerStats2.AttackSpeed;
        PlayerStatData.MoveSpeed = PlayerStats2.MoveSpeed;

        PlayerStatData.Reach = PlayerStats2.Reach;
        PlayerStatData.Range = PlayerStats2.Range;
        PlayerStatData.Knockback = PlayerStats2.Knockback;

        PlayerStatData.LifeSteal = PlayerStats2.LifeSteal;
        PlayerStatData.healthRegen = PlayerStats2.healthRegen;
        PlayerStatData.Resurrection = PlayerStats2.Resurrection;
        PlayerStatData.Armor = PlayerStats2.Armor;

        PlayerStatData.Luck = PlayerStats2.Luck;
        PlayerStatData.ExpGainRate = PlayerStats2.ExpGainRate;
        PlayerStatData.WeaponExp = PlayerStats2.WeaponExpAdd;
        PlayerStatData.GodBlessDropRate = PlayerStats2.GodBlessDropRate;
        PlayerStatData.GoldDropRate = PlayerStats2.GoldDropRate;

        PlayerStatData.AddLaunch = PlayerStats2.AddLaunch;
        PlayerStatData.Bounce = PlayerStats2.Bounce;
        PlayerStatData.Pass = PlayerStats2.Pass;
        PlayerStatData.Magnet = PlayerStats2.Magnet;

        DontDestroyOnLoad(PlayerStatData.gameObject);
        DontDestroyOnLoad(WeaponData.gameObject);

        SceneManager.LoadScene("INGAME");
        Time.timeScale = 1f;
    }
}