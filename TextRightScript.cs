// Decompiled with JetBrains decompiler
// Type: TextRightScript
// Assembly: Assembly-CSharp, Version=9.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0AB8CA89-B4E8-42A6-A741-F039C11ACBC5
// Assembly location: C:\Users\err00\Desktop\ИСХОДНИКИ desc 4\Материалы\Assembly-CSharp\Оригинальный\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class TextRightScript : MonoBehaviour
{
  public TextFieldController tLEFT;
  public TextFieldController tRIGHT;
  private string textToType = GameStrings.getString(GameStrings.journal, "entry_intro");
  private GameObject nextBtn;
  private GameObject prevBtn;
  private int currentPage;
  private bool rewinded;
  private List<string> pages;

  private void Start()
  {
    this.rewinded = false;
    this.textToType = JournalTexts.pickTexts(GameDataController.gd.getCurrentDay(), true);
    this.tLEFT = this.gameObject.GetComponent<TextFieldController>();
    this.tRIGHT = GameObject.Find("TextRight").gameObject.GetComponent<TextFieldController>();
    this.prevBtn = GameObject.Find("InfoPrev");
    this.nextBtn = GameObject.Find("InfoNext");
    this.pages = new List<string>();
    this.pages.Add(string.Empty);
    this.tLEFT.directionY = 1f;
    this.tRIGHT.directionY = 1f;
    this.currentPage = 0;
    this.tLEFT.maxLines = 13;
    this.tRIGHT.maxLines = 13;
    this.viewText(this.tLEFT, this.textToType);
    if (this.tLEFT.remains.Length == 0)
      this.tLEFT.remains = " ";
    GameDataController.gd.setJournalDetail("journal_changed", 0);
  }

  public void gotoNextPage()
  {
    this.currentPage += 2;
    MonoBehaviour.print((object) ("current page: " + (object) this.currentPage));
    if (this.pages.Count <= this.currentPage)
    {
      this.currentPage -= 2;
    }
    else
    {
      if (this.pages.Count > this.currentPage)
        this.viewText(this.tLEFT, this.pages[this.currentPage]);
      if (this.pages.Count > this.currentPage + 1)
        this.viewText(this.tRIGHT, this.pages[this.currentPage + 1]);
      else
        this.viewText(this.tRIGHT, " ");
    }
    GameDataController.gd.setObjectiveDetail("journal_page", this.currentPage);
  }

  public void gotoPrevPage()
  {
    this.currentPage -= 2;
    if (this.currentPage < 0)
    {
      this.currentPage = 0;
    }
    else
    {
      if (this.pages.Count > this.currentPage)
        this.viewText(this.tLEFT, this.pages[this.currentPage]);
      if (this.pages.Count > this.currentPage + 1)
        this.viewText(this.tRIGHT, this.pages[this.currentPage + 1]);
    }
    MonoBehaviour.print((object) ("current page: " + (object) this.currentPage));
    GameDataController.gd.setObjectiveDetail("journal_page", this.currentPage);
  }

  private void Update()
  {
    if (this.tLEFT.remains.Length > 0)
    {
      this.pages[this.pages.Count - 1] = this.tLEFT.TypedText;
      this.pages.Add(this.tLEFT.remains);
      this.viewText(this.tRIGHT, this.tLEFT.remains);
      this.tLEFT.remains = string.Empty;
    }
    else if (this.tRIGHT.remains.Length > 0)
    {
      this.pages[this.pages.Count - 1] = this.tRIGHT.TypedText;
      this.pages.Add(this.tRIGHT.remains);
      this.viewText(this.tLEFT, this.tRIGHT.remains);
      this.tRIGHT.remains = string.Empty;
    }
    else if (!this.rewinded)
    {
      this.rewinded = true;
      this.currentPage = GameDataController.gd.getObjectiveDetail("journal_page");
      while (this.currentPage > this.pages.Count - 1)
        this.currentPage -= 2;
      GameDataController.gd.setObjectiveDetail("journal_page", this.currentPage);
      if (this.currentPage < 0)
        this.currentPage = 0;
      while (this.pages.Count < this.currentPage)
        this.currentPage -= 2;
      if (this.pages.Count > this.currentPage)
        this.viewText(this.tLEFT, this.pages[this.currentPage]);
      if (this.pages.Count > this.currentPage + 1)
        this.viewText(this.tRIGHT, this.pages[this.currentPage + 1]);
      else
        this.viewText(this.tRIGHT, " ");
    }
    if (this.pages.Count <= this.currentPage + 2)
    {
      this.nextBtn.GetComponent<SpriteRenderer>().enabled = false;
      this.nextBtn.GetComponent<PolygonCollider2D>().enabled = false;
    }
    else
    {
      this.nextBtn.GetComponent<SpriteRenderer>().enabled = true;
      this.nextBtn.GetComponent<PolygonCollider2D>().enabled = true;
    }
    if (this.currentPage <= 0)
    {
      this.prevBtn.GetComponent<SpriteRenderer>().enabled = false;
      this.prevBtn.GetComponent<PolygonCollider2D>().enabled = false;
    }
    else
    {
      this.prevBtn.GetComponent<SpriteRenderer>().enabled = true;
      this.prevBtn.GetComponent<PolygonCollider2D>().enabled = true;
    }
  }

  private void viewText(TextFieldController tf, string text)
  {
    MonoBehaviour.print((object) ("No dobra, to ja teraz musze napisac... [" + text + "]"));
    Vector2 screen = ScreenControler.gameToScreen(new Vector2(120f, 65f));
    Vector3 worldPoint = Camera.main.ScreenToWorldPoint(new Vector3(screen.x, screen.y, 0.0f));
    worldPoint.z = -3f;
    tf.transform.position = worldPoint;
    tf.viewText(text, quick: true, instant: true, mwidth: 102, r: 0.34f, g: 0.29f, b: 0.28f, ba: 0.0f);
    tf.black.SetActive(false);
    tf.keepAlive = true;
  }
}
