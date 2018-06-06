using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace TabControlWithCloseButton
{
    public partial class TabControlWithCloseButton : TabControl
    {
        public TabControlWithCloseButton(): base()
        {
            InitializeComponent();

            this.Padding = new Point(12, 4);
            this.DrawMode = TabDrawMode.OwnerDrawFixed;

            this.DrawItem += TabControlWithCloseButton_DrawItem;
            this.MouseDown += TabControlWithCloseButton_MouseDown;
            this.Selecting += TabControlWithCloseButton_Selecting;
            this.HandleCreated += TabControlWithCloseButton_HandleCreated;
        }

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);
        private const int TCM_SETMINTABWIDTH = 0x1300 + 49;
        private void TabControlWithCloseButton_HandleCreated(object sender, EventArgs e)
        {
            SendMessage(this.Handle, TCM_SETMINTABWIDTH, IntPtr.Zero, (IntPtr)16);
        }
        private void TabControlWithCloseButton_Selecting(object sender, TabControlCancelEventArgs e)
        {
           
        }
        private void TabControlWithCloseButton_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.TabPages.Count > 1)
            {
                for (var i = 0; i < this.TabPages.Count; i++)
                {
                    var tabRect = this.GetTabRect(i);
                    tabRect.Inflate(-2, -2);
                    var closeImage = Properties.Resources.Close;
                    var imageRect = new Rectangle(
                        (tabRect.Right - closeImage.Width + 10),
                        tabRect.Top + (tabRect.Height - closeImage.Height) / 2,
                        closeImage.Width,
                        closeImage.Height);
                    if (imageRect.Contains(e.Location))
                    {
                        this.TabPages.RemoveAt(i);
                        break;
                    }
                }
            }
        }
        private void TabControlWithCloseButton_DrawItem(object sender, DrawItemEventArgs e)
        {
            var tabPage = this.TabPages[e.Index];
            var tabRect = this.GetTabRect(e.Index);
            tabRect.Inflate(-2, -2);
            {
                var closeImage = Properties.Resources.Close;
                e.Graphics.DrawImage(closeImage,
                    (tabRect.Right - closeImage.Width + 10),
                    tabRect.Top + (tabRect.Height - closeImage.Height) / 2);
                TextRenderer.DrawText(e.Graphics, tabPage.Text, tabPage.Font,
                    tabRect, tabPage.ForeColor, TextFormatFlags.Left);
            }
        }
    }
}
