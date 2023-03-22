using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceProcess;
using System.Data.SqlClient;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private readonly ServiceController _monitoringServer = new ServiceController("MSSQL$SQLEXPRESS");


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ServiceController[] services = ServiceController.GetServices();
                var res = services.Where(x => x.ServiceName.Contains("MSSQLSERVER"));
                var servicess = services.ToList().Where(x => x.ServiceName.StartsWith("MSSQL"));

                foreach (var item in servicess)
                {
                    item.Stop();
                }
                var myFile = File.Create("C:\\temp\\MSDBData.mdf");
                myFile.Close();
                File.Copy(@"C:\\Program Files\\Microsoft SQL Server\\MSSQL15.SQLEXPRESS\\MSSQL\\DATA\\MSDBData.mdf", @"C:\\temp\\MSDBData.mdf", true);
                File.SetAttributes("C:\\temp", FileAttributes.Normal);
                foreach (var item in servicess)
                {
                    item.WaitForStatus(ServiceControllerStatus.StartPending);
                }
              //  var procesus =  new List<Process>();
              //var totaux = Process.GetProcesses();
              //foreach (var pp in totaux)
              //{
              //    // Temp is a document which you need to kill.
              //    procesus.Add(pp);
              //}

              ////myPath = "C:\file.txt"
              
               // var ppSql = Process.GetProcessesByName("sqlservr");
               // var ssms = Process.GetProcessesByName("ssms");

               /* foreach (var pp in Process.GetProcessesByName("sqlservr"))
                {
                    // Temp is a document which you need to kill.
                    pp.Kill();
                    procesus.Add(pp);
                }*/
              /* foreach (var pp in Process.GetProcessesByName("ssms"))
                {
                    // Temp is a document which you need to kill.
                    pp.Kill();
                    procesus.Add(pp);
                }*/
                //var process = Process.GetCurrentProcess(); // Or whatever method you are using
                //string fullPath = process.MainModule.FileName;
                //var current = Process.GetCurrentProcess();
                //process.Kill();

                ////fullPath has the path to exe.

                //var myFile = File.Create("C:\\temp\\MSDBData.mdf");
                ////myPath = "C:\file.txt"
                //myFile.Close();

               
            }
            catch (Exception ex)
            {

                throw;
            }
           
                     
           

        }
        private Process proc;
        private List<int> pids = new List<int>();

        public void StartProc()
        {
            // this tries to simulate what you're doing. Starts the process, then 
            // wait to be sure that the second process starts, then kill proc
            proc.Start();
            pids.Add(proc.Id);
            Thread.Sleep(300);
            try
            {
                ////proc.Kill();
            }
            catch { }
        }
        // the method returns the PID of the process
        public int Test()
        {
            proc = new Process();
            proc.StartInfo.FileName = @"sqlservr.exe";
            for (int i = 0; i < 2; i++)
            {
                Thread t = new Thread(StartProc);
                t.Start();
                Thread.Sleep(200);
            }
            Thread.Sleep(500);
            return proc.Id;
        }
        private static void LoadDatabase()
        {
            //Connect to the server
            var connectionString = "Data Source=localhost\\sqlexpress;Initial Catalog=master;Integrated Security=SSPI";
            var con = new SqlConnection(connectionString);
            ServerConnection serverConnection = new ServerConnection(con);
            Server sqlServer = new Server(serverConnection);

            System.IO.FileInfo mdf = new System.IO.FileInfo(@"Buzzle.mdf");
            System.IO.FileInfo ldf = new System.IO.FileInfo(@"Buzzle_log.LDF");

            var dbPath = sqlServer.MasterDBPath;
            var databasePath = dbPath + @"\Buzzle.mdf";
            var databaseLogPath = dbPath + @"\Buzzle_log.LDF";

            File.Copy(mdf.FullName, databasePath, true);
            File.Copy(ldf.FullName, databaseLogPath, true);

            var databasename = mdf.Name.ToLower().Replace(@".mdf", @"");

            System.Collections.Specialized.StringCollection databasefiles = new System.Collections.Specialized.StringCollection();
            databasefiles.Add(databasePath);
            databasefiles.Add(databaseLogPath);

            sqlServer.AttachDatabase(databasename, databasefiles);
        }
    }
}
