// Decompiled with JetBrains decompiler
// Type: FireplaceLight
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using UnityEngine;

public class FireplaceLight : MonoBehaviour
{
  public SpriteRenderer fireLight;

  private void Start()
  {
  }

  private void Update()
  {
  }

  public void newShadow() => this.fireLight.color = new Color(1f, 1f, 1f, Random.Range(0.85f, 1f));
}
