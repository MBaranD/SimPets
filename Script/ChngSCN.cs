using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChngSCN : MonoBehaviour
{
    public Button dogButton;
    public Button catButton;
    public Button nextButton;

    public GameObject dogAudioSourceObject; // Dog audio source
    public GameObject catAudioSourceObject; // Cat audio source

    private bool dogSelected = false;
    private bool catSelected = false;

    private AudioSource dogAudioSource;
    private AudioSource catAudioSource;
    public InputField userInput;
    public Text new_name;

    [System.Serializable]
    public class Data
    {
        public string name;
    }

    void Awake()
    {
        // Get the AudioSource from the specified GameObjects
        dogAudioSource = dogAudioSourceObject.GetComponent<AudioSource>();
        catAudioSource = catAudioSourceObject.GetComponent<AudioSource>();

        // Add listeners to buttons
        dogButton.onClick.AddListener(OnDogButtonClicked);
        catButton.onClick.AddListener(OnCatButtonClicked);
        nextButton.onClick.AddListener(OnNextButtonClicked);

        // Add listener to input field to monitor changes
        userInput.onValueChanged.AddListener(OnInputFieldChanged);

        // Initially disable the next button
        nextButton.interactable = false;
    }

    void OnDogButtonClicked()
    {
        dogSelected = true;
        catSelected = false; // Ensure only one selection is active at a time
        Debug.Log("Dog selected.");
        dogAudioSource.Play();
    }

    void OnCatButtonClicked()
    {
        catSelected = true;
        dogSelected = false; // Ensure only one selection is active at a time
        Debug.Log("Cat selected.");
        catAudioSource.Play();
    }

    void OnInputFieldChanged(string text)
    {
        // Enable the next button if the input field is not empty, disable otherwise
        nextButton.interactable = !string.IsNullOrEmpty(text);
    }

    public void OnNextButtonClicked()
    {
        if (dogSelected)
        {
            SaveName("data.json", "FirstScene");
        }
        else if (catSelected)
        {
            SaveName("data2.json", "SecondScene");
        }
        else
        {
            Debug.LogWarning("No selection made.");
        }
    }

    public void SaveName(string fileName, string sceneName)
    {
        string filePath = Path.Combine(Application.persistentDataPath, fileName);
        string userInp = userInput.text;

        Data nameData = new Data();
        if (File.Exists(filePath))
        {
            string dataAsJson = File.ReadAllText(filePath);
            nameData = JsonUtility.FromJson<Data>(dataAsJson);
        }

        nameData.name = userInp;
        string newDataAsJson = JsonUtility.ToJson(nameData);
        File.WriteAllText(filePath, newDataAsJson);

        Debug.Log("New Pet name: " + nameData.name);

        SceneManager.LoadScene(sceneName);
    }
}
