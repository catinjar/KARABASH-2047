using DefaultNamespace;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;

    public static SoundManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject().AddComponent<SoundManager>();
                DontDestroyOnLoad(instance.gameObject);
            }

            return instance;
        }
    }
    
    public void PlaySound(AudioClip clip)
    {
        var soundEffect = new GameObject();
        soundEffect.AddComponent<SoundEffect>();
        
        var audioSource = soundEffect.AddComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.volume = 0.1f;
        audioSource.Play();
    }
}
