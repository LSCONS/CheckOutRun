using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Card : MonoBehaviour
{
    public int index;
    public SpriteRenderer frontimage;
    public SpriteRenderer backImage;
    public GameObject front;
    public GameObject back;

    public GameObject backBtn;

    private AudioSource flipSound;

    public Animator anim;
    public int colorTypeCard = 1;

    private void Start()
    {
        colorTypeCard = ColorManager.instance.colorType;

        switch (colorTypeCard)
        {
            case 1:
                backImage.sprite = Resources.Load<Sprite>($"Back{colorTypeCard}");
            break;

            case 2:
                backImage.sprite = Resources.Load<Sprite>($"Back{colorTypeCard}");
            break;

            case 3:
                backImage.sprite = Resources.Load<Sprite>($"Back{colorTypeCard}");
            break;

            case 4:
                backImage.sprite = Resources.Load<Sprite>($"Back{colorTypeCard}");
            break;

            case 5:
                backImage.sprite = Resources.Load<Sprite>($"Back{colorTypeCard}");
            break;
            
        }



        flipSound = GetComponent<AudioSource>();
        flipSound.clip = AudioManager.instance.cardFlipClip;
    }

    void Update()
    {
        if(transform.eulerAngles.y >= -90f && transform.eulerAngles.y <= 90f)   //카드가 뒷면
        {
            front.SetActive(false);
            back.SetActive(true);
        }
        else
        {
            front.SetActive(true);
            back.SetActive(false);
        }
    }
    public void DestroyCard()
    {
        Invoke("DestroyCardInvoke", GameManager2.Instance.cardCloseDelayTime);
    }
    void DestroyCardInvoke()
    {
        Destroy(gameObject);
    }
    public void OpenCard()
    {
        anim.SetBool("isOpen", true);
        backBtn.SetActive(false);
        flipSound.Play();
        GameManager2.Instance.selectCount++;

        if (GameManager2.Instance.firstCard == null)
        {
            GameManager2.Instance.firstCard = this;
        }
        else 
        { 
            GameManager2.Instance.secondCard = this;
            GameManager2.Instance.isMatched();
        }
    }

    public void CloseCard()
    {
        Invoke("CloseCardInvoke", GameManager2.Instance.cardCloseDelayTime);
    }
    void CloseCardInvoke()
    {
        anim.SetBool("isOpen", false);
        backBtn.SetActive(true);
    }

    public void Setting(int number)
    {
        index = number;
        frontimage.sprite = Resources.Load<Sprite>($"card{index}");

    }

   

}
