using System;
using TMPro;
using UnityEngine;

public class text : MonoBehaviour
{
    public TMP_Text _textBox;
    public GameObject textfield;
    public int textIndex = 0;
    public bool sd = true;
    public GameObject textTriger;
    string[] txt = new string[] { 
        "ffs fskjsjgij ij i eio ei ee hoehhho iheed", 
        "hdfhshsjhdfs hjb  j jgvgf ffff  drtdxbv hg",
    "fghyujikohg gtyhujikojhgfwhyghuji,",
        "hjklkjhhjklop;okiju hujikolplokijuh jklookj",
    "ghjklkjh bhnjmkloplokijuhy bhjkiolkijuh"};
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

    public void pushText(int startIndex, int maxindex)
    {
        if (sd)
        {
            textIndex = startIndex;
            textfield.SetActive(true);
            //_textBox.text = " ";
            sd = false;

        }
        if (textIndex <= maxindex)
        {
            if (er)
            {
             e.Invoke();
                er = false;
            }
           // _textBox.text = " ";
            _textBox.text = txt[textIndex];

        }
        else
        {
            _textBox.text = " ";
            textfield.SetActive(false);
            textTriger.SetActive(false);
            dialogEnd.Invoke();
        }

    }
    public void indext()
    {
        er = true;
        textIndex++;
    }
}
