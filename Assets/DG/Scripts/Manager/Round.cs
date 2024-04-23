using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Monobehivor 가 없는 일반 클래스 */

public class Round
{
    public int roundLevel = 1;

    public List<IEnumerator> ronudList = new List<IEnumerator>();
    /* IEnum형 리스트를 만든 뒤에 */

    public Round() /* 생성자로 라운드 정보를 초기화 */
    {
        ronudList.Add(Round_01());
        ronudList.Add(Round_02());
        ronudList.Add(Round_03());
        ronudList.Add(Round_04());
    }

    /* 아래는 해당 라운드 정보들을 정의 */
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
