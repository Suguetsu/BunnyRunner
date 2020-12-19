using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetaObstaculos : MonoBehaviour
{
    private GameManager _GM;

    private float x, y;
    private int platNmber;
    private int indexSetobj;
    int index;
    int indexPLat;
    private bool isIsntanciado;
    private GameObject[] temp = new GameObject[2];
    public float posYAsset;



    // Start is called before the first frame update
    void Start()
    {


        _GM = FindObjectOfType(typeof(GameManager)) as GameManager;

        _GM.individalPlatform = GetComponentsInChildren<SpriteRenderer>();// pega a posiçao individual das plataformas


        index = Random.Range(0, 8);

        platNmber = _GM.individalPlatform.Length;







        for (int j = 0; j < _GM.objects; j++)
        {
            indexPLat = Random.Range(0, platNmber);
            StartCoroutine("SetaPrefabs");

        }

        Debug.Log("Chamei" + platNmber);
    }


    IEnumerator SetaPrefabs()
    {
        Debug.Log("entrei");

        yield return new WaitForSeconds(0);


        y = _GM.individalPlatform[indexPLat].GetComponent<SpriteRenderer>().size.y;
        x = _GM.individalPlatform[indexPLat].transform.localPosition.x;


        if (_GM.obstacles[index].gameObject.CompareTag("flower") && !isIsntanciado)
        {
            isIsntanciado = true;


            for (int i = 0; i < 12; i++)
            {

                temp[0] = Instantiate(_GM.obstacles[index].gameObject);

                temp[0].transform.SetParent(_GM.individalPlatform[indexPLat].gameObject.transform);

                float xGM = _GM.individalPlatform[indexPLat].GetComponent<BoxCollider2D>().offset.x - 0.5f;
                float yGm = _GM.individalPlatform[indexPLat].GetComponent<BoxCollider2D>().offset.y;

                temp[0].transform.localPosition = new Vector2(xGM + i, yGm + 0.8f); ;

                temp[0].GetComponent<SpriteRenderer>().sortingOrder = 2;
                temp[0].GetComponent<SpriteRenderer>().sortingLayerName = "mid";



                if (temp[0].transform.localPosition.sqrMagnitude >= _GM.individalPlatform[indexPLat].transform.localPosition.magnitude)
                {

                    Destroy(temp[0].gameObject);
                }


            }


            Debug.Log("flower");




        }
        else if (_GM.obstacles[index].gameObject.CompareTag("carrot") && !isIsntanciado)
        {


            for (int i = 0; i < 15; i++)
            {

                temp[1] = Instantiate(_GM.obstacles[index].gameObject);


                temp[1].transform.SetParent(_GM.individalPlatform[indexPLat].gameObject.transform);

                float xGM = _GM.individalPlatform[indexPLat].GetComponent<BoxCollider2D>().offset.x - 0.5f;
                float yGm = _GM.individalPlatform[indexPLat].GetComponent<BoxCollider2D>().offset.y;

                temp[1].transform.localPosition = new Vector2(xGM + i, yGm + 0.8f); ;

                temp[1].GetComponent<SpriteRenderer>().sortingOrder = 10;
                temp[1].GetComponent<SpriteRenderer>().sortingLayerName = "mid";




                if (temp[1].transform.localPosition.sqrMagnitude >= _GM.individalPlatform[indexPLat].transform.localPosition.magnitude)
                {

                    Destroy(temp[1].gameObject);
                }


            }


            isIsntanciado = true;

            Debug.Log("carrot");

        }
        else if (_GM.obstacles[index].gameObject.CompareTag("obstaculo") && !isIsntanciado)
        {



            GameObject temp2 = Instantiate(_GM.obstacles[index].gameObject);
            temp2.transform.SetParent(_GM.individalPlatform[indexPLat].gameObject.transform);
            float inde = Random.Range(0, _GM.individalPlatform[indexPLat].GetComponent<BoxCollider2D>().offset.x);



            float yGm = _GM.individalPlatform[indexPLat].GetComponent<BoxCollider2D>().offset.y;

            temp2.transform.localPosition = new Vector2(inde, yGm + 0.3f);
            isIsntanciado = true;

            temp2.GetComponent<SpriteRenderer>().sortingOrder = 2;
            temp2.GetComponent<SpriteRenderer>().sortingLayerName = "mid";

            Debug.Log("obstaculo");


        }
        else
        {

            indexPLat = Random.Range(0, platNmber);


            GameObject temp = Instantiate(_GM.obstacles[index].gameObject);
            temp.transform.SetParent(_GM.individalPlatform[indexPLat].gameObject.transform);

            float xGM = _GM.individalPlatform[indexPLat].GetComponent<BoxCollider2D>().offset.x - 0.5f;
            float yGm = _GM.individalPlatform[indexPLat].GetComponent<BoxCollider2D>().offset.y;
            temp.transform.localPosition = new Vector2(xGM, yGm + 0.3f);
            

            temp.GetComponent<SpriteRenderer>().sortingOrder = 2;
            temp.GetComponent<SpriteRenderer>().sortingLayerName = "mid";
            isIsntanciado = true;

            Debug.Log("acheinada");

            if (temp.transform.localPosition.sqrMagnitude >= _GM.individalPlatform[indexPLat].transform.localPosition.magnitude || (temp.gameObject.CompareTag("flower") || temp.gameObject.CompareTag("carrot")))
            {

                Destroy(temp.gameObject);
            }


            isIsntanciado = true;


        }



    }


}
