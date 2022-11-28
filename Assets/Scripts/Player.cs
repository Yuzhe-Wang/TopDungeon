using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Mover
{
    public Joystick joystick;

    private SpriteRenderer spriteRenderer;
    private bool isAlive = true;

    protected override void Start()
    {
        base.Start();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    protected override void ReceiveDamage(Damage damage)
    {
        if(!isAlive)
        {
            return;
        }
        base.ReceiveDamage(damage);
        GameManager.manager.OnHitpointChange();
    }

    private void FixedUpdate()
    {
        // get the input
        float x = Input.GetAxisRaw("Horizontal");
        x += joystick.Direction.x;
        float y = Input.GetAxisRaw("Vertical");
        y += joystick.Direction.y;

        if (isAlive)
        {
            UpdateMotor(new Vector3(x, y, 0));
        }
    }

    public void SwapSprite(int skinId)
    {
        spriteRenderer.sprite = GameManager.manager.playerSprites[skinId];
    }

    public void OnLevelUp()
    {
        maxHitpoint++;
        hitpoint = maxHitpoint;
    }

    public void SetLevel(int level)
    {
        for(int i= 0; i < level; ++i)
        {
            OnLevelUp();
        }
    }

    public void Heal(int healingAmount)
    {
        if(hitpoint == maxHitpoint)
        {
            return;
        }
        hitpoint += healingAmount;
        if (hitpoint > maxHitpoint)
        {
            hitpoint = maxHitpoint;
        }  
        GameManager.manager.ShowText("+" + healingAmount.ToString() + "hp", 25, Color.green, transform.position, Vector3.up * 30, 1.0f);
        GameManager.manager.OnHitpointChange();
    }

    protected override void Death()
    {
        isAlive = false;
        GameManager.manager.DeathMenuAnimator.SetTrigger("Show");
    }

    public void Respawn()
    {
        Heal(maxHitpoint);
        isAlive = true;
        lastImmune = Time.time;
        pushDirection = Vector3.zero;
    }
}
