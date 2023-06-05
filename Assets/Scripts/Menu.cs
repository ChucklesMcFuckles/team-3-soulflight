using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Menu : MonoBehaviour
{
    [Header("Sound Setting")]
    [SerializeField] private TMP_Text volumeValue = null;
    [SerializeField] private Slider volumeSlider = null;
    [SerializeField] private float defaultVolume = 3.0f;

    [Header("Gameplay Setting")]
    [SerializeField] private TMP_Text sensitivityValue = null;
    [SerializeField] private Slider sensitiveSlider = null;
    [SerializeField] private int defaultSen = 4;
    public int mainControllerSen = 4;

    [Header("Toggle Settings")]
    [SerializeField] private Toggle invertedY = null;

    [Header("Confirmation Box")]
    [SerializeField] private GameObject confirmationPrompt = null;
    

    [Header("Runs to Load")]
    public string _newGame;
    private string loadRun;

    [SerializeField] private GameObject noSaveRunData = null;

    public void NewGameDialog()
    {
        SceneManager.LoadScene(_newGame);
    }

    public void LoadGameDialog()
    {
        if (PlayerPrefs.HasKey("SavedRun"))
        {
            loadRun = PlayerPrefs.GetString("SavedRun");
            SceneManager.LoadScene(loadRun);
        }

        else
        {
            noSaveRunData.SetActive(true);
        }
    }

    public void ExitGameButton()
    {
        Application.Quit();
    }

    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
        volumeValue.text = volume.ToString("0.0");
    }

    public void applyVolume()
    {
        PlayerPrefs.SetFloat("masterVolume", AudioListener.volume);
        StartCoroutine(Confirmation());
    }

    public void SetSensitivity(float sensitivity)
    {
        mainControllerSen = Mathf.RoundToInt(sensitivity);
        sensitivityValue.text = sensitivity.ToString("0");
    }

    public void applyGamePlay()
    {
        if (invertedY.isOn)
        {
            PlayerPrefs.SetInt("MasterInvertY", 1);
        }
        else
        {
            PlayerPrefs.SetInt("MasterInvertY", 0);
        }

        PlayerPrefs.SetFloat("MasterSen", mainControllerSen);
        StartCoroutine(Confirmation());
    }

    public void defaultReset(string MenuType)
    {
        if(MenuType == "Audio")
        {
            AudioListener.volume = defaultVolume;
            volumeSlider.value = defaultVolume;
            volumeValue.text = defaultVolume.ToString("0.0");
            applyVolume();
        }

        if(MenuType == "Gameplay")
        {
            sensitivityValue.text = defaultSen.ToString("0");
            sensitiveSlider.value = defaultSen;
            mainControllerSen = defaultSen;
            invertedY.isOn = false;
            applyGamePlay();
        }
    }

    public IEnumerator Confirmation()
    {
        confirmationPrompt.SetActive(true);
        yield return new WaitForSeconds(2);
        confirmationPrompt.SetActive(false);
    }
}
