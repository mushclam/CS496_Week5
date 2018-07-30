using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class genManager : MonoBehaviour {

    public static genManager instance;
    public Text genText;
    private string gen;
    void Awake()
    {
        if (!instance)
            instance = this;
    }
    public void setGenealogy(string g)
    {
        genText.text = g;
    }
}
