using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeapotScript : MonoBehaviour
{
    [SerializeField]private bool dragging = false;
    private Vector3 offset;

    private Vector3 startPos;
    private Quaternion startRotation;
    public static TeapotScript _instance;
    public GameObject cupToBeFilled;

    private void Awake()
    {
        if (_instance == null && _instance != this)
        {
            _instance = this;
        }
        startPos = transform.position;
        startRotation = transform.rotation;
    }
    private void Update()
    {
        if (dragging)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset + new Vector3(0, 0, 10);
        }
        if (isPouring && dragging)
        {
            this.gameObject.transform.eulerAngles = new Vector3(0, 0, 44);
            Container container = cupToBeFilled.GetComponent<Container>();
            container.FillCup();
        }
        else
        {
            transform.rotation = startRotation;
        }
    }
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
        }
        
        if (collision.gameObject.CompareTag("Pouring"))
        {
            isPouring = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pouring"))
        {
            isPouring = false;
        }
    }

    //Pouring Mechanics
    [SerializeField]private bool isPouring = false;


}
