using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    private Vector2 jumpForce = new Vector2(0, 3000);
    private Rigidbody2D rb2d;
    public bool dead = false;
    private void Start()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0) && dead == false)
        {
            rb2d.velocity = Vector2.zero;
            rb2d.AddForce(jumpForce);
        }

        Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        if (screenPosition.y > Screen.height || screenPosition.y < 0)
        {
            StartCoroutine(Die());
        }
    }

    private IEnumerator Die()
    {
        dead = true;
        rb2d.velocity = Vector2.zero;
        rb2d.angularVelocity *= -1000 * Time.deltaTime;
        rb2d.AddForce(new Vector2(0, 1500));
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(Die());
    }
}