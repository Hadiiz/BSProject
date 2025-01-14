﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage = Data.playerDamage;
    public float speed;
    public Vector2 velocity = new Vector2(0.0f, 0.0f);

    void Update()
    {
        Vector2 currentPosition = new Vector2(transform.position.x, transform.position.y);
        Vector2 newPosition = currentPosition + velocity * Time.deltaTime * speed;

        Debug.DrawLine(currentPosition, newPosition, Color.red);

        RaycastHit2D[] hits = Physics2D.LinecastAll(currentPosition, newPosition);

        foreach (RaycastHit2D hit in hits)
        {
            GameObject other = hit.collider.gameObject;
            Debug.Log(hit.collider.gameObject);
            if (other.CompareTag("Walls"))
            {
                Destroy(gameObject);
                break;
            }
            if (other.CompareTag("Enemy"))
            {
                Destroy(gameObject);
                other.GetComponent<DemonData>().health -= damage;
                break;
            }
            if (other.CompareTag("AlienBoss"))
            {
                Destroy(gameObject);
                other.GetComponent<AlienBossHealthBar>().Damage(damage);
                break;
            }
            if (other.CompareTag("SkeletonBoss"))
            {
                Destroy(gameObject);
                other.GetComponent<SkeletonBossHealthBar>().Damage(damage);
                break;
            }
        }

        transform.position = newPosition;

    }
}
