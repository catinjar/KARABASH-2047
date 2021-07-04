using DefaultNamespace;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScreen : MonoBehaviour
{
    public TextMeshProUGUI score;
    public TextMeshProUGUI highScore;
    public AudioClip clickSound;

    private void Start()
    {
        score.text = $"РЕЙТИНГ {GameResult.Result}";
        highScore.text = $"ЛУЧШИЙ РЕЗУЛЬТАТ {GameResult.BestResult}";
    }

    public void Next()
    {
        SceneManager.LoadScene("RulesScreen");
        SoundManager.Instance.PlaySound(clickSound);
    }
}