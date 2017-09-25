using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Talk : MonoBehaviour {

    //Text which is modified on every scene
    public Text speech1;
    public Text name1;

    public static string[,] dialog = new string[4, 2];

    public int currentScene = -1; //-1 stands for currently not in scene
    public Button nextBtn;

    public Image character1;

    public Button choice1;
    public Button choice2;


    public void Start()
    {
        Button btn = nextBtn.GetComponent<Button>();
        btn.onClick.AddListener(OnBtnClick);

        PopulateDialog();
        ChangeScene();  //Change scene to 0 - the initial story point
    }

    public void PopulateDialog()
    {
        dialog[0, 0] = "Destiny";
        dialog[0, 1] = "Speech 1";

        dialog[1, 0] = "Death";
        dialog[1, 1] = "Speech 2";

        dialog[2, 0] = "Death";
        dialog[2, 1] = "Speech 3";

        dialog[3, 0] = "Destiny";
        dialog[3, 1] = "Speech 4";
    }

    public void ChangeScene()
    {
        currentScene += 1;  //Next scene started

        if (currentScene < dialog.GetLength(0))
        {
            name1.text = dialog[currentScene, 0];
            speech1.text = dialog[currentScene, 1];

            if (name1.text == "Destiny")
                character1.enabled = true;
            else
                character1.enabled = false;
        }
        else //Choice
        {
            choice1.GetComponentInChildren<Text>().text = "Choice A";
            choice2.GetComponentInChildren<Text>().text = "Choice B";
            choice1.gameObject.SetActive(true);
            choice2.gameObject.SetActive(true);

        }
     
    }

    void OnBtnClick()
    {
        ChangeScene();
    }

    //TODO
    //Choice situation
}

