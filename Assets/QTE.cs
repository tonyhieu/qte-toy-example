using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QTE : MonoBehaviour
{
    public TMP_InputField input;
    public TMP_Text text;

    private List<string> prompts = new List<string> {"something", "test", "momochi"};
    private List<string> answers = new List<string> {"something", "test", "momochi"};

    private bool activeQTE = false;
    private string answer;

    // Start is called before the first frame update
    void Start()
    {
        // from: https://docs.unity3d.com/2018.1/Documentation/ScriptReference/UI.InputField-onValueChanged.html
        input.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            int index = Random.Range(0, 3);

            input.ActivateInputField();
            input.text = "";
            text.text = prompts[index];
            answer = answers[index];
            activeQTE = true;
        }
    }

    public void ValueChangeCheck()
    {
        if (!activeQTE)
        {
            return;
        }

        string lowercaseInput = input.text.ToLower();
        bool isSameSoFar = string.Compare(lowercaseInput, answer.Substring(0, input.text.Length)) == 0;
        if (!isSameSoFar)
        {
            text.text = "You failed!";
            activeQTE = false;
        }
        if (string.Compare(lowercaseInput, answer) == 0)
        {
            text.text = "You won!";
            activeQTE = false;
        }
    }
}
