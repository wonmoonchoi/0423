using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    // TextMeshPro - Text (UI) ������Ʈ�� ������ ����
    public TextMeshProUGUI textField;

    void Start()
    {
        // TextMeshPro - Text (UI) ������Ʈ�� ���� �Է�
        textField.text =
            "�ִ� ü��\n" +
            "���� ü��\n\n" +

            "���� ������\n" +
            "���� ������\n\n" +

            "ũ��Ƽ�� Ȯ��\n" +
            "ũ��Ƽ�� ������\n\n" +

            "���� �ӵ�\n" +
            "�̵� �ӵ�\n\n" +

            "��Ÿ�\n" +
            "����\n" +
            "�˹�\n\n" +

            "ü�� ���\n" +
            "ü�� �ڿ� ȸ��\n" +
            "��Ȱ\n" +
            "����\n\n" +

            "���\n" +
            "����ġ ȹ���\n" +
            "���� ���õ�\n" +
            "���ǰ�ȣ �����\n" +
            "��� ȹ���\n\n" +

            "�߰� �߻�ü\n" +
            "ƨ��\n" +
            "����\n" +
            "������ ȹ�� �ݰ�\n";
    }
}
