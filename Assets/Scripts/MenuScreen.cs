using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScreen : MonoBehaviour
{
    public void Next()
    {
        SceneManager.LoadScene("LoreScreen");
    }
}
