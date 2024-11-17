using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class LapCounter : MonoBehaviour
{
    public GameObject wineffect;
    public GameObject loseeffect;
    public TMP_Text Score;


    public int[] laps;
    public int[] pllaps;
    private void OnTriggerEnter(Collider other)
    {
        int index = Convert.ToInt32(other.gameObject.name[^1].ToString());
        
        int lps = laps[index] +=1;
        
        Score.text = "Laps:" + lps + "/" + "3";
        
        if (laps[index] ==3)
        {

            if (other.gameObject.name.Contains("Player"))
            {
                wineffect.SetActive(true);
            }
            else
            {
                loseeffect.SetActive(true);
            }
            
        }
    }
    
}
