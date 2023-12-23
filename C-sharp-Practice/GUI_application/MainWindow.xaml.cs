using System;
using System.Net.Http;
using System.Windows;

namespace LoginApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            var domain = DomainBox.Text;
            var username = UsernameBox.Text;
            var password = PasswordBox.Password; // Use Password property for PasswordBox

            // Assuming a simple HTTP POST request for login (this is just an example)
            using (var client = new HttpClient())
            {
                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("username", username),
                    new KeyValuePair<string, string>("password", password)
                });

                HttpResponseMessage response;
                try
                {
                    response = await client.PostAsync(domain, content);
                    if (response.IsSuccessStatusCode)
                    {
                        ResultText.Text = "Success";
                    }
                    else
                    {
                        ResultText.Text = "Failure";
                    }
                }
                catch (Exception ex)
                {
                    ResultText.Text = "Error: " + ex.Message;
                }
            }
        }
    }
}
