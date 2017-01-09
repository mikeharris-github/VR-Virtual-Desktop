using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class KeyInput : MonoBehaviour {

    public SteamVR_TrackedObject left;
    public SteamVR_TrackedObject right;


	// Use this for initialization
	void Start () {
        //SteamVR.instance.overlay.ShowKeyboard(0, 0, "Description", 256, "", true,0);
        SteamVR_Utils.Event.Listen("KeyboardCharInput", OnKeyboard);
    }
	
	// Update is called once per frame
	void Update () {
        var lDevice = SteamVR_Controller.Input((int)left.index); //create variable lDevice for left controller
        var rDevice = SteamVR_Controller.Input((int)right.index); //create variable rDevice for right controller

        if (lDevice != null && lDevice.GetPressDown(SteamVR_Controller.ButtonMask.ApplicationMenu))
        {
            SteamVR.instance.overlay.ShowKeyboard(0, 0, "Description", 256, "", true, 0);
        }
        if (lDevice != null && lDevice.GetPressDown(SteamVR_Controller.ButtonMask.ApplicationMenu))
        {
            SteamVR.instance.overlay.ShowKeyboard(0, 0, "Description", 256, "", true, 0);

        }


    }

    private void OnKeyboard(object[] args)
    {
        VREvent_t evt = (VREvent_t)args[0];
        Debug.Log ((char)evt.data.keyboard.cNewInput0);
        VdmDesktopManager.Instance.SimulateKey((char)evt.data.keyboard.cNewInput0); //custom code utilizing Windows API
        // WindowsInput.InputSimulator.SimulateKeyPress((WindowsInput.VirtualKeyCode)evt.data.keyboard.cNewInput0);
        //InputSimulator.SimulateKeyPress(VirtualKeyCode.SPACE);
        // Do something with the accumulated text here
    }
}
