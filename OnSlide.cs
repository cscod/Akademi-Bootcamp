using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnSlide : MonoBehaviour
{
    public Image veil;
    public GameObject slider;

    // Start is called before the first frame update
    void Start()
    {
        SliderAnim.SliderMoved += Reveal;
    }

    private void Reveal()
    {
        Destroy(slider);
        veil.CrossFadeAlpha(0, 1, true);
    }
}
