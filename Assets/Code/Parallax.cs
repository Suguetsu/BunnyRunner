using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    // Start is called before the first frame update

    public int orderLayer;
    public string sortingLayer;

    private Renderer mRender;
    private Material materialoffset;
    private GameManager _GM;


    public float incrementoOffset;
    public float offset;

    void Start()
    {

        _GM = FindObjectOfType(typeof(GameManager)) as GameManager;


        mRender = GetComponent<MeshRenderer>();

        mRender.sortingLayerName = sortingLayer;
        mRender.sortingOrder = orderLayer;

        materialoffset = mRender.material;




    }

    // Update is called once per frame
    void FixedUpdate()
    {
        offset += incrementoOffset;

        materialoffset.SetTextureOffset("_MainTex", new Vector3(offset*_GM.speed, 0));
    }
}
