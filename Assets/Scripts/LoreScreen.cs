using UnityEngine;
using UnityEngine.SceneManagement;

public class LoreScreen : MonoBehaviour
{
    public void NextScreen()
    {
        SceneManager.LoadScene("RulesScreen");
    }
}
