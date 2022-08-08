using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows.Forms;

namespace LINENotifyImage
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string token = ""; // Please set the Token.
            string msg = "Notify test";
            string ApiUrl = "https://notify-api.line.me/api/notify";
            FileStream img = File.OpenRead(@"C:\Windows\Web\Screen\img100.jpg");
            var http = new HttpClient();
            {
                http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("multipart/form-data"));
                http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var body = new MultipartFormDataContent();
                body.Add(new StringContent(msg), "message");
                if (img != Stream.Null)
                {
                    var imgFile = new StreamContent(img);
                    body.Add(imgFile, "imageFile", "*");
                }
                http.PostAsync(ApiUrl, body);
            }
        }
    }
}
