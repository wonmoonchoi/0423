using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class AxeController : Search
{
    /* 무기 스테이터스 */
    public float damage;
    public float criticalPer;
    public float criticalDamage;
    public float attackSpeed;
    public int knockBack;

    float timer = 0.0f;
    public float swingSpeed = 300.0f;
    public float returnSpeed = 150.0f;

    private Vector3 originalPosition;
    private Quaternion originalRotation;

    void Start()
    {
        Search_Init();
        originalPosition = transform.localPosition;
        originalRotation = transform.localRotation;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 10.0f)
            timer = 0.0f;

        SearchSomething();
        if (target && timer > 5.0f)
        {
            StartCoroutine(SwingSword());
            timer = 0.0f;
        }
    }

    IEnumerator SwingSword()
    {
        //Step1 : 자세잡기
        originalPosition = transform.position;
        originalRotation = transform.rotation;

        //transform.LookAt(target);
        transform.position = target.up;

        //Step2 : 휘두르기
        while (transform.localRotation.x > 240f)
        {
            transform.localRotation *= Quaternion.Euler(swingSpeed * Time.deltaTime, 0, 0);
            yield return null;
        }

        //Step3 : 돌아오기
        //while (Quaternion.Angle(transform.localRotation, originalRotation) > 0.1f)
        //{
        //    transform.localRotation = Quaternion.RotateTowards(transform.localRotation, originalRotation, returnSpeed * Time.deltaTime);
        //    yield return null;
        //}

        transform.position = originalPosition;
        transform.rotation = originalRotation;
    }
}
