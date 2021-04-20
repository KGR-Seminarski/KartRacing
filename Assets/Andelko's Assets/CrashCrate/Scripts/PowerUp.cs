using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
namespace KartRacing.CrashCrate.Scripts
{
  public class PowerUp : MonoBehaviour
  {

    private Vector3 orgScale;
    private float rotationSpeed = 25.0f;
    private float bubbleAmplitude = 0.3f;

    public GameObject playerPrefab;

    [Header("Whole Create")]
    public MeshRenderer wholeCrate;
    public BoxCollider boxCollider;
    [Header("Fractured Create")]
    public GameObject fracturedCrate;
    [Header("Audio")]
    public AudioSource crashAudioClip;

    [SerializeField]
    public float startTransformY = 1;
    [SerializeField]
    public float startRotationZ = 23;
    [SerializeField]
    public float respawnTime = 3.0f;
    private void Start()
    {
      orgScale = transform.localScale;

      //Sets defaults position for gameobject and rotation
      var pos = transform.position;
      pos.y = startTransformY;
      transform.position = pos;
      transform.Rotate(new Vector3(0,
        0
      , startRotationZ));

    }

    private void Update()
    {
      if (!fracturedCrate.activeSelf)
      {
        //Transform gameobject on place
        transform.Rotate(new Vector3(0,
          Time.deltaTime * rotationSpeed
        , 0));
        Vector3 position = transform.position;
        position.y -= Mathf.Sin(Time.timeSinceLevelLoad - Time.deltaTime) * bubbleAmplitude;
        position.y += Mathf.Sin(Time.timeSinceLevelLoad) * bubbleAmplitude;
        transform.position = position;
      }

    }
    private void destroyCompoenent()
    {
      boxCollider.enabled = false;
      wholeCrate.enabled = false;
      fracturedCrate.SetActive(true);
      crashAudioClip.Play();
      Invoke("DestroySelf", respawnTime);
    }
    private void OnTriggerEnter(Collider other)
    {
      destroyCompoenent();
    }
    private void RespawnObject()
    {
      crashAudioClip.Play();
    }
    void DestroySelf()
    {
      Destroy(gameObject);
    }
    [Button("Test crash")]
    public void Test()
    {
      destroyCompoenent();
    }
  }
}
