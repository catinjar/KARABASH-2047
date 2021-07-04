using System.Collections;
using UnityEngine;

namespace DefaultNamespace
{
    public class SoundEffect : MonoBehaviour
    {
        private void Start()
        {
            StartCoroutine(Routine());
            DontDestroyOnLoad(this);
        }

        private IEnumerator Routine()
        {
            yield return new WaitForSeconds(1);
            Destroy(gameObject);
        }
    }
}