using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaRegen : MonoBehaviour
{
    private Image manaBar;

    //[SerializeField]
    //private float lerpSpeed;
    //private float currentFill;
    //public float MyMaxValue { get; set; }
    //private float currentValue;
    //public float MyCurrentValue
    //{
    //    get
    //    {
    //        return currentValue;
    //    }
    //    set
    //    {
    //        if (value > MyMaxValue)
    //        {
    //            currentValue = MyMaxValue;
    //        }
    //        else if (value < 0)
    //        {
    //            currentValue = 0;
    //        }
    //        else
    //        {
    //            currentValue = value;
    //        }
    //        currentFill = currentValue / MyMaxValue;
    //    }
    //}

    // Start is called before the first frame update
    void Start()
    {
        //MyMaxValue = 100;
        //manaBar = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (currentFill != manaBar.fillAmount)
        //{
        //    manaBar.fillAmount = Mathf.Lerp(manaBar.fillAmount, currentFill, Time.deltaTime * lerpSpeed);
        //}
        //manaBar.fillAmount = currentFill;
        //Debug.Log(MyCurrentValue);
    }

    //public void Initialize(float currentValue, float maxValue)
    //{
    //    //Upon game start, set these values
    //    MyMaxValue = maxValue;
    //    MyCurrentValue = currentValue;
    //}

}
