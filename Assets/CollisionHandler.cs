using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
   [SerializeField] private  CollisionDetector detector;

    private void Start()
    {
        if (detector != null)
        {
            detector.OnEnemyCollisionDetected += HandleEnemyCollision;
        }
    }

    private void HandleEnemyCollision(GameObject enemy)
    {
        Debug.Log($" {gameObject.name} столкнулся с Фигней {enemy.name}!");
    }

    private void OnDestroy()
    {
        if (detector != null)
        {
            detector.OnEnemyCollisionDetected -= HandleEnemyCollision;
        }
    }
}
