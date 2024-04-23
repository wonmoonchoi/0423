using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

enum GameState
{
    start,
    inprogress,
    breaktime,
}

public class GameManager : MonoBehaviour
{
    //매니저 등록 관련
    public static GameManager instance;
    public PoolManager pool;
    public Player player;
    public Player_Stat player_Stat;
    public Spawner spawner;
    public WeaponManager weaponManager;
    //전역 변수 관련
    public int currentRound = 1;
    public int money = 5000;
    //라운드 관련
    GameState state = new GameState();
    Round _round = new Round();
    public Text moneyText;
    public Text timerText;
    public bool isPlay = false;
    float timer = 0.0f;

    public GameObject prefabToCreate;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        GameObject Player = Instantiate(prefabToCreate, transform.position, Quaternion.identity);
        Player.name = prefabToCreate.name;

        player = GameObject.Find("Player").GetComponent<Player>();
        player_Stat = GameObject.Find("Player").GetComponent<Player_Stat>();
        pool = GameObject.Find("PoolManager").GetComponent<PoolManager>();
        spawner = GameObject.Find("Spawner").GetComponent<Spawner>();

        Init_Update();
    }

    void FixedUpdate()
    {
        timer += Time.deltaTime;
    }

    void Update()
    {
        //Init_Update();

        switch (state)
        {
            case GameState.start:
                StartCoroutine(_round.ronudList[currentRound - 1]);

                isPlay = true;
                state = GameState.inprogress;
                break;

            case GameState.inprogress:
                Init_UI();
                moneyText.text = money.ToString();
                timerText.text = timer.ToString("F1");

                if (player._level != currentRound)
                {
                    currentRound++;
                    StopAllCoroutines();
                    state = GameState.start;
                }

                if(Input.GetKeyDown(KeyCode.B))
                {
                    StopAllCoroutines();
                    Time.timeScale = 0f;
                    SceneManager.LoadScene("INVENTORY");

                    isPlay = false;
                    state = GameState.breaktime;
                }
                break;

            case GameState.breaktime:
                if (Time.timeScale > 0f)
                {
                    isPlay = true;
                    state = GameState.inprogress;
                }
                break;

            default:
                break;
        }
    }

    void Init_Update()
    {
        //if (target == null)
        //{
        //    GameObject playerObject = GameObject.Find("Player");
        //    if (playerObject != null)
        //    {
        //        target = playerObject.transform;
        //    }
        //    else
        //    {
        //        Debug.Log("Player 가 없습니다. GameManager");
        //    }
        //}

        player._level = player_Stat.level;
        player._currentExp = player_Stat.currentExp;
        player._currentHp = player_Stat.currentHp;
        player._maxExp = player_Stat.maxExp;
        player._maxHp = player_Stat.maxHp;
    }

    void Init_UI()
    {
        if (moneyText == null || timerText == null)
        {
            Canvas canvas = FindObjectOfType<Canvas>();

            if (canvas != null)
            {
                Image[] images = canvas.GetComponentsInChildren<Image>();

                foreach (Image image in images)
                {
                    if (image.name == "Image_Money")
                    {
                        moneyText = image.GetComponentInChildren<Text>();
                    }
                    if (image.name == "Image_Timer")
                    {
                        timerText = image.GetComponentInChildren<Text>();
                    }
                }
            }
        }
    }
}