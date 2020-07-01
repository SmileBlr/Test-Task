using System;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    private int currentFill;
    private string fillView;

    [SerializeField] private Text fillWork;
    [SerializeField] private Text fillShop;

    void Start()
    {
        currentFill = 20000;
        FillView();
    }

    void FillView()
    {
        fillView = currentFill.ToString();
        if (currentFill > 999)
        {
            for (int i = 1; i < 4; i++)
            {
                fillView=fillView.Remove(fillView.Length - 1);
            }

            fillView += "K";
        }
        changeFill();
    }

     void changeFill()
    {
        fillShop.text = fillView;
        fillWork.text = fillView;
    }

    public void upFill(int count)
    {
        currentFill += count;
        FillView();
    }

    public void useFill(int count)
    {
        currentFill -= count;
        FillView();
    }
}
