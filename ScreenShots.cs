// Decompiled with JetBrains decompiler
// Type: ScreenShots
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using System;
using System.IO;
using UnityEngine;

public class ScreenShots : MonoBehaviour
{
  private int bigWidth = 90;
  private int bigHeight = 51;
  private int smallWidth = 36;
  private int smallHeight = 20;
  private bool takeShot;
  private string takeShotNOW = string.Empty;
  private Camera camera;
  public static ScreenShots ss;
  public byte[] small;
  public byte[] big;

  public static string ScreenShotName(int width, int height) => Application.persistentDataPath + "/screen.png";

  private void Awake()
  {
    if ((UnityEngine.Object) ScreenShots.ss == (UnityEngine.Object) null)
    {
      UnityEngine.Object.DontDestroyOnLoad((UnityEngine.Object) this.gameObject);
      ScreenShots.ss = this;
    }
    else
    {
      if (!((UnityEngine.Object) ScreenShots.ss != (UnityEngine.Object) this))
        return;
      UnityEngine.Object.Destroy((UnityEngine.Object) this.gameObject);
    }
  }

  public void Start()
  {
  }

  public Sprite getSprite(string name, bool big = false)
  {
    string str = Application.persistentDataPath + "/" + name;
    if ((UnityEngine.Object) this.camera == (UnityEngine.Object) null)
      this.camera = GameObject.Find("Main Camera").GetComponent<Camera>();
    int num1;
    int num2;
    string path;
    if (big)
    {
      num1 = this.bigHeight;
      num2 = this.bigWidth;
      path = str + "_b.png";
    }
    else
    {
      num1 = this.smallHeight;
      num2 = this.smallWidth;
      path = str + "_s.png";
    }
    byte[] data;
    try
    {
      data = File.ReadAllBytes(path);
    }
    catch (Exception ex)
    {
      data = (byte[]) null;
    }
    if (data != null)
    {
      Texture2D texture2D = new Texture2D(73, 73);
      texture2D.LoadImage(data);
      texture2D.filterMode = FilterMode.Point;
      return Sprite.Create(texture2D, new Rect(0.0f, 0.0f, (float) num2, (float) num1), new Vector2(0.0f, 1f), 108f);
    }
    return big ? Resources.Load<Sprite>("Bitmaps/Misc/save_b") : Resources.Load<Sprite>("Bitmaps/Misc/save_s");
  }

  public void shot()
  {
    this.takeShot = true;
    this.takeShotNOW = string.Empty;
  }

  public void shotAndSave(string path)
  {
    this.takeShot = true;
    this.takeShotNOW = path;
  }

  public void saveShots(string name)
  {
    File.WriteAllBytes(Application.persistentDataPath + "/" + name + "_s.png", this.small);
    File.WriteAllBytes(Application.persistentDataPath + "/" + name + "_b.png", this.big);
  }

  private void LateUpdate()
  {
    this.takeShot |= Input.GetKeyDown("k");
    if (!this.takeShot)
      return;
    if ((UnityEngine.Object) this.camera == (UnityEngine.Object) null)
      this.camera = GameObject.Find("Main Camera").GetComponent<Camera>();
    int cullingMask = this.camera.cullingMask;
    CurtainController.cc.gameObject.GetComponent<SpriteRenderer>().enabled = false;
    int height1 = (int) ((double) this.bigHeight * (1.0 / (double) this.camera.rect.height));
    int width1 = (int) ((double) this.bigWidth * (1.0 / (double) this.camera.rect.width));
    RenderTexture renderTexture1 = new RenderTexture(width1, height1, 24);
    this.camera.targetTexture = renderTexture1;
    Texture2D tex1 = new Texture2D(this.bigWidth, this.bigHeight, TextureFormat.RGB24, false);
    this.camera.Render();
    RenderTexture.active = renderTexture1;
    MonoBehaviour.print((object) ("CAMERA RECT" + (object) this.camera.rect));
    float num1 = (float) width1;
    float num2 = (float) height1;
    float f1 = num1 * (this.camera.rect.x * 1f);
    float f2 = num2 * (this.camera.rect.y * 1f);
    float num3 = Mathf.Round(f1);
    float num4 = Mathf.Round(f2);
    MonoBehaviour.print((object) ("xshift " + (object) num3 + " ,  yshift " + (object) num4));
    tex1.ReadPixels(new Rect((float) (int) num3, (float) (int) num4, (float) width1, (float) height1), 0, 0);
    this.camera.targetTexture = (RenderTexture) null;
    RenderTexture.active = (RenderTexture) null;
    UnityEngine.Object.Destroy((UnityEngine.Object) renderTexture1);
    this.big = tex1.EncodeToPNG();
    int height2 = (int) ((double) this.smallHeight * (1.0 / (double) this.camera.rect.height));
    int width2 = (int) ((double) this.smallWidth * (1.0 / (double) this.camera.rect.width));
    float num5 = (float) width2;
    float num6 = (float) height2;
    float f3 = num5 * (this.camera.rect.x * 1f);
    float f4 = num6 * (this.camera.rect.y * 1f);
    float num7 = Mathf.Round(f3);
    float num8 = Mathf.Round(f4);
    RenderTexture renderTexture2 = new RenderTexture(width2, height2, 24);
    this.camera.targetTexture = renderTexture2;
    Texture2D tex2 = new Texture2D(this.smallWidth, this.smallHeight, TextureFormat.RGB24, false);
    this.camera.Render();
    RenderTexture.active = renderTexture2;
    tex2.ReadPixels(new Rect((float) (int) num7, (float) (int) num8, (float) width2, (float) height2), 0, 0);
    this.camera.targetTexture = (RenderTexture) null;
    RenderTexture.active = (RenderTexture) null;
    UnityEngine.Object.Destroy((UnityEngine.Object) renderTexture2);
    this.small = tex2.EncodeToPNG();
    this.camera.cullingMask = cullingMask;
    CurtainController.cc.gameObject.GetComponent<SpriteRenderer>().enabled = true;
    this.takeShot = false;
    if (!(this.takeShotNOW != string.Empty))
      return;
    this.saveShots(this.takeShotNOW);
    this.takeShotNOW = string.Empty;
  }
}
