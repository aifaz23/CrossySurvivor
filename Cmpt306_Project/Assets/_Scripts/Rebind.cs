using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rebind : MonoBehaviour
{
    [SerializeField] private KeyCode forward = KeyCode.W; 
    [SerializeField] private KeyCode left = KeyCode.A; 
    [SerializeField] private KeyCode right = KeyCode.D; 
    [SerializeField] private KeyCode backward = KeyCode.S; 
    [SerializeField] private KeyCode weaponLoadout1 = KeyCode.Alpha1; 
    [SerializeField] private KeyCode weaponLoadout2 = KeyCode.Alpha2; 
    [SerializeField] private KeyCode weaponLoadout3 = KeyCode.Alpha3; 
    [SerializeField] private KeyCode weaponLoadout4 = KeyCode.Alpha4; 
    [SerializeField] private bool rebinding = false;
    [SerializeField] private string keyToRebind;

    private int checkValidity(KeyCode newKey){
        if(newKey== forward){
            return -1;
        }
        if(newKey== left){
            return -1;
        }
        if(newKey== right){
            return -1;
        }
        if(newKey== backward){
            return -1;
        }
        if(newKey== weaponLoadout1){
            return -1;
        }
        if(newKey== weaponLoadout2){
            return -1;
        }
        if(newKey== weaponLoadout3){
            return -1;
        }
        if(newKey== weaponLoadout4){
            return -1;
        }
        return 0;
    }

    public void ChangeForward(){
        if(rebinding==false){
            keyToRebind="forward";
            rebinding=true;
        }
        foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode))){
            if(Input.GetKey(vKey)){
                if(checkValidity(vKey)==0){
                   transform.GetChild(1).gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/WhiteVariant/"+vKey.ToString());
                    transform.GetChild(1).GetChild(0).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "Move Up";
                    forward=vKey;
                    rebinding=false; 
                }
                else{
                    transform.GetChild(1).GetChild(0).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "Move Up";
                    rebinding=false;
                }
                
            }
        }
        
    }
    public void ChangeLeft(){
        if(rebinding==false){
        keyToRebind="left";
        rebinding=true;}
        foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode))){
            if(Input.GetKey(vKey)){
                if(checkValidity(vKey)==0){
                    transform.GetChild(2).gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/WhiteVariant/"+vKey.ToString());
                    transform.GetChild(2).GetChild(0).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "Move Right";
                    left=vKey;
                    rebinding=false;
                }
                else{
                    transform.GetChild(2).GetChild(0).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "Move Right";
                    rebinding=false;
                }
                
            }
        }
    }
    public void ChangeBackward(){
        if(rebinding==false){
        keyToRebind="backward";
        rebinding=true;}
        foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode))){
            if(Input.GetKey(vKey)){
                if(checkValidity(vKey)==0){
                    transform.GetChild(3).gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/WhiteVariant/"+vKey.ToString());
                    transform.GetChild(3).GetChild(0).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "Move Down";
                    backward=vKey;
                    rebinding=false;
                }
                else{
                    transform.GetChild(3).GetChild(0).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "Move Down";
                    rebinding=false;
                }
                
            }
        }
    }
    public void ChangeRight(){
        if(rebinding==false){
        keyToRebind="right";
        rebinding=true;}
        foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode))){
            if(Input.GetKey(vKey)){
                if(checkValidity(vKey)==0){
                    transform.GetChild(4).gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/WhiteVariant/"+vKey.ToString());
                    transform.GetChild(4).GetChild(0).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "Move Left";
                    right=vKey;
                    rebinding=false;
                }
                else{
                    transform.GetChild(4).GetChild(0).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "Move Left";
                    rebinding=false;
                }
                
            }
        }
    }
    
    public void ChangeWeaponLoadout1(){
        if(rebinding==false){
        keyToRebind="weaponLoadout1";
        rebinding=true;}
        foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode))){
            if(Input.GetKey(vKey)){
                if(checkValidity(vKey)==0){
                    transform.GetChild(9).gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/WhiteVariant/"+vKey.ToString());
                    transform.GetChild(9).GetChild(0).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "Change to weapon 1";
                    weaponLoadout1=vKey;
                    rebinding=false;
                }
                else{
                    transform.GetChild(9).GetChild(0).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "Change to weapon 1";
                    rebinding=false;
                }
                
            }
        }
    }
    public void ChangeWeaponLoadout2(){
        if(rebinding==false){
        keyToRebind="weaponLoadout2";
        rebinding=true;}
        foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode))){
            if(Input.GetKey(vKey)){
                if(checkValidity(vKey)==0){
                    transform.GetChild(10).gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/WhiteVariant/"+vKey.ToString());
                    transform.GetChild(10).GetChild(0).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "Change to weapon 2";
                    weaponLoadout2=vKey;
                    rebinding=false;
                }
                else{
                    transform.GetChild(10).GetChild(0).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "Change to weapon 2";
                    rebinding=false;
                }
                
            }
        }
    }
    public void ChangeWeaponLoadout3(){
        if(rebinding==false){
        keyToRebind="weaponLoadout3";
        rebinding=true;}
        foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode))){
            if(Input.GetKey(vKey)){
                if(checkValidity(vKey)==0){
                    transform.GetChild(11).gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/WhiteVariant/"+vKey.ToString());
                    transform.GetChild(11).GetChild(0).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "Change to weapon 3";
                    weaponLoadout3=vKey;
                    rebinding=false;
                }
                else{
                    transform.GetChild(11).GetChild(0).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "Change to weapon 3";
                    rebinding=false;
                }
                
            }
        }
    }
    public void ChangeWeaponLoadout4(){
        if(rebinding==false){
        keyToRebind="weaponLoadout4";
        rebinding=true;}
        foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode))){
            if(Input.GetKey(vKey)){
                if(checkValidity(vKey)==0){
                    transform.GetChild(12).gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/WhiteVariant/"+vKey.ToString());
                    transform.GetChild(12).GetChild(0).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "Change to weapon 4";
                    weaponLoadout4=vKey;
                    rebinding=false;
                }
                else{
                    transform.GetChild(12).GetChild(0).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "Change to weapon 4";
                    rebinding=false;
                }
                
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(rebinding==true){
            if(keyToRebind=="forward")ChangeForward();
            else if(keyToRebind=="left")ChangeLeft();
            else if(keyToRebind=="right")ChangeRight();
            else if(keyToRebind=="backward")ChangeBackward();
            else if(keyToRebind=="weaponLoadout1")ChangeWeaponLoadout1();
            else if(keyToRebind=="weaponLoadout2")ChangeWeaponLoadout2();
            else if(keyToRebind=="weaponLoadout3")ChangeWeaponLoadout3();
            else if(keyToRebind=="weaponLoadout4")ChangeWeaponLoadout4();
        }
        else{
            keyToRebind="";
        }
    }
}
