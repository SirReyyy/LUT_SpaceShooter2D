using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaiderScript : MonoBehaviour
{
    private Singleton _singletonManager;

    [SerializeField]
    private SpriteRenderer raiderSpriteRenderer;
    private float moveSpeed;
    private float timer = 0, maxTime = 12.0f;
    public float minSpeed = 4.0f, maxSpeed = 10.0f;


    private void Awake() {
        raiderSpriteRenderer = GetComponent<SpriteRenderer>();
    } //-- Awake end

    void Start() {
        _singletonManager = Singleton.Instance;
    } //-- start end
    
    void Update() {
        transform.position += new Vector3(-moveSpeed * Time.deltaTime, 0, 0);

        timer += Time.deltaTime;
        if (timer > maxTime) {
            Destroy(this.gameObject);
        }
    } //-- Update end

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

