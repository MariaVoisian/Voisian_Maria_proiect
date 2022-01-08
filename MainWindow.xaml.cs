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
namespace Voisian_Maria_proiect
{

    public partial class MainWindow : Window
    {
        private int mFruitsApple = 0;
        private int mFruitsBanana = 0;
        private int mFruitsStrawberry = 0;
        private int mFruitsRasberry = 0;
        private int mFruitsLemon = 0;
        private int mFruitsGrapes = 0;
        private int mVegetablesPepper = 0;
        private int mVegetablesOnion = 0;
        private int mVegetablesCauliflower = 0;
        private int mVegetablesBroccoli = 0;
        private double Total = 0;
        private AlimenteType selectedAlimente;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AppleMenuItem_Click(object sender, RoutedEventArgs e)
        {
            mFruitsApple++;
            txtAppleFruits.Text = mFruitsApple.ToString();
        }

        private void BananaMenuItem_Click(object sender, RoutedEventArgs e)
        {
            mFruitsBanana++;
            txtBananaFruits.Text = mFruitsBanana.ToString();
        }

        private void GrapesMenuItem_Click(object sender, RoutedEventArgs e)
        {
            mFruitsGrapes++;
            txtGrapesFruits.Text = mFruitsGrapes.ToString();

        }

        private void LemonMenuItem_Click(object sender, RoutedEventArgs e)
        {
            mFruitsLemon++;
            txtLemonFruits.Text = mFruitsLemon.ToString();
        }

        private void StrawberryMenuItem_Click(object sender, RoutedEventArgs e)
        {
            mFruitsStrawberry++;
            txtStrawberryFruits.Text = mFruitsStrawberry.ToString();
        }

        private void RasberryMenuItem_Click(object sender, RoutedEventArgs e)
        {
            mFruitsRasberry++;
            txtRasberryFruits.Text = mFruitsRasberry.ToString();
        }

        private void PepperMenuItem_Click(object sender, RoutedEventArgs e)
        {
            mVegetablesPepper++;
            txtPepperVegetables.Text = mVegetablesPepper.ToString();

        }

        private void OnionMenuItem_Click(object sender, RoutedEventArgs e)
        {
            mVegetablesOnion++;
            txtOnionVegetables.Text = mVegetablesOnion.ToString();
        }

        private void CauliflowerMenuItem_Click(object sender, RoutedEventArgs e)
        {
            mVegetablesCauliflower++;
            txtCauliflowerVegetables.Text = mVegetablesCauliflower.ToString();
        }

        private void BroccoliMenuItem_Click(object sender, RoutedEventArgs e)
        {
            mVegetablesBroccoli++;
            txtBroccoliVegetables.Text = mVegetablesBroccoli.ToString();
        }

        private void ExitMenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        KeyValuePair<AlimenteType, double>[] PriceList = {

        new KeyValuePair<AlimenteType, double>(AlimenteType.Apple, 2) ,
        new KeyValuePair<AlimenteType, double>(AlimenteType.Banana,3) ,
        new KeyValuePair<AlimenteType, double>(AlimenteType.Strawberry,5),
        new KeyValuePair<AlimenteType, double>(AlimenteType.Rasberry,6),
        new KeyValuePair<AlimenteType, double>(AlimenteType.Lemon,3),
        new KeyValuePair<AlimenteType, double>(AlimenteType.Grapes,7),
        new KeyValuePair<AlimenteType, double>(AlimenteType.Pepper,3),
        new KeyValuePair<AlimenteType, double>(AlimenteType.Onion,4),
        new KeyValuePair<AlimenteType, double>(AlimenteType.Cauliflower,5),
        new KeyValuePair<AlimenteType, double>(AlimenteType.Broccoli,9)
        };
        private void frmMain_Loaded(object sender, RoutedEventArgs e)
        {
            cmbType.ItemsSource = PriceList;
            cmbType.DisplayMemberPath = "Key";
            cmbType.SelectedValuePath = "Value";
        }

        private void cmbType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txtprice.Text = cmbType.SelectedValue.ToString();
            KeyValuePair<AlimenteType, double> selectedEntry =
           (KeyValuePair<AlimenteType, double>)cmbType.SelectedItem;
            selectedAlimente = selectedEntry.Key;
        }
        private int ValidateQuantity(AlimenteType selectedaAlimente)
        {
            int q = int.Parse(txtQuantity.Text);
            int r = 1;

            switch (selectedAlimente)
            {
                case AlimenteType.Apple:
                    if (q > mFruitsApple)
                        r = 0;
                    break;
                case AlimenteType.Banana:
                    if (q > mFruitsBanana)
                        r = 0;
                    break;
                case AlimenteType.Strawberry:
                    if (q > mFruitsStrawberry)
                        r = 0;
                    break;
                case AlimenteType.Grapes:
                    if (q > mFruitsGrapes)
                        r = 0;
                    break;
                case AlimenteType.Rasberry:
                    if (q > mFruitsRasberry)
                        r = 0;
                    break;
                case AlimenteType.Lemon:
                    if (q > mFruitsLemon)
                        r = 0;
                    break;

                case AlimenteType.Pepper:
                    if (q > mVegetablesPepper)
                        r = 0;
                    break;
                case AlimenteType.Onion:
                    if (q > mVegetablesOnion)
                        r = 0;
                    break;
                case AlimenteType.Broccoli:
                    if (q > mVegetablesBroccoli)
                        r = 0;
                    break;
                case AlimenteType.Cauliflower:
                    if (q > mVegetablesCauliflower)
                        r = 0;
                    break;
            }
            return r;
        }

        private void txtQuantity_KeyPress(object sender, KeyEventArgs e)
        {
            if (!(e.Key >= Key.D0 && e.Key <= Key.D9))
            {
                MessageBox.Show("Numai cifre se pot introduce!", "Input Error", MessageBoxButton.OK,
               MessageBoxImage.Error);
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateQuantity(selectedAlimente) > 0)
            {
                lstSale.Items.Add(txtQuantity.Text + " " + selectedAlimente.ToString() +
               ":" + txtprice.Text + " " + double.Parse(txtQuantity.Text) *
               double.Parse(txtprice.Text));
                Total = Total + double.Parse(txtQuantity.Text) * double.Parse(txtprice.Text);
                txtTotal.Text = Total.ToString();
            }
            else
            {
                MessageBox.Show("Cantitatea introdusa nu este disponibila in stoc!");
            }
        }

        private void btnRemoveItem_Click(object sender, RoutedEventArgs e)
        {
            lstSale.Items.Remove(lstSale.SelectedItem);
        }

        private void btnCheckOut_Click(object sender, RoutedEventArgs e)
        {
            txtTotal.Text = "0";
            foreach (string s in lstSale.Items)
            {
                switch (s.Substring(s.IndexOf(" ") + 1, s.IndexOf(":") - s.IndexOf(" ") -
               1))
                {
                    case "Apple":
                        mFruitsApple = mFruitsApple - Int32.Parse(s.Substring(0,
                       s.IndexOf(" ")));
                        txtAppleFruits.Text = mFruitsApple.ToString();
                        break;
                    case "Banana":
                        mFruitsBanana = mFruitsBanana - Int32.Parse(s.Substring(0,
                       s.IndexOf(" ")));
                        txtBananaFruits.Text = mFruitsBanana.ToString();
                        break;
                    case "Grapes":
                        mFruitsGrapes = mFruitsGrapes - Int32.Parse(s.Substring(0,
                       s.IndexOf(" ")));
                        txtGrapesFruits.Text = mFruitsGrapes.ToString();
                        break;
                    case "Strawberry":
                        mFruitsStrawberry = mFruitsStrawberry - Int32.Parse(s.Substring(0,
                       s.IndexOf(" ")));
                        txtStrawberryFruits.Text = mFruitsStrawberry.ToString();
                        break;
                    case "Rasberry":
                        mFruitsRasberry = mFruitsRasberry - Int32.Parse(s.Substring(0,
                       s.IndexOf(" ")));
                        txtRasberryFruits.Text = mFruitsRasberry.ToString();
                        break;
                    case "Lemon":
                        mFruitsLemon = mFruitsLemon - Int32.Parse(s.Substring(0,
                       s.IndexOf(" ")));
                        txtLemonFruits.Text = mFruitsLemon.ToString();
                        break;
                    case "Pepper":
                        mVegetablesPepper = mVegetablesPepper - Int32.Parse(s.Substring(0,
                       s.IndexOf(" ")));
                        txtPepperVegetables.Text = mVegetablesPepper.ToString();
                        break;
                    case "Onion":
                        mVegetablesOnion = mVegetablesOnion - Int32.Parse(s.Substring(0,
                       s.IndexOf(" ")));
                        txtOnionVegetables.Text = mVegetablesOnion.ToString();
                        break;
                    case "Broccoli":
                        mVegetablesBroccoli = mVegetablesBroccoli - Int32.Parse(s.Substring(0,
                       s.IndexOf(" ")));
                        txtBroccoliVegetables.Text = mVegetablesBroccoli.ToString();
                        break;
                    case "Cauliflower":
                        mVegetablesCauliflower = mVegetablesCauliflower - Int32.Parse(s.Substring(0,
                       s.IndexOf(" ")));
                        txtCauliflowerVegetables.Text = mVegetablesCauliflower.ToString();
                        break;
                }
            }
            lstSale.Items.Clear();
        }


    }



};




