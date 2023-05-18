using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TheCharacter : MonoBehaviour
{
    public GameObject DJAbility;
    public GameObject DJAbilityUI;
    public GameObject DJAbilityInstr;

    public GameObject SWAbility;
    public GameObject SWAbilityUI;
    public GameObject SWAbilityInstr;
    public GameObject SWCollider;

    public GameObject ShootAbility;
    public GameObject ShootAbilityUI;
    public GameObject ShootAbilityInstr;

    public GameObject Endgame;
    public GameObject EndingDialogue;

    public int DJValue;
    public int SWValue;
    public int ShootValue;

    public Slider healthbar;

    private bool isInvincible = false;
    [SerializeField] private float invincibilityDurationSeconds;
    [SerializeField] private float delayBetweenInvincibilityFlashes;
    [SerializeField] private float shockwaveDurationSeconds;
    [SerializeField] private float delayBetweenShockwave;

    // Start is called before the first frame update
    void Start()
    {
        DJValue = 0;
        SWValue = 0;
        ShootValue = 0;
        DJAbilityUI.SetActive(false);
        SWAbilityUI.SetActive(false);
        ShootAbilityUI.SetActive(false);
        SWCollider.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        AbilitySwitch();
        Shockwave();
        Reset();
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
            SWAbilityUI.SetActive(false);
            ShootAbilityUI.SetActive(false);
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
            Endgame.SetActive(true);
            EndingDialogue.SetActive(true);
        }
    }
    void OnCollisionEnter(Collision collision){
        if (collision.gameObject.CompareTag("Enemy")){
            LoseHealth(20);
        }
        if (collision.gameObject.CompareTag("Hazard")){
            LoseHealth(10);
        }
        //if (collision.gameObject.CompareTag("Health")){
            //LoseHealth(-30);
       // }
    }

    void AbilitySwitch(){
        if (Input.GetButtonDown("Fire1")) {
            if (DJAbilityUI.activeSelf == true) {
                if (GameObject.FindWithTag("SWAbility")) {
                    if (GameObject.FindWithTag("ShootAbility")) {
                        print("Nothing to switch to");
                    }
                    else {
                        DJAbilityUI.SetActive(false);
                        ShootAbilityUI.SetActive(true);
                    }
                }
                else {
                    DJAbilityUI.SetActive(false);
                    SWAbilityUI.SetActive(true);
                }
            }
            else if (SWAbilityUI.activeSelf == true) {
                if (GameObject.FindWithTag("ShootAbility")) {
                    if (GameObject.FindWithTag("DJAbility")) {
                        print("Nothing to switch to");
                    }
                    else {
                        SWAbilityUI.SetActive(false);
                        DJAbilityUI.SetActive(true);
                    }
                }
                else {
                    SWAbilityUI.SetActive(false);
                    ShootAbilityUI.SetActive(true);
                }
            }
            else if (ShootAbilityUI.activeSelf == true) {
                if (GameObject.FindWithTag("DJAbility")) {
                    if (GameObject.FindWithTag("SWAbility")) {
                        print("Nothing to switch to");
                    }
                    else {
                        ShootAbilityUI.SetActive(false);
                        SWAbilityUI.SetActive(true);
                    }
                }
                else {
                    ShootAbilityUI.SetActive(false);
                    DJAbilityUI.SetActive(true);
                }
            }
            else {
                print("Get lost");
            }
        }
    }
    public void Shockwave(){
        if (Input.GetButtonDown("Fire2")){
            if (SWAbilityUI.activeSelf == true){
                StartCoroutine(ShockwaveRoutine());
                Game.globalInstance.sndPlayer.PlayOnce(SoundType.OBOE, GetComponent<AudioSource>());
            }
            else if (ShootAbilityUI.activeSelf== true) {
                Game.globalInstance.sndPlayer.PlayOnce(SoundType.HARP, GetComponent<AudioSource>());
            }
        }
    }
    private IEnumerator ShockwaveRoutine(){
        SWCollider.SetActive(true);
        for (float i = 0; i < shockwaveDurationSeconds; i += delayBetweenShockwave){
            yield return new WaitForSeconds(delayBetweenShockwave);
        }
        SWCollider.SetActive(false);
    }
    private IEnumerator BecomeTemporarilyInvincible(){
        print("Player turned invincible!");
        isInvincible = true;

        for (float i = 0; i < invincibilityDurationSeconds; i += delayBetweenInvincibilityFlashes){
            yield return new WaitForSeconds(delayBetweenInvincibilityFlashes);

        }
        print("Player is no longer invincible!");
        isInvincible = false;
    }
    public void LoseHealth(int amount){
        if (isInvincible) return;
        healthbar.value -= amount;

        // The player died
        if (healthbar.value <= 0){
            healthbar.value = 0;
            return;
        }
        StartCoroutine(BecomeTemporarilyInvincible());
    }
    void Reset(){
        if (healthbar.value <= 0){
            print("die");
            SceneManager.LoadScene("Game");
        }
    }
}
