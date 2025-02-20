using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    [SerializeField] private string npcName = "NPCA";  // NPC 이름
    [SerializeField] private string dialogue = "뭐하러 왔니.";  // 기본 대화 내용

    private bool isPlayerInRange = false;  // 플레이어가 범위 내에 있는지 확인

    private void Update()
    {
        // 플레이어가 범위 내에 있고, 상호작용 키(E)를 누르면 대화 실행
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // 플레이어가 범위에 들어오면 상호작용 가능 상태로 변경
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
            Debug.Log($"{npcName} : '{dialogue}' (E 키를 눌러 대화)");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // 플레이어가 범위를 벗어나면 상호작용 불가능 상태로 변경
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            Debug.Log($"{npcName} : '다음에 다시 만나요!'");
        }
    }

    private void Interact()
    {
        Debug.Log($"{npcName} : '{dialogue}'");  // NPC 대화 출력
        // 여기에 UI 창을 띄우거나 이벤트 추가 가능
    }
}