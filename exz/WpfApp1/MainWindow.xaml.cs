using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.Models;
namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            LoadUsers();
            authTextBlock.Text = $"{AppState.CurrentUser!.Фио} ";

        }

        private void LoadUsers()
        {
            try
            {
                var db = new exzContext(); // Создаем контекст для работы с бд аналог EM в PHP
                var users = db.Пользователиs.ToList(); // Получаем из бд пользователей

                userTable.ItemsSource = users; // Указываем для DataGrid наших пользователей
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void userTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            var db = new exzContext(); // создаем DB context

            var lastName = SearchBox.Text; // добавляем переменную данные из пользовательского ввода

            var users = string.IsNullOrWhiteSpace(lastName)
         ? db.Пользователиs.ToList()
         : db.Пользователиs
             .Where(x => x.Фио.Contains(lastName)) // тут x.LastName это поле модели
             .ToList();
            // ищем пользователей у которых содержаться данные в интересующем нам столбце, если пользовательский ввод пустой выводим всех пользователей

            userTable.ItemsSource = users; // обновляем таблицу

        }
    }
}