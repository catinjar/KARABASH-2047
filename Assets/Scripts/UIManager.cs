using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI score;
    public Image healthBar;
    public Image flamethrowerAmmoBar;

    private void Update()
    {
        score.text = $"РЕЙТИНГ\n{GameState.Instance.Score}";

        float health01 = GameState.Instance.Health / 100;
        float ammo01 = GameState.Instance.FlamethrowerAmmo / 100;
        
        healthBar.transform.localScale = new Vector3(health01, 1, 1);
        healthBar.color = Color.Lerp(Color.red, Color.green, health01);

        flamethrowerAmmoBar.transform.localScale = new Vector3(ammo01, 1, 1);
    }
}
