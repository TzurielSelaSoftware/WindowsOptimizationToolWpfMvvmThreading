using System;
using System.Collections.ObjectModel;
using System.IO;
using PowerShell;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WindowsOptimizationTool.Commands;
namespace WindowsOptimizationTool.ViewModels
{
    class MainViewModel : BaseViewModel
    {
        #region POWERSHELL
        private RunPowerShell run;
        #endregion

        #region BUTTON STATUS
        private bool isEnabled;
        public bool IsEnabled
        {
            get { return isEnabled; }
            set { isEnabled = value;
                OnPropertyChanged(nameof(IsEnabled));
            }
        }
        #endregion

        #region PROGRESS BAR PROPERTIES
        private int progBarLength;
        public int ProgBarLength
        {
            get { return progBarLength; }
            set { progBarLength = value;
                OnPropertyChanged(nameof(ProgBarLength));
            }
        }
        private int progBarValue;
        public int ProgBarValue
        {
            get { return progBarValue; }
            set { progBarValue = value;
                OnPropertyChanged(nameof(ProgBarValue));
            }
        }
        #endregion

        #region CONSOLE VIEW PROPERTIES
        private ObservableCollection<string> consoleData;
        public ObservableCollection<string> ConsoleData
        {
            get { return consoleData; }
            set
            {
                consoleData = value;
                OnPropertyChanged(nameof(ConsoleData));
            }
        }
        #endregion

        #region C: DRIVE INFO PROPERTIES
        private DriveInfo DI = new DriveInfo("c");
        private string spaceInfo;
        public string SpaceInfo
        {
            get { return spaceInfo; }
            set
            {
                spaceInfo = value;
                OnPropertyChanged(nameof(SpaceInfo));
            }
        }
        #endregion

        #region COMBOBOX PROPERTIES
        private int selectedValue = -1;
        public int SelectedValue
        {
            get { return selectedValue; }
            set
            {
                selectedValue = value;
                OnPropertyChanged(nameof(SelectedValue));
                SelectedItem();
            }
        }
        private void SelectedItem()
        {
            if (SelectedValue == 0)
            {
                Environment.Exit(1);
            }
            else
            {
                MessageBox.Show("Created by Tzuriel Sela - Software Engineer\nPhone: 0546758780\nEmail: tzurielselasoftware@gmail.com", "About", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }
        }
        #endregion 

        #region Constructor 
        public MainViewModel()
        {
            SpaceInfo = @"Drive C:\" + "\nTotal size - " + DI.TotalSize + " Bytes , Free space - " + DI.AvailableFreeSpace + " Bytes";
            progBarLength = 100;
            progBarValue = 0;
            IsEnabled = true;
        }
        #endregion

        #region REMOVE TRASH METHODES 
        public ICommand CleanUp => new DelegateCommand(RunDiskCleanUP);
        public ICommand EmptyTempFolder => new DelegateCommand(ClearTemp);
        public ICommand RemoveEmptyFolders => new DelegateCommand(ClearEmptyFolders);
        private async void ClearTemp()
        {
            try
            {
                IsEnabled = false;
                ProgBarValue = 0;
                ConsoleData = new ObservableCollection<string>();
                var tmpPath = Path.GetTempPath();
                var files = Directory.GetFiles(tmpPath);
                string[] subDir = Directory.GetDirectories(tmpPath);
                ProgBarLength = files.Length + subDir.Length;
                var progress = new Progress<int>(value => ProgBarValue = value);
                int y = 0;
                int countFiles = 0;
                int countDirectories = 0;
                ConsoleData.Add("Searching...");
                await Task.Run(() =>
                {
                    foreach (var file in files)
                    {
                        y++;
                        if (file != @"C:\Users\Tzuriel\AppData\Local\Temp\.NETFramework,Version=v4.7.2.AssemblyAttributes.cs")
                        {
                            try
                            {
                                ((IProgress<int>)progress).Report(y);
                                Thread.Sleep(100);
                                File.Delete(file);
                                if (!File.Exists(file))
                                {
                                    App.Current.Dispatcher.Invoke((Action)delegate
                                    {
                                        ConsoleData.Add(file + "    File successfully deleted");
                                    });
                                    countFiles++;
                                }
                            }
                            catch
                            {
                                continue;
                            }
                        }
                    }
                    SpaceInfo = @"Drive C:\" + "\nTotal size - " + DI.TotalSize + " Bytes , Free space - " + DI.AvailableFreeSpace + " Bytes";
                    for (int i = 0; i < subDir.Length; i++)
                    {
                        y++;
                        try
                        {
                            ((IProgress<int>)progress).Report(y);
                            Thread.Sleep(100);
                            Directory.Delete(subDir[i], true);
                            if (!Directory.Exists(subDir[i]))
                            {
                                App.Current.Dispatcher.Invoke((Action)delegate
                                {
                                    ConsoleData.Add(subDir[i] + "   Directory successfully deleted");
                                });
                                countDirectories++;
                            }
                        }
                        catch
                        {
                            continue;
                        }
                    }
                });
                SpaceInfo = @"Drive C:\" + "\nTotal size - " + DI.TotalSize + " Bytes , Free space - " + DI.AvailableFreeSpace + " Bytes";
                ConsoleData.Add($"\nTotal {countFiles} files and {countDirectories} directory deleted.");
                IsEnabled = true;
            }
            catch (Exception)
            {
                ConsoleData.Add("\nClear Temp folder Error!\nOperation failed.");
            }
        }
        private async void ClearEmptyFolders()
        {
            try
            {
                IsEnabled = false;
                ProgBarValue = 0;
                var count = 0;
                ConsoleData = new ObservableCollection<string>();
                ConsoleData.Add("Searching...");
                string path = @"c:\";
                string[] directories = Directory.GetDirectories(path);
                ProgBarLength = directories.Length;
                var progress = new Progress<int>(value => ProgBarValue = value);
                await Task.Run(() =>
                {
                    for (int i = 0; i < directories.Length; i++)
                    {
                        try
                        {
                            ((IProgress<int>)progress).Report(i);
                            Thread.Sleep(100);
                            if (Directory.GetFiles(directories[i], "*", SearchOption.AllDirectories).Length == 0)
                            {
                                try
                                {
                                    App.Current.Dispatcher.Invoke((Action)delegate
                                    {
                                        ConsoleData.Add(directories[i] + "  Directory successfully deleted");
                                    });
                                    count++;
                                    Directory.Delete(directories[i], true);
                                }
                                catch
                                {
                                    continue;
                                }
                            }
                        }
                        catch
                        {
                            continue;
                        }
                    }
                });
                ProgBarValue = ProgBarLength;
                SpaceInfo = @"Drive C:\" + "\nTotal size - " + DI.TotalSize + " Bytes , Free space - " + DI.AvailableFreeSpace + " Bytes";
                ConsoleData.Add($"\nTotal {count} directory deleted.");
                IsEnabled = true;
            }
            catch (Exception)
            {
                ConsoleData.Add("\nClear Empty Folders Error!\nOperation failed.");
            }
        }
        private async void RunDiskCleanUP()
        {
            try
            {
                IsEnabled = false;
                System.Diagnostics.Process.Start(@"c:\windows\SYSTEM32\cleanmgr.exe");
                IsEnabled = true;
                await Task.Run(() =>
                {
                    Thread.Sleep(90000);
                    SpaceInfo = @"Drive C:\" + "\nTotal size - " + DI.TotalSize + " Bytes , Free space - " + DI.AvailableFreeSpace + " Bytes";
                });
            }
            catch (Exception)
            {
            }
        }
        #endregion

        #region STORAGE METHODES
        public ICommand CmdCommand => new DelegateCommand(Hibernate);
        private void Hibernate()
        {
            try
            {
                IsEnabled = false;
                ProgBarValue = 0;
                ProgBarLength = 1;
                ConsoleData = new ObservableCollection<string>();
                ConsoleData.Add("disabling...");
                System.Diagnostics.Process.Start("powercfg.exe", "/h off");
                ConsoleData.Add("\nHibernate OFF.");
                IsEnabled = true;
                Thread.Sleep(100);
                ProgBarValue = 1;
                SpaceInfo = @"Drive C:\" + "\nTotal size - " + DI.TotalSize + " Bytes , Free space - " + DI.AvailableFreeSpace + " Bytes";
            }
            catch (Exception)
            {
                ConsoleData.Add("\nDisable Hibernate Error!\nOperation failed.");
            }
        }
        public ICommand RestorePoine => new DelegateCommand(DisableRestorePoint);
        private void DisableRestorePoint()
        {

            try
            {
                run = new RunPowerShell();
                ConsoleData = new ObservableCollection<string>();
                IsEnabled = false;
                ProgBarValue = 0;
                ProgBarLength = 1;
                run.InvokePS("Disable-ComputerRestore -Drive C:");
                ConsoleData.Add("Restore point was disabled successfully");
                Thread.Sleep(100);
                ProgBarValue = 1;
                IsEnabled = true;
                SpaceInfo = @"Drive C:\" + "\nTotal size - " + DI.TotalSize + " Bytes , Free space - " + DI.AvailableFreeSpace + " Bytes";
            }
            catch (Exception)
            {
                ConsoleData.Add("\nRestore-Point Error!\nOperation failed.");
            }
        }
        public ICommand Index => new DelegateCommand(DisableIndexing);
        private void DisableIndexing()
        {
            try
            {
                ConsoleData = new ObservableCollection<string>();
                IsEnabled = false;
                ProgBarValue = 0;
                ProgBarLength = 1;
                File.SetAttributes(@"c:\", FileAttributes.NotContentIndexed);
                ConsoleData.Add("Indexing disabled!\nDrive C: Info:");
                ConsoleData.Add(File.GetAttributes(@"c:\").ToString());
                IsEnabled = true;
                Thread.Sleep(100);
                ProgBarValue = 1;
                SpaceInfo = @"Drive C:\" + "\nTotal size - " + DI.TotalSize + " Bytes , Free space - " + DI.AvailableFreeSpace + " Bytes";
            }
            catch (Exception)
            {
                ConsoleData.Add("\nDisable Indexing Error!\nOperation failed.");
            }
        }
        #endregion

        #region USER PREFERENCES
        public ICommand UAC => new DelegateCommand(DisableUAC);
        private void DisableUAC()
        {
            try
            {
                ConsoleData = new ObservableCollection<string>();
                IsEnabled = false;
                ProgBarLength = 1;
                ProgBarValue = 0;
                run = new RunPowerShell();
                run.InvokePS(@"New-ItemProperty -Path HKLM:Software\Microsoft\Windows\CurrentVersion\policies\system -Name EnableLUA -PropertyType DWord -Value 0 -Force");
                ConsoleData.Add("UAC is Off, System need to reboot to take effect.");
                Thread.Sleep(100);
                ProgBarValue = 1;
                IsEnabled = true;
                SpaceInfo = @"Drive C:\" + "\nTotal size - " + DI.TotalSize + " Bytes , Free space - " + DI.AvailableFreeSpace + " Bytes";
            }
            catch (Exception)
            {
                ConsoleData.Add("\nUAC Error!\nOperation failed.");
            }
        }
        public ICommand Visual => new DelegateCommand(DisableVE);
        private void DisableVE()
        {
            try
            {
                IsEnabled = false;
                ProgBarValue = 0;
                ProgBarLength = 1;
                ConsoleData = new ObservableCollection<string>();
                System.Diagnostics.Process.Start("SystemPropertiesPerformance.exe");
                ConsoleData.Add("\nSelect 'Adjust for best performance'\nAnd click OK.");
                IsEnabled = true;
                Thread.Sleep(100);
                ProgBarValue = 1;
            }
            catch (Exception)
            {
                ConsoleData.Add("\nDisable VE Error!\nOperation failed.");
            }
        }
        public ICommand WD => new DelegateCommand(DisableWD);
        private void DisableWD()
        {
            try
            {
                ConsoleData = new ObservableCollection<string>();
                IsEnabled = false;
                ProgBarLength = 1;
                ProgBarValue = 0;
                run = new RunPowerShell();
                ConsoleData.Add("Windows Defender is OFF!");
                run.InvokePS("Set-MpPreference -DisableRealtimeMonitoring $true");
                ProgBarValue = 1;
                IsEnabled = true;
            }
            catch (Exception)
            {
                ConsoleData.Add("\nDisable WD Error!\nOperation failed.");
            }
        }    
        #endregion
    }
}
