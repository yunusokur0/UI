using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private float forwardSpeed;
    [SerializeField] private Text diamondtext;
    public int currentindex;
    public Text text;
    public int currentIndex2;
    public bool reward;
    public int value;

    public static Player player;

    private void Awake()
    {
        player = this;
        currentindex = PlayerPrefs.GetInt("currentindex", currentindex);
        diamondtext.text = currentindex.ToString();
    }
    void Update()
    {
        MoveForward();
    }
    private void MoveForward()
    {
        if (start.Start.isGameStart)
        {
            transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);
        }
    }


    public void nextThanks()
    {
        if (!reward)
        {
            StartCoroutine(AfterRewardButtonText(currentIndex2));
            MoneyAnimation.moneyAnimation.rewardpieofcoin();
        }
        if (reward)
        {
            StartCoroutine(AfterRewardButtonText(currentIndex2 * 5));
            MoneyAnimation.moneyAnimation.rewardpieofcoin();
        }
        PlayerPrefs.SetInt("currentindex", currentindex);
        PlayerPrefs.Save();

    }

    public void nextReward()
    {
        StartCoroutine(AfterRewardButton());
        reward = true;
    }

    public IEnumerator AfterRewardButtonText(int incrementAmount)
    {
        for (int i = currentindex; i <= currentindex + incrementAmount; i += value)
        {
            diamondtext.text = i.ToString();
            yield return null;
        }
        currentindex += incrementAmount;
        diamondtext.text = currentindex.ToString();
        PlayerPrefs.SetInt("currentindex", currentindex);
        PlayerPrefs.Save();
        LoadingScreenManager.loadaing.NextLevel();
        SceneManager.LoadScene(0);
    }
    public IEnumerator AfterRewardButton()
    {
        for (int i = currentIndex2; i <= currentIndex2 * 5; i += value)
        {
            text.text = i.ToString();
            yield return new WaitForSeconds(0.000001f);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Vibration"))
        {
            if (PlayerPrefs.GetInt("Vibration") == 0)
            { Vibration.Vibrate(100); }
            AudioSource collectDiamondSound = GetComponents<AudioSource>()[1];
            collectDiamondSound.Play();
            currentindex += 10;
            diamondtext.text = currentindex.ToString();
            PlayerPrefs.SetFloat("currentindex", currentindex);
            PlayerPrefs.Save();          
            Destroy(other.gameObject);
        }

        if(other.gameObject.CompareTag("Finish"))
        {
            currentIndex2 += 20;
            text.text = currentIndex2.ToString();            
            ADController.Instance.ShowInterstitial();
        }
    }
}
