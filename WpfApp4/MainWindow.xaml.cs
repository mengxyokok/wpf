using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

using Telerik.Windows.Controls;

namespace WpfApp4
{

    public class WarehouseItem : INotifyPropertyChanged
    {
        private string name;
        private int count;
        private ObservableCollection<WarehouseItem> items;

        public WarehouseItem(string name, int count)
        {
            this.Name = name;
            this.Count = count;
            this.Items = new ObservableCollection<WarehouseItem>();
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (value != this.name)
                {
                    this.name = value;
                    this.OnPropertyChanged("Name");
                }
            }
        }
        public ObservableCollection<WarehouseItem> Items
        {
            get
            {
                return this.items;
            }
            set
            {
                if (value != this.items)
                {
                    this.items = value;
                    this.OnPropertyChanged("Items");
                }
            }
        }
        public int Count
        {
            get
            {
                return this.count;
            }
            set
            {
                if (value != this.count)
                {
                    this.count = value;
                    this.OnPropertyChanged("Count");
                }
            }
        }

        protected virtual void OnPropertyChanged(PropertyChangedEventArgs args)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, args);
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            this.OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }

    public class WarehouseService
    {
        public static ObservableCollection<WarehouseItem> GetWarehouseData()
        {
            ObservableCollection<WarehouseItem> data = new ObservableCollection<WarehouseItem>();
            WarehouseItem drinks = new WarehouseItem("Drinks", 35);
            drinks.Items.Add(new WarehouseItem("Water", 10));
            WarehouseItem tea = new WarehouseItem("Tea", 20);
            tea.Items.Add(new WarehouseItem("Black", 10));
            tea.Items.Add(new WarehouseItem("Green", 10));
            drinks.Items.Add(tea);
            drinks.Items.Add(new WarehouseItem("Coffee", 5));
            data.Add(drinks);
            WarehouseItem vegetables = new WarehouseItem("Vegeatbles", 75);
            vegetables.Items.Add(new WarehouseItem("Tomato", 40));
            vegetables.Items.Add(new WarehouseItem("Carrot", 25));
            vegetables.Items.Add(new WarehouseItem("Onion", 10));
            data.Add(vegetables);
            WarehouseItem fruits = new WarehouseItem("Fruits", 55);
            fruits.Items.Add(new WarehouseItem("Cherry", 30));
            fruits.Items.Add(new WarehouseItem("Apple", 20));
            fruits.Items.Add(new WarehouseItem("Melon", 5));
            data.Add(fruits);
            return data;
        }
    }

    public class WarehouseViewModel : ViewModelBase
    {
        private ObservableCollection<WarehouseItem> warehouseItems;

        public ObservableCollection<WarehouseItem> WarehouseItems
        {
            get
            {
                if (this.warehouseItems == null)
                {
                    this.warehouseItems = WarehouseService.GetWarehouseData();
                }

                return this.warehouseItems;
            }
        }
    }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }
}
