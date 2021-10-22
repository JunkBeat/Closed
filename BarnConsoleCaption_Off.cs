// Decompiled with JetBrains decompiler
// Type: BarnConsoleCaption_Off
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using UnityEngine;

public class BarnConsoleCaption_Off : MonoBehaviour
{
  public string nameToDisplay;
  public float colormod = 1f;
  private TextFieldController t;

  private void Start()
  {
    Vector2 screen = ScreenControler.gameToScreen(new Vector2(120f, 67f));
    Vector3 worldPoint = Camera.main.ScreenToWorldPoint(new Vector3(screen.x, screen.y, 0.0f));
    worldPoint.z = -0.9f;
    this.gameObject.transform.position = worldPoint;
    this.t = this.GetComponent<TextFieldController>();
    this.t.useSeparateCamera = false;
    this.t.viewText(GameStrings.getString(GameStrings.world_labels, this.nameToDisplay), quick: true, instant: true, mwidth: 200, r: ((float) ((double) this.colormod * 48.0 / (double) byte.MaxValue)), g: ((float) ((double) this.colormod * 82.0 / (double) byte.MaxValue)), b: ((float) ((double) this.colormod * 33.0 / (double) byte.MaxValue)), ba: 0.0f);
    this.t.keepAlive = true;
  }

  private void Update()
  {
  }
}
