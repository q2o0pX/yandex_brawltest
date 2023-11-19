using UnityEngine;

public class DiagonalBackgroundMovement : MonoBehaviour
{
    public float moveSpeed = 5f;          // Скорость движения фона.
    public float returnDelay = 2f;        // Задержка перед возвращением фона (в секундах).

    private Vector3 startPosition;        // Начальная позиция фона.
    private Vector3 targetPosition;       // Целевая позиция для возвращения.
    private float returnTimer = 0f;       // Таймер для отслеживания времени возвращения.
    private bool isReturning = false;     // Флаг для определения, происходит ли возвращение.
    private Vector3 returnDirection;      // Направление для возвращения.

    void Start()
    {
        startPosition = transform.position;
        targetPosition = startPosition;
        returnDirection = Vector3.down + Vector3.left; // Направление возвращения (в данном случае вниз и влево).
    }

    void Update()
    {
        if (!isReturning)
        {
            // Двигаем фон по диагонали.
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }

        // Проверяем, прошло ли достаточно времени для возвращения.
        returnTimer += Time.deltaTime;
        if (returnTimer >= returnDelay)
        {
            // Начинаем возвращение.
            targetPosition = startPosition;
            returnTimer = 0f;
            isReturning = true;
        }

        // Если возвращение происходит, плавно перемещаем объект к целевой позиции.
        if (isReturning)
        {
            float returnSpeed = moveSpeed; // Используем ту же скорость при возвращении.
            transform.Translate(returnDirection * returnSpeed * Time.deltaTime);

            // Проверяем, достигли ли целевой позиции для возвращения.
            if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
            {
                isReturning = false;
            }
        }
    }
}
