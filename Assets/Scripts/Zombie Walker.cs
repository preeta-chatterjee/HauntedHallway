using UnityEngine;

public class ZombieWalker : MonoBehaviour
{
    public float speed = 1.5f;
    private KeySpawner spawner;
    private Animator animator;

    void Start()
    {
        spawner = FindFirstObjectByType<KeySpawner>();
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if (GameManager.Instance.IsGameOver())
        {
            if (animator != null)
                animator.enabled = false;
            return;
        }

        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if (transform.position.x < -9f)
        {
            if (spawner != null)
                spawner.ZombieReachedEnd();
            Destroy(gameObject);
        }
    }
}