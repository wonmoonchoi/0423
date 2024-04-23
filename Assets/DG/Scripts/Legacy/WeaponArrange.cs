using UnityEngine;

public class WeaponArrange : MonoBehaviour
{
    int count = 8;

    void Start()
    {
        ArrangeMent();
    }

    void Update()
    {
        
    }

    void ArrangeMent()
    {
        for(int index = 0; index < count; index++)
        {
            Transform weapon = GameManager.instance.pool.Get(1).transform;
            weapon.parent = transform;

            Vector3 rotVec = Vector3.forward * 360 * index / count;
            weapon.Rotate(rotVec);
            weapon.Translate(weapon.up * 1.5f, Space.World);
            //weapon.GetComponent<MeleeWeapon>().Init(damage, -1);
        }
    }
}
