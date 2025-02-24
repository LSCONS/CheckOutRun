using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static TimeManager Instance { get; private set; }
    //1�ð��� 20�ʰ� �帣����
    public float gameTime { get; private set; } = 9f * 60f;
    public float gameSpeed = 3f; //1�ʴ� 3���� �귯�� ��(60�� = 20��)
    private float speedMultiplier = 1f; //�ӵ������� ���� ����

    private float startHour = 9f * 60f; //�⼮ �ð�
    private float endHour = 21f * 60f; //��� �ð�

    //private bool isBoss = false; //21�� ����, ����������� �����ߴ���
    [SerializeField] private Player player;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (player == null) return;
        //if (player.isDead) return;
        
        
        //�ӵ� ���� �������� �Ծ��ٸ� gameTime�� speedMultipler�� ���ؾ� ��
        //24�ð� �������� �ð� ����
        if(gameTime >= endHour)
        {
            //�ٷ� ������ 9�÷� �Ѿ�°� �ƴ϶�, ���������� ��� ����ϴ� ���ǹ� �ʿ�
            //if(isBoss == true)
            //{

            //}
            //else
            gameTime = startHour;
        }
        gameTime += Time.deltaTime * gameSpeed;
    }

}
