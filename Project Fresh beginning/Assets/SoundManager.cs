using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(CharacterController))]
public class SoundManager : MonoBehaviour
{
    // AudioSource để phát âm thanh bước chân
    public AudioSource footstepAudioSource;

    // Âm thanh bước chân
    public AudioClip[] footstepSounds;

    // Thời gian giữa các bước chân
    public float footstepInterval = 0.5f;

    // Thành phần CharacterController
    private CharacterController characterController;

    // Trạng thái nhân vật
    private bool isOnGround = true;
    private bool isMoving = false;
    private float footstepTimer = 0f;

    void Start()
    {
        // Lấy CharacterController và AudioSource
        characterController = GetComponent<CharacterController>();

        if (footstepAudioSource == null)
        {
            Debug.LogError("AudioSource chưa được gán. Vui lòng gán AudioSource!");
        }
    }

    void Update()
    {
        // Kiểm tra xem nhân vật có đang di chuyển hay không
        isMoving = characterController.velocity.magnitude > 0.1f;

        // Kiểm tra xem nhân vật có trên mặt đất không
        isOnGround = characterController.isGrounded;

        // Chỉ phát âm thanh nếu nhân vật đang di chuyển trên mặt đất
        if (isMoving && isOnGround)
        {
            footstepTimer += Time.deltaTime;

            if (footstepTimer >= footstepInterval)
            {
                PlayFootstepSound();
                footstepTimer = 0f;
            }
        }
        else
        {
            // Đặt lại bộ đếm khi nhân vật dừng lại hoặc nhảy
            footstepTimer = 0f;
        }
    }

    void PlayFootstepSound()
    {
        if (footstepSounds.Length > 0)
        {
            // Chọn ngẫu nhiên một âm thanh bước chân từ danh sách
            AudioClip footstep = footstepSounds[Random.Range(0, footstepSounds.Length)];
            footstepAudioSource.PlayOneShot(footstep);
        }
    }
}
