using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Talk : MonoBehaviour {

    //Text which is modified on every scene
    public Text speech1;
    public Text name1;

    public string[] dialog;

    public int currentScene = -1; //-1 stands for currently not in scene
    //public GameObject choiceA;
    //public GameObject choiceB;
    public Button nextBtn;

    public void Start()
    {
        Button btn = nextBtn.GetComponent<Button>();
        btn.onClick.AddListener(OnBtnClick);
    }

    public void changeScene()
    {
        currentScene += 1;  //Next scene started

        if (currentScene < dialog.Length)
        {
            speech1.text = dialog[currentScene];
            name1.text = "Char 1";
        }
     
    }

    void OnBtnClick()
    {
        changeScene();
    }
}
