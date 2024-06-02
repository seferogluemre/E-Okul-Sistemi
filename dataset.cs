using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Okul_Sistemi
{
    public partial class dataset : Component
    {
        public dataset()
        {
            InitializeComponent();
        }

        public dataset(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
