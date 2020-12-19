using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    public GameManager _GM;

    private bool isJumping;
    private bool isGrouded;
    private Rigidbody2D rb2D;
    public float powerJump;
    private int count;
  
    public Transform groundCheck;
    // Start is called before the first frame update
    void Start()
    {
        _GM = FindObjectOfType(typeof(GameManager)) as GameManager;
    }

    // Update is called once per frame

    private void FixedUpdate()
    {
        isGrouded = Physics2D.OverlapCircle(groundCheck.position, 0.02f);
        
        // responsávell por criar um circulo de dectção para detectar o chão
    }


    void Update()
    {
        isJumping = Input.GetButtonDown("Jump");
        rb2D = GetComponent<Rigidbody2D>();

        Pulo();


        if (transform.position.y < _GM.isfallenToGameOver)
        {
            _GM.SceneToLod("GameOver");
        }
        else if(transform.position.x < _GM.isfallenToGameOver)
        {
            _GM.SceneToLod("GameOver");
        }
    }



    void Pulo()
    {
        if (isJumping && isGrouded)
        {
            count = 0;
            count++;
            isJumping = !isJumping;
            rb2D.AddForce(new Vector2(0, powerJump));
            Debug.Log("pulei");

        }
        else if (isJumping && count == 1)
        {
            isJumping = !isJumping;
            rb2D.AddForce(new Vector2(0, powerJump));
            count = 0;
            Debug.Log("pulei2");
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "carrot")
        {
            Destroy(collision.gameObject);

            _GM.pointInt++;
            _GM.pointText.text = "Pontos: " + _GM.pointInt.ToString();

        }
        else if (collision.gameObject.tag == "flower")
        {
            Destroy(collision.gameObject);
            _GM.groundVel += 0.1f;

        }
        else if (collision.gameObject.tag == "obstaculo")
        {
            Debug.Log("morreu");

            _GM.SceneToLod("GameOver");
        }
    }


}
