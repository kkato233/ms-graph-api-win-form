using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MicrosftGraphApiWinForm
{
    public partial class ServiceExceptionDialog : Form
    {
        public ServiceExceptionDialog()
        {
            InitializeComponent();
        }

        public void SetException(Microsoft.Graph.ServiceException exp)
        {
            this.propertyGrid1.SelectedObject = exp;
            this.textBox1.Text = exp.RawResponseBody;
        }
    }
}
