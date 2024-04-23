using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Unity.Jobs;
using Unity.VisualScripting;
//using UnityEditor.Build.Content;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//using static UnityEditor.Progress;

public class PickUpDown : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Transform MainSlot; // 커서 좌표로 움직일 오브젝트
    Vector3 pos; // 마우스 좌표 구할때 사용
    Vector3 ItemPos; // 아이템 원래 좌표
    [HideInInspector] public bool Drag = false;
    [HideInInspector] public bool DragEnd;

    private List<GameObject> FoundObjects; // 거리 계산할 오브젝트들 배열에 넣는 용도
    public GameObject Slot; // 가장 가까운 오브젝트명
    public GameObject Slot2;
    public string TagName; // 거리 계산할 오브젝트 태그 입력
    private float shortDis; // 가장 가까운 오브젝트와의 거리

    private int CountCheck; // 자식 숫자 체크

    public bool Equip; // 장착 체크

    [HideInInspector] public bool Rotate; // 회전 체크
    [HideInInspector] public bool SlotYes;
    public GameObject[] slot;
    public bool FinalCheckM;
    public bool[] CheckList;

    public GameObject Highlight;
    public GameObject HighlightNull;

    public Tooltip TooltipScript;
    public Combination CombinationScript;
    public Sell SellScript;
    public UseBtn UseBtn;
    public GameObject Canvas;
    public GameObject ImageObject;
    public GameObject LockImage;
    public GameObject Stat;
    public SlotToolTip SlotStats;
    public int Upgrade = 1;
    public PlayerStats2 playerStats;

    public Transform Store;
    public Store store;

    public int saveObjectCount = 0;

    Vector3 NoRotate;

    public List<GameObject> Saves = new List<GameObject>();
    public GameObject SavePrefeb;
    public Vector3[] SavePos = new Vector3[2];

    public Gold Gold;

    public bool PickUpCheck;

    public bool Lock = false;

    public AddButton AddButton;

    public ItemTear ItemTear;

    public GameObject BlockImage;

    public bool ch;

    public int SubSlotCountCheck;

    public List<GameObject> SubSlot = new List<GameObject>();
    //********************************************************************************************************************************************

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
            Start();
        }
    }



    void Start()
    {
        if (AddButton == null)
        {
            AddButton = GameObject.Find("AddButton").GetComponent<AddButton>();
        }
        ItemPos = transform.position; // 원래 좌표 저장용
        if (Canvas == null)
        {
            Canvas = GameObject.Find("Canvas");
        }
        Transform tooltipTransform = Canvas.transform.Find("Tooltip");
        Transform PSTransform = Canvas.transform.Find("PlayerStats");
        Transform goldTransform = Canvas.transform.Find("Gold");
        if (Gold == null)
        {
            Gold = goldTransform.GetComponent<Gold>();
        }
        if (Stat == null)
        {
            Transform StatTransform = PSTransform.Find("Stats");
            if (StatTransform != null)
            {
                Stat = StatTransform.gameObject;
                playerStats = Stat.GetComponent<PlayerStats2>();
            }
        }
        SlotStats = GetComponent<SlotToolTip>();
        if (TooltipScript == null)
        {
            TooltipScript = tooltipTransform.GetComponent<Tooltip>();
        }
        if (ImageObject == null)
        {
            Transform imageTransform = tooltipTransform.Find("Image");
            if (imageTransform != null)
            {
                // Image 오브젝트를 변수에 할당합니다.
                ImageObject = imageTransform.gameObject;
            }
        }
        if (LockImage == null)
        {
            Transform lockTransform = tooltipTransform.Find("LockImage");
            if (lockTransform != null)
            {
                LockImage = lockTransform.gameObject;
            }
        }
        if (ItemTear == null)
        {
            Transform itemtearTransform = tooltipTransform.Find("ItemTear");
            ItemTear = itemtearTransform.GetComponent<ItemTear>();
        }
        if (CombinationScript == null)
        {
            Transform combinationTransform = tooltipTransform.Find("Combination");
            CombinationScript = combinationTransform.GetComponent<Combination>();
        }
        if (SellScript == null)
        {
            Transform sellTransform = tooltipTransform.Find("Sell");
            SellScript = sellTransform.GetComponent<Sell>();
        }
        if (UseBtn == null)
        {
            Transform usebtnTransform = tooltipTransform.Find("UseBtn");
            UseBtn = usebtnTransform.GetComponent<UseBtn>();
        }
        NoRotate = transform.eulerAngles;
        if (store == null)
        {
            store = GameObject.Find("StoreItemCreate").GetComponent<Store>();
        }
        Saverota();
    }
    //********************************************************************************************************************************************
    void Update()
    {
        if (Drag)
        {
            DragON();
        }
        else if (DragEnd)
        {
            DragOFF();
        }
    }
    //********************************************************************************************************************************************
    public void DragON() // 오브젝트가 커서 좌표대로 이동
    {
        pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 9f));

        if (MainSlot != null)
            MainSlot.position = pos;

        Rotate = true;
        Equip = false;

        //********************************************************************************************************************************************

        Transform parentTransform = transform.parent; // 오브젝트 드래그시 인벤슬롯에서 빠져나옴

        if (parentTransform != null)
        {
            // 부모를 제거하여 현재 오브젝트를 최상위 레벨로 이동시킵니다.
            transform.parent = null;
        }

        //********************************************************************************************************************************************

        FoundObjects = new List<GameObject>(GameObject.FindGameObjectsWithTag(TagName)); // 해당 오브젝트와 가장 가까운 TagName 입력한 오브젝트를 찾아주고 그 거리수치가 shortDis
        shortDis = Vector3.Distance(gameObject.transform.position, FoundObjects[0].transform.position);

        Slot = FoundObjects[0];

        foreach (GameObject found in FoundObjects)
        {
            float Distance = Vector3.Distance(gameObject.transform.position, found.transform.position);

            if (Distance < shortDis)
            {
                Slot = found;
                shortDis = Distance;
            }
        }
        if (Slot.name == "Save")
        {
            int saveLayer = LayerMask.NameToLayer("Save");

            // 씬에서 모든 GameObject를 가져옵니다.
            GameObject[] allObjects = GameObject.FindObjectsOfType<GameObject>();

            // "Save" 레이어를 가진 GameObject 개수를 저장할 변수를 초기화합니다.
            saveObjectCount = 0;

            // 모든 GameObject를 반복하면서 "Save" 레이어를 가진 경우 개수를 세어봅니다.
            foreach (GameObject obj in allObjects)
            {
                if (obj.layer == saveLayer)
                {
                    saveObjectCount++;
                }
            }

            // "Save" 레이어를 가진 GameObject가 1개인 경우에만 실행합니다.
            if (saveObjectCount == 1 && Slot2 != null && Slot2.layer == LayerMask.NameToLayer("Slot"))
            {
                if ((ch && Mathf.Abs(transform.rotation.z) == 0.7071068f) || ch == false)
                {
                    foreach (Transform child in transform)
                    {
                        if (child.CompareTag("Sub"))
                        {
                            Vector3 childPosition = child.position - transform.position;
                            GameObject instance = Instantiate(SavePrefeb, Slot.transform.position + childPosition, Quaternion.identity);
                            Saves.Add(instance);
                        }
                    }
                }
            }
        }
        //********************************************************************************************************************************************

        if ((Highlight != null) && (HighlightNull == null))
        {
            HighlightNull = Instantiate(Highlight);
        }
        if (shortDis <= 1.1)
        {
            if (!HighlightNull.activeSelf)
            {
                HighlightNull.SetActive(true);
            }
            HighlightNull.transform.position = Slot.transform.position;
        }
        else if (shortDis > 1.1)
        {
            HighlightNull.SetActive(false);
        }
    }
    //********************************************************************************************************************************************

    public void DragOFF() // 오브젝트를 내려놨을때
    {
        if (DragEnd) // 놨을시
        {
            if (PickUpCheck)
            {
                SonArray();
                if (Slot2 != null && Slot2.layer == LayerMask.NameToLayer("Slot"))
                {
                    ModifyPlayerStats(playerStats, SlotStats, '-');
                }
                Rotate = false;
                if ((Slot.transform.childCount == 0 && shortDis <= 1.1 && FinalCheckM && Slot2 != null && SubSlotChildCheck() && SonPos())
                    || (Gold.Money >= SlotStats.Price && (Slot.transform.childCount == 0) && (shortDis <= 1.1) && FinalCheckM) && SubSlotChildCheck() && SonPos()) // 외부 스크립트 접근 자식이 1미만일때 
                {
                    if (Slot2 == null && Gold.Money >= SlotStats.Price)
                    {
                        Gold.Money -= SlotStats.Price;
                        Gold.Start();
                    }
                    transform.position = Slot.transform.position; // 가장 가까운 오브젝트 변수(Slot)의 좌표로 이동
                    ItemPos = Slot.transform.position; // 이동한 좌표 ItemPos 에 저장
                    transform.parent = Slot.transform; // 해당 슬롯의 자식으로 들어감
                    Slot2 = Slot;
                    SlotYes = true;
                    Store = transform.parent;
                    NoRotate = transform.eulerAngles;
                }
                else
                {

                    transform.position = ItemPos; // 먼 거리일시 원래 저장된 좌표로 복귀
                    SlotYes = false;
                    transform.parent = Store;
                    transform.eulerAngles = NoRotate;
                }
                if (HighlightNull != null)
                {
                    HighlightNull.transform.position = transform.position;
                    Destroy(HighlightNull);
                }
                Equip = true;
                FinalCheckM = false;
                if (Slot2 != null && Slot2.layer == LayerMask.NameToLayer("Slot"))
                {
                    ModifyPlayerStats(playerStats, SlotStats, '+');
                }
                if (SlotStats != null)
                {
                    SlotStats.text();
                }
                if (ItemTear != null)
                {
                    ItemTear.Itemtear(Upgrade);
                }
            }
            if (Store.gameObject.layer != LayerMask.NameToLayer("Store"))
            {
                if (store.CreateItem.Contains(gameObject))
                {
                    store.CreateItem.Remove(gameObject);
                }
            }
            PickUpCheck = false;
            if (Slot2 != null && Slot2.layer != LayerMask.NameToLayer("Save"))
            {
                foreach (var save in Saves)
                {
                    Destroy(save);
                }
                Saves.Clear();
            }

        }
    }

    //********************************************************************************************************************************************
    public void OnPointerDown(PointerEventData eventData) // 해당 오브젝트에 마우스 클릭시
    {
        if (AddButton.PickUp)
        {
            if (eventData.button == PointerEventData.InputButton.Left)
            {
                if (Drag) // 픽다운
                {
                    TooltipScript.gameObject.SetActive(true);
                    if (gameObject.layer == LayerMask.NameToLayer("Weapon"))
                    {
                        CombinationScript.gameObject.SetActive(true);
                    }
                    if (gameObject.layer == LayerMask.NameToLayer("Potion"))
                    {
                        UseBtn.gameObject.SetActive(true);
                    }
                    SellScript.gameObject.SetActive(true);
                    TooltipScript.Stop = true;
                    Drag = false;
                    DragEnd = true;
                    TooltipScript.UIstop = false;
                    PickUpCheck = true;
                }
                else if (Drag == false) // 픽업
                {
                    CombinationScript.gameObject.transform.SetParent(TooltipScript.gameObject.transform);
                    SellScript.gameObject.transform.SetParent(TooltipScript.gameObject.transform);
                    UseBtn.gameObject.transform.SetParent(TooltipScript.gameObject.transform);
                    TooltipScript.gameObject.SetActive(false);
                    CombinationScript.gameObject.SetActive(false);
                    SellScript.gameObject.SetActive(false);
                    UseBtn.gameObject.SetActive(false);
                    CombinationScript.Items.Remove(gameObject);
                    TooltipScript.Stop = true;
                    Drag = true;
                    DragEnd = false;
                    TooltipScript.UIstop = false;
                }
            }
            if (Rotate) // 드래그 상태일시 회전가능
            {
                if (eventData.button == PointerEventData.InputButton.Right)
                {
                    // 현재 회전 각도를 저장합니다.
                    Vector3 currentRotation = transform.eulerAngles;
                    // y축 회전 각도를 90도씩 추가합니다.
                    currentRotation.z += -90f;
                    // 새로운 회전 각도를 설정합니다.
                    transform.eulerAngles = currentRotation;
                }
            }
            else if ((Rotate == false) && (Slot2 != null))
            {
                if (eventData.button == PointerEventData.InputButton.Right)
                {
                    TooltipScript.Stop = false;
                    CombinationScript.gameObject.transform.SetParent(Canvas.transform);
                    SellScript.gameObject.transform.SetParent(Canvas.transform);
                    UseBtn.gameObject.transform.SetParent(Canvas.transform);
                    CombinationScript.Item = gameObject;
                    UseBtn.Item = gameObject;
                    SellScript.Item = gameObject;
                    TooltipScript.UIstop = true;
                }
            }
            if (Rotate == false && Slot2 == null && eventData.button == PointerEventData.InputButton.Right)
            {
                Lock = !Lock;
                if (LockImage != null)
                {
                    Image image = LockImage.GetComponent<Image>();
                    if (image != null)
                    {
                        Color color = image.color;

                        // 알파 값을 설정합니다.
                        color.a = Lock ? 255f : 0f;

                        // 변경된 color 값을 Image 컴포넌트에 다시 할당합니다.
                        image.color = color;
                        TooltipScript.gameObject.SetActive(false);
                    }
                }
                TooltipScript.gameObject.SetActive(true);
            }
        }
    }
    public bool SubSlotChildCheck()
    {
        SubSlotCountCheck = 0;
        if (transform.childCount > 1)
        {
            GameObject[] SubSlot = new GameObject[transform.childCount];
            for (int i = 1; i < transform.childCount; i++)
            {
                SubSlot[i] = transform.GetChild(i).gameObject;
                SlotParent slotParent = SubSlot[i].GetComponent<SlotParent>();
                if (slotParent.Slot.transform.childCount == 0)
                {
                    SubSlotCountCheck++;
                }
            }
        }
        if (SubSlotCountCheck == transform.childCount - 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void Saverota()
    {
        if (transform.childCount > 1)
        {
            int childCount = transform.childCount;
            GameObject[] slottt = new GameObject[childCount];
            ch = false;
            for (int i = 1; i < childCount; i++)
            {
                slottt[i] = transform.GetChild(i).gameObject;
                if (slottt[i].transform.localPosition.y > 3.4)
                {
                    ch = true;
                }
            }
        }
    }
    public void Sach()
    {
        int childCount = transform.childCount;
        GameObject[] slott = new GameObject[childCount];
        int Check = 0;

        slott[1] = transform.GetChild(1).gameObject;
        SlotParent slotParent = slott[1].GetComponent<SlotParent>();
        if (Slot.layer == slotParent.Slot.layer)
        {
            if (childCount <= 2)
            {
                // return true;
            }
            for (int i = 2; i < childCount; i++)
            {
                slott[i] = transform.GetChild(i).gameObject;
                slotParent = slott[i].GetComponent<SlotParent>();
                for (int j = 3; j < childCount; j++)
                {
                    if (slott[i].layer == slotParent.Slot.layer)
                    {
                        Check++;
                    }
                }
            }
        }
    }
    public bool SonPos()
    {
        if (transform.childCount > 1)
        {
            int childCount = transform.childCount;
            GameObject[] slott = new GameObject[childCount];
            int Check = 0;
            for (int i = 1; i < childCount; i++)
            {
                slott[i] = transform.GetChild(i).gameObject;
                SlotParent slotParent = slott[i].GetComponent<SlotParent>();
                if (slotParent.Pos() == 0 || slotParent.Slot.layer == LayerMask.NameToLayer("Save"))
                {
                    Check++;
                }
            }
            if ((Check == childCount - 1))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else if (transform.childCount == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void SonArray()
    {
        if (transform.childCount > 1)
        {
            int childCount = transform.childCount;
            slot = new GameObject[childCount];
            int Check = 0;
            int Check2 = 0;
            // 각 자식 오브젝트를 순회합니다.
            for (int i = 1; i < childCount; i++)
            {
                // 현재 자식 오브젝트를 배열에 할당합니다.
                slot[i] = transform.GetChild(i).gameObject;

                // 자식 오브젝트의 SlotParent 컴포넌트를 가져옵니다.
                SlotParent slotParent = slot[i].GetComponent<SlotParent>();
                for (int j = 2; j < childCount; j++)
                {
                    GameObject[] slot2 = new GameObject[childCount];
                    slot2[j] = transform.GetChild(j).gameObject;
                    SlotParent slotParent2 = slot2[j].GetComponent<SlotParent>();
                    if ((slotParent.Slot == slotParent2.Slot) && i != j)
                    {
                        Check2++;
                    }
                }
                if ((slotParent != null) && (slotParent.Slot != null) && (slotParent.Slot != Slot) && (slotParent.DisCheckS))
                {
                    Check += 1;
                }
            }
            if ((Check == (childCount - 1)) && Check2 == 0)
            {
                FinalCheckM = true;
            }
            else if (Check != (childCount - 1))
            {
                FinalCheckM = false;
            }
        }
        else if (transform.childCount == 1)
        {
            FinalCheckM = true;
        }
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        if (TooltipScript != null)
        {
            if (TooltipScript.UIstop == false)
            {
                if (TooltipScript.Stop)
                {
                    TooltipScript.gameObject.transform.position = new Vector3(2200, 850, 0);
                    TooltipScript.gameObject.SetActive(false);
                    CombinationScript.gameObject.SetActive(false);
                    UseBtn.gameObject.SetActive(false);
                    SellScript.gameObject.SetActive(false);
                    TooltipScript.Stop = false;
                }
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (AddButton.PickUp)
        {
            if (TooltipScript != null)
            {
                if (TooltipScript.UIstop == false)
                {
                    if (Equip) // 슬롯에 안착했을때
                    {
                        if (SlotStats != null)
                        {
                            SlotStats.text();
                        }
                        if (ItemTear != null)
                        {
                            ItemTear.Itemtear(Upgrade);
                        }
                        if (LockImage != null)
                        {
                            Image image = LockImage.GetComponent<Image>();
                            if (image != null)
                            {
                                if (Lock)
                                {
                                    Color color = image.color;

                                    // 알파 값을 0으로 설정합니다.
                                    color.a = 255f;

                                    // 변경된 color 값을 Image 컴포넌트에 다시 할당합니다.
                                    image.color = color;
                                }
                                else if (Lock == false)
                                {
                                    Color color = image.color;

                                    // 알파 값을 0으로 설정합니다.
                                    color.a = 0f;

                                    // 변경된 color 값을 Image 컴포넌트에 다시 할당합니다.
                                    image.color = color;
                                }
                            }
                        }
                        CombinationScript.gameObject.transform.SetParent(TooltipScript.gameObject.transform); // 버튼 2개가 툴팁의 자식으로 돌아감
                        SellScript.gameObject.transform.SetParent(TooltipScript.gameObject.transform);
                        UseBtn.gameObject.transform.SetParent(TooltipScript.gameObject.transform);
                        TooltipScript.Stop = true; // 툴팁이 움직임
                        TooltipScript.gameObject.SetActive(true); // UI 오브젝트들 활성화
                        SellScript.gameObject.SetActive(true);
                        if (gameObject.layer == LayerMask.NameToLayer("Weapon"))
                        {
                            CombinationScript.gameObject.SetActive(true);
                        }
                        if (gameObject.layer == LayerMask.NameToLayer("Potion"))
                        {
                            UseBtn.gameObject.SetActive(true);
                        }
                        InputImage();
                    }
                }
            }
        }
    }
    public void InputImage()
    {
        BlockImage = GameObject.Find(gameObject.tag);
        GameObject childObject = BlockImage;
        SpriteRenderer spriteRenderer = childObject.GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            if (ImageObject != null)
            {
                // Image 오브젝트의 Image 컴포넌트를 가져옵니다.
                Image image = ImageObject.GetComponent<Image>();

                // Image 컴포넌트가 null이 아니라면 가져온 컴포넌트를 사용합니다.
                if (image != null)
                {
                    image.sprite = spriteRenderer.sprite;
                }
            }
        }
    }
    public void ModifyPlayerStats(PlayerStats2 playerStats, SlotToolTip SlotStats, char operation)
    {
        if (playerStats != null && SlotStats != null)
        {
            if (operation == '+')
            {
                playerStats.HP += SlotStats.HP;
                playerStats.NowHP += SlotStats.NowHP;

                playerStats.NormalDamage += SlotStats.NormalDamage;
                playerStats.MagicDamage += SlotStats.MagicDamage;

                playerStats.CriticalChance += SlotStats.CriticalChance;
                playerStats.CriticalDamage += SlotStats.CriticalDamage;

                playerStats.AttackSpeed += SlotStats.AttackSpeed;
                playerStats.MoveSpeed += SlotStats.MoveSpeed;

                playerStats.Reach += SlotStats.Reach;
                playerStats.Range += SlotStats.Range;
                playerStats.Knockback += SlotStats.Knockback;

                playerStats.LifeSteal += SlotStats.LifeSteal;
                playerStats.healthRegen += SlotStats.healthRegen;
                playerStats.Resurrection += SlotStats.Resurrection;
                playerStats.Armor += SlotStats.Armor;

                playerStats.Luck += SlotStats.Luck;
                playerStats.ExpGainRate += SlotStats.ExpGainRate;
                playerStats.WeaponExpAdd += SlotStats.WeaponExpAdd;
                playerStats.GodBlessDropRate += SlotStats.GodBlessDropRate;
                playerStats.GoldDropRate += SlotStats.GoldDropRate;

                playerStats.AddLaunch += SlotStats.AddLaunch;
                playerStats.Bounce += SlotStats.Bounce;
                playerStats.Pass += SlotStats.Pass;
                playerStats.Magnet += SlotStats.Magnet;
            }
            else if (operation == '-')
            {
                playerStats.HP -= SlotStats.HP;
                playerStats.NowHP -= SlotStats.NowHP;

                playerStats.NormalDamage -= SlotStats.NormalDamage;
                playerStats.MagicDamage -= SlotStats.MagicDamage;

                playerStats.CriticalChance -= SlotStats.CriticalChance;
                playerStats.CriticalDamage -= SlotStats.CriticalDamage;

                playerStats.AttackSpeed -= SlotStats.AttackSpeed;
                playerStats.MoveSpeed -= SlotStats.MoveSpeed;

                playerStats.Reach -= SlotStats.Reach;
                playerStats.Range -= SlotStats.Range;
                playerStats.Knockback -= SlotStats.Knockback;

                playerStats.LifeSteal -= SlotStats.LifeSteal;
                playerStats.healthRegen -= SlotStats.healthRegen;
                playerStats.Resurrection -= SlotStats.Resurrection;
                playerStats.Armor -= SlotStats.Armor;

                playerStats.Luck -= SlotStats.Luck;
                playerStats.ExpGainRate -= SlotStats.ExpGainRate;
                playerStats.WeaponExpAdd -= SlotStats.WeaponExpAdd;
                playerStats.GodBlessDropRate -= SlotStats.GodBlessDropRate;
                playerStats.GoldDropRate -= SlotStats.GoldDropRate;

                playerStats.AddLaunch -= SlotStats.AddLaunch;
                playerStats.Bounce -= SlotStats.Bounce;
                playerStats.Pass -= SlotStats.Pass;
                playerStats.Magnet -= SlotStats.Magnet;
            }
            playerStats.Start();
        }
    }
}
