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
    private void Start()
    {
        fillLinePos = fillLine.transform.localPosition;
        //fillLinePos = fillLine.transform.position;
    }
    //Set the pouring mechanics and display how full the cup is.
    [SerializeField] private float desiredAmount;
    public Slider fillBar;
    public GameObject fillLine;
    private Vector3 fillLinePos;
    [SerializeField] GameObject posA, posB;
    public void setFillAmount(float amount)
    {
        desiredAmount = amount;
        //var linePos = fillBar.GetComponent<RectTransform>().localPosition;
        //Calculate for bar
        // Calculate the distance
        float distance = Vector3.Distance(posA.transform.position, posB.transform.position);
        distance = distance * amount;
        Vector3 difference = posB.transform.position - posA.transform.position;
        difference = difference.normalized * distance;


        var point =  posA.transform.position + difference;
        fillLine.transform.position = point;
    }
    public void Transaction(float amountFilled)
    {
        var difference = Mathf.Abs(desiredAmount - amountFilled);
        Debug.Log(difference);
        fillLine.transform.localPosition = fillLinePos;
    }
}
