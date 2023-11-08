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
    public partial class EmployeeGrid : Form
    {
        private const string ApiBaseUrl = Common.ApiUrl;

        public EmployeeGrid()
        {
            InitializeComponent();
        }

        private async void EmployeeGrid_Load(object sender, EventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(ApiBaseUrl + "employeeList");

                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();

                    List<EmployeeInfo> employees = JsonConvert.DeserializeObject<List<EmployeeInfo>>(apiResponse);


                    foreach (var employee in employees)
                    {
                        Panel cardPanel = new Panel
                        {
                            Width = 200,
                            Height = 100,
                            BorderStyle = BorderStyle.FixedSingle,
                            Margin = new Padding(10),
                        };

                        Label nameLabel = new Label
                        {
                            Text = $"Name: {employee.empName}",
                            Location = new Point(10, 10),
                        };

                        Label designationLabel = new Label
                        {
                            Text = $"Designation: {employee.designation}",
                            Location = new Point(10, 30),
                        };

                        Label departmentLabel = new Label
                        {
                            Text = $"Phone: {employee.phone}",
                            Location = new Point(10, 50),
                        };

                        cardPanel.Controls.Add(nameLabel);
                        cardPanel.Controls.Add(designationLabel);
                        cardPanel.Controls.Add(departmentLabel);

                        Controls.Add(cardPanel);
                    }



                    //dataGridView1.DataSource = employees;
                }
                else
                {
                    MessageBox.Show("Error retrieving employee list.");
                }
            }
        }
    }
}
