using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI score;
    public Image healthBar;

    private void Update()
    {
        score.text = $"РЕЙТИНГ\n{GameState.Instance.Score}";

        float health01 = GameState.Instance.Health / 100;
        
        healthBar.transform.localScale = new Vector3(health01, 1, 1);
        healthBar.color = Color.Lerp(Color.red, Color.green, health01);
    }
}
