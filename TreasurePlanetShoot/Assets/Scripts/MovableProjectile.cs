﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableProjectile : MonoBehaviour
{
    private Vector3 direction;
    private float speed = 5;

    private bool isEnnemy = true;
    private float damage = 1, bonusDamage;

    private Vector3 startPos;

    [SerializeField]
    private SpriteRenderer sprite = default;

    private void Start()
    {
        startPos = transform.position;
        gameObject.SetActive(false);
    }

    public void Initialise(Weapon newWeapon, ShipPlaytimeStatue shooter, Vector2 lazerDirection)
    {
        sprite.sprite = newWeapon.projectileSprite;
        direction = lazerDirection;
        speed = newWeapon.projectileSpeed;
        transform.position = shooter.transform.position;
        isEnnemy = !shooter.isPlayer;
        damage = newWeapon.damage;
        bonusDamage = newWeapon.damageByDifficulty;

        transform.up = direction;
        gameObject.SetActive(true);
    }

    public void DestroyLazer()
    {
        direction = Vector3.zero;
        speed = 0;
        transform.position = startPos;
        gameObject.SetActive(false);
    }

    private void FixedUpdate()
    {
        transform.position += direction * speed * Time.fixedDeltaTime;

        if (transform.position.x < -8.6f || transform.position.x > 8.6f || transform.position.y < -4.6f || transform.position.y > 4.6f)
        {
            DestroyLazer();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<ShipPlaytimeStatue>() != null)
        {
            if (collision.GetComponent<ShipPlaytimeStatue>().TakeDamage(damage, bonusDamage, isEnnemy))
            {
                DestroyLazer();
            }
        }
        else if (collision.tag == "Obstacle" || collision.tag == "MapBorder")
        {
            DestroyLazer();
        }
    }
}

