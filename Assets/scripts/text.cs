using System;
using System.Linq;
using TMPro;
using UnityEngine;

public class text : MonoBehaviour
{
    public TMP_Text _textBox;
    public GameObject textfield;
    public int textIndex = 0;
    public bool sd = true;
    // public GameObject textTriger;

    public static event Action dialogEnd;
    public static event Action e;
    bool er = true;
    void Start()
    {

    }
    private void Awake()
    {
        TextSystem.CompleteTextRevealed += indext;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            textfield.SetActive(true);
            // _textBox.text = "";
            _textBox.text = "the nachtkrapp is a german myth parrents tell their children that if they dont sleep at night that the nachtkrapp will come and if it see them awake it will take them to its nest and rip off their arms and eat their heart  ";

        }
    }

    public void pushText(string[] dialog)
    {
        if (sd)
        {
            textIndex = 0;
            textfield.SetActive(true);
            //_textBox.text = " ";
            sd = false;

        }
        if (textIndex <= dialog.Length - 1)
        {
            if (Input.GetKey(KeyCode.E) || Input.GetKey(KeyCode.Mouse0) || Input.GetKey(KeyCode.Mouse1))
            {
                if (er)
                {
                    e.Invoke();
                    er = false;
                }
                // _textBox.text = " ";
                _textBox.text = dialog[textIndex];


            }

        }
        else
        {
            _textBox.text = " ";
            textfield.SetActive(false);
            gameObject.SetActive(false);
            dialogEnd.Invoke();
        }

    }
    public void indext()
    {
        er = true;
        textIndex++;
    }
}
