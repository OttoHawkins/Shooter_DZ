using System;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    public event Action<GameObject> OnEnemyCollisionDetected;

    private void OnCollisionEnter(Collision collision)
    {
        // Проверяем, имеет ли объект тег "Enemy"
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log($"Столкновение с врагом: {collision.gameObject.name}");
            OnEnemyCollisionDetected?.Invoke(collision.gameObject);
        }
    }
}
