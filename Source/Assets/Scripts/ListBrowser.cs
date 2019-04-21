using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListBrowser : MonoBehaviour
{
    private int index = 0;
    public List<Selectable> but;
    private bool blockOveflow = false;
    private bool firstInput = false;

    public enum modeChose {Vertical,Horizontal};

    public modeChose ScrollingMode = modeChose.Vertical;

    public void verticalMenuSwitching()
    {
        float joystickVal = 0;
        if(ScrollingMode == modeChose.Vertical)
        {
            joystickVal = Input.GetAxisRaw("Vertical gamepad");
        }else if(ScrollingMode == modeChose.Horizontal)
        {
            joystickVal = Input.GetAxisRaw("Horizontal gamepad");
        }
        if (!blockOveflow)
        {
            if (joystickVal > 0.9 && index > 0)
            {
                if (firstInput)
                {
                    index--;
                    blockOveflow = true;
                    firstInput = true;
                }
            }
            else if (joystickVal < -0.9 && index < but.Count - 1)
            {
                if (firstInput)
                {
                    index++;
                }
                blockOveflow = true;
                firstInput = true;

            }
        }

        if(joystickVal <= 0.05 && joystickVal >= -0.05)
        {
            blockOveflow = false;
        }


    }

    private void checkInput()
    {
        if (firstInput)
        {
            if (but.Count > 0)
            {
                but[index].Select();
            }

            if (but[index] is Button)
            {
                if (Input.GetButton("Submit") && index > 0)
                {
                    but[index - 1].enabled = true;
                }
            }
            if (but[index] is Slider)
            {
                float horizontalVal = Input.GetAxisRaw("Horizontal gamepad");
                Slider d = (Slider)but[index];
                d.value += horizontalVal * 0.02f;
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeSelf)
        {
            verticalMenuSwitching();
            checkInput();
        }
    }
}
