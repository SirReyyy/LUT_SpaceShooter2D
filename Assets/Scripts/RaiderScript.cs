using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaiderScript : MonoBehaviour
{
    private Singleton _singletonManager;

    [SerializeField]
    private SpriteRenderer raiderSpriteRenderer;
    private float moveSpeed;
    private float timer = 0, maxTime = 10.0f;
    public float minSpeed = 3.0f, maxSpeed = 8.0f;


    private void Awake() {
        raiderSpriteRenderer = GetComponent<SpriteRenderer>();
    } //-- Awake end

    void Start() {
        _singletonManager = Singleton.Instance;
    } //-- start end

    void Update() {
        timer += Time.deltaTime;
        if (timer > maxTime) {
            Destroy(this.gameObject);
        }
    } //-- Update

    void FixedUpdate() {
        transform.position += new Vector3(-moveSpeed * Time.deltaTime, 0, 0);
    } //-- FixedUpdate end

    public void SetDirection(bool isRight) {
        moveSpeed = Random.Range(minSpeed, maxSpeed);

        if (!isRight) {
            moveSpeed = -moveSpeed;
            raiderSpriteRenderer.flipX = true;
        }
    } //-- SetDirection end

} //-- class end


/*
Project: 
Made by: 
*/

