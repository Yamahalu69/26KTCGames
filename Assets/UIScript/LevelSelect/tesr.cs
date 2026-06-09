using UnityEngine;
using UnityEngine.InputSystem;
public class tesr : MonoBehaviour
{
    public float saiteiOkane = 0;
    public float imaOkane=0;
    public float okaneMaiByo = 97;
    public float okaneMax = 999;

    void Update()
    {
        if (Keyboard.current.spaceKey.isPressed==true)
        {
            imaOkane += okaneMaiByo * Time.deltaTime;
            // imaOkane += okaneMaiByo * Time.deltaTime;
        if (imaOkane > okaneMax)
        {
            imaOkane = okaneMax;
        }
        }
        else
        {
            imaOkane -= 200f * Time.deltaTime;
            if(imaOkane < saiteiOkane)
            {
                imaOkane = saiteiOkane;
            }
        }

        
    }
}
