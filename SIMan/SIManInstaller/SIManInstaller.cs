using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.IO;
using Microsoft.Win32;

namespace SIManInstaller
{
    [RunInstaller(true)]
    public partial class SIManInstaller : Installer
    {
        //CE application manager path in the registry
        public string CEAppManagerPath = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\App Paths\\CEAPPMGR.EXE";
        //ActiveSync Install Folder Path in registry
        public string ActiveSyncDir = "SOFTWARE\\Microsoft\\Windows CE Services";
        //Install Directory
        public string INSTALLED_DIR = "InstalledDir";
        //CE Application Manager File Name
        public string CEAppManagerEXEFileName = "CEAPPMGR.EXE";
        //CE Application Manager .ini file name
        public string CEAppManagerINIFileName = "SIManInstaller.ini";
        //Application's Directory
        public string AppDir = "\\SIManInstaller";
        //System Temporary folder path
        public string TempDir = Environment.SystemDirectory + "\\TEMP\\SIManInstaller";

        public SIManInstaller()
        {
            InitializeComponent();
            this.BeforeInstall += new InstallEventHandler(SIManInstaller_BeforeInstall);
            this.BeforeUninstall += new InstallEventHandler(SIManInstaller_BeforeUninstall);
            this.AfterInstall += new InstallEventHandler(SIManInstaller_AfterInstall);
        }

        private string GetInstallDir()
        {
            RegistryKey ActiveSyncKey = Registry.LocalMachine.OpenSubKey(ActiveSyncDir);
            if (ActiveSyncKey == null)
            {
                throw new Exception("ActiveSync is not installed on this PC!");
            }
            // Create a directory inside ActiveSync folder for the deployment
            string activeSyncPath = (string)ActiveSyncKey.GetValue(INSTALLED_DIR);
            string installPath = activeSyncPath + AppDir;
            ActiveSyncKey.Close();
            return installPath;
        }


        void SIManInstaller_AfterInstall(object sender, InstallEventArgs e)
        {
            // Delete the temp install files after install finished (optional)
            foreach (string tempFile in Directory.GetFiles(TempDir))
            {
                File.Delete(tempFile);
            }
        }



        void SIManInstaller_BeforeUninstall(object sender, InstallEventArgs e)
        {
            // Find where the application is installed
            string installPath = GetInstallDir();
            // Delete the files
            foreach (string appFile in Directory.GetFiles(installPath))
            {
                File.Delete(appFile);
            }
            // Delete the folder
            Directory.Delete(installPath);
        }



        void SIManInstaller_BeforeInstall(object sender, InstallEventArgs e)
        {
            //* Here we get the install dir, create it, copy files to it, then run the
            // CEAppmgr.exe to install the files from there.
            // Find the location where the application will be installed
            string installPath = GetInstallDir();
            // Create the target directory
            Directory.CreateDirectory(installPath);
            // Copy your application files to the directory
            foreach (string installFile in Directory.GetFiles(TempDir))
            {
                File.Copy(installFile, Path.Combine(installPath,
                    Path.GetFileName(installFile)), true);
            }
            // Get the path to ceappmgr.exe
            RegistryKey keyAppMgr = Registry.LocalMachine.OpenSubKey(CEAppManagerPath);
            string appMgrPath = (string)keyAppMgr.GetValue(null);
            keyAppMgr.Close();
            // Run CeAppMgr.exe to install the files to the device
            System.Diagnostics.Process.Start(appMgrPath,
                "\"" + Path.Combine(installPath, CEAppManagerINIFileName) + "\"");
        }
    }
}