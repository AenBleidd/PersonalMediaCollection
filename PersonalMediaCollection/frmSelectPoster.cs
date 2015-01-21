using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonalMediaCollection
{
    public partial class frmSelectPoster : Form
    {
        public frmSelectPoster()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (listPosters.SelectedItems.Count > 0)
            {
                frmMain main = this.Owner as frmMain;
                if (main != null)
                {
                    main.setSelectedImage(listPosters.FocusedItem.Name);
                }
            }
        }

        private void listPosters_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btnOK_Click(sender, e);
            Close();
        }
    }
}
