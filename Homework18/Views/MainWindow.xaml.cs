using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Homework18.Model;
using Homework18.Model.OpenSaveOperations;
using Homework18.ViewModels;

namespace Homework18.Views
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //IAnimal ia = AnimalFactory.GetNewAnimal("Homework18.Model.Mammal", "Barsik", 3);
            //IAnimal ia2 = AnimalFactory.GetNewAnimal("Homework18.Model.Bird", "Kesha", 10);

            //ObservableCollection<IAnimal> animals = new ObservableCollection<IAnimal>();
            //(ia as Mammal).CoatLength = 10;
            //(ia2 as Bird).WingSpan = 3;

            //animals.Add(ia);
            //animals.Add(ia2);


            //JSonKeeper jsk = new JSonKeeper();
            //FileWorker fwJSon = new FileWorker(jsk);
            //string fName = @"Output\jsonSerialization.txt";
            //fwJSon.Save(animals, fName);


            //XmlKeeper xmlk = new XmlKeeper();
            //FileWorker fwXml = new FileWorker(xmlk);
            //fName = @"Output\xmlSerialization.txt";
            //fwXml.Save(animals, fName);



        }


    }
}
