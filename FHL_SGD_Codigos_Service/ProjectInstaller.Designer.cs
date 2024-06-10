namespace GeneracionImagenesService
{
    partial class GeneracionImagenesInstaller
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.GeneracionImagenesServiceInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            this.ServiceInstaller1 = new System.ServiceProcess.ServiceInstaller();
            // 
            // GeneracionImagenesServiceInstaller
            // 
            this.GeneracionImagenesServiceInstaller.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.GeneracionImagenesServiceInstaller.Password = null;
            this.GeneracionImagenesServiceInstaller.Username = null;
            this.GeneracionImagenesServiceInstaller.AfterInstall += new System.Configuration.Install.InstallEventHandler(this.GeneracionImagenesServiceInstaller_AfterInstall);
            // 
            // ServiceInstaller1
            // 
            this.ServiceInstaller1.Description = "Servicio de generación de imagenes para SGD";
            this.ServiceInstaller1.DisplayName = "Servicio de generación de imagenes SGD";
            this.ServiceInstaller1.ServiceName = "GeneracionImagenService";
            this.ServiceInstaller1.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            this.ServiceInstaller1.AfterInstall += new System.Configuration.Install.InstallEventHandler(this.serviceInstaller1_AfterInstall);
            // 
            // GeneracionImagenesServiceInstaller1
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.GeneracionImagenesServiceInstaller,
            this.ServiceInstaller1});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller GeneracionImagenesServiceInstaller;
        private System.ServiceProcess.ServiceInstaller ServiceInstaller1;
    }
}