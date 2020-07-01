using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Painter : MonoBehaviour
{

    [SerializeField] private Color[] colorList;
    [SerializeField] private Color curColor;
    [SerializeField] private int colorCount;
    private string testColor;
    public RaycastHit2D hit;

    #region ArgsForColors
    [SerializeField] private GameObject color1;
    [SerializeField] private GameObject color2;
    [SerializeField] private GameObject color3;
    [SerializeField] private GameObject color4;
    [SerializeField] private GameObject color5;
    [SerializeField] private GameObject color6;
    /*
    private int totalColor0;
    private int totalColor1;
    private int totalColor2;
    private int totalColor3;
    private int totalColor4;
    private int totalColor5;

    private int nowColor0;
    private int nowColor1;
    private int nowColor2;
    private int nowColor3;
    private int nowColor4;
    private int nowColor5;
    */
    #endregion

    private bool magickWand;

    private bool magicSearche;

    private bool colorActive;

    private Color helpColor;

    void Start()
    {
        helpColor = new Color(255,0,215);
        magickWand = false;
        magicSearche = false;

        #region TotalColors
        /*
        GameObject[] index0 = GameObject.FindGameObjectsWithTag("0");
        foreach (var i in index0)
        {
            totalColor0++;
        }
        GameObject[] index1 = GameObject.FindGameObjectsWithTag("0");
        foreach (var i in index1)
        {
            totalColor1++;
        }
        GameObject[] index2 = GameObject.FindGameObjectsWithTag("0");
        foreach (var i in index2)
        {
            totalColor2++;
        }
        GameObject[] index3 = GameObject.FindGameObjectsWithTag("0");
        foreach (var i in index3)
        {
            totalColor3++;
        }
        GameObject[] index4 = GameObject.FindGameObjectsWithTag("0");
        foreach (var i in index4)
        {
            totalColor4++;
        }
        GameObject[] index5 = GameObject.FindGameObjectsWithTag("0");
        foreach (var i in index5)
        {
            totalColor5++;
        }
        */
        #endregion

    }
    public void Update()
    {
        curColor = colorList[colorCount];
        /*
        color1.GetComponent<Image>().fillAmount = nowColor0 / totalColor0;
        color2.GetComponent<Image>().fillAmount = nowColor1 / totalColor1;
        color3.GetComponent<Image>().fillAmount = nowColor2 / totalColor2;
        color4.GetComponent<Image>().fillAmount = nowColor3 / totalColor3;
        color5.GetComponent<Image>().fillAmount = nowColor4 / totalColor4;
        color6.GetComponent<Image>().fillAmount = nowColor5 / totalColor5;
        */
        #region MagicWand
        if (magickWand && colorActive)
        {
            magickWand = false;
            colorActive = false;
            GameObject[] objectsForLook = GameObject.FindGameObjectsWithTag(Convert.ToString(colorCount));
            foreach (var i in objectsForLook)
            {
                i.GetComponent<SpriteRenderer>().color = curColor;
            }
        }
        #endregion

        #region MagicSearche
        if (magicSearche && colorActive)
        {
            magicSearche = false;
            colorActive = false;
            GameObject[] objectsForLook = GameObject.FindGameObjectsWithTag(Convert.ToString(colorCount));
            foreach (var i in objectsForLook)
            {
                i.GetComponent<SpriteRenderer>().color = helpColor;
            }
        }
        #endregion

            var ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        hit = Physics2D.Raycast(ray, -Vector2.up);

        if (Input.GetMouseButtonDown(0))
        {
            if (hit.collider != null)
            {
                SpriteRenderer sp = hit.collider.gameObject.GetComponent<SpriteRenderer>();

                if (hit.transform.tag == testColor)
                {

                    #region upper
                    /*
                    if (testColor == "0")
                    {
                        nowColor0++;
                    }
                    if (testColor == "1")
                    {
                        nowColor1++;
                    }
                    if (testColor == "2")
                    {
                        nowColor2++;
                    }
                    if (testColor == "3")
                    {
                        nowColor3++;
                    }
                    if (testColor == "4")
                    {
                        nowColor4++;
                    }
                    if (testColor == "5")
                    {
                        nowColor5++;
                    }
                    */
                    #endregion

                    sp.color = curColor;
                }


                if (hit.collider == null)
                {
                    Camera.main.backgroundColor = curColor;
                }
            }
        }
    }

    public void paint(int colorCode)
    {
        colorCount = colorCode;
        testColor = Convert.ToString(colorCount);
        if (magickWand||magicSearche)
        {
            colorActive = true;
        }
    }

    public void magicWandActive(bool wand)
    {
        magickWand = wand;
    }

    public void magicSearcheActive(bool searche)
    {
        magicSearche = searche;
    }
}
