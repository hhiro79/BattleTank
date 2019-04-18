using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameClear : MonoBehaviour
{
    private Text clearNormaText;
    private Text destroyCountText;
    public int norma;
    private int destroyCount;

    // Start is called before the first frame update
    void Start()
    {
        clearNormaText = GameObject.Find("ClearNormaLabel").GetComponent<Text>();
        destroyCountText = GameObject.Find("DestroyCountLabel").GetComponent<Text>();

        clearNormaText.text = "目標数 : " + norma;
        destroyCountText.text = "撃破数 : " + destroyCount; 
    }

    public void AddDestroyCount(int amount){
        destroyCount += amount;
        destroyCountText.text = "撃破数 : " + destroyCount;

        if(destroyCount >= norma){
            SceneManager.LoadScene("GameClear");
        }
    }
}
