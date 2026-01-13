using UnityEngine;
using UnityEngine.UI;

public class LifeUI : MonoBehaviour
{
    public Image heart1;
    public Image heart2;
    public Image heart3;

    public void UpdateHearts(int lives)
    {
        heart1.enabled = lives >= 1;
        heart2.enabled = lives >= 2;
        heart3.enabled = lives >= 3;
    }
}
