using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField]
    private BusinessData businessData;
    [SerializeField]
    private CardInformation cardInformation;
    [SerializeField]
    private TMPro.TMP_Text businessNameText;
    [SerializeField]
    private TMPro.TMP_Text levelText;
    [SerializeField]
    private TMPro.TMP_Text incomeText;
    [SerializeField]
    private TMPro.TMP_Text upgradeButtonText;
    [SerializeField]
    private TMPro.TMP_Text firstBoostText;
    [SerializeField]
    private TMPro.TMP_Text secondBoostText;

    [SerializeField]
    private BalanceManager balanceManager;
    [SerializeField]
    private SaveLoad saveLoad;
    private Converter converter;

    private int _currentIncome = 0;
    private int _currentPriceOfUpgrade = 0;
    private float _multiplier = 1;
    private bool _firstBoostIsBought;
    private bool _secondBoostIsBought;
    public int Timer { get; private set; }
    public int Level { get; private set; }



    void Awake()
    {
        converter = new Converter();
        Timer = businessData.IncomeDelay;

        int level = saveLoad.LoadData(businessData.Id);
        Level = level == 0 ? businessData.CurrentLevel : level;

        _firstBoostIsBought = converter.IntToBool(saveLoad.LoadData(cardInformation.FirstBoostName + businessData.Id));
        _secondBoostIsBought = converter.IntToBool(saveLoad.LoadData(cardInformation.SecondBoostName + businessData.Id));
    }
    void Start()
    {
        OverwriteText();
    }

    private void OverwriteText()
    {
        ParametersControl();
        businessNameText.text = cardInformation.BusinessName;
        levelText.text = $"LVL\n{Level}";
        incomeText.text = $"Доход\n{_currentIncome}";
        upgradeButtonText.text = $"LVL UP\nЦена: {_currentPriceOfUpgrade}";
        firstBoostText.text = $"{cardInformation.FirstBoostName}\nДоход +{businessData.MultiplierOfFirstBoost}%\n {(_firstBoostIsBought ? "Куплено" : $"{businessData.PriceOfFirstBoost}$")}";
        secondBoostText.text = $"{cardInformation.SecondBoostName}\nДоход +{businessData.MultiplierOfSecondBoost}%\n {(_secondBoostIsBought ? "Куплено" : $"{businessData.PiceOfSecondBoost}$")}";
    }

    private void ParametersControl()
    {
        _currentIncome = Mathf.RoundToInt(Level * businessData.InitialIncome * _multiplier);
        _currentPriceOfUpgrade = (Level + 1) * businessData.InitialPrice;
    }
    public void AddBalance()
    {
        balanceManager.IncreaseBalance(_currentIncome);
    }

    public void BuyLevel()
    {
        if (CheckAbilityToPay(_currentPriceOfUpgrade))
        {
            Level++;
            balanceManager.DecreaseBalance(_currentPriceOfUpgrade);
            saveLoad.SaveData(businessData.Id, Level);
            OverwriteText();
        }
    }
    public void BuyFirstBoost()
    {
        if (!_firstBoostIsBought && CheckAbilityToPay(businessData.PriceOfFirstBoost))
        {
            _firstBoostIsBought = true;
            _multiplier += businessData.MultiplierOfFirstBoost / 100f;
            balanceManager.DecreaseBalance(businessData.PriceOfFirstBoost);
            saveLoad.SaveData(cardInformation.FirstBoostName + businessData.Id, converter.BoolToInt(_firstBoostIsBought));
            OverwriteText();
        }
    }
    public void BuySecondBoost()
    {
        if (!_secondBoostIsBought && CheckAbilityToPay(businessData.PriceOfFirstBoost))
        {
            _secondBoostIsBought = true;
            _multiplier += businessData.MultiplierOfSecondBoost / 100f;
            balanceManager.DecreaseBalance(businessData.PiceOfSecondBoost);
            saveLoad.SaveData(cardInformation.SecondBoostName + businessData.Id, converter.BoolToInt(_secondBoostIsBought));
            OverwriteText();
        }
    }

    private bool CheckAbilityToPay(int cost)
    {
        return (balanceManager.GetBalance() >= cost);

    }
}
