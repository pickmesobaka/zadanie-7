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
using System.Windows.Shapes;
using WpfApp1.Models;
using System.Security.Cryptography;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void authButton_Click(object sender, RoutedEventArgs e)
        {
            // Получаем данные из текстбоксов и убираем пробелы по бокам
            string login = LoginTextBox.Text.Trim();
            string password = PasswordTextBox.Text.Trim();

            // Хэшируем введенный пароль (точно так же, как мы сделали это в базе через SHA2)
            // ВАЖНО: Убедись, что вверху файла есть using System.Security.Cryptography; и using System.Text;
            byte[] bytes = SHA256.HashData(Encoding.UTF8.GetBytes(password));
            string hash = Convert.ToHexString(bytes).ToLower();

            // Создаем контекст (exzContext вместо testContext)
            var db = new exzContext();

            // Ищем пользователя по логину
            var user = db.Пользователиs.FirstOrDefault(x => x.Логин == login);

            if (user == null)
            {
                MessageBox.Show("Неверный логин"); // Если не нашли — выводим сообщение
                return;
            }

            // Сравниваем хэш
            if (hash != user.Пароль)
            {
                MessageBox.Show("Неверный пароль"); // Если хэш не совпал — выводим сообщение
                return;
            }
            AppState.CurrentUser = user; // Сохраняем нашего пользователя в State



            // Если всё ок — открываем главное окно
            var mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }
    }
}
