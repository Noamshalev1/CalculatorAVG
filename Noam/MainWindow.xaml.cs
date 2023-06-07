using Noam.Models;
using Noam.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace Noam
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    // This class should represent the View leyer int Mvvm
    // Asking from the ViewModel the list of the students to view them to the user
    public partial class MainWindow : Window
    {
        Calculator calculator; // The connection class between Models to View
        public MainWindow()
        {
            InitializeComponent();
            calculator = new Calculator(); 
            ListBoxStudents.ItemsSource = calculator.getData(); // return a list of students
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            Student selectedStudent = (Student)comboBox.SelectedItem;
            string txt = calculator.CalculateAvg(selectedStudent, 10).ToString(); // get the heighest average by 10 points total
            ResultTextBox.Text = txt;
            
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
