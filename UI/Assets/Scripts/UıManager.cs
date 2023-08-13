using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UıManager : MonoBehaviour
{
    public static UıManager uıManager;
    public Image fillRateImage;
    public GameObject player;
    public GameObject finishLine;
    public GameObject winpanle;

    public Animator Layoutanimator;
    public Animator Layoutanimator1;
    public Animator Layoutanimator2;
    public Animator Layoutanimator3;
    public Animator Layoutanimator4;
    public GameObject settingsOpen;
    public GameObject settingsClose;
    public GameObject soundMute;
    public GameObject VibrationClose;
    public GameObject FailPanel;
    public GameObject thanksbutton;
    private bool isVibrationEnabled;

    private void Awake()
    {
        uıManager = this;
        ApplySoundSettings();
    }

    

    private void Start()
    {
        isVibrationEnabled = PlayerPrefs.GetInt("Vibration", 0) == 1;
        UpdateVibrationUI();
    }

    public void ToggleVibration()
    {
        isVibrationEnabled = !isVibrationEnabled;
        int valueToSave = isVibrationEnabled ? 1 : 0;

        PlayerPrefs.SetInt("Vibration", valueToSave);
        PlayerPrefs.Save();

        UpdateVibrationUI();
    }

    private void UpdateVibrationUI()
    {
        VibrationClose.gameObject.SetActive(isVibrationEnabled);
    }

    void Update()
    {
        fillRateImage.fillAmount = (player.transform.position.z) / (finishLine.transform.position.z);

    }

    #region sound
    private bool IsSoundEnabled()
    {
        return PlayerPrefs.GetInt("SoundPref", 1) == 1;
    }

    private void ApplySoundSettings()
    {
        bool soundEnabled = IsSoundEnabled();
        AudioListener.pause = !soundEnabled;
        soundMute.SetActive(!soundEnabled);
    }

    private void SetSoundEnabled(bool enabled)
    {
        int soundPref = enabled ? 1 : 0;
        PlayerPrefs.SetInt("SoundPref", soundPref);
        PlayerPrefs.Save();

        ApplySoundSettings();
    }
    public void ToggleSound()
    {
        bool soundEnabled = !IsSoundEnabled();
        SetSoundEnabled(soundEnabled);
    }
    #endregion

    #region Settings image
    public void SettingsOpen()
    {
        Layoutanimator.SetTrigger("open");
        Layoutanimator2.SetTrigger("open");
        Layoutanimator3.SetTrigger("open");
        Layoutanimator4.SetTrigger("open");
        Layoutanimator1.SetTrigger("open");
        settingsOpen.SetActive(false);
        settingsClose.SetActive(true);
    }

    public void SettingsClose()
    {
        Layoutanimator.SetTrigger("close");
        Layoutanimator2.SetTrigger("close");
        Layoutanimator3.SetTrigger("close");
        Layoutanimator4.SetTrigger("close");
        Layoutanimator1.SetTrigger("close");
        settingsOpen.SetActive(true);
        settingsClose.SetActive(false);
    }
    #endregion

    #region panel
    public void Winnpanel()
    {
        start.Start.isGameStart = false;
        winpanle.SetActive(true);
        StartCoroutine(noThanks());
    }
    public void Failpanel()
    {
        start.Start.isGameStart = false;
        FailPanel.SetActive(true);
    }

    IEnumerator noThanks()
    {
        yield return new WaitForSecondsRealtime(1);
        thanksbutton.SetActive(true);
    }

    #endregion

    public void retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
    public void Nextlevel()
    {
        LoadingScreenManager.loadaing.NextLevel();
    }
}
