using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SwordController : Search
{
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
        if (target && timer > 4.0f)
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

        transform.LookAt(target);
        transform.rotation *= Quaternion.Euler(0, 0, 90);
        transform.position = target.right + (target.up * 0.5f);

        //Step2 : 휘두르기
        while (transform.localRotation.eulerAngles.x < 90.0f)
        {
            transform.localRotation *= Quaternion.Euler(0f, swingSpeed * Time.deltaTime, 0f);
            //transform.Rotate(Vector3.up, swingSpeed * Time.deltaTime);

            //transform.position = Vector3.Lerp(transform.position, target.position + offset, Time.deltaTime * swingSpeed);
            yield return null;
        }

        //Step3 : 돌아오기
        while (Quaternion.Angle(transform.localRotation, originalRotation) > 0.1f)
        {
            transform.localRotation = Quaternion.RotateTowards(transform.localRotation, originalRotation, returnSpeed * Time.deltaTime);
            yield return null;
        }

        transform.position = originalPosition;
        transform.rotation = originalRotation;
    }
}
