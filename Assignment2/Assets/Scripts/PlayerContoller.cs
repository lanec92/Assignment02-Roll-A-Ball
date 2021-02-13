using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerContoller : MonoBehaviour
{

    public float speed = 20f;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    public Material PlayerColor;
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    private int count;
    Vector3 vec = new Vector3(3f, 3f, 3f);



    void Awake()
    {
        ChangePlayerColor();

        if (GiantMode.giant == true)
        {
            GiantBall();
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;

        SetCountText();
        winTextObject.SetActive(false);


    }

    private void GiantBall()
    {
        transform.localScale = vec;
    }

    public void ChangePlayerColor()
    {
        switch(PickColor.playerColor)
        {
            default:
                PlayerColor.color = new Color(128/255f, 0, 0, 1);
                break;
            case 1:
                PlayerColor.color = new Color(128/255f, 0, 0, 1);
                break;
            case 2:
                PlayerColor.color = new Color(0, 128/255f, 1, 1);
                break;
            case 3:
                PlayerColor.color = new Color(161/255f, 23/255f, 242/255f, 1);
                break;
        }
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 12)
        {
            winTextObject.SetActive(true);
            Invoke("nxtLev", 5);

        }
    }

    public void nxtLev()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void AdjustSpeed(float newSpeed)
    {
        speed = newSpeed;
    }
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count += 1;

            SetCountText();
        }
    }
}
