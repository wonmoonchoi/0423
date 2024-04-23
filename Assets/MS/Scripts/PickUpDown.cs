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
    public Transform MainSlot; // Ŀ�� ��ǥ�� ������ ������Ʈ
    Vector3 pos; // ���콺 ��ǥ ���Ҷ� ���
    Vector3 ItemPos; // ������ ���� ��ǥ
    [HideInInspector] public bool Drag = false;
    [HideInInspector] public bool DragEnd;

    private List<GameObject> FoundObjects; // �Ÿ� ����� ������Ʈ�� �迭�� �ִ� �뵵
    public GameObject Slot; // ���� ����� ������Ʈ��
    public GameObject Slot2;
    public string TagName; // �Ÿ� ����� ������Ʈ �±� �Է�
    private float shortDis; // ���� ����� ������Ʈ���� �Ÿ�

    private int CountCheck; // �ڽ� ���� üũ

    public bool Equip; // ���� üũ

    [HideInInspector] public bool Rotate; // ȸ�� üũ
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
        // SceneManager�� sceneLoaded �̺�Ʈ�� OnSceneLoaded �Լ��� ����մϴ�.
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        // ��ũ��Ʈ�� ��Ȱ��ȭ�Ǹ� �̺�Ʈ�� �����մϴ�.
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // �ε�� ���� �̸��� "INVENTORY"�� ��쿡�� Start �Լ��� ȣ���մϴ�.
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
        ItemPos = transform.position; // ���� ��ǥ �����
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
                // Image ������Ʈ�� ������ �Ҵ��մϴ�.
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
    public void DragON() // ������Ʈ�� Ŀ�� ��ǥ��� �̵�
    {
        pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 9f));

        if (MainSlot != null)
            MainSlot.position = pos;

        Rotate = true;
        Equip = false;

        //********************************************************************************************************************************************

        Transform parentTransform = transform.parent; // ������Ʈ �巡�׽� �κ����Կ��� ��������

        if (parentTransform != null)
        {
            // �θ� �����Ͽ� ���� ������Ʈ�� �ֻ��� ������ �̵���ŵ�ϴ�.
            transform.parent = null;
        }

        //********************************************************************************************************************************************

        FoundObjects = new List<GameObject>(GameObject.FindGameObjectsWithTag(TagName)); // �ش� ������Ʈ�� ���� ����� TagName �Է��� ������Ʈ�� ã���ְ� �� �Ÿ���ġ�� shortDis
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

            // ������ ��� GameObject�� �����ɴϴ�.
            GameObject[] allObjects = GameObject.FindObjectsOfType<GameObject>();

            // "Save" ���̾ ���� GameObject ������ ������ ������ �ʱ�ȭ�մϴ�.
            saveObjectCount = 0;

            // ��� GameObject�� �ݺ��ϸ鼭 "Save" ���̾ ���� ��� ������ ����ϴ�.
            foreach (GameObject obj in allObjects)
            {
                if (obj.layer == saveLayer)
                {
                    saveObjectCount++;
                }
            }

            // "Save" ���̾ ���� GameObject�� 1���� ��쿡�� �����մϴ�.
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

    public void DragOFF() // ������Ʈ�� ����������
    {
        if (DragEnd) // ������
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
                    || (Gold.Money >= SlotStats.Price && (Slot.transform.childCount == 0) && (shortDis <= 1.1) && FinalCheckM) && SubSlotChildCheck() && SonPos()) // �ܺ� ��ũ��Ʈ ���� �ڽ��� 1�̸��϶� 
                {
                    if (Slot2 == null && Gold.Money >= SlotStats.Price)
                    {
                        Gold.Money -= SlotStats.Price;
                        Gold.Start();
                    }
                    transform.position = Slot.transform.position; // ���� ����� ������Ʈ ����(Slot)�� ��ǥ�� �̵�
                    ItemPos = Slot.transform.position; // �̵��� ��ǥ ItemPos �� ����
                    transform.parent = Slot.transform; // �ش� ������ �ڽ����� ��
                    Slot2 = Slot;
                    SlotYes = true;
                    Store = transform.parent;
                    NoRotate = transform.eulerAngles;
                }
                else
                {

                    transform.position = ItemPos; // �� �Ÿ��Ͻ� ���� ����� ��ǥ�� ����
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
    public void OnPointerDown(PointerEventData eventData) // �ش� ������Ʈ�� ���콺 Ŭ����
    {
        if (AddButton.PickUp)
        {
            if (eventData.button == PointerEventData.InputButton.Left)
            {
                if (Drag) // �ȴٿ�
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
                else if (Drag == false) // �Ⱦ�
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
            if (Rotate) // �巡�� �����Ͻ� ȸ������
            {
                if (eventData.button == PointerEventData.InputButton.Right)
                {
                    // ���� ȸ�� ������ �����մϴ�.
                    Vector3 currentRotation = transform.eulerAngles;
                    // y�� ȸ�� ������ 90���� �߰��մϴ�.
                    currentRotation.z += -90f;
                    // ���ο� ȸ�� ������ �����մϴ�.
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

                        // ���� ���� �����մϴ�.
                        color.a = Lock ? 255f : 0f;

                        // ����� color ���� Image ������Ʈ�� �ٽ� �Ҵ��մϴ�.
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
            // �� �ڽ� ������Ʈ�� ��ȸ�մϴ�.
            for (int i = 1; i < childCount; i++)
            {
                // ���� �ڽ� ������Ʈ�� �迭�� �Ҵ��մϴ�.
                slot[i] = transform.GetChild(i).gameObject;

                // �ڽ� ������Ʈ�� SlotParent ������Ʈ�� �����ɴϴ�.
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
                    if (Equip) // ���Կ� ����������
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

                                    // ���� ���� 0���� �����մϴ�.
                                    color.a = 255f;

                                    // ����� color ���� Image ������Ʈ�� �ٽ� �Ҵ��մϴ�.
                                    image.color = color;
                                }
                                else if (Lock == false)
                                {
                                    Color color = image.color;

                                    // ���� ���� 0���� �����մϴ�.
                                    color.a = 0f;

                                    // ����� color ���� Image ������Ʈ�� �ٽ� �Ҵ��մϴ�.
                                    image.color = color;
                                }
                            }
                        }
                        CombinationScript.gameObject.transform.SetParent(TooltipScript.gameObject.transform); // ��ư 2���� ������ �ڽ����� ���ư�
                        SellScript.gameObject.transform.SetParent(TooltipScript.gameObject.transform);
                        UseBtn.gameObject.transform.SetParent(TooltipScript.gameObject.transform);
                        TooltipScript.Stop = true; // ������ ������
                        TooltipScript.gameObject.SetActive(true); // UI ������Ʈ�� Ȱ��ȭ
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
                // Image ������Ʈ�� Image ������Ʈ�� �����ɴϴ�.
                Image image = ImageObject.GetComponent<Image>();

                // Image ������Ʈ�� null�� �ƴ϶�� ������ ������Ʈ�� ����մϴ�.
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
