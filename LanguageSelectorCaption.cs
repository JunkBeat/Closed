// Decompiled with JetBrains decompiler
// Type: LanguageSelectorCaption
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using UnityEngine;

public class LanguageSelectorCaption : MonoBehaviour
{
  private TextFieldController t;

  private void Start()
  {
    Vector2 screen = ScreenControler.gameToScreen(new Vector2(15f, 15f));
    Vector3 worldPoint = Camera.main.ScreenToWorldPoint(new Vector3(screen.x, screen.y, 0.0f));
    worldPoint.z = -3f;
    this.gameObject.transform.position = worldPoint;
    this.t = this.GetComponent<TextFieldController>();
    this.updateText();
  }

  public void updateText()
  {
    this.t.viewText(GameStrings.getString(GameStrings.languages, PlayerPrefs.GetString("lang", GameStrings.Language.EN.ToString())), quick: true, instant: true, mwidth: 200, r: 0.5f, g: 0.5f, b: 0.5f, ba: 0.0f);
    this.t.keepAlive = true;
  }

  public void hideText()
  {
    this.t.dissmiss(true);
    this.t.keepAlive = false;
  }

  private void Update()
  {
  }
}
