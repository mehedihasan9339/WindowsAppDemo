using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsAppDemo.Global;
using WindowsAppDemo.Models;

namespace WindowsAppDemo.Forms.Employee
{
    public partial class EmployeeList : Form
    {
        private const string ApiBaseUrl = Common.ApiUrl;
        public EmployeeList()
        {
            InitializeComponent();
        }

        private async void EmployeeList_Load(object sender, EventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(ApiBaseUrl + "employeeList");

                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();

                    List<EmployeeInfo> employees = JsonConvert.DeserializeObject<List<EmployeeInfo>>(apiResponse);




                    dataGridView1.DataSource = employees;
                }
                else
                {
                    MessageBox.Show("Error retrieving employee list.");
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
