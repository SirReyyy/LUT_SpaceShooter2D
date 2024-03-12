using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CrosshairScript : MonoBehaviour
{
    private Singleton _singletonManager;
    public GameObject gameObj;

    private Rigidbody2D rb;
    public float moveSpeed;

    void Start() {
        _singletonManager = Singleton.Instance;

        rb = GetComponent<Rigidbody2D>();
    } //-- start end

    void Update() {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        rb.velocity = new Vector2(moveHorizontal * moveSpeed, moveVertical * moveSpeed);
        
        
        if (Input.GetKeyDown(KeyCode.Space)) {
            CheckHit();
        }
    } //-- Update end

    private void OnColliderEnter2D(Collider2D other) {
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (other.tag == "Raider") {
                Debug.Log("Hit");
            }   
        }
    } //-- OnCollisionEnter2D

    public void CheckHit() {
        Vector2 crosshairPos = new Vector2(transform.position.x, transform.position.y);

        if (GetComponent<Collider2D>() != Physics2D.OverlapPoint(crosshairPos)) {
            gameObj = Physics2D.OverlapPoint(crosshairPos).gameObject;

            if (gameObj.tag == "Raider") {
                _singletonManager.currentScore += 5;
                Destroy(gameObj);
            }
        }
    } //-- CheckHit end

} //-- class end


/*
Project: 
Made by: 
*/

