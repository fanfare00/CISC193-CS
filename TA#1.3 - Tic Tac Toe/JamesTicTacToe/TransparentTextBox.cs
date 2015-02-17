using System;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;


namespace JamesTicTacToe
{
    public class TransparentTextBox : RichTextBox
    {
        [
        Description("Secures the data from viewing or copying if set to true."),
        Category("Appearance"),
        Browsable(true),
        EditorBrowsable(EditorBrowsableState.Always)
        ]        
        
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;

                cp.ExStyle |= 0x00000020; // WS_EX_TRANSPARENT

                return cp;
            }
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            //do not allow the background to be painted 
        }

        protected void InvalidateEx()
        {
            if (Parent == null)
                return;

            Rectangle rc = new Rectangle(this.Location, this.Size);
            Parent.Invalidate(rc, true);
        }
    }
}
