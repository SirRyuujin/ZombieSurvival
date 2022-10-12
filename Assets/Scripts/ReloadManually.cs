using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ReloadManually : MonoBehaviour {
	
	public Button button;
    private Shooting shootClass;
    private GameObject Ammo; 
    public Image reloadingCircle;
    public Image reloadingCircleProgress;
    public static bool can_shoot = true;
    
    void Start()
    {
    	button.onClick.AddListener(Reload);
    }
    
    public void Reload()
    {
        reloadingCircle.enabled = true;
        reloadingCircleProgress.enabled = true;
        Text myText;
        myText = GameObject.Find("Ammo").GetComponent<Text>();
        can_shoot = false;
        myText.text = "Ammo: 0/" + Shooting.max_ammo;
        button.enabled = false;
                
        Invoke("ExecuteAfterTime", 2.5f);
    }

    void ExecuteAfterTime()
    {
        Text myText;
        myText = GameObject.Find("Ammo").GetComponent<Text>();
    
        reloadingCircle.enabled = false;
        reloadingCircleProgress.enabled = false;
        Shooting.ammo = Shooting.max_ammo;
        myText.text = "Ammo: " + Shooting.ammo.ToString() + "/" + Shooting.max_ammo;
        can_shoot = true;
        button.enabled = true;
    
    }
}