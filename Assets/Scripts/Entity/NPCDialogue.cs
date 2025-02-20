using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    [SerializeField] private string npcName = "NPCA";  // NPC �̸�
    [SerializeField] private string dialogue = "���Ϸ� �Դ�.";  // �⺻ ��ȭ ����

    private bool isPlayerInRange = false;  // �÷��̾ ���� ���� �ִ��� Ȯ��

    private void Update()
    {
        // �÷��̾ ���� ���� �ְ�, ��ȣ�ۿ� Ű(E)�� ������ ��ȭ ����
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // �÷��̾ ������ ������ ��ȣ�ۿ� ���� ���·� ����
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
            Debug.Log($"{npcName} : '{dialogue}' (E Ű�� ���� ��ȭ)");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // �÷��̾ ������ ����� ��ȣ�ۿ� �Ұ��� ���·� ����
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            Debug.Log($"{npcName} : '������ �ٽ� ������!'");
        }
    }

    private void Interact()
    {
        Debug.Log($"{npcName} : '{dialogue}'");  // NPC ��ȭ ���
        // ���⿡ UI â�� ���ų� �̺�Ʈ �߰� ����
    }
}