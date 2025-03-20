using UnityEngine;
using UnityEngine.UI;

public class AudioSys : MonoBehaviour
{
    public AudioSource musicSource; // Unity editöründe bu atama yapýldý mý?
    public Slider volumeSlider; // Unity editöründe bu atama yapýldý mý?

    void Start()
    {
        // Eðer bileþenler doðrudan atandýysa bunlarý alma
        if (musicSource == null)
        {
            musicSource = GameObject.Find("MusicSourceObjectName").GetComponent<AudioSource>(); // AudioSource bileþenini doðru GameObject'ten al
        }

        if (volumeSlider == null)
        {
            volumeSlider = GameObject.Find("VolumeSliderObjectName").GetComponent<Slider>(); // Slider bileþenini doðru GameObject'ten al
        }

        if (musicSource == null || volumeSlider == null)
        {
            Debug.LogError("musicSource or volumeSlider is not assigned!");
            return;
        }

        // Attach the method to the slider's change event
        volumeSlider.onValueChanged.AddListener(delegate { SetVolume(); });

        // Find the speaker button and attach its click event
        Button speakerButton = GameObject.Find("SpeakerButton").GetComponent<Button>();
        if (speakerButton != null)
        {
            speakerButton.onClick.AddListener(ToggleMute);
        }
        else
        {
            Debug.LogError("SpeakerButton not found!");
        }

        // Set the slider value to the music source volume at the beginning
        volumeSlider.value = musicSource.volume;
    }

    // Set the volume level based on the slider value 
    public void SetVolume()
    {
        musicSource.volume = volumeSlider.value;
    }

    // Toggle mute state
    public void ToggleMute()
    {
        // If the volume is currently muted, unmute it; otherwise, mute it
        if (musicSource.volume > 0)
        {
            musicSource.volume = 0;
            volumeSlider.value = 0;
        }
        else
        {
            musicSource.volume = 1;
            volumeSlider.value = 1;
        }
    }
}
