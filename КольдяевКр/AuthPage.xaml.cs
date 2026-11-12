using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace КольдяевКр
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        public string captS = "";
        public AuthPage()
        {
            InitializeComponent();
            CaptTB.Visibility = Visibility.Hidden;
            StackCP.Visibility = Visibility.Hidden;

        }

        public void UpdateCapt()
        {
            captS = Capt.CRCapt();
            captchaOneWord.Text = captS[0].ToString();
            captchaTwoWord.Text = captS[1].ToString();
            captchaThreeWord.Text = captS[2].ToString();
            captchaFourWord.Text = captS[3].ToString();
        }

        private async void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTB.Text;
            string password = PassTB.Text;
            string capt = CaptTB.Text;

            if(login == "" || password == "")
            {
                MessageBox.Show("Есть пустые поля");
             
                return;
            }
            

            User user = Koldyaev41Entities1.GetContext().User.ToList().Find(p => p.UserLogin == login && p.UserPassword == password);
       


            if ((user != null) && (captS == capt))
            {
                Manager.MainFrame.Navigate(new ProductPage(user));
                LoginTB.Text = "";
                PassTB.Text = "";
                CaptTB.Text = "";
                CaptTB.Visibility = Visibility.Hidden;
                StackCP.Visibility = Visibility.Hidden;
            }
            else
            {
                MessageBox.Show("Введены неверные данные");
                LoginBtn.IsEnabled = false;
                CaptTB.Visibility = Visibility.Visible;
                StackCP.Visibility = Visibility.Visible;
                UpdateCapt();
                CaptTB.Text = "";
                await Task.Delay(TimeSpan.FromSeconds(7));
                LoginBtn.IsEnabled = true;
            }



        }

        private void GostBtn_Click(object sender, RoutedEventArgs e)
        { 
            Manager.MainFrame.Navigate(new ProductPage(null));
            CaptTB.Visibility = Visibility.Hidden;
            StackCP.Visibility = Visibility.Hidden;
        }
    }
}
