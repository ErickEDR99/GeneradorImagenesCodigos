using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.Threading.Tasks;

namespace GeneracionImagenesService
{
    [RunInstaller(true)]
    public partial class GeneracionImagenesInstaller : System.Configuration.Install.Installer
    {
        public GeneracionImagenesInstaller()
        {
            InitializeComponent();
        }

        private void serviceInstaller1_AfterInstall(object sender, InstallEventArgs e)
        {

        }

        private void GeneracionImagenesServiceInstaller_AfterInstall(object sender, InstallEventArgs e)
        {

        }
    }
}
