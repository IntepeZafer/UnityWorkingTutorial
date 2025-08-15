using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    public float speed = 10f;
    private int count;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        winTextObject.SetActive(false);
        SetCountText();
        count = 0;
    }
    public void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }
    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f , movementY);
        rb.AddForce(movement * speed);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count++;
        }
        SetCountText();
    }
    void SetCountText() 
    {
        countText.text = "Count: " + count.ToString();
        if(count >= 4)
        {
            winTextObject.SetActive(true);
        }
    }
}
