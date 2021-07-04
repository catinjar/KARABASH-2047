using UnityEngine;
using UnityEngine.SceneManagement;

public class RulesScreen : MonoBehaviour
{
    public AudioClip clickSound;

    public void Next()
    {
        SceneManager.LoadScene("GameScreen");
        SoundManager.Instance.PlaySound(clickSound);
    }
}
