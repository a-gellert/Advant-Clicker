using UnityEngine;

[CreateAssetMenu(fileName = "New Business Config", menuName = "Business Config Data", order = 51)]
public class BusinessData : ScriptableObject
{

    [SerializeField]
    private string id;
    [SerializeField]
    private int incomeDelay;
    [SerializeField]
    private int initialPrice;
    [SerializeField]
    private int initialIncome;
    [SerializeField]
    private int currentLevel;

    [SerializeField]
    private int priceOfFirstBoost;
    [SerializeField]
    private int multiplierOfFirstBoost;
    [SerializeField]
    private int priceOfSecondBoost;
    [SerializeField]
    private int multiplierOfSecondBoost;


    public string Id
    {
        get
        {
            return id;
        }
    }
    public int IncomeDelay
    {
        get
        {
            return incomeDelay;
        }
    }
    public int InitialPrice
    {
        get
        {
            return initialPrice;
        }
    }
    public int InitialIncome
    {
        get
        {
            return initialIncome;
        }
    }
    public int CurrentLevel
    {
        get
        {
            return currentLevel;
        }
    }
    public int PriceOfFirstBoost
    {
        get
        {
            return priceOfFirstBoost;
        }
    }
    public int MultiplierOfFirstBoost
    {
        get
        {
            return multiplierOfFirstBoost;
        }
    }
    public int PiceOfSecondBoost
    {
        get
        {
            return priceOfSecondBoost;
        }
    }
    public int MultiplierOfSecondBoost
    {
        get
        {
            return multiplierOfSecondBoost;
        }
    }

}
