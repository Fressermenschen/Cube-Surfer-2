using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using Random = UnityEngine.Random;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance;
    
    [SerializeField] private TextMeshProUGUI coinCounterText;
    [SerializeField] private TextMeshProUGUI coinCounterFinText;
    [SerializeField] private Transform traget;
    [SerializeField] private Transform source;
    [SerializeField] private GameObject animatedCoin;
    [SerializeField] private int maxCoins;
    private Queue<GameObject> coinsQueue = new Queue<GameObject>();
    [SerializeField] [Range(0.5f, 0.9f)] private float minAnimDuration;
    [SerializeField] [Range(0.9f, 2f)] private float maxAnimDuration;
    private int coins = 0;

    private Vector3 targetrPosition;

    private void Awake()
    {
        instance = this;
        coins = PlayerPrefs.GetInt("Coins");
        coinCounterText.text = coins.ToString() + " Coins";
    }

    public void AddCoins(int coinNum)
    {
        coinCounterFinText.text = coinNum.ToString() + " Coins";
        coins += coinNum;
        PlayerPrefs.SetInt("Coins", coins);
    }

    public void CounterUpdate()
    {
        Animate();
        coinCounterText.text = coins.ToString() + " Coins";
    }

    private void Animate()
    {
        targetrPosition = traget.position;
        for (int i = 0; i < maxCoins; i++)
        {
            GameObject coin;
            coin = Instantiate(animatedCoin, source);
            float duration = Random.Range(minAnimDuration, maxAnimDuration);
            coin.transform.DOMove(targetrPosition, duration)
                .SetEase(Ease.InOutBack)
                .OnComplete(()=>Destroy(coin));
        }
    }
}
