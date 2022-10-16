using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReloadClass : MonoBehaviour
{
    public int max_ammo = 30;
    public int ammo = 30;
    private GameObject Ammo; 
    public Image reloadingCircle;
    public Image reloadingCircleProgress;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Reload(string funcName)
    {
        reloadingCircle.enabled = true;
        reloadingCircleProgress.enabled = true;
                
        Invoke(funcName, 2.5f);
    }

    void ExecuteAfterTime()
 {
    Text myText;
    myText = GameObject.Find("Ammo").GetComponent<Text>();
 
    reloadingCircle.enabled = false;
    reloadingCircleProgress.enabled = false;
    ammo = max_ammo;
    myText.text = "Ammo: " + ammo.ToString() + "/" + max_ammo;
    
 }
}
