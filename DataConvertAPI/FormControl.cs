using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataConvertAPI
{
    public partial class FormControl : Form
    {
        public FormControl()
        {
            InitializeComponent();
        }
        public string Key;
        private void btnTTXX_Click(object sender, EventArgs e)
        {
            if (JsonCV.CheckAPI(Key))
            {
                MessageBox.Show(Key);
            }
            else
            {
                this.Close();
            }
        }
    }
}
