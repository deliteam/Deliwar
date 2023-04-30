using UnityEngine;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public void SetVolume(float volume){
        Debug.Log(volume);
        audioMixer.SetFloat("volume", volume);
    }
}
