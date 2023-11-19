using UnityEngine;

public class DiagonalBackgroundMovement : MonoBehaviour
{
    public float moveSpeed = 5f;          // �������� �������� ����.
    public float returnDelay = 2f;        // �������� ����� ������������ ���� (� ��������).

    private Vector3 startPosition;        // ��������� ������� ����.
    private Vector3 targetPosition;       // ������� ������� ��� �����������.
    private float returnTimer = 0f;       // ������ ��� ������������ ������� �����������.
    private bool isReturning = false;     // ���� ��� �����������, ���������� �� �����������.
    private Vector3 returnDirection;      // ����������� ��� �����������.

    void Start()
    {
        startPosition = transform.position;
        targetPosition = startPosition;
        returnDirection = Vector3.down + Vector3.left; // ����������� ����������� (� ������ ������ ���� � �����).
    }

    void Update()
    {
        if (!isReturning)
        {
            // ������� ��� �� ���������.
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }

        // ���������, ������ �� ���������� ������� ��� �����������.
        returnTimer += Time.deltaTime;
        if (returnTimer >= returnDelay)
        {
            // �������� �����������.
            targetPosition = startPosition;
            returnTimer = 0f;
            isReturning = true;
        }

        // ���� ����������� ����������, ������ ���������� ������ � ������� �������.
        if (isReturning)
        {
            float returnSpeed = moveSpeed; // ���������� �� �� �������� ��� �����������.
            transform.Translate(returnDirection * returnSpeed * Time.deltaTime);

            // ���������, �������� �� ������� ������� ��� �����������.
            if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
            {
                isReturning = false;
            }
        }
    }
}
