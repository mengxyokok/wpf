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

    public class GridItem
    {
        public string ParentName { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }

        public GridItem(string parentname, string name, int count = 2)
        {
            this.ParentName = parentname;
            this.Name = name;
            this.Count = count;
        }
    }

    public class NodeItem
    {
        public GridItem CurrentData { get; set; }
        public List<NodeItem> ChildItems { get; set; }


        public NodeItem(GridItem data)
        {
            this.CurrentData = data;
            this.ChildItems = new List<NodeItem>();
        }
    }
    public partial class MainWindow : Window
    {
        //递归方法
        List<GridItem> items = new List<GridItem>();
        void AddChild(NodeItem currentItem)
        {
            var filterList = items.Where(x => x.ParentName == currentItem.CurrentData.Name).ToList();

            foreach (var tt in filterList)
            {
                var childItem = new NodeItem(tt);
                currentItem.ChildItems.Add(childItem);
                var childrenList = items.Where(x => x.ParentName == tt.Name).ToList();
                if (childrenList.Count > 0)
                {
                    AddChild(childItem);
                }
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            //List<NodeItem> data = new List<NodeItem>();
            //NodeItem item1 = new NodeItem("1", 12); data.Add(item1);
            //NodeItem item2 = new NodeItem("2", 12); data.Add(item2);
            //NodeItem item3 = new NodeItem("3", 12); data.Add(item3);
            //NodeItem item11 = new NodeItem("1.1", 12); item1.ChildItems.Add(item11);
            //NodeItem item12 = new NodeItem("1.2", 12); item1.ChildItems.Add(item12);
            //NodeItem item111 = new NodeItem("1.1.1", 12); item11.ChildItems.Add(item111);

            items.Add(new GridItem("", "root"));
            items.Add(new GridItem("1.1", "1.1.1"));
            items.Add(new GridItem("root", "1"));
            items.Add(new GridItem("root", "2"));
            items.Add(new GridItem("root", "3"));
            items.Add(new GridItem("1", "1.1"));
            items.Add(new GridItem("1", "1.2"));

            var rootData = items.First(x => x.Name == "root");
            var rootItem = new NodeItem(rootData);
            AddChild(rootItem);

            radTreeListView.ItemsSource =  rootItem.ChildItems;
            radTreeListView.AutoExpandItems = true; 
        }


    }
}
