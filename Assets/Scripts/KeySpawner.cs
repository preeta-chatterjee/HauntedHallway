using UnityEngine;
using TMPro;

public class KeySpawner : MonoBehaviour
{
    public GameObject keyPrefab;
    public TextMeshProUGUI promptText;
    public int totalKeys = 5;

    private int keysCollected = 0;
    private GameObject currentKey;

    float minX = -7f;
    float maxX = 7f;
    float minY = -3f;
    float maxY = 3f;

    void Start()
    {
        SpawnKey();
        UpdatePrompt();
    }

    void SpawnKey()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        Vector3 spawnPos = new Vector3(randomX, randomY, 0f);
        currentKey = Instantiate(keyPrefab, spawnPos, Quaternion.identity);
    }

    public void KeyCollected()
    {
        if (GameManager.Instance.IsGameOver()) return;
        keysCollected++;
        UpdatePrompt();

        if (keysCollected >= totalKeys)
        {
            GameManager.Instance.WinGame();
        }
        else
        {
            SpawnKey();
        }
    }

    public void ZombieReachedEnd()
    {
        if (currentKey != null)
            Destroy(currentKey);
        GameManager.Instance.LoseGame();
    }

    void UpdatePrompt()
    {
        int remaining = totalKeys - keysCollected;
        promptText.text = "Keys remaining: " + remaining +
                          " — collect them before the zombie reaches you!";
    }
}