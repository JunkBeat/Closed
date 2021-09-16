// Decompiled with JetBrains decompiler
// Type: WorldCaption
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using UnityEngine;

public class WorldCaption : MonoBehaviour
{
  public string nameToDisplay;
  public string overrideString = string.Empty;
  public float r;
  public float g;
  public float b;
  public int width;
  private TextFieldController t;

  private void Start()
  {
    Vector2 screen = ScreenControler.gameToScreen(new Vector2(120f, 67f));
    Vector3 worldPoint = Camera.main.ScreenToWorldPoint(new Vector3(screen.x, screen.y, 0.0f));
    worldPoint.z = -3f;
    this.gameObject.transform.position = worldPoint;
    this.t = this.GetComponent<TextFieldController>();
    if (this.overrideString != string.Empty)
      this.t.viewText(this.overrideString, quick: true, instant: true, mwidth: this.width, r: (this.r / (float) byte.MaxValue), g: (this.g / (float) byte.MaxValue), b: (this.b / (float) byte.MaxValue), ba: 0.0f);
    else
      this.t.viewText(GameStrings.getString(GameStrings.world_labels, this.nameToDisplay), quick: true, instant: true, mwidth: this.width, r: (this.r / (float) byte.MaxValue), g: (this.g / (float) byte.MaxValue), b: (this.b / (float) byte.MaxValue), ba: 0.0f);
    this.t.keepAlive = true;
  }

  private void Update()
  {
  }

  public void manualUpdate() => this.Start();

  public void hide()
  {
    this.t = this.GetComponent<TextFieldController>();
    this.t.viewText(" ", quick: true, instant: true, mwidth: this.width, r: (this.r / (float) byte.MaxValue), g: (this.g / (float) byte.MaxValue), b: (this.b / (float) byte.MaxValue), ba: 0.0f);
  }
}
