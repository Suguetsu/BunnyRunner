using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGround : MonoBehaviour
{
    // Start is called before the first frame update
    private GameManager _GM;
    private Rigidbody2D groundRb;
    private float dist;
    private bool instanciar;
    private int count = 1;

    void Start()
    {
        _GM = FindObjectOfType(typeof(GameManager)) as GameManager;

        groundRb = GetComponent<Rigidbody2D>();



        groundRb.velocity = new Vector2(-1 * (_GM.groundVel), 0);


        if (transform.position.x < _GM.posToSet)
        {
            instanciar = false;
        }
        else
        {
            instanciar = true;
        }


    }

    // Update is called once per frame
    void Update()
    {
        dist = transform.position.x + _GM.widthGround;



        if (transform.position.x <= _GM.posToSet && instanciar)
        {
            if (_GM.platformCont >= _GM.groundRange.Length)
            {
                _GM.platformCont = 0;
            }


            Debug.Log("instanciado");
            GameObject temp = Instantiate(_GM.groundRange[_GM.platformCont]);
            temp.transform.position = new Vector2(dist, transform.position.y);

            _GM.platformCont += count;


            instanciar = false;


        }

        if (transform.position.x < _GM.toDestroy)
        {
            Destroy(this.gameObject);
            Debug.Log(dist);
            instanciar = true;
        }


    }
}
