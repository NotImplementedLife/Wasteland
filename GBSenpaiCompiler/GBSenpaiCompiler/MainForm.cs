using GBSenpaiCompiler.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;
using System.Xml.Linq;
using File = System.IO.File;
using System.Diagnostics;

namespace GBSenpaiCompiler
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            if(!Directory.Exists("devkitPro"))
            {
                MessageBox.Show("devkitPro not found.");
                close_signal = true;
            }

        }

        private void ProjPathSel_Click(object sender, EventArgs e)
        {
            var dialog = new FolderPicker();
            if(dialog.ShowDialog()==true)
            {
                ProjPath.Text = dialog.ResultPath;
            }
        }

        LogsForm logs;

        private void WriteLog(string msg)
        {
            this.Invoke((MethodInvoker)delegate
            {
                logs.WriteLine(msg);
            });
            Thread.Sleep(10);

        }

        private static void CheckDir(string path, string err)
        {
            if (!Directory.Exists(path))
            {
                throw new Exception(err);
            }
        }

        private static void CheckFile(string path, string err)
        {
            if(!File.Exists(path))
            {
                throw new Exception(err);
            }
        }

        private void DownloadSenpaiRes()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = assembly.GetManifestResourceNames()
                .Single(str => str.EndsWith("gbsenpai.zip"));

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                using (var memoryStream = new MemoryStream())
                {
                    stream.CopyTo(memoryStream);

                    if (Directory.Exists("~tmp_senpai"))
                        Directory.Delete("~tmp_senpai", true);

                    new ZipArchive(stream).ExtractToDirectory("~tmp_senpai");                    
                }
            }            
        }

        private void CompileBtn_Click(object sender, EventArgs e)
        {
            try
            {
                DownloadSenpaiRes();
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Could not dispatch gbsenpai.\n{ex.Message}");
            }
            logs = new LogsForm();
            logs.Show();

            this.Enabled = false;            

            Task.Run(() =>
            {
                try
                {                    
                    WriteLog("Checking project path...");

                    var proj_path = ProjPath.Text;
                    WriteLog($"{proj_path}");
                    CheckDir(proj_path, "Project path does not exist");

                    //WriteLog("Getting project name...");

                    string[] gbsfiles = System.IO.Directory.GetFiles(proj_path, "*.gbsproj");

                    if (gbsfiles.Length == 0)
                    {
                        throw new Exception("The specified path does not contain a GB Studio project file (*.gbsproj)");
                    }

                    if (gbsfiles.Length > 1)
                    {
                        WriteLog("WARNING! Multiple GB Studio project files have been found in this path. Only one of them is being processed");
                    }

                    var gbs_path = Path.Combine(proj_path, gbsfiles[0]);
                    string s = File.ReadAllText(gbs_path);
                    var reg = Regex.Match(s, "\"name\": \"(.*)\",");
                    if(!reg.Success)
                    {
                        throw new Exception("Could not read project name from GB Studio project file.");
                    }
                    var project_name = reg.Groups[1].Value.Replace(' ', '_');
                    WriteLog($"Project Name = {project_name}");

                    var proj_s_path = Path.Combine(proj_path, "build", "src");
                    WriteLog($"{proj_s_path}");
                    CheckDir(proj_s_path, "Project source files not found. Make sure to export source code from GBStudio.");
                    

                    var p_inc_path = Path.Combine(proj_s_path, "include");
                    var p_src_path = Path.Combine(proj_s_path, "src");

                    WriteLog($"{p_inc_path}");
                    CheckDir(p_inc_path, "Project source dump is corrupted. Include folder not found");
                    WriteLog($"{p_src_path}");
                    CheckDir(p_src_path, "Project source dump is corrupted. Sources folder not found");


                    WriteLog("Creating gbsenpai sources...");
                    var src_dest = Path.Combine("~tmp_senpai", "gbsenpai", project_name);
                    Directory.CreateDirectory(src_dest);

                    WriteLog("Copying sources");

                    var s_data = Path.Combine(p_src_path, "data");
                    WriteLog(s_data);
                    CheckDir(s_data, "Project source dump is corrupted. src/data not found");

                    foreach(var file in Directory.GetFiles(s_data))
                    {
                        var fname = Path.GetFileName(file);
                        WriteLog(fname);
                        File.Copy(file, Path.Combine(src_dest, fname));
                    }

                    var s_music = Path.Combine(p_src_path, "music");
                    WriteLog(s_music);
                    CheckDir(s_music, "Project source dump is corrupted. src/music not found");

                    foreach (var file in Directory.GetFiles(s_music))
                    {
                        var fname = Path.GetFileName(file);
                        WriteLog(fname);
                        File.Copy(file, Path.Combine(src_dest, fname));
                    }

                    var i_banks = Path.Combine(p_inc_path, "banks.h");
                    WriteLog(i_banks);
                    CheckFile(i_banks, "banks.h not found");
                    File.Copy(i_banks, Path.Combine(src_dest, "banks.h"));

                    var i_data_ptrs = Path.Combine(p_inc_path, "data_ptrs.h");
                    WriteLog(i_data_ptrs);
                    CheckFile(i_data_ptrs, "data_ptrs.h not found");
                    File.Copy(i_data_ptrs, Path.Combine(src_dest, "data_ptrs.h"));

                    var platform_c = Path.Combine(p_src_path, "states", "Platform.c");
                    if (File.Exists(platform_c))
                    {
                        WriteLog(platform_c);
                        var dest = Path.Combine(src_dest, "..", "source", "states", "Platform.c");
                        if (File.Exists(dest))
                            File.Delete(dest);                        
                        File.Copy(platform_c, dest);
                    }

                    WriteLog("Preparing msys2...");

                    var fstab = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "devkitPro", "msys2", "etc", "fstab");                    
                    var txt = "# For a description of the file format, see the Users Guide\r\n" +
                    "# https://cygwin.com/cygwin-ug-net/using.html#mount-table\r\n\r\n" +
                    "# DO NOT REMOVE NEXT LINE. It remove cygdrive prefix from path\r\n" +
                    "none / cygdrive binary,posix=0,noacl,user 0 0\r\n\r\n" +
                    "# Share home with windows\r\nC:\\Users\t/home\r\n\r\n" +
                    $"# map devkitPro to /opt\r\n{Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "devkitPro")}\t /opt/devkitpro";

                    File.WriteAllText(fstab, txt);

                    WriteLog("Updating Makefile...");
                    var mkfile = Path.Combine("~tmp_senpai", "gbsenpai", "Makefile.gba");
                    var str = File.ReadAllText(mkfile).Replace("@{PROJNAME}", project_name);
                    File.WriteAllText(mkfile, str);

                    WriteLog("");
                    WriteLog("Project preparation ready.");
                    WriteLog("");
                    WriteLog("Compiling...");
                    WriteLog("");

                    WriteLog("make -f Makefile.gba");

                    WriteLog(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "devkitPro", "msys2", "usr", "bin", "make.exe"));
                    var process = new Process();
                    process.StartInfo = new ProcessStartInfo
                    {
                        FileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "devkitPro", "msys2", "usr", "bin", "make.exe"),
                        Arguments = "-f Makefile.gba",                        
                        WorkingDirectory = Path.Combine("~tmp_senpai","gbsenpai"),                          
                    };
                    process.StartInfo.EnvironmentVariables.Add("DEVKITARM", Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "devkitPro", "devkitARM"));

                    //process.OutputDataReceived += Process_OutputDataReceived;
                    //process.ErrorDataReceived += Process_OutputDataReceived;


                    process.Start();
                    WriteLog("Wait...");
                    process.WaitForExit();

                    if (process.ExitCode != 0)
                        throw new Exception($"Error!!! Process returned with exit code {process.ExitCode}");

                    WriteLog("Done.");
                    Process.Start(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "~tmp_senpai", "gbsenpai"));
                }
                catch(Exception ex)
                {
                    WriteLog("");
                    WriteLog("Operation halted due to exception encountered:");
                    WriteLog("");
                    WriteLog(ex.Message);
                }
                
                this.Invoke((MethodInvoker)delegate
                {
                    this.Enabled = true;
                });
            });
            
        }

        private void Process_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            WriteLog(e.Data);
        }

        bool close_signal = false;

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (close_signal)
                Close();
        }
    }
}
