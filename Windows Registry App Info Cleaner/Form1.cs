using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Registry_Cleaner
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Read(null);
        }

        public void Read(string KeyName)
        {
            
            try
            {
                GetInstalledSoftware();                
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void GetInstalledSoftware()
        {
            string displayName;
            string uRLInfoAbout;
            string uRLUpdateInfo;
            string comments;
            string helpLink;
            string contact;
            string helpTelephone;
            string readMe;
            RegistryKey key;
            int rowsCount = 0;

            // search in: CurrentUser
            key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall");
            foreach (String keyName in key.GetSubKeyNames())
            {
                RegistryKey subkey = key.OpenSubKey(keyName);
                displayName = subkey.GetValue("DisplayName") as string;
                uRLInfoAbout = subkey.GetValue("URLInfoAbout") as string;
                uRLUpdateInfo = subkey.GetValue("URLUpdateInfo") as string;
                comments = subkey.GetValue("Comments") as string;
                helpLink = subkey.GetValue("HelpLink") as string;
                contact = subkey.GetValue("Contact") as string;
                helpTelephone = subkey.GetValue("HelpTelephone") as string;
                readMe = subkey.GetValue("Readme") as string;

                if (displayName!=null)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[rowsCount].Cells[0].Value = displayName;
                    dataGridView1.Rows[rowsCount].Cells[1].Value = uRLInfoAbout;
                    dataGridView1.Rows[rowsCount].Cells[2].Value = uRLUpdateInfo;
                    dataGridView1.Rows[rowsCount].Cells[3].Value = comments;
                    dataGridView1.Rows[rowsCount].Cells[4].Value = helpLink;
                    dataGridView1.Rows[rowsCount].Cells[5].Value = contact;
                    dataGridView1.Rows[rowsCount].Cells[6].Value = helpTelephone;
                    dataGridView1.Rows[rowsCount].Cells[7].Value = readMe;
                    rowsCount++;
                    textBox1.AppendText(displayName);
                    textBox1.AppendText(Environment.NewLine);
                }

            }

            // search in: LocalMachine_32
            key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall");
            foreach (String keyName in key.GetSubKeyNames())
            {
                RegistryKey subkey = key.OpenSubKey(keyName);
                displayName = subkey.GetValue("DisplayName") as string;
                uRLInfoAbout = subkey.GetValue("URLInfoAbout") as string;
                uRLUpdateInfo = subkey.GetValue("URLUpdateInfo") as string;
                comments = subkey.GetValue("Comments") as string;
                helpLink = subkey.GetValue("HelpLink") as string;
                contact = subkey.GetValue("Contact") as string;
                helpTelephone = subkey.GetValue("HelpTelephone") as string;
                readMe = subkey.GetValue("Readme") as string;

                if (displayName != null)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[rowsCount].Cells[0].Value = displayName;
                    dataGridView1.Rows[rowsCount].Cells[1].Value = uRLInfoAbout;
                    dataGridView1.Rows[rowsCount].Cells[2].Value = uRLUpdateInfo;
                    dataGridView1.Rows[rowsCount].Cells[3].Value = comments;
                    dataGridView1.Rows[rowsCount].Cells[4].Value = helpLink;
                    dataGridView1.Rows[rowsCount].Cells[5].Value = contact;
                    dataGridView1.Rows[rowsCount].Cells[6].Value = helpTelephone;
                    dataGridView1.Rows[rowsCount].Cells[7].Value = readMe;
                    rowsCount++;
                    textBox1.AppendText(displayName);
                    textBox1.AppendText(Environment.NewLine);
                }
            }

            // search in: LocalMachine_64
            key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall");
            foreach (String keyName in key.GetSubKeyNames())
            {
                RegistryKey subkey = key.OpenSubKey(keyName);
                displayName = subkey.GetValue("DisplayName") as string;
                uRLInfoAbout = subkey.GetValue("URLInfoAbout") as string;
                uRLUpdateInfo = subkey.GetValue("URLUpdateInfo") as string;
                comments = subkey.GetValue("Comments") as string;
                helpLink = subkey.GetValue("HelpLink") as string;
                contact = subkey.GetValue("Contact") as string;
                helpTelephone = subkey.GetValue("HelpTelephone") as string;
                readMe = subkey.GetValue("Readme") as string;

                if (displayName != null)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[rowsCount].Cells[0].Value = displayName;
                    dataGridView1.Rows[rowsCount].Cells[1].Value = uRLInfoAbout;
                    dataGridView1.Rows[rowsCount].Cells[2].Value = uRLUpdateInfo;
                    dataGridView1.Rows[rowsCount].Cells[3].Value = comments;
                    dataGridView1.Rows[rowsCount].Cells[4].Value = helpLink;
                    dataGridView1.Rows[rowsCount].Cells[5].Value = contact;
                    dataGridView1.Rows[rowsCount].Cells[6].Value = helpTelephone;
                    dataGridView1.Rows[rowsCount].Cells[7].Value = readMe;
                    rowsCount++;
                    textBox1.AppendText(displayName);
                    textBox1.AppendText(Environment.NewLine);
                }
            }
            key.Close();
        }

        //Ставит пустые значения для контактной информации и тому подобному
        private void ClearUnusefullInfo()
        {
            string displayName;
            RegistryKey key;

            // search in: CurrentUser
            key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall",true);
            foreach (String keyName in key.GetSubKeyNames())
            {
                RegistryKey subkey = key.OpenSubKey(keyName,true);
                displayName = subkey.GetValue("DisplayName") as string;
                if (displayName != null)
                {
                    subkey.SetValue("URLInfoAbout", "");
                    subkey.SetValue("URLUpdateInfo", "");
                    subkey.SetValue("Comments", "");
                    subkey.SetValue("HelpLink", "");
                    subkey.SetValue("Contact", "");
                    subkey.SetValue("HelpTelephone", "");
                    subkey.SetValue("Readme", "");
                }
            }

            // search in: LocalMachine_32
            key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall",true);
            foreach (String keyName in key.GetSubKeyNames())
            {
                RegistryKey subkey = key.OpenSubKey(keyName,true);
                displayName = subkey.GetValue("DisplayName") as string;
                if (displayName != null)
                {
                    subkey.SetValue("URLInfoAbout", "");
                    subkey.SetValue("URLUpdateInfo", "");
                    subkey.SetValue("Comments", "");
                    subkey.SetValue("HelpLink", "");
                    subkey.SetValue("Contact", "");
                    subkey.SetValue("HelpTelephone", "");
                    subkey.SetValue("Readme", "");
                }
            }

            // search in: LocalMachine_64
            key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall",true);
            foreach (String keyName in key.GetSubKeyNames())
            {
                RegistryKey subkey = key.OpenSubKey(keyName, true);
                displayName = subkey.GetValue("DisplayName") as string;
                if (displayName != null)
                {
                    subkey.SetValue("URLInfoAbout", "");
                    subkey.SetValue("URLUpdateInfo", "");
                    subkey.SetValue("Comments", "");
                    subkey.SetValue("HelpLink", "");
                    subkey.SetValue("Contact", "");
                    subkey.SetValue("HelpTelephone", "");
                    subkey.SetValue("Readme", "");
                }
            }
            key.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClearUnusefullInfo();
        }
    }
}