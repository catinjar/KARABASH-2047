using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogoScreen : MonoBehaviour
{
    public float duration = 2;

    private void Start()
    {
        StartCoroutine(Routine());
    }

    private IEnumerator Routine()
    {
        yield return new WaitForSeconds(duration);

        SceneManager.LoadScene("MenuScreen");
    }
}
