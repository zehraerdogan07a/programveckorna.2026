using UnityEngine;
using UnityEngine.UI;

public class LifeUI : MonoBehaviour
{
    private Image[] hearts;

    void Awake()
    {
        hearts = GetComponentsInChildren<Image>();
    }

    public void UpdateHearts(int lives)
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].enabled = i < lives;
        }
    }
}
