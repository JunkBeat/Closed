// Decompiled with JetBrains decompiler
// Type: BaseBathroomPlayerMirror
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using UnityEngine;

public class BaseBathroomPlayerMirror : MonoBehaviour
{
  public SpriteRenderer spriteRenderer;
  public SpriteRenderer playerSprite;

  private void Start()
  {
    this.spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
    this.playerSprite = PlayerController.pc.gameObject.GetComponent<SpriteRenderer>();
  }

  private void Update()
  {
    this.spriteRenderer.sprite = this.playerSprite.sprite;
    this.spriteRenderer.flipX = this.playerSprite.flipX;
    this.gameObject.transform.position = new Vector3(PlayerController.pc.gameObject.transform.position.x, PlayerController.pc.gameObject.transform.position.y + 0.075f, this.gameObject.transform.position.z);
    this.gameObject.transform.position = ScreenControler.roundToNearestFullPixel2(this.gameObject.transform.position);
  }
}
