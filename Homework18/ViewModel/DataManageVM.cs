using Homework18.Model;
using Homework18.Model.OpenSaveOperations;
using Skillbox_Homework17_Entity.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homework18.Utils;
using System.ComponentModel;

namespace Homework18.ViewModel
{
    public class DataManageVM : INotifyPropertyChanged
    {
        #region Поля и свойства

        private ObservableCollection<IAnimal> allAnimals;
        public ObservableCollection<IAnimal> AllAnimals
        {
            get { return allAnimals; }
            set
            {
                if (allAnimals != value)
                {
                    allAnimals = value;
                    RaisePropertyChangedEvent("AllAnimals");
                }
            }
        }
        public FileWorker fileOperations { get; set; }

        public ObservableCollection<string> LoadFrom { get; set; }
        public ObservableCollection<string> SaveTo { get; set; }

        public string SelectedLoadFrom { get; set; }
        public string SelectedSaveTo { get; set; }

        #endregion

        #region Конструкторы

        public DataManageVM()
        {
            AllAnimals = new ObservableCollection<IAnimal>();
            LoadFrom = new ObservableCollection<string>() { "JSon", "Xml" };
            SelectedLoadFrom = LoadFrom[0];
            SaveTo = new ObservableCollection<string>() { "JSon", "Xml" };
            SelectedSaveTo = SaveTo[0];

        }

        #endregion

        #region Методы
        
        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChangedEvent(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
        #endregion

        #region Команды


        private RelayCommand loadAnimals;
        public RelayCommand LoadAnimals
        {
            get
            {
                return loadAnimals ?? new RelayCommand(obj =>
                {
                    switch (SelectedLoadFrom)
                    {
                        case "JSon": fileOperations = new FileWorker(new JSonKeeper()); break;
                        case "Xml": fileOperations = new FileWorker(new XmlKeeper()); break;
                        default: return;
                    }

                    DefaultDialogService OpenDialog = new DefaultDialogService();
                    if (OpenDialog.OpenFileDialog())
                    {
                        AllAnimals = (ObservableCollection<IAnimal>) fileOperations.Load(OpenDialog.FilePath);
                    }
                });
            }
        }

        private RelayCommand saveAnimals;
        public RelayCommand SaveAnimals
        {
            get
            {
                return saveAnimals ?? new RelayCommand(obj =>
                {
                    switch (SelectedLoadFrom)
                    {
                        case "JSon": fileOperations = new FileWorker(new JSonKeeper()); break;
                        case "Xml": fileOperations = new FileWorker(new XmlKeeper()); break;
                        default: return;
                    }

                    DefaultDialogService SaveDialog = new DefaultDialogService();
                    if (SaveDialog.SaveFileDialog())
                    {
                        fileOperations.Save(allAnimals, SaveDialog.FilePath);
                    }
                });
            }
        }


        #endregion






    }
}
