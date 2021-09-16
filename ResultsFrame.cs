// Decompiled with JetBrains decompiler
// Type: ResultsFrame
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using UnityEngine;

public class ResultsFrame : MonoBehaviour
{
  public SpriteRenderer sr;
  public SpriteRenderer frame;
  private float targetAlpha;
  private float alpha;
  private Sprite nextSprite;

  private void Start()
  {
    this.gameObject.transform.position = ScreenControler.roundToNearestFullPixel2(this.gameObject.transform.position);
    this.frame = this.gameObject.GetComponent<SpriteRenderer>();
    this.sr = this.gameObject.transform.Find("inside").GetComponent<SpriteRenderer>();
  }

  public void move(float x, float y)
  {
    this.gameObject.transform.position = new Vector3(x, y, this.gameObject.transform.position.z);
    this.gameObject.transform.position = ScreenControler.roundToNearestFullPixel2(this.gameObject.transform.position);
  }

  private void Update()
  {
    if ((double) this.targetAlpha < (double) this.alpha)
      this.alpha -= 0.1f;
    if ((double) this.alpha < (double) this.targetAlpha)
      this.alpha += 0.1f;
    if ((double) Mathf.Abs(this.targetAlpha - this.alpha) < 0.100000001490116)
      this.alpha = this.targetAlpha;
    if ((double) this.alpha == 0.0 && (Object) this.nextSprite != (Object) null)
    {
      this.sr.sprite = this.nextSprite;
      this.nextSprite = (Sprite) null;
      this.targetAlpha = 1f;
    }
    this.sr.color = new Color(1f, 1f, 1f, this.alpha);
    this.frame.color = new Color(1f, 1f, 1f, this.alpha);
  }

  public void show(Sprite sprite)
  {
    MonoBehaviour.print((object) ("SHOWING: " + (object) sprite));
    this.nextSprite = sprite;
    this.targetAlpha = 0.0f;
  }

  public void hide()
  {
    this.nextSprite = (Sprite) null;
    this.targetAlpha = 0.0f;
  }
}
