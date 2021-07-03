using UnityEngine;
using UnityEngine.SceneManagement;

public class RulesScreen : MonoBehaviour
{
    public void Next()
    {
        SceneManager.LoadScene("GameScreen");
    }
}
