using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

public class MoneyAnimation : MonoBehaviour
{
    public List<GameObject> pileofcoinparents;
    public int currentIndex = 0;
    public static MoneyAnimation moneyAnimation;
    private void Awake()
    {
        moneyAnimation = this;
    }

    public void rewardpieofcoin()
    {
        if (currentIndex < pileofcoinparents.Count)
        {
            GameObject pile = pileofcoinparents[currentIndex];
            pile.SetActive(true);
            foreach (Transform child in pile.transform)
            {
                child.DOScale(0.637F, .9f).SetEase(Ease.OutBack);
                child.GetComponent<RectTransform>().DOAnchorPos(new Vector2(292.9999f, 561.256f), 0.9f).SetEase(Ease.InBack);
                child.DORotate(Vector3.zero, 0.7f).SetEase(Ease.OutFlash);
                child.DOScale(0F, 0.3F).SetDelay(1.2f).SetEase(Ease.OutQuint);
            }
            currentIndex++;
        }
    }
}
