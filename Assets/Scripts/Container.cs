using UnityEngine;
using UnityEngine.UI;

public class Container : MonoBehaviour
{
    public float ContainerCapacity, fillRate, fillAmount;
    public Slider fillBar;
    public GameObject fillBarObject;

    //dragging mechanics 
    [SerializeField] private bool dragging = false;
    private Vector3 offset;

    private Vector3 startPos;
    private Quaternion startRotation;

    private void Start()
    {
        TeapotScript._instance.cupToBeFilled = this.gameObject;
        startPos = transform.position;
        startRotation = transform.rotation;
    }
    private void Update()
    {
        fillBar.value = fillAmount;
        DisplayFillBar();

        if (dragging)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset + new Vector3(0, 0, 10);
        }
    }
    public void PickPourAmount()
    {
        var desiredAmount = Random.Range(0, ContainerCapacity - 0.01f);
        GameManager._instance.setFillAmount(desiredAmount);
    }
    public void DisplayFillBar()
    {
        if (fillBar.value == 0)
        {
            fillBarObject.SetActive(false);
        }
        if (fillBar.value > 0)
        {
            fillBarObject.SetActive(true);
        }
    }
    public void FillCup()
    {
        if (fillBar.value != ContainerCapacity)
        {
            fillAmount += 1 * fillRate * Time.deltaTime;
        }
    }

    //dragging mechanics
    private void OnMouseDown()
    {
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dragging = true;
    }

    private void OnMouseUp()
    {

        dragging = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bounds"))
        {
            transform.position = startPos;
            dragging = false;
            fillAmount = 0;
        }
    }
}