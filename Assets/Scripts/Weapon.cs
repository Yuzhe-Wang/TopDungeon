using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Collidable
{
    // damage
    public int [] damagePoint = {1, 2, 3, 4, 5, 6, 7};
    public float [] pushForce = { 2.0f, 2.2f, 2.5f, 3.0f, 3.2f, 3.6f, 4.0f };

    // upgrade
    public int weaponLevel = 0;
    private SpriteRenderer spriteRenderer;

    // swing
    private Animator anim;
    private float cooldown = 0.5f;
    private float lastSwing;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    protected override void Start()
    {
        base.Start();
        anim = GetComponent<Animator>();
    }

    protected override void Update()
    {
        base.Update();
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(Time.time - lastSwing > cooldown)
            {
                lastSwing = Time.time;
                Swing();
            }
        }
    }

    protected override void OnCollide(Collider2D coll)
    {
        if (coll.tag == "Fighter")
        {
            if(coll.name == "Player")
            {
                return;
            }

            // create a damage object, then send it to the fighter we've hit
            Damage damage = new Damage();
            damage.damageAmount = damagePoint[weaponLevel];
            damage.origin = transform.position;
            damage.pushForce = pushForce[weaponLevel];

            coll.SendMessage("ReceiveDamage", damage);
            Debug.Log("attacking");
        }
    }

    public void Swing()
    {
        anim.SetTrigger("Swing");
    }

    public void UpgradeWeapon()
    {
        weaponLevel++;
        spriteRenderer.sprite = GameManager.manager.weaponSprites[weaponLevel];
    }

    public void SetWeaponLevel(int level)
    {
        weaponLevel = level;
        spriteRenderer.sprite = GameManager.manager.weaponSprites[level];
    }
}
