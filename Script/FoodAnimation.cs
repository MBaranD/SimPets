using System.Collections;
using System.Collections.Generic;
//using Nobi.UiRoundedCorners;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class FoodAnimation : MonoBehaviour
{
    public UnityEngine.UI.Button m_Button;
    public UnityEngine.UI.Image image1;
    public UnityEngine.UI.Image image2;
    
    void Start(){
        OnClicked(m_Button);
    }

    void OnClicked(UnityEngine.UI.Button button){
        if(button.name == "Food2"){
            UnityEngine.UI.Button btn = m_Button.GetComponent<UnityEngine.UI.Button>();
            btn.onClick.AddListener(FoodxAnimation);
        }
        if(button.name == "Food1"){
            UnityEngine.UI.Button btn = m_Button.GetComponent<UnityEngine.UI.Button>();
            btn.onClick.AddListener(FoodyAnimation);
        }
    }

    void FoodxAnimation(){
        Food1Animation();
        Food2Animation();
    }

    void FoodyAnimation(){
        Food1aAnimation();
        Food2aAnimation();
    }

    void Food1Animation(){
        this.image1.GetComponent<RectTransform>().localPosition = new Vector3(-276, -800, 0);

        UnityEngine.UI.Image img1 = image1.GetComponent<UnityEngine.UI.Image>();
        var tempColor = img1.color;
        tempColor.a = 0.5f;
        img1.color = tempColor;

        img1.rectTransform.sizeDelta = new Vector2(100,100);
    }

    void Food2Animation(){
        this.image2.GetComponent<RectTransform>().localPosition = new Vector3(0, -800, 0);

        UnityEngine.UI.Image img2 = image2.GetComponent<UnityEngine.UI.Image>();
        var tempColor = img2.color;
        tempColor.a = 1f;
        img2.color = tempColor;

        img2.rectTransform.sizeDelta = new Vector2(130,130);
    }

    void Food1aAnimation(){
        this.image1.GetComponent<RectTransform>().localPosition = new Vector3(0, -800, 0);

        UnityEngine.UI.Image img1 = image1.GetComponent<UnityEngine.UI.Image>();
        var tempColor = img1.color;
        tempColor.a = 1f;
        img1.color = tempColor;

        img1.rectTransform.sizeDelta = new Vector2(130,130);
    }

    void Food2aAnimation(){
        this.image2.GetComponent<RectTransform>().localPosition = new Vector3(276, -800, 0);

        UnityEngine.UI.Image img2 = image2.GetComponent<UnityEngine.UI.Image>();
        var tempColor = img2.color;
        tempColor.a = 0.5f;
        img2.color = tempColor;

        img2.rectTransform.sizeDelta = new Vector2(100,100);
    }
}
