using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    // Bomb
    [Header("Bomb")]
    public GameObject bombPrefab;
    public KeyCode inputKey = KeyCode.Space;
    public float bombFuseTime = 3f;
    public int bombAmount = 1;
    private int bombsRemaining;

    // Explosion
    [Header("Explosion")]
    public Explosion explosionPrefab;
    public LayerMask explosionLayerMask;
    public float explosionDuration = 1f;
    // bomb size
    public int explosionRadius = 1;

    private void OnEnable()
    {
        bombsRemaining = bombAmount;
    }
    private void Update()
    {
        if (bombsRemaining > 0 && Input.GetKeyDown(inputKey))
        {
            StartCoroutine(PlaceBomb());
        }
    }
        private IEnumerator PlaceBomb()
        {
            Vector2 position = transform.position;
            position.x = Mathf.Round(position.x);
            position.y = Mathf.Round(position.y);

            GameObject bomb = Instantiate(bombPrefab, position, Quaternion.identity);
            bombsRemaining--;

            yield return new WaitForSeconds(bombFuseTime);

            position = bomb.transform.position;
            position.x = Mathf.Round(position.x);
            position.y = Mathf.Round(position.y);

            Explosion explosion = Instantiate(explosionPrefab, position, Quaternion.identity);
            explosion.SetActiveRenderer(explosion.start);
            explosion.DestroyAfter(explosionDuration);
            Destroy(explosion.gameObject, explosionDuration);

            Explose(position, Vector2.up, explosionRadius);
            Explose(position, Vector2.down, explosionRadius);
            Explose(position, Vector2.left, explosionRadius);
            Explose(position, Vector2.right, explosionRadius);

            Destroy(bomb);
            bombsRemaining++;

        }
    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if(collision.gameObject.layer == LayerMask.NameToLayer("Bomb"))
    //    {
    //        collision.isTrigger = false;
    //    }
    //}

    private void Explose(Vector2 position, Vector2 direction, int length)
    {
        if(length <= 0)
        {
            return;
        }

        position += direction;

        if(Physics2D.OverlapBox(position, Vector2.one / 2f, 0f, explosionLayerMask))
        {
            return;
        }

        Explosion explosion = Instantiate(explosionPrefab, position, Quaternion.identity);
        explosion.SetActiveRenderer(length > 1 ? explosion.middle : explosion.end);
        explosion.SetDirection(direction);
        explosion.DestroyAfter(explosionDuration);
        //Destroy(explosion.gameObject, explosionDuration);

        Explose(position, direction, length - 1);
    }
}