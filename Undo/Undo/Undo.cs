using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Undo
{
    class Undo
    {
        Button _button;
        Color _brush;

        public Undo(Button button)
        {
            _button = button;
            _brush = ColorTranslator.FromHtml(String.Format("#{0:X2}{1:X2}{2:X2}", 
                                                 button.BackColor.R,
                                                 button.BackColor.G,
                                                 button.BackColor.B));
        }

        public void Execute()
        {
            _button.BackColor = _brush;
        }

        public override string ToString()
        {
            return string.Format("{0}: {1}", _button.Text, _brush.ToString());
        }
    }
}
