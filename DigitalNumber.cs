// Decompiled with JetBrains decompiler
// Type: DigitalNumber
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5


using UnityEngine;

public class DigitalNumber : MonoBehaviour
{
  public Sprite[] digits;
  public string dataSource;
  public int digit;
  public DigitalNumber next;
  public DigitalNumber prev;
  private SpriteRenderer sr;

  private void Start()
  {
    this.sr = this.GetComponent<SpriteRenderer>();
    this.transform.position = ScreenControler.roundToNearestFullPixel2(this.transform.position);
  }

  private void Update() => this.sr.sprite = this.digits[int.Parse(GameDataController.gd.getObjectiveDetail(this.dataSource).ToString()[this.digit].ToString())];
}
