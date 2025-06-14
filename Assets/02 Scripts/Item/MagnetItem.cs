using System.Collections;
using UnityEngine;

public class MagnetItem : MonoBehaviour, IItem
{
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] ParticleSystem particle;
    public float duration = 5f; // 자석 효과 지속 시간
    private GameObject absorber;
    private GameObject absorber1;

    private PointEffector2D pointEffect;

    private void Start()
    {
        Transform trPlayer = GameObject.FindWithTag(ReadonlyData.PlayerTagName).transform;
        absorber = trPlayer.Find("Absorber")?.gameObject;
        absorber1 = trPlayer.Find("Absorber1")?.gameObject;

        if (absorber == null)
        {
            Debug.LogError("Absorber 오브젝트를 찾을 수 없습니다!");
        }
        else
        {
            // Absorber 오브젝트 안에 있는 PointEffector2D 컴포넌트 찾기
            pointEffect = absorber.GetComponent<PointEffector2D>();

            if (pointEffect == null)
            {
                Debug.LogError("Absorber 오브젝트에 PointEffector2D나 Collider2D를 찾을 수 없습니다!");
            }
        }
    }

    public void OnCollisionEffect()
    {
        // 아이템을 보이지 않게 하고, 효과를 실행
        if (spriteRenderer != null)
        {
            Destroy(spriteRenderer.gameObject);
        }

        // 자석 효과 활성화
        StartCoroutine(MagnetEffect(duration));
    }

    private IEnumerator MagnetEffect(float duration)
    {
        if (absorber == null || absorber1 == null)
        {
            Destroy(gameObject); // Absorber가 없으면 아이템 삭제
            yield break;
        }

        absorber.SetActive(true);
        absorber1.SetActive(true);

        // 지정된 시간 동안 대기
        yield return new WaitForSeconds(duration);

        // 자석 효과 종료
        absorber.SetActive(false);
        absorber1.SetActive(false);

        // 아이템 삭제
        Destroy(gameObject);
    }
}
