using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MenuEvents : MonoBehaviour
{
    public Slider volumnSlider;
    public AudioMixer mixer;
    private float value;

    private void Start()
    {
        mixer.GetFloat("volume", out value);
        volumnSlider.value = value;
    }

    public void SetVolumn()
    {
        mixer.SetFloat("volume", volumnSlider.value);
    }
    public void LoadLevel(int index)
    {
        SceneManager.LoadScene(index);
    }
}
