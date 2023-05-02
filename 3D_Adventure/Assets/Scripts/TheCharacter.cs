using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TheCharacter : MonoBehaviour
{
    public GameObject DJAbility;
    public GameObject DJAbilityUI;
    public GameObject DJAbilityInstr;
    public GameObject SWAbility;
    public GameObject SWAbilityUI;
    public GameObject SWAbilityInstr;
    public GameObject ShootAbility;
    public GameObject ShootAbilityUI;
    public GameObject ShootAbilityInstr;
    public Slider healthbar;
    private int DJValue;
    private int SWValue;
    private int ShootValue;
    // Start is called before the first frame update
    void Start()
    {
        DJValue = 0;
        SWValue = 0;
        ShootValue = 0;
        DJAbilityUI.SetActive(false);
        SWAbilityUI.SetActive(false);
        ShootAbilityUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (DJAbilityUI.activeSelf == true) {
            DJValue = 1;
        }
        else {
            DJValue = 0;
        }
        if (SWAbilityUI.activeSelf == true) {
            SWValue = 1;
        }
        else {
            SWValue = 0;
        }
        if (ShootAbilityUI.activeSelf == true){
            ShootValue = 1;
        }
        else {
            ShootValue = 0;
        }
    }
    void OnTriggerEnter(Collider collision){
        if (collision.gameObject.CompareTag("DJAbility")){
            Destroy(DJAbility);
            //SWAbilityUI.SetActive(false);
            //ShootAbilityUI.SetActive(false);
            DJAbilityUI.SetActive(true);
        }
        if (collision.gameObject.CompareTag("SWAbility")){
            Destroy(SWAbility);
            DJAbilityUI.SetActive(false);
            ShootAbilityUI.SetActive(false);
            SWAbilityUI.SetActive(true);
        }
        if (collision.gameObject.CompareTag("ShootAbility")){
            Destroy(ShootAbility);
            SWAbilityUI.SetActive(false);
            DJAbilityUI.SetActive(false);
            ShootAbilityUI.SetActive(true);
        }
    }
    void OnCollisionEnter(Collision collision){
        if (collision.gameObject.CompareTag("Enemy")){
            healthbar.value -= 20;
            // Knockback
            // Invincibility frames
        }
    }
}