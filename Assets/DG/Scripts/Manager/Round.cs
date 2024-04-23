using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Monobehivor �� ���� �Ϲ� Ŭ���� */

public class Round
{
    public int roundLevel = 1;

    public List<IEnumerator> ronudList = new List<IEnumerator>();
    /* IEnum�� ����Ʈ�� ���� �ڿ� */

    public Round() /* �����ڷ� ���� ������ �ʱ�ȭ */
    {
        ronudList.Add(Round_01());
        ronudList.Add(Round_02());
        ronudList.Add(Round_03());
        ronudList.Add(Round_04());
    }

    /* �Ʒ��� �ش� ���� �������� ���� */
    public IEnumerator Round_01()
    {
        while (GameManager.instance.player._level == 1)
        {
            GameManager.instance.spawner.Spawn0();

            yield return new WaitForSeconds(1.2f);
        }

        yield return null;
    }
    
    public IEnumerator Round_02()
    {
        while (GameManager.instance.player._level == 2)
        {
            GameManager.instance.spawner.Spawn1();

            yield return new WaitForSeconds(1.2f);
        }

        yield return null;
    }

    public IEnumerator Round_03()
    {
        while (GameManager.instance.player._level == 3)
        {
            GameManager.instance.spawner.Spawn2();

            yield return new WaitForSeconds(1.2f);
        }

        yield return null;
    }
    
    public IEnumerator Round_04()
    {
        while (GameManager.instance.player._level == 4)
        {
            GameManager.instance.spawner.Spawn0();

            yield return new WaitForSeconds(1.2f);
        }

        yield return null;
    }
}
