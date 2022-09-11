using UnityEngine;

public class BalanceManager : MonoBehaviour
{

    [SerializeField]
    private TMPro.TMP_Text balanceText;
    private int _balance;

    [SerializeField]
    private SaveLoad saveLoad;

    private readonly string BALANCE_ID = "balance";
    void Start()
    {
        _balance = saveLoad.LoadData(BALANCE_ID);
        balanceText.text = $"Баланс: {_balance}$";
    }
    public int GetBalance()
    {
        return _balance;
    }
    public void IncreaseBalance(int income)
    {
        if (income < 0) return;
        _balance += income;
        balanceText.text = $"Баланс: {_balance}$";
        saveLoad.SaveData(BALANCE_ID, _balance);
    }

    public void DecreaseBalance(int expense)
    {
        if (expense < 0 || expense > _balance) return;
        _balance -= expense;
        balanceText.text = $"Баланс: {_balance}$";
        saveLoad.SaveData(BALANCE_ID, _balance);
    }
}
