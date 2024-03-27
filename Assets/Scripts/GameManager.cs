using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance;
    private void Awake()
    {
        if (_instance == null && _instance != this)
        {
            _instance = this;
        }
    }

    //Set the pouring mechanics and display how full the cup is.
    private float desiredAmount;
    public Slider fillBar;
    public void setFillAmount(float amount)
    {
        desiredAmount = amount;
    }
}
