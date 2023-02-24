using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class GameView : MonoBehaviour
{
    [SerializeField]
    public GameObject UpgradeUI;
    
    [SerializeField]
    public GameObject SellOilUI;
    
    [SerializeField]
    private TextMeshProUGUI moneyText;

    [SerializeField]
    private TextMeshProUGUI oilText;
    
    [SerializeField]
    private TextMeshProUGUI upgradeHaveText;
    
    [SerializeField]
    private TextMeshProUGUI upgradeNeedText;
    
    [SerializeField]
    private TextMeshProUGUI upgradeLevelText;
    
    [SerializeField]
    private TextMeshProUGUI upgradeLevelButtonText;

    [SerializeField]
    private TextMeshProUGUI oilSellPriceText;
    
    private GameObject _oilFactoryObject;
    
    private const int OilMult = 2;
    private const float PriceMult = 5f;
    private const float OilSellTimer = 60f;
    private const float PayDayTimer = 10f;
    
    private int _playerMoney = 0;
    private int _playerOil = 0;
    private int _playerLevel = 1;

    private int _upgradePrice = 1000;

    private int _oilRevenue = 10;
    private int _oilSellPrice = 105;
    private int _dayCount = 1;

    private float _payDayTime = PayDayTimer;
    private float _oilSellPriceUpdateTime = OilSellTimer;

    private List<int> _allSellPrices = new();

    public void SellAllOil()
    {
        int money = _oilSellPrice * _playerOil;
        _playerOil = 0;
        _playerMoney += money;
        UpdateGlobalInfo();
    }

    public void UpgradeOilFactory()
    {
        if (_playerMoney >= _upgradePrice)
        {
            _playerLevel += 1;
            _playerMoney -= _upgradePrice;
            _upgradePrice = (int)(_upgradePrice * PriceMult);
            _oilRevenue *= OilMult;
            _oilFactoryObject.transform.localScale += new Vector3(0.2f, 0, 0.2f);
        }

        UpdateGlobalInfo();
    }
    
    public void FixedUpdate()
    {
        if (_payDayTime > 0)
            _payDayTime -= Time.fixedDeltaTime;
        else
            PayDay();

        if (_oilSellPriceUpdateTime > 0)
            _oilSellPriceUpdateTime -= Time.fixedDeltaTime;
        else
            UpdateOilPrice();
    }

    private void Awake()
    {
        StartCoroutine(GetFreshSellPricesData());
        UpdateGlobalInfo();
        _oilFactoryObject = GameObject.FindWithTag("Clickable");
    }

    private void UpdateGlobalInfo()
    {
        moneyText.text = "$" + _playerMoney;
        oilText.text = _playerOil.ToString();
        upgradeHaveText.text = _playerMoney.ToString();
        upgradeNeedText.text = _upgradePrice + "$";
        upgradeLevelText.text = (_playerLevel + 1).ToString();
        upgradeLevelButtonText.text = (_playerLevel + 1).ToString();
        oilSellPriceText.text = _oilSellPrice + "$";
    }

    private void UpdateOilPrice()
    {
        _oilSellPriceUpdateTime = OilSellTimer;
        _dayCount++;
        _oilSellPrice = _allSellPrices[_dayCount];
        UpdateGlobalInfo();
    }

    private void PayDay()
    {
        _payDayTime = PayDayTimer;
        _playerOil += _oilRevenue;
        UpdateGlobalInfo();
    }

    private IEnumerator GetFreshSellPricesData()
    {
        UnityWebRequest request = UnityWebRequest.Get("https://s3.us-west-2.amazonaws.com/secure.notion-static.com/5079b9d3-d379-480f-9262-1722b77c1004/brent_2014-2016.txt?X-Amz-Algorithm=AWS4-HMAC-SHA256&X-Amz-Content-Sha256=UNSIGNED-PAYLOAD&X-Amz-Credential=AKIAT73L2G45EIPT3X45%2F20230223%2Fus-west-2%2Fs3%2Faws4_request&X-Amz-Date=20230223T155808Z&X-Amz-Expires=86400&X-Amz-Signature=0c82a31ec28c4e00847d5f29467c511fcb2e749d8b9efa603d86538fbb4eda4f&X-Amz-SignedHeaders=host&response-content-disposition=filename%3D%22brent%25202014-2016.txt%22&x-id=GetObject");

        yield return request.SendWebRequest();

        var allText = request.downloadHandler.text.Split(",");
        
        for (int i = 15; i < allText.Length - 1;)
        {
            var str = allText[i].Split(".");
            _allSellPrices.Add(Int32.Parse(str[0]));
            i += 8;
        }
    }
}