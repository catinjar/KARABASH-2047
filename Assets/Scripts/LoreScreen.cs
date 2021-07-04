using UnityEngine;
using UnityEngine.SceneManagement;

public class LoreScreen : MonoBehaviour
{
    public AudioClip clickSound;
    
    public void NextScreen()
    {
        SceneManager.LoadScene("RulesScreen");
        SoundManager.Instance.PlaySound(clickSound);
    }
}
