using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/* INGAME 에서 사용되는 Player */

public class Player : Search
{
    public delegate void PlayerDieHandler();
    public static event PlayerDieHandler OnPlayerDie;

    public Animator anim;
    public Slider hpSlider;
    public Slider expSlider;

    public int _level = 1;
    public float _maxExp = 10.0f, _currentExp = 0.0f;
    public float _maxHp = 100, _currentHp = 100;
    public float moveSpeed = 0.1f;

    private bool isPaused = false;

    void Start()
    {
        anim = GetComponent<Animator>();

        Search_Init();
        DontDestroyOnLoad(this.gameObject);
    }
    void Update()
    {
        SearchSomething();

        LevelUp();

        Init_UI();
        hpSlider.value = _currentHp / _maxHp;
        expSlider.value = _currentExp / _maxExp;

        if (_currentHp <= 0)
        {
            PlayerDie();
        }

        //if(Time.timeScale == 0f)
        //{
        //    gameObject.SetActive(false);
        //}
        //if(Time.timeScale == 1f)
        //{
        //    gameObject.SetActive(true);
        //}
    }

    void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 moveVec = new Vector3(h, 0, v).normalized;

        transform.position += moveVec * moveSpeed;
        anim.SetBool("IsMove", true);

        transform.LookAt(transform.position + moveVec);

        if (moveVec.magnitude <= 0.0f)
            anim.SetBool("IsMove", false);
    }

    void LevelUp()
    {
        if (_currentExp > _maxExp)
        {
            float temp = _currentExp - _maxExp;
            _currentExp = 0.0f + temp;
            _maxExp = _maxExp * 2;

            _currentHp = 100;
            _level++;
        }
    }

    void PlayerDie()
    {
        OnPlayerDie();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PUNCH"))
        {
            _currentHp -= other.GetComponent<Monster_Punch>()._damage;
        }
    }

    void Init_UI()
    {
        if (hpSlider == null || expSlider == null)
        {
            Canvas canvas = FindObjectOfType<Canvas>();

            if (canvas != null)
            {
                Image[] images = canvas.GetComponentsInChildren<Image>();

                foreach (Image image in images)
                {
                    if (image.name == "Image_HP")
                    {
                        hpSlider = image.GetComponentInChildren<Slider>();
                    }
                    if (image.name == "Image_Level")
                    {
                        expSlider = image.GetComponentInChildren<Slider>();
                    }
                }
            }
        }
    }
}
