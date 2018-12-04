using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 날아가서 Drone 과 부딪혔다면??
// 그 주변을 다 날려버린다. (Drone)
public class Bomb : MonoBehaviour {
    // 주변의 범위
    public float bombRange = 5;
    // 폭발 효과
    public ParticleSystem psBomb;
    AudioSource sound;
	// Use this for initialization
	void Start () {
        sound = psBomb.GetComponent<AudioSource>();
    }

    // 충돌했을때 효과 재생
    private void OnCollisionEnter(Collision collision)
    {
        // 날아가서 부딪혔는데 그 주변에 drone 있다면 없애라
        // 날아가서 Drone 과 부딪혔다면??
        // 그 주변을 다 날려버린다. (Drone)
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit[] hitInfos =
            Physics.SphereCastAll(ray, bombRange, 1, 1 << LayerMask.NameToLayer("Drone"));

        // 부딪힌 녀석이 있다면??
        if(hitInfos.Length > 0)
        {

            //for (int i = 0;i<hitInfos.Length;i++)
            //{
            //    hitInfos[i]
            //}
            foreach (RaycastHit hit in hitInfos)
            {
                // 1. Drone 제거     
                Destroy(hit.transform.gameObject);
            }                
        }

        // 2. 폭발효과 발생
        // - bomb 위치에 폭발 효과 발생 
        psBomb.transform.position = transform.position;
        psBomb.Stop();
        psBomb.Play();
        sound.Stop();
        sound.Play();
        // 3. Bomb 도 제거
        //Destroy(gameObject);
        BombSpawn.Instance.ActiveBomb();
    }
}
