using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : ObjectStats
{
    // Start is called before the first frame update
    [HideInInspector]
    public bool invulnerable = false;
    public float maxMana;
    public float manaRegen;
    public int damageGive;
    private Slider healthSlider;
    private Slider manaSlider;
    private Image manaSliderBar;
    
    float currentMana;

    private float manaBuffTime;
    private float manaMultiplier = 1f;

    public Color manaPoweredColor;
    private Color manaOriginalColor;



    public override void ChangeHealth(int damage)
    {
        if(invulnerable && damage < 0) return;
        base.ChangeHealth(damage);

        healthSlider.value = (float) Health / maxHealth;
    }

    public void ChangeMana(float change){
        currentMana = Mathf.Clamp(currentMana + change, 0.0f, maxMana);
    }

    public float getMana(){
        return currentMana;
    }

    protected override void Start()
    {
        base.Start();
        currentMana = maxMana;
        healthSlider = GameObject.Find("HealthSlider").GetComponent<Slider>();
        manaSlider = GameObject.Find("ManaSlider").GetComponent<Slider>();

        // ... Don't judge
        manaSliderBar = manaSlider.transform.Find("Fill Area").transform.Find("Fill").GetComponent<Image>();
        manaOriginalColor = manaSliderBar.color;
    } 
    protected override void Dead()
    {
        healthSlider.value = 0;
        base.Dead();

        GameManager.Instance.PlayerDied();
    }

    // Update is called once per frame
    protected override void Update()
    {
        currentMana = Mathf.Clamp(currentMana + (manaRegen * Time.deltaTime * manaMultiplier), 0f, maxMana);
        manaSlider.value = currentMana / maxMana;

        manaBuffTime -= Time.deltaTime;
        if (manaBuffTime <= 0f)
        {
            manaMultiplier = 1f;
            manaSliderBar.color = manaOriginalColor;
        }
    }


    public bool ManaBuff(float mult, float time)
    {
        if (manaBuffTime > float.Epsilon)
        {
            return false;
        }

        manaBuffTime = time;
        manaMultiplier = mult;

        manaSliderBar.color = manaPoweredColor;
        return true;
    }
}
