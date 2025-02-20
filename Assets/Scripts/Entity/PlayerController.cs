using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BaseController
{
    private Camera camera;// ī�޶� ����, ���콺 ��ġ�� ���� ��ǥ�� ��ȯ�� �� ���

    protected override void Start()// Start �޼��忡�� �ʱ�ȭ �۾��� ����
    {
        base.Start(); // BaseController�� Start()�� ȣ���Ͽ� �θ� Ŭ������ �ʱ�ȭ �۾� ����
        camera = Camera.main; // �⺻ ī�޶� ã�� ���� (Main Camera)
    }

    protected override void HandleAction() // �÷��̾��� �̵� �� �ü� ������ ó���ϴ� �޼���
    {
        // �Է��� �޾Ƽ� ����(horizontal)�� ����(vertical) �������� �̵��� ���� ����
        float horizontal = Input.GetAxisRaw("Horizontal");// �¿� �̵� (A, D, ȭ��ǥ �¿�) ����
        float vertial = Input.GetAxisRaw("Vertical");// ���� �̵� (W, S, ȭ��ǥ ����) ����
        movementDirection = new Vector2(horizontal, vertial).normalized;
        // �̵� ���͸� ���� `movementDirection`�� ���� (�̵� ���� ����ȭ)

        Vector2 mousePosition = Input.mousePosition;// ���콺 ��ġ�� ȭ�� �󿡼� �޾ƿ���
        Vector2 worldPos = camera.ScreenToWorldPoint(mousePosition);
        // ���콺 ��ġ�� ���� ��ǥ�� ��ȯ (��ũ�� ��ǥ -> ���� ��ǥ)
        lookDirection = (worldPos - (Vector2)transform.position);
        // ���콺�� �÷��̾� ���� ���� ���� ���

        if (lookDirection.magnitude < .9f)// ���콺�� �Ÿ��� �ʹ������� �ü������� (0,0)���� ����
        {
            lookDirection = Vector2.zero; // ���콺�� �ʹ� ����� ��� �ü� ������ 0���� ����
        }
        else
        {
            lookDirection = lookDirection.normalized;
        } // �ü� ���� ���͸� ����ȭ�Ͽ� ���⸸�� �����ϰ� ũ��� 1�� ����
    }
}
