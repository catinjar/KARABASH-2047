using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScreen : MonoBehaviour
{
    public AudioClip clickSound;
    
    public void Next()
    {
        SceneManager.LoadScene("LoreScreen");
        SoundManager.Instance.PlaySound(clickSound);
    }
}
