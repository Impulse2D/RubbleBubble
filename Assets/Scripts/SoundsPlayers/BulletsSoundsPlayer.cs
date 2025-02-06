using UnityEngine;

public class BulletsSoundsPlayer : SoundsPlayer
{
    [SerializeField] private SpawnerBullets _spawnerBullets;

    private void OnEnable()
    {
        _spawnerBullets.ProjectileCollisionDetected += PlaySound;

        PauseService.PauseDisabled += StopSound;
    }

    private void OnDisable()
    {
        _spawnerBullets.ProjectileCollisionDetected -= PlaySound;

        PauseService.PauseDisabled -= StopSound;
    }

    public override void PlaySound()
    {
        float minValuePitch = 0.9f;
        float maxValuePitch = 1.1f;

        AudioSource.pitch = Random.Range(minValuePitch, maxValuePitch);

        SoundsService.PlaySoundOneShot(AudioSource, AudioClip);
    }
}
