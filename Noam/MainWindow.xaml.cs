using Noam.Models;
using Noam.ViewModels;
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

namespace Noam
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Student[] students;

        Calculator calculator;
        public MainWindow()
        {
            InitializeComponent();
            calculator = new Calculator();
            ListBoxStudents.ItemsSource = calculator.getData();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            Student selectedStudent = (Student)comboBox.SelectedItem;
            string txt = calculator.CalculateAvg(selectedStudent).ToString();
            ResultTextBox.Text = txt;
            // Assuming you have a separate ListBox control named "ListBoxStudents" to display the selected student list
            //ListBoxStudents.ItemsSource = selectedStudent.ToString();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
