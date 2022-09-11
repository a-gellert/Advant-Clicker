using UnityEngine;

[CreateAssetMenu(fileName = "New Card Info", menuName = "Card Information Data", order = 52)]
public class CardInformation : ScriptableObject
{
    [SerializeField]
    private int businessId;
    [SerializeField]
    private string businessName;
    [SerializeField]
    private string firstBoostName;
    [SerializeField]
    private string secondBoostName;

    public int BusinessId
    {
        get
        {
            return businessId;
        }
    }
    public string BusinessName
    {
        get
        {
            return businessName;
        }
    }
    public string FirstBoostName
    {
        get
        {
            return firstBoostName;
        }
    }
    public string SecondBoostName
    {
        get
        {
            return secondBoostName;
        }
    }

}
