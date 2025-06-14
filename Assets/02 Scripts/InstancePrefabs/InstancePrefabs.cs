using UnityEngine;

public class InstancePrefabs : MonoBehaviour
{
    public GameObject[] backgroundPrefabs;
    public GameObject[] backgroundZeps;
    private float maxWidthX = 400;
    private float maxRandHeightY = 2;
    private float minRandHeightY = 0;
    private float minRandWidthX = 1;
    private float maxRandWidthX = 3;
    private SpriteRenderer[] backgroundsSpriteRenderer;
    private Color minusColor = new Color(0.1f, 0.1f, 0.1f, 0f);
    private GameObject player;
    [SerializeField]private Color beforeColor;
    [SerializeField]private Color nextColor;
    private float nowTime = 60f;
    private float lerpT = 0;
    private float startColor = 0.9f;


    private void Awake()
    {
        player = GameObject.FindWithTag(ReadonlyData.PlayerTagName);
        ShuffleArray(backgroundPrefabs);
        ShuffleArray(backgroundZeps);
        ResetBackgroundImage();
        ResetCharactorImage();
        backgroundsSpriteRenderer = GetComponentsInChildren<SpriteRenderer>();
    }

    private void Start()
    {
        ResetBackgroundColor();
    }


    private void Update()
    {
        SettingColor();
        ChangeColor();
    }


    //컬러를 배어받은 후, 배경들의 색깔을 변경하는 메서드
    private void ResetBackgroundColor()
    {
        beforeColor = new Color(startColor, startColor, startColor, 1);
        nextColor = new Color(startColor, startColor, startColor, 1);
        for (int i = 0; i < backgroundsSpriteRenderer.Length; i++)
        {
            backgroundsSpriteRenderer[i].color = beforeColor;
        }
    }


    //배경 바탕 이미지를 초기화
    private void ResetBackgroundImage()
    {
        float nowWidthX = 0;
        int i = 0;
        while (nowWidthX < maxWidthX)
        {
            if (i >= backgroundPrefabs.Length) i = 0;

            float randHeightY       = Random.Range(minRandHeightY, maxRandHeightY);
            float randWidthX        = Random.Range(minRandWidthX, maxRandWidthX);
            Vector3 tempVector      = new Vector3(nowWidthX, randHeightY, 0f);
            GameObject obj          = Instantiate(backgroundPrefabs[i], tempVector, Quaternion.identity);
            Renderer renderer       = obj.GetComponent<Renderer>();
            obj.transform.parent    = this.transform;

            if (renderer != null)
            {
                nowWidthX              += renderer.bounds.size.x + randWidthX;
                Color beforeColor       = renderer.material.color;
                renderer.material.color = new Color(beforeColor.r, beforeColor.g, beforeColor.b, 0.6f);
            }
            else
            {
                Debug.LogError("renderer is null");
            }
            i++;
        }
    }

    
    //배경 캐릭터 이미지를 초기화
    private void ResetCharactorImage()
    {
        float nowWidthX = 0;
        int i = 0;
        while (nowWidthX < maxWidthX)
        {
            if (i >= backgroundZeps.Length) i = 0;

            int randIndex           = Random.Range(0, backgroundZeps.Length);
            float randHeightY       = Random.Range(minRandHeightY, maxRandHeightY);
            float randWidthX        = Random.Range(minRandWidthX, maxRandWidthX);
            Vector3 tempVector      = new Vector3(nowWidthX, randHeightY, 0f);
            GameObject obj          = Instantiate(backgroundZeps[i], tempVector, Quaternion.identity);
            obj.transform.parent    = this.transform;
            Renderer renderer       = obj.GetComponentInChildren<Renderer>();

            if (renderer != null)
            {
                nowWidthX              += renderer.bounds.size.x + randWidthX;
                Color beforeColor       = renderer.material.color;
                renderer.material.color = new Color(beforeColor.r, beforeColor.g, beforeColor.b, 0.6f);
            }
            else
            {
                Debug.LogError("renderer is null");
            }
            i++;
        }
    }


    //현재 시간에 비례해서 색깔의 목표치를 정하는 메서드
    private void SettingColor()
    {
        if (nowTime <= player.transform.position.x)
        {
            if (nowTime < 299)
            {
                nextColor = nextColor + (minusColor / 4);
            }
            else
            {
                nextColor = nextColor - (minusColor / 0.9f);
            }
            lerpT = 0;
            nowTime += 60f;
        }
    }


    //before컬러를 next컬러로 교체하는 메서드
    private void ChangeColor()
    {
        if (beforeColor != nextColor)
        {
            lerpT += Time.deltaTime * 2;
            if (lerpT >= 1) lerpT = 1;
            beforeColor = Color.Lerp(beforeColor, nextColor, lerpT);
            for (int i = 0; i < backgroundsSpriteRenderer.Length; i++)
            {
                backgroundsSpriteRenderer[i].color = beforeColor;
            }
        }
    }


    //입력된 배열들을 무작위로 섞는 메서드
    private void ShuffleArray<T>(T[] array)
    {
        for (int i = array.Length - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            T temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}
