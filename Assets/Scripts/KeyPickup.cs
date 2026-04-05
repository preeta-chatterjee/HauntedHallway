using UnityEngine;
using UnityEngine.InputSystem;

public class KeyPickup : MonoBehaviour
{
    private Camera mainCamera;
    private KeySpawner spawner;

    void Start()
    {
        mainCamera = Camera.main;
        spawner = FindFirstObjectByType<KeySpawner>();
    }

    void Update()
    {
        Vector2 inputPos = Vector2.zero;
        bool inputDetected = false;

        if (Touchscreen.current != null &&
            Touchscreen.current.primaryTouch.press.wasPressedThisFrame)
        {
            inputPos = Touchscreen.current.primaryTouch.position.ReadValue();
            inputDetected = true;
        }
        else if (Mouse.current != null &&
                 Mouse.current.leftButton.wasPressedThisFrame)
        {
            inputPos = Mouse.current.position.ReadValue();
            inputDetected = true;
        }

        if (inputDetected)
        {
            Vector2 worldPos = mainCamera.ScreenToWorldPoint(inputPos);
            RaycastHit2D hit = Physics2D.Raycast(worldPos, Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                spawner.KeyCollected();
                Destroy(gameObject);
            }
        }
    }
}