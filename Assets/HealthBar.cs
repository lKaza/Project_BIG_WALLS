using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image foreground;
    [SerializeField] float updateSpeedSeconds = 0.5f;

    private void Awake() {
        GetComponentInParent<Enemy>().OnHealthPcChanged += HandleHealthChange; 
    }

    private void HandleHealthChange(float pct){
        StartCoroutine(ChangetoPct(pct));
    }

     IEnumerator ChangetoPct(float pct){
         float preChangePct = foreground.fillAmount;
         float elapsed =0f;
         while (elapsed <updateSpeedSeconds){
             elapsed +=Time.deltaTime;
             foreground.fillAmount = Mathf.Lerp(preChangePct,pct,elapsed/updateSpeedSeconds);
            yield return null;
         }
        foreground.fillAmount = pct;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.LookAt(Camera.main.transform);
        transform.Rotate(0,180,0);
    }
}
