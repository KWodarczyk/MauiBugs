
using Microsoft.Maui.Controls.Shapes;

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MauiTest
{

    public class Selectable : INotifyPropertyChanged
    {
        private bool _selected;

        private int _value;

        public int Value
        {
            get { return _value; }
            set { _value = value; OnPropertyChanged(); }
        }


        public int Index { get; set; }

        private Brush _background = Brush.Blue;

        public Brush SelecableColor
        {
            get { return _background; }
            set { _background = value; OnPropertyChanged(); }
        }





        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }



    public partial class MainPage : ContentPage
    {

        private double _itemHeight;
        private Rectangle rec;
        private double _recTopEdge;
        private double _recBottomEdge;
        private Selectable _selectedItem;
        private Selectable _selectableTest;
        private int _numberOfVisibleItems;

        public Selectable SelectableTest
        {
            get { return _selectableTest; }
            set { _selectableTest = value; }
        }



        public ObservableCollection<Selectable> SelectableItems { get; set; }


        private int[] _items;

        public MainPage()
        {
            SelectableTest = new Selectable();
            SelectableItems = new ObservableCollection<Selectable>()
            {

                new Selectable(){Value=0, Index=0},
                new Selectable(){Value=1, Index=1},
                new Selectable(){Value=2, Index = 2},
                new Selectable(){Value=3, Index = 3},
                new Selectable(){Value=4, Index = 4},
                new Selectable(){Value=5, Index = 5},
                new Selectable(){Value=6, Index = 6},
                new Selectable(){Value=7, Index = 7},
                new Selectable(){Value=8, Index = 8},
                new Selectable(){Value=9, Index = 9},
                new Selectable(){Value=10,Index = 10},
                new Selectable(){Value=20, Index = 11},
                new Selectable(){Value=30, Index = 12},
                new Selectable(){Value=40, Index = 13},
                new Selectable(){Value=50, Index = 14},
                new Selectable(){Value=60, Index = 15},
                new Selectable(){Value=70, Index = 16},
                new Selectable(){Value=80, Index = 17},
                new Selectable(){Value=90, Index = 18},
                new Selectable(){Value=99, Index = 19},

            };
            BindingContext = this;
            InitializeComponent();

        }


        private void CollectionView_Scrolled(object sender, ItemsViewScrolledEventArgs e)
        {
            int numberOfVisibleItems = (e.LastVisibleItemIndex - e.FirstVisibleItemIndex)+1;

            SelectItemOnScroll(e.VerticalOffset);
        }

        private void SelectItemOnScroll(double verticalOffset)
        {

            int currentIndex = (int) ((_recTopEdge + verticalOffset) / _itemHeight);

            if (_selectedItem is not null && _selectedItem.Index != currentIndex)
            {
                _selectedItem.SelecableColor = Brush.Blue;
            }

            SelectableItems[currentIndex].SelecableColor = Brush.Red;

            _selectedItem = SelectableItems[currentIndex];

            //for (int i = 0; i < numberOfVisibleItems; i++)
            //{
            //    double itemTopEdgePosition = _itemHeight * i;
            //    double itemBottomEdgePosition = itemTopEdgePosition + _itemHeight;

            //    double itemSelectionPoint = itemBottomEdgePosition + (_itemHeight / 2);//selection point is item's center point

            //    if (itemSelectionPoint >= _recTopEdge)
            //    {


            //        if (_selectedItem is not null && _selectedItem.Index != currentIndex)
            //        {
            //            _selectedItem.SelecableColor = Brush.Blue;
            //        }


            //        SelectableItems[currentIndex].SelecableColor = Brush.Red;

            //        _selectedItem = SelectableItems[currentIndex];
            //        break;
            //    }

            //    currentIndex++;
            //}
        }

        private void SelectItemOnScroll(int firstVisibleItemIndex, int numberOfVisibleItems)
        {
            int currentIndex = firstVisibleItemIndex;
            for (int i = 0; i < numberOfVisibleItems; i++)
            {
                double itemTopEdgePosition = _itemHeight * i ;
                double itemBottomEdgePosition = itemTopEdgePosition + _itemHeight;

                double itemSelectionPoint = itemBottomEdgePosition + (_itemHeight / 2);//selection point is item's center point

                if (itemSelectionPoint >= _recTopEdge)
                {


                    if (_selectedItem is not null && _selectedItem.Index != currentIndex)
                    {
                        _selectedItem.SelecableColor = Brush.Blue;
                    }


                    SelectableItems[currentIndex].SelecableColor = Brush.Red;

                    _selectedItem = SelectableItems[currentIndex];
                    break;
                }

                currentIndex++;
            }
        }

        private void ContentPage_Loaded(object sender, EventArgs e)
        {
            var h = 300;// mycollectionview.Bounds.Height;

            var h2 = mycollectionview.DesiredSize.Height;
            var h3 = mycollectionview.Frame.Height;
            var center = h / 2;

            _numberOfVisibleItems = 8;// ((IElementController)mycollectionview).LogicalChildren.Count;
            _itemHeight = h / _numberOfVisibleItems;

            rec = new Rectangle();
            rec.HeightRequest = _itemHeight;
            rec.Stroke = Brush.Aqua;
            rec.StrokeThickness = 2;



            _recTopEdge =    center - (_itemHeight / 2);
            _recBottomEdge = _recTopEdge + rec.HeightRequest;

            myGrid.Children.Add(rec);

            SelectItemOnScroll(0);
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            SelectableItems[6].SelecableColor = Brush.DimGray;

            if(SelectableTest.SelecableColor == Brush.Blue)
            {
                SelectableTest.SelecableColor = Brush.Red;
            }
            else
            {
                SelectableTest.SelecableColor = Brush.Blue;
            }
        }

    }
}