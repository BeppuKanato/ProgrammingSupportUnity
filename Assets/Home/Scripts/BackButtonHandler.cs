using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButtonHandler : MonoBehaviour
{
    [SerializeField]
    HomeManager homeManager;
    //–ß‚éƒ{ƒ^ƒ“‚ğ‰Ÿ‚³‚ê‚½‚Æ‚«‚Ìˆ—
    public void OnClickBackButton()
    {
        homeManager.ChangeToPreveState();
    }
}
