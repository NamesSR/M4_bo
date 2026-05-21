using TMPro;
using UnityEngine;

public class text : MonoBehaviour
{
   public TMP_Text _textBox;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            _textBox.text = "the nachtkrapp is a german myth parrents tell their children that if they dont sleep at night that the nachtkrapp will come and if it see them awake it will take them to its nest and rip off their arms and eat their heart  ";

        }
    }
}
