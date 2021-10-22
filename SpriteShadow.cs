// Decompiled with JetBrains decompiler
// Type: SpriteShadow
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using System;
using UnityEngine;
using UnityEngine.Rendering;

[Serializable]
public class SpriteShadow
{
  private SpriteShadowSlice[] shadows;
  private GameObject gameObject;
  private Sprite shadow_mask;
  public int offsetY;
  [SerializeField]
  public int offsetY2;
  public float startAlpha = 1f;
  public float alphaMod = 1f;
  public float fadeRateH = 0.025f;
  public float fadeRateV = 0.025f;
  public float source = 160f;
  public float scaleFactor = 0.75f;
  public float skewFactor = 40f;
  public float skewFactor2;
  public bool downwards = true;
  public string lastFrame;
  public string lastScene;
  private int shadowOffsetY;

  public SpriteShadow(GameObject t)
  {
    this.gameObject = t;
    this.shadow_mask = Resources.Load<Sprite>("Bitmaps/misc/shadow_mask");
    this.shadows = new SpriteShadowSlice[(int) this.gameObject.GetComponent<SpriteRenderer>().sprite.rect.height];
    for (int i = 0; i < this.shadows.Length; ++i)
      this.newShadowPiece(i);
    this.offsetY = !((UnityEngine.Object) this.gameObject.GetComponent<WalkController>() != (UnityEngine.Object) null) ? (!((UnityEngine.Object) this.gameObject.GetComponent<NPCWalkController>() != (UnityEngine.Object) null) ? 0 : this.gameObject.GetComponent<NPCWalkController>().offsetY) : this.gameObject.GetComponent<WalkController>().offsetY;
    this.offsetY2 = 2;
    this.lastFrame = string.Empty;
  }

  public void clearLastFrame() => this.lastFrame = string.Empty;

  private void newShadowPiece(int i)
  {
    this.shadows[i] = new SpriteShadowSlice();
    this.shadows[i].shadowHolder = new GameObject();
    this.shadows[i].shadowHolder.transform.parent = this.gameObject.transform;
    this.shadows[i].shadowHolder.name = this.gameObject.name + "_shadowHolder_" + (object) i;
    this.shadows[i].shadowHolder.AddComponent<SortingGroup>();
    this.shadows[i].shadow = new GameObject()
    {
      transform = {
        parent = this.shadows[i].shadowHolder.transform
      }
    }.AddComponent<SpriteRenderer>();
    this.shadows[i].shadow.name = "shadow_sprite_" + (object) i;
    this.shadows[i].shadow.maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
    this.shadows[i].mask = new GameObject()
    {
      transform = {
        parent = this.shadows[i].shadowHolder.transform
      }
    }.AddComponent<SpriteMask>();
    this.shadows[i].mask.name = "shadow_mask_" + (object) i;
    this.shadows[i].mask.sprite = this.shadow_mask;
  }

  public void update(Vector3 postion, Vector2 currentXY, int offset)
  {
    this.shadowOffsetY = offset;
    if (this.shadowOffsetY <= -7)
      this.shadowOffsetY -= 3;
    else
      this.shadowOffsetY = this.shadowOffsetY != -6 ? (this.shadowOffsetY != -5 ? (this.shadowOffsetY != -4 ? (this.shadowOffsetY != -3 ? (this.shadowOffsetY != -2 ? (this.shadowOffsetY != -1 ? 0 : 0) : 0) : 0) : -1) : -2) : -3;
    if (this.gameObject.GetComponent<SpriteRenderer>().sprite.name != this.lastFrame || (double) this.alphaMod != 1.0)
    {
      for (int index = 0; index < this.shadows.Length; ++index)
      {
        if ((double) index >= (double) this.shadows.Length * (double) this.scaleFactor)
        {
          this.shadows[index].shadow.enabled = false;
          this.shadows[index].mask.enabled = false;
        }
        else
        {
          this.shadows[index].shadow.enabled = true;
          this.shadows[index].mask.enabled = true;
        }
        int num1 = (int) ((double) index * (1.0 / (double) this.scaleFactor - 1.0));
        if (num1 > this.shadows.Length - 1)
          num1 = this.shadows.Length - 1;
        this.shadows[index].shadow.sprite = this.gameObject.GetComponent<SpriteRenderer>().sprite;
        this.shadows[index].shadow.flipY = this.downwards;
        this.shadows[index].shadow.flipX = this.gameObject.GetComponent<SpriteRenderer>().flipX;
        float num2 = this.startAlpha - this.fadeRateV * (float) index - this.fadeRateH * Mathf.Abs(currentXY.x - this.source);
        if ((double) num2 < 0.0)
          num2 = 0.0f;
        this.shadows[index].shadow.color = new Color(0.0f, 0.0f, 0.0f, num2 * this.alphaMod);
        float num3 = (-this.source + currentXY.x) * (this.skewFactor / 1000f) - this.skewFactor2 / 10f;
        float num4 = !this.downwards ? -1f : 1f;
        Vector3 position1 = new Vector3(0.0f, 0.0f, -0.055f);
        position1 = Camera.main.WorldToScreenPoint(position1);
        Vector2 vectorToChange1 = new Vector2();
        vectorToChange1.x = currentXY.x + num3 * (float) index;
        vectorToChange1.y = currentXY.y;
        vectorToChange1 = ScreenControler.gameToScreen(vectorToChange1);
        Vector3 position2 = new Vector3(vectorToChange1.x, vectorToChange1.y, position1.z);
        this.shadows[index].shadowHolder.transform.position = Camera.main.ScreenToWorldPoint(position2);
        Vector2 vectorToChange2 = new Vector2();
        vectorToChange2.x = currentXY.x + num3 * (float) index;
        vectorToChange2.y = currentXY.y - (float) (this.offsetY + this.offsetY2 - num1 - this.shadowOffsetY) * num4;
        vectorToChange2 = ScreenControler.gameToScreen(vectorToChange2);
        Vector3 position3 = new Vector3(vectorToChange2.x, vectorToChange2.y, position1.z);
        this.shadows[index].shadow.transform.position = Camera.main.ScreenToWorldPoint(position3);
        Vector2 vectorToChange3 = (Vector2) new Vector3();
        vectorToChange3.x = currentXY.x + num3 * (float) index;
        vectorToChange3.y = currentXY.y - (float) index * num4;
        Vector2 screen = ScreenControler.gameToScreen(vectorToChange3);
        Vector3 position4 = new Vector3(screen.x, screen.y, position1.z);
        this.shadows[index].mask.transform.position = Camera.main.ScreenToWorldPoint(position4);
      }
    }
    this.lastFrame = this.gameObject.GetComponent<SpriteRenderer>().sprite.name;
  }
}
