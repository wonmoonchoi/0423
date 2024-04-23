using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Camera_Test : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 5.0f;
    public LayerMask obstacleMask;
    public float cameraOffset = 0.3f;

    private Camera mainCamera;

    Vector3 offset;

    void Start()
    {
        mainCamera = GetComponent<Camera>();

        offset = new Vector3(0, 4, -6);
    }

    void LateUpdate()
    {
        RaycastHit hit;
        Vector3 direction = player.position - transform.position;
        if (Physics.Raycast(transform.position, direction, out hit, direction.magnitude, obstacleMask))
        {
            // �÷��̾��� forward ������ ����Ͽ� ī�޶��� ��ǥ ��ġ ���
            Vector3 targetPosition = player.position + player.forward * cameraOffset;

            // ī�޶� �ε巴�� ��ǥ ��ġ�� �̵���Ŵ
            transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            transform.LookAt(player.position);
        }
        else
        {
            transform.position = player.position + offset;
        }
    }
}
