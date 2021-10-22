// Decompiled with JetBrains decompiler
// Type: CS3ThugSprite
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using UnityEngine;

public class CS3ThugSprite : MonoBehaviour
{
  public SpriteShadow shadow;
  public int shadowOffsetY;
  public bool thisOneCanBeShot;

  private void Start()
  {
    this.gameObject.transform.position = ScreenControler.roundToNearestFullPixel2(this.gameObject.transform.position);
    this.shadow = new SpriteShadow(this.gameObject);
    this.shadow.startAlpha = 0.5f;
    this.shadow.fadeRateV = 0.009f;
    this.shadow.fadeRateH = 0.004f;
    this.shadowOffsetY = 0;
    this.shadow.update(new Vector3(10f, 10f, 0.0f), new Vector2(10f, 10f), 0);
    this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
    if (this.thisOneCanBeShot && GameDataController.gd.getObjective("cs_thug_shot"))
      this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
    if (!GameDataController.gd.getObjective("cs_safe"))
      return;
    this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
  }

  private void Update()
  {
  }
}
