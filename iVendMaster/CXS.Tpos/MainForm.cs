using System.Windows.Forms;
using CXS.Core.Common.Interfaces;

namespace CXS.Tpos
{
    public partial class MainForm : Form
    {
        private readonly IIvendContext _ivendContext;

        public MainForm(IIvendContext ivendContext)
        {
            _ivendContext = ivendContext;
            InitializeComponent();
        }
    }
}
