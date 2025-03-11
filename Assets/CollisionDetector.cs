using System;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    public event Action<GameObject> OnEnemyCollisionDetected;

    private void OnCollisionEnter(Collision collision)
    {
        // ���������, ����� �� ������ ��� "Enemy"
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log($"������������ � ������: {collision.gameObject.name}");
            OnEnemyCollisionDetected?.Invoke(collision.gameObject);
        }
    }
}
