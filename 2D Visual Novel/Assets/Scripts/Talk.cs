using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Talk : MonoBehaviour {

    //Text which is modified on every scene
    public Text speech1;
    public Text name1;

   // public static string[,] dialog = new string[20, 2];
    public List<ExpressionClass> dialogPhrases = new List<ExpressionClass>();

    public int currentScene = -1; //-1 stands for currently not in scene
    public Button nextBtn;

    public Image character1;

    public Button choice1;
    public Button choice2;

    int nextDialogLine = 0;


    public void Start()
    {
        Button btn = nextBtn.GetComponent<Button>();
        btn.onClick.AddListener(OnBtnClick);

        //ChangeScene();  //Change scene to 0 - the initial story point
    }

    public void addToDialog(string characterName_, string characterPhrase_)
    {
        ExpressionClass newPhrase = new ExpressionClass();
        newPhrase.characterName = characterName_;
        newPhrase.characterExpression = characterPhrase_;
        dialogPhrases.Add(newPhrase);
    }

    public void ChangeScene()
    {
        currentScene += 1;  //Next scene started

        if (currentScene < dialogPhrases.Count)
        {
            name1.text = dialogPhrases[currentScene].characterName;
            speech1.text = dialogPhrases[currentScene].characterExpression;

            if (name1.text == "Char 1")
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

public class ExpressionClass
{
    public string characterName;
    public string characterExpression;
};

