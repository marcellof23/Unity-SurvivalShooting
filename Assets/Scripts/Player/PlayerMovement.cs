﻿using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6f;
    Vector3 movement;
    Animator anim;
    Rigidbody playerRigidBody;
    int floorMask;
    float camRayLength = 100f;

    public PlayerAttributes playerAttributes;

    private void Awake() {
        //Mendapatkan nilai mask dari layer yang bernama floor
        floorMask = LayerMask.GetMask("Floor");

        anim = GetComponent<Animator>();

        playerRigidBody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate() {
        //Mendapatkan nilai input horizontal (-1, 0, 1)
        float h = Input.GetAxisRaw("Horizontal");

        //Mendapatkan nilai input vertikal (-1, 0, 1)
        float v = Input.GetAxisRaw("Vertical");

        Move(h, v);
        Turning();
        Animating(h, v);
    }

    void Animating(float h, float v) {
        bool walking = h != 0f || v != 0f;
        anim.SetBool("IsWalking", walking);
    }

    void Turning() {
        //Buat ray dari posisi mouse di layar
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        //Buat raycast untuk floorHit
        RaycastHit floorHit;

        //Lakukan raycast
        if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask)) {
            //Mendapatkan vector dari posisi player dan posisi floorHit
            Vector3 playerToMouse = floorHit.point - transform.position;
            playerToMouse.y = 0f;

            //Mendapatkan look rotation baru ke hit position
            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);

            //Rotase player
            playerRigidBody.MoveRotation(newRotation);
        }
    }

    void Move(float h, float v) {
        //Set nilai x dan y
        movement.Set(h, 0f, v);

        //Menormalisasi nilai vector agar total panjang dari vector adalah 1
        movement = movement.normalized * speed * Time.deltaTime * playerAttributes.currentSpeedModifier;

        //Move to position
        playerRigidBody.MovePosition(transform.position + movement);
    }
}
