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
using WindowsAppDemo.Models;

namespace WindowsAppDemo.Forms.Auth
{
    public partial class Login : Form
    {
        private const string ApiBaseUrl = "https://localhost:7038/";

        public Login()
        {
            InitializeComponent();
            txtPass.PasswordChar = '*';
            txtUser.Text = "mehedi";
            txtPass.Text = "Test@123";
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            var loginViewModel = new LoginViewModel
            {
                Username = txtUser.Text,
                Password = txtPass.Text
            };

            string apiResponse = await PerformLoginAsync(loginViewModel);

            if (apiResponse == "true")
            {
                Dashboard dashboard = new Dashboard();
                dashboard.Show();

                this.Hide();
            }
            else
            {
                MessageBox.Show("Login failed. Invalid credentials.");
            }
        }



        private async Task<string> PerformLoginAsync(LoginViewModel loginViewModel)
        {
            using (HttpClient client = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(loginViewModel);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(ApiBaseUrl + "login", content);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    return null;
                }
            }
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Login login = new Login();
            login.Close();
        }
    }
}
