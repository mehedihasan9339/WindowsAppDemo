using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsAppDemo.Forms.Auth;
using WindowsAppDemo.Forms.Employee;

namespace WindowsAppDemo.Forms
{
    public partial class Dashboard : Form
    {
        Home home;
        AboutUs about;
        EmployeeGrid employeeGrid;
        EmployeeList employeeList;
        public Dashboard()
        {
            InitializeComponent();
        }

        private void Dashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            Login loginForm = new Login();
            loginForm.Show();
        }

        private void menuTransition_Tick(object sender, EventArgs e)
        {

        }

        bool sidebarExpand = false;
        private void sidebarTransition_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {
                sideBar.Width -= 10;
                if (sideBar.Width <= 58)
                {
                    sidebarExpand = false;
                    sidebarTransition.Stop();
                }
            }
            else
            {
                sideBar.Width += 10;
                if (sideBar.Width >= 172)
                {
                    sidebarExpand = true;
                    sidebarTransition.Stop();
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            sidebarTransition.Start();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            if (home == null)
            {
                home = new Home();
                home.FormClosed += Home_FormClosed;
                home.MdiParent = this;
                home.Dock = DockStyle.Fill;
                home.Show();
            }
            else
            {
                home.Activate();
            }
        }

        private void Home_FormClosed(object sender, FormClosedEventArgs e)
        {
            home = null;
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            if (about == null)
            {
                about = new AboutUs();
                about.FormClosed += Home_FormClosed;
                about.MdiParent = this;
                about.Dock = DockStyle.Fill;
                about.Show();
            }
            else
            {
                about.Activate();
            }
        }

        private void About_FormClosed(object sender, FormClosedEventArgs e)
        {
            about = null;
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            home = new Home();
            home.FormClosed += Home_FormClosed;
            home.MdiParent = this;
            home.Dock = DockStyle.Fill;
            home.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (employeeGrid == null)
            {
                employeeGrid = new EmployeeGrid();
                employeeGrid.FormClosed += EmployeeGrid_FormClosed;
                employeeGrid.MdiParent = this;
                employeeGrid.Dock = DockStyle.Fill;
                employeeGrid.Show();
            }
            else
            {
                employeeGrid.Activate();
            }
        }

        private void EmployeeGrid_FormClosed(object sender, FormClosedEventArgs e)
        {
            employeeGrid = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (employeeList == null)
            {
                employeeList = new EmployeeList();
                employeeList.FormClosed += EmployeeList_FormClosed;
                employeeList.MdiParent = this;
                employeeList.Dock = DockStyle.Fill;
                employeeList.Show();
            }
            else
            {
                employeeList.Activate();
            }
        }
        private void EmployeeList_FormClosed(object sender, FormClosedEventArgs e)
        {
            employeeList = null;
        }
    }
}
