// Decompiled with JetBrains decompiler
// Type: MoonbaseLightFlicker
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using UnityEngine;

public class MoonbaseLightFlicker : MonoBehaviour
{
  public LocationManager lm;
  public SpriteRenderer lights;
  public SpriteRenderer darkness;
  public SpriteRenderer darkness2;
  public NPCWalkController cody;
  public NPCWalkController barry;
  public NPCWalkController cate;
  public float time1;
  public float time2;
  public SpriteRenderer moreObjects1;
  public SpriteRenderer moreObjects2;
  public SpriteRenderer moreObjects3;
  public SpriteRenderer moreObjects4;
  public SpriteRenderer moreObjects5;
  public bool lightsFailed;

  private void Start()
  {
    this.time1 = Random.Range(1f, 2f);
    this.time2 = Random.Range(1f, 2f);
    this.lightsFailed = GameDataController.gd.getObjective("moon_light_failed") && !GameDataController.gd.getObjective("moon_light_restored");
    if (!GameDataController.gd.getObjective("moon_light_restored") || GameDataController.gd.getObjective("moon_door_closed"))
      return;
    this.time1 = 10f;
    this.time2 = 10f;
    this.lm.needShake = 0.0f;
    this.darkness.enabled = false;
  }

  private void Update()
  {
    if (this.lightsFailed)
    {
      this.darkness.enabled = true;
      if ((Object) this.darkness2 != (Object) null)
        this.darkness2.enabled = true;
    }
    else if ((double) this.lm.needShake > 0.0)
    {
      if ((double) this.time1 <= 0.0)
      {
        this.lights.enabled = !this.lights.enabled;
        this.time1 = Random.Range(0.0f, 0.5f);
      }
      else
        this.time1 -= Time.deltaTime;
      if ((double) this.time2 <= 0.0)
      {
        this.darkness.enabled = !this.darkness.enabled;
        if ((Object) this.darkness2 != (Object) null)
          this.darkness2.enabled = !this.darkness2.enabled;
        this.time2 = Random.Range(0.0f, 0.5f);
      }
      else
        this.time2 -= Time.deltaTime;
    }
    else
    {
      this.darkness.enabled = false;
      if ((Object) this.darkness2 != (Object) null)
        this.darkness2.enabled = false;
      this.lights.enabled = true;
      this.time1 = Random.Range(0.0f, 1f);
      this.time2 = Random.Range(0.0f, 1f);
    }
    this.charLights();
  }

  public void charLights()
  {
    float num = 1f;
    if (this.darkness.enabled)
      num = 0.5f;
    PlayerController.wc.gameObject.GetComponent<SpriteRenderer>().color = new Color(num, num, num);
    this.cody.colorBlue = num;
    this.cody.colorRed = num;
    this.cody.colorGreen = num;
    this.cody.gameObject.GetComponent<SpriteRenderer>().color = new Color(this.cody.colorRed, this.cody.colorGreen, this.cody.colorBlue, this.cody.colorAlpha);
    this.cate.colorBlue = num;
    this.cate.colorRed = num;
    this.cate.colorGreen = num;
    this.cate.gameObject.GetComponent<SpriteRenderer>().color = new Color(this.cate.colorRed, this.cate.colorGreen, this.cate.colorBlue, this.cate.colorAlpha);
    this.barry.colorBlue = num;
    this.barry.colorRed = num;
    this.barry.colorGreen = num;
    this.barry.gameObject.GetComponent<SpriteRenderer>().color = new Color(this.barry.colorRed, this.barry.colorGreen, this.barry.colorBlue, this.barry.colorAlpha);
    if ((bool) (Object) this.moreObjects1)
      this.moreObjects1.color = new Color(num, num, num, 1f);
    if ((bool) (Object) this.moreObjects2)
      this.moreObjects2.color = new Color(num, num, num, 1f);
    if ((bool) (Object) this.moreObjects3)
      this.moreObjects3.color = new Color(num, num, num, 1f);
    if ((bool) (Object) this.moreObjects4)
      this.moreObjects4.color = new Color(num, num, num, 1f);
    if (!(bool) (Object) this.moreObjects5)
      return;
    this.moreObjects5.color = new Color(num, num, num, 1f);
  }
}
