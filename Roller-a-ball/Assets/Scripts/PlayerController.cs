using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    public TMP_Text countText;
    public TMP_Text winText;
    public float speed = 10.0f;
    private Rigidbody rb;

    private int count; //Score

    // holds movement x and y
    private float movementX;
    private float movementY;

    // Start is called before the first frame update
    void Start()
    {
        count = 0; // set to 0
        SetCountText();
        rb = GetComponent<Rigidbody>(); // sets rigibody component to rb
        winText.gameObject.SetActive(false);
    }

    void OnMove(InputValue movementValue)
    {
        // create a vector 2 variable and store the x ant y movement valuest in it
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // set the movement to the x and z variables (keep y at 0)
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);

            // and 1 to the score
            count++;
            SetCountText();
        }

    }

    void SetCountText()
    {
        countText.text = "Player count:" + count.ToString()+"/12";
        if (count >= 12)
        {
            winText.gameObject.SetActive(true);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
