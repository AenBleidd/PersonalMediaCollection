using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PersonalMediaCollection
{
  public partial class frmMassAdd : Form
  {
    string coverPath = "";
    int Type;
    public frmMassAdd(int _Type)
    {
      InitializeComponent();
      Type = _Type;
    }

    private void cbParentCover_CheckedChanged(object sender, EventArgs e)
    {
      if (cbParentCover.Checked == true)
      {
        coverPath = "";
        cbDefaultCover.Checked = false;
        btnDeleteCover.Enabled = false;
        frmMain main = this.Owner as frmMain;
        if (main != null)
        {
          pbCover.Image = main.getCover(false);
        }
      }
      else if (cbParentCover.Checked == false && coverPath.Length == 0)
      {
        cbDefaultCover.Checked = true;
      }
    }

    private void cbDefaultCover_CheckedChanged(object sender, EventArgs e)
    {
      if (cbDefaultCover.Checked == true)
      {
        coverPath = "";
        cbParentCover.Checked = false;
        btnDeleteCover.Enabled = false;
        frmMain main = this.Owner as frmMain;
        if (main != null)
        {
          pbCover.Image = main.getCover(true);
        }
      }
      else if (cbDefaultCover.Checked == false && coverPath.Length == 0)
      {
        cbParentCover.Checked = true;
      }
    }

    private void cbAutoNum_CheckedChanged(object sender, EventArgs e)
    {
      if (cbAutoNum.Checked == false)
      {
        udNumCount.Enabled = false;
        udFirstNum.Enabled = false;
      }
      else
      {
        udNumCount.Enabled = true;
        udFirstNum.Enabled = true;
      }
    }

    private void btnSetCover_Click(object sender, EventArgs e)
    {
      if (dlgImage.ShowDialog() == DialogResult.OK)
      {
        FileStream file = new FileStream(dlgImage.FileName, FileMode.Open, FileAccess.Read);
        coverPath = dlgImage.FileName;
        BinaryReader reader = new BinaryReader(file);
        byte[] imageBytes = reader.ReadBytes((int)file.Length);
        MemoryStream ms = new MemoryStream(imageBytes);
        Image image = Image.FromStream(ms);
        pbCover.Image = image;
        btnDeleteCover.Enabled = true;
        cbParentCover.Checked = false;
        cbDefaultCover.Checked = false;
      }
    }

    private void btnDeleteCover_Click(object sender, EventArgs e)
    {
      coverPath = "";
      cbParentCover.Checked = true;
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
      frmMain main = this.Owner as frmMain;
      if (main != null)
      {
        Cursor = Cursors.WaitCursor;
        main.AddMassGroupOrElement(Type, Convert.ToInt32(udCount.Value), cbAutoNum.Checked, Convert.ToInt32(udNumCount.Value), 
          Convert.ToInt32(udFirstNum.Value), edtPrefix.Text, cbParentCover.Checked, cbDefaultCover.Checked, coverPath);
        Cursor = Cursors.Default;
      }
    }

    private void frmMassAdd_Shown(object sender, EventArgs e)
    {
      frmMain main = this.Owner as frmMain;
      if (main != null)
      {
        if (cbDefaultCover.Checked == true)
        {
          pbCover.Image = main.getCover(true);
        }
        else if (cbParentCover.Checked == true)
        {
          pbCover.Image = main.getCover(false);
        }
      }
    }
  }
}
