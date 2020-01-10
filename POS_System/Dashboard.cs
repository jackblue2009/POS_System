using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CashierApp
{
    public partial class Dashboard : Form
    {
        private Panel mainPanel = new Panel();

        private Label title = new Label();
        private Label subtitle = new Label();

        private Button cat1Btn = new Button();
        private Button cat2Btn = new Button();
        private Button cat3Btn = new Button();
        private Button cat4Btn = new Button();

        private Label itemsLbl = new Label();

        private Button item1Btn = new Button();
        private Button item2Btn = new Button();
        private Button item3Btn = new Button();
        private Button item4Btn = new Button();
        private Button item5Btn = new Button();

        //private Button qBtn = new Button(); //Reference for quantity button
        TextBox itemNameBox = new TextBox();
        TextBox itemUnitBox = new TextBox();

        private ListView orderList = new ListView();
        private Label invoiceLbl = new Label();
        private Label invoiceNo = new Label();
        private Label totalLbl = new Label();
        private Label totalAmount = new Label();
        private Label totalBdLabel = new Label();

        private Button payCashBtn = new Button();
        private Button payCardBtn = new Button();
        private Button clearCartBtn = new Button();
        private Button removeItemBtn = new Button();

        private double currentPrice;
        private double price1, price2, price3, price4, price5;
        private int phase;

        private List<Tuple<string, double, int>> itemList = new List<Tuple<string, double, int>>();

        public Dashboard()
        {
            ////////////////////////////////////
            InitializeComponent();

            this.title.Name = "Title";
            this.title.Text = "Company Title";
            this.title.Font = new Font("Arial", 26F, FontStyle.Regular);
            this.title.Location = new Point(10, 50);
            this.title.Size = new Size(450, 50);
            this.Controls.Add(title);

            this.subtitle.Name = "Subtitle";
            this.subtitle.Text = "Powered by Abdulrahman Bucheeri";
            this.subtitle.Font = new Font("Arial", 22F, FontStyle.Italic);
            this.subtitle.ForeColor = Color.LightGray;
            this.subtitle.Location = new Point(10, 110);
            this.subtitle.Size = new Size(500, 50);
            this.Controls.Add(subtitle);

            this.mainPanel.BackColor = Color.AntiqueWhite;
            this.mainPanel.Location = new Point(0, 100);
            this.mainPanel.Dock = DockStyle.Bottom;
            this.mainPanel.AutoScroll = true;
            this.mainPanel.AutoScrollMinSize = new Size(600, 600);
            this.mainPanel.Size = new Size(1350, 950);
            this.mainPanel.BorderStyle = BorderStyle.FixedSingle;
            this.mainPanel.Paint += new PaintEventHandler(MainPanel_Paint);
            this.Controls.Add(mainPanel);

            this.itemList.Add(new Tuple<string, double, int>("Chicken Biryani", 1.5, 1));
            this.itemList.Add(new Tuple<string, double, int>("Mutton Biryani", 2.5, 1));
            this.itemList.Add(new Tuple<string, double, int>("Fish Biryani", 2.0, 1));
            this.itemList.Add(new Tuple<string, double, int>("Beef Biryani", 2.8, 1));
            this.itemList.Add(new Tuple<string, double, int>("Chinese Biryani", 1.0, 1));

            this.itemList.Add(new Tuple<string, double, int>("Beef Burger", 1.2, 2));
            this.itemList.Add(new Tuple<string, double, int>("Chicken Burger", 1.2, 2));
            this.itemList.Add(new Tuple<string, double, int>("Twister", 0.6, 2));
            this.itemList.Add(new Tuple<string, double, int>("Chicken Mayonese", 0.8, 2));
            this.itemList.Add(new Tuple<string, double, int>("Tender Roll", 0.5, 2));

            this.itemList.Add(new Tuple<string, double, int>("Chicken Nuggets (9 pcs)", 1.0, 3));
            this.itemList.Add(new Tuple<string, double, int>("Veg Salad", 0.5, 3));
            this.itemList.Add(new Tuple<string, double, int>("Chicken Salad", 0.6, 3));
            this.itemList.Add(new Tuple<string, double, int>("Fish Sticks (5 pcs)", 1.5, 3));
            this.itemList.Add(new Tuple<string, double, int>("Buffalo Wings (4 pcs)", 3.0, 3));

            this.itemList.Add(new Tuple<string, double, int>("Latte (Iced/Hot)", 1.2, 4));
            this.itemList.Add(new Tuple<string, double, int>("Americano (Iced/Hot)", 1.2, 4));
            this.itemList.Add(new Tuple<string, double, int>("Orange Juice Small", 1.7, 4));
            this.itemList.Add(new Tuple<string, double, int>("Orange Juice Large", 1.9, 4));
            this.itemList.Add(new Tuple<string, double, int>("Promotional Drink", 2.2, 4));

            this.cat1Btn.Name = "catOneBtn";
            this.cat1Btn.Text = "Main";
            this.cat1Btn.BackColor = Color.Orange;
            this.cat1Btn.ForeColor = Color.White;
            this.cat1Btn.Font = new Font("Calibri", 24F, FontStyle.Bold);
            this.cat1Btn.FlatStyle = FlatStyle.Flat;
            this.cat1Btn.FlatAppearance.BorderColor = Color.White;
            this.cat1Btn.Location = new Point(1835, 20);
            this.cat1Btn.Size = new Size(200, 200);
            this.cat1Btn.Click += Cat1Btn_OnClick;
            this.mainPanel.Controls.Add(cat1Btn);
            phase = 1;

            this.cat2Btn.Name = "catTwoBtn";
            this.cat2Btn.Text = "Sandwiches";
            this.cat2Btn.BackColor = Color.LightBlue;
            this.cat2Btn.ForeColor = Color.White;
            this.cat2Btn.Font = new Font("Calibri", 24F, FontStyle.Bold);
            this.cat2Btn.FlatStyle = FlatStyle.Flat;
            this.cat2Btn.FlatAppearance.BorderColor = Color.White;
            this.cat2Btn.Location = new Point(1835, 230);
            this.cat2Btn.Size = new Size(200, 200);
            this.cat2Btn.Click += Cat2Btn_OnClick;
            this.mainPanel.Controls.Add(cat2Btn);

            this.cat3Btn.Name = "catThreeBtn";
            this.cat3Btn.Text = "Sides";
            this.cat3Btn.BackColor = Color.Blue;
            this.cat3Btn.ForeColor = Color.White;
            this.cat3Btn.Font = new Font("Calibri", 24F, FontStyle.Bold);
            this.cat3Btn.FlatStyle = FlatStyle.Flat;
            this.cat3Btn.FlatAppearance.BorderColor = Color.White;
            this.cat3Btn.Location = new Point(1835, 440);
            this.cat3Btn.Size = new Size(200, 200);
            this.cat3Btn.Click += Cat3Btn_OnClick;
            this.mainPanel.Controls.Add(cat3Btn);

            this.cat4Btn.Name = "catFourBtn";
            this.cat4Btn.Text = "Drinks && Beverages";
            this.cat4Btn.BackColor = Color.Green;
            this.cat4Btn.ForeColor = Color.White;
            this.cat4Btn.Font = new Font("Calibri", 24F, FontStyle.Bold);
            this.cat4Btn.FlatStyle = FlatStyle.Flat;
            this.cat4Btn.FlatAppearance.BorderColor = Color.White;
            this.cat4Btn.Location = new Point(1835, 650);
            this.cat4Btn.Size = new Size(200, 200);
            this.cat4Btn.Click += Cat4Btn_OnClick;
            this.mainPanel.Controls.Add(cat4Btn);

            this.itemsLbl.Name = "ItemsLabel";
            this.itemsLbl.Text = "Items";
            this.itemsLbl.ForeColor = Color.DarkBlue;
            this.itemsLbl.Font = new Font("Calibri", 22F, FontStyle.Regular);
            this.itemsLbl.Location = new Point(1250, 20);
            this.itemsLbl.Size = new Size(250, 50);
            this.mainPanel.Controls.Add(itemsLbl);

            this.item1Btn.Name = "ItemOneBtn";
            this.item1Btn.Text = itemList[0].Item1;
            this.item1Btn.BackColor = Color.AliceBlue;
            this.item1Btn.ForeColor = Color.Black;
            this.item1Btn.Font = new Font("Calibri", 20F, FontStyle.Regular);
            this.item1Btn.FlatStyle = FlatStyle.Flat;
            this.item1Btn.FlatAppearance.BorderColor = Color.Black;
            this.item1Btn.Location = new Point(710, 80);
            this.item1Btn.Size = new Size(200, 150);
            this.item1Btn.Click += Item1Btn_OnClick;
            this.mainPanel.Controls.Add(item1Btn);
            this.price1 = itemList[0].Item2;

            this.item2Btn.Name = "ItemTwoBtn";
            this.item2Btn.Text = itemList[1].Item1;
            this.item2Btn.BackColor = Color.AliceBlue;
            this.item2Btn.ForeColor = Color.Black;
            this.item2Btn.Font = new Font("Calibri", 20F, FontStyle.Regular);
            this.item2Btn.FlatStyle = FlatStyle.Flat;
            this.item2Btn.FlatAppearance.BorderColor = Color.Black;
            this.item2Btn.Location = new Point(920, 80);
            this.item2Btn.Size = new Size(200, 150);
            this.item2Btn.Click += Item2Btn_OnClick;
            this.mainPanel.Controls.Add(item2Btn);
            this.price2 = itemList[1].Item2;

            this.item3Btn.Name = "ItemThreeBtn";
            this.item3Btn.Text = itemList[2].Item1;
            this.item3Btn.BackColor = Color.AliceBlue;
            this.item3Btn.ForeColor = Color.Black;
            this.item3Btn.Font = new Font("Calibri", 20F, FontStyle.Regular);
            this.item3Btn.FlatStyle = FlatStyle.Flat;
            this.item3Btn.FlatAppearance.BorderColor = Color.Black;
            this.item3Btn.Location = new Point(1130, 80);
            this.item3Btn.Size = new Size(200, 150);
            this.item3Btn.Click += Item3Btn_OnClick;
            this.mainPanel.Controls.Add(item3Btn);
            this.price3 = itemList[2].Item2;

            this.item4Btn.Name = "ItemFourBtn";
            this.item4Btn.Text = itemList[3].Item1;
            this.item4Btn.BackColor = Color.AliceBlue;
            this.item4Btn.ForeColor = Color.Black;
            this.item4Btn.Font = new Font("Calibri", 20F, FontStyle.Regular);
            this.item4Btn.FlatStyle = FlatStyle.Flat;
            this.item4Btn.FlatAppearance.BorderColor = Color.Black;
            this.item4Btn.Location = new Point(1340, 80);
            this.item4Btn.Size = new Size(200, 150);
            this.item4Btn.Click += Item4Btn_OnClick;
            this.mainPanel.Controls.Add(item4Btn);
            this.price4 = itemList[3].Item2;

            this.item5Btn.Name = "ItemfiveBtn";
            this.item5Btn.Text = itemList[4].Item1;
            this.item5Btn.BackColor = Color.AliceBlue;
            this.item5Btn.ForeColor = Color.Black;
            this.item5Btn.Font = new Font("Calibri", 20F, FontStyle.Regular);
            this.item5Btn.FlatStyle = FlatStyle.Flat;
            this.item5Btn.FlatAppearance.BorderColor = Color.Black;
            this.item5Btn.Location = new Point(1550, 80);
            this.item5Btn.Size = new Size(200, 150);
            this.item5Btn.Click += Item5Btn_OnClick;
            this.mainPanel.Controls.Add(item5Btn);
            this.price5 = itemList[4].Item2;

            /////////////////////////////////////////////////////////
            /// THE FOLLOWING IS A QUANTITY BUTTON CODE CURRENTLY UNUSED

            /*this.qBtn.Name = "QuantityBtn";
            this.qBtn.Text = "Quantity";
            this.qBtn.Location = new Point(1550, 650);
            this.qBtn.Size = new Size(200, 200);
            this.qBtn.BackColor = Color.Red;
            this.qBtn.ForeColor = Color.White;
            this.qBtn.Font = new Font("Calibri", 20F, FontStyle.Bold);
            this.qBtn.FlatStyle = FlatStyle.Flat;
            this.qBtn.FlatAppearance.BorderColor = Color.White;
            this.mainPanel.Controls.Add(qBtn);*/

            /////////////////////////////////////////////////////////
            ///
            this.orderList.Location = new Point(50, 82);
            this.orderList.Name = "OrderList";
            this.orderList.Size = new Size(600, 668);
            this.orderList.BackColor = Color.GhostWhite;
            this.orderList.ForeColor = Color.Black;
            this.orderList.Font = new Font("Calibri", 18F, FontStyle.Regular);
            this.orderList.View = View.Details;
            this.orderList.Columns.Add("Units", 100, HorizontalAlignment.Left);
            this.orderList.Columns.Add("Name", 300, HorizontalAlignment.Left);
            this.orderList.Columns.Add("Price", 200, HorizontalAlignment.Left);
            this.mainPanel.Controls.Add(orderList);

            this.invoiceLbl.Name = "InvoiceLbl";
            this.invoiceLbl.Text = "Invoice No:";
            this.invoiceLbl.Location = new Point(50, 25);
            this.invoiceLbl.Size = new Size(125, 50);
            this.invoiceLbl.ForeColor = Color.Black;
            this.invoiceLbl.Font = new Font("Calibri", 18F, FontStyle.Regular);
            this.mainPanel.Controls.Add(invoiceLbl);

            this.invoiceNo.Name = "InvoiceNo";
            this.invoiceNo.Location = new Point(180, 25);
            this.invoiceNo.Size = new Size(150, 50);
            this.invoiceNo.ForeColor = Color.DarkBlue;
            this.invoiceNo.Font = new Font("Calibri", 18F, FontStyle.Bold);
            this.mainPanel.Controls.Add(invoiceNo);


            this.totalLbl.Location = new Point(400, 750);
            this.totalLbl.Name = "TotalLabel";
            this.totalLbl.Text = "Total:";
            this.totalLbl.Size = new Size(77, 50);
            this.totalLbl.ForeColor = Color.Black;
            this.totalLbl.Font = new Font("Calibri", 20F, FontStyle.Bold);
            this.mainPanel.Controls.Add(totalLbl);

            this.totalAmount.Name = "TotalAmount";
            this.totalAmount.Location = new Point(470, 750);
            this.totalAmount.Size = new Size(110, 50);
            this.totalAmount.ForeColor = Color.Black;
            this.totalAmount.Font = new Font("Calibri", 20F, FontStyle.Bold);
            this.mainPanel.Controls.Add(totalAmount);

            this.totalBdLabel.Name = "TotalBd";
            this.totalBdLabel.Text = "B.D.";
            this.totalBdLabel.Location = new Point(580, 750);
            this.totalBdLabel.Size = new Size(75, 50);
            this.totalBdLabel.ForeColor = Color.Black;
            this.totalBdLabel.Font = new Font("Calibri", 20F, FontStyle.Bold);
            this.mainPanel.Controls.Add(totalBdLabel);

            this.payCashBtn.Name = "PayCashBtn";
            this.payCashBtn.Text = "Pay Cash";
            this.payCashBtn.Location = new Point(500, 800);
            this.payCashBtn.Size = new Size(150, 50);
            this.payCashBtn.FlatStyle = FlatStyle.Flat;
            this.payCashBtn.FlatAppearance.BorderColor = Color.White;
            this.payCashBtn.BackColor = Color.YellowGreen;
            this.payCashBtn.ForeColor = Color.White;
            this.payCashBtn.Font = new Font("Calibri", 18F, FontStyle.Bold);
            this.mainPanel.Controls.Add(payCashBtn);

            this.payCardBtn.Name = "PayCardBtn";
            this.payCardBtn.Text = "Pay Debit/Credit Card";
            this.payCardBtn.Location = new Point(240, 800);
            this.payCardBtn.Size = new Size(250, 50);
            this.payCardBtn.FlatStyle = FlatStyle.Flat;
            this.payCardBtn.FlatAppearance.BorderColor = Color.White;
            this.payCardBtn.BackColor = Color.Red;
            this.payCardBtn.ForeColor = Color.White;
            this.payCardBtn.Font = new Font("Calibri", 18F, FontStyle.Bold);
            this.mainPanel.Controls.Add(payCardBtn);

            this.clearCartBtn.Name = "ClearCartBtn";
            this.clearCartBtn.Text = "Clear";
            this.clearCartBtn.Location = new Point(50, 800);
            this.clearCartBtn.Size = new Size(75, 50);
            this.clearCartBtn.BackColor = Color.AliceBlue;
            this.clearCartBtn.Font = new Font("Calibri", 18F, FontStyle.Regular);
            this.clearCartBtn.Click += ClearItemsCart_OnClick;
            this.mainPanel.Controls.Add(clearCartBtn);

            this.removeItemBtn.Name = "RemoveItemBtn";
            this.removeItemBtn.Text = "Remove";
            this.removeItemBtn.Location = new Point(130, 800);
            this.removeItemBtn.Size = new Size(105, 50);
            this.removeItemBtn.BackColor = Color.AliceBlue;
            this.removeItemBtn.Font = new Font("Calibri", 18F, FontStyle.Regular);
            this.removeItemBtn.Click += RemoveitemCart_OnClick;
            this.mainPanel.Controls.Add(removeItemBtn);
        }

        private void ClearItemsCart_OnClick(object sender, EventArgs e)
        {
            if (this.orderList.Items.Count > 0)
            {
                this.orderList.Items.Clear();
                this.totalAmount.Text = "";
                if (this.invoiceNo.Text != null)
                {
                    this.invoiceNo.Text = null;
                }
            }
        }

        private void RemoveitemCart_OnClick(object sender, EventArgs e)
        {
            try
            {
                double total = Double.Parse(this.totalAmount.Text);
                if (this.orderList.Items.Count > 0)
                {
                    foreach (ListViewItem eachItem in this.orderList.SelectedItems)
                    {
                        double sub = Int32.Parse(eachItem.SubItems[0].Text) * Double.Parse(eachItem.SubItems[2].Text);
                        //MessageBox.Show(sub.ToString());
                        total = total - sub;
                        this.orderList.Items.Remove(eachItem);
                        totalAmount.Text = total.ToString();
                    }
                    if (this.orderList.Items.Count < 1)
                    {
                        if (this.invoiceNo.Text != null)
                        this.invoiceNo.Text = null;
                    }
                }
            }
            catch (Exception err)
            {
                //
            }
        }

        private string GenerateInvoiceNumber()
        {
            Random rand = new Random();
            string r = "";
            int i;
            for (i = 1; i < 10; i++)
            {
                r += rand.Next(0, 9).ToString();
            }
            return r;
        }

        private void AddItemToCart(int unit, string name, double price)
        {
            string[] row = { name, price.ToString() };
            currentPrice = currentPrice + (unit * price);
            double newPrice = currentPrice;
            //MessageBox.Show(newPrice.ToString());
            this.orderList.Items.Add(unit.ToString()).SubItems.AddRange(row);
            totalAmount.Text = newPrice.ToString();
            if (this.orderList.Items.Count <= 1)
            {
                this.invoiceNo.Text = GenerateInvoiceNumber();
            }
        }

        private void Item1Btn_OnClick(object sender, EventArgs e)
        {
            ConfirmItemDialog(item1Btn.Text, price1);
        }

        private void Item2Btn_OnClick(object sender, EventArgs e)
        {
            ConfirmItemDialog(item2Btn.Text, price2);
        }

        private void Item3Btn_OnClick(object sender, EventArgs e)
        {
            ConfirmItemDialog(item3Btn.Text, price3);
        }

        private void Item4Btn_OnClick(object sender, EventArgs e)
        {
            ConfirmItemDialog(item4Btn.Text, price4);
        }

        private void Item5Btn_OnClick(object sender, EventArgs e)
        {
            ConfirmItemDialog(item5Btn.Text, price5);
        }

        private void Cat1Btn_OnClick(object sender, EventArgs e)
        {
            phase = 1;
            this.item1Btn.Text = itemList[0].Item1;
            this.price1 = itemList[0].Item2;
            this.item2Btn.Text = itemList[1].Item1;
            this.price2 = itemList[1].Item2;
            this.item3Btn.Text = itemList[2].Item1;
            this.price3 = itemList[2].Item2;
            this.item4Btn.Text = itemList[3].Item1;
            this.price4 = itemList[3].Item2;
            this.item5Btn.Text = itemList[4].Item1;
            this.price5 = itemList[4].Item2;
        }

        private void Cat2Btn_OnClick(object sender, EventArgs e)
        {
            phase = 2;
            this.item1Btn.Text = itemList[5].Item1;
            this.price1 = itemList[5].Item2;
            this.item2Btn.Text = itemList[6].Item1;
            this.price2 = itemList[6].Item2;
            this.item3Btn.Text = itemList[7].Item1;
            this.price3 = itemList[7].Item2;
            this.item4Btn.Text = itemList[8].Item1;
            this.price4 = itemList[8].Item2;
            this.item5Btn.Text = itemList[9].Item1;
            this.price5 = itemList[9].Item2;
        }

        private void Cat3Btn_OnClick(object sender, EventArgs e)
        {
            phase = 3;
            this.item1Btn.Text = itemList[10].Item1;
            this.price1 = itemList[10].Item2;
            this.item2Btn.Text = itemList[11].Item1;
            this.price2 = itemList[11].Item2;
            this.item3Btn.Text = itemList[12].Item1;
            this.price3 = itemList[12].Item2;
            this.item4Btn.Text = itemList[13].Item1;
            this.price4 = itemList[13].Item2;
            this.item5Btn.Text = itemList[14].Item1;
            this.price5 = itemList[14].Item2;
        }

        private void Cat4Btn_OnClick(object sender, EventArgs e)
        {
            phase = 4;
            this.item1Btn.Text = itemList[15].Item1;
            this.price1 = itemList[15].Item2;
            this.item2Btn.Text = itemList[16].Item1;
            this.price2 = itemList[16].Item2;
            this.item3Btn.Text = itemList[17].Item1;
            this.price3 = itemList[17].Item2;
            this.item4Btn.Text = itemList[18].Item1;
            this.price4 = itemList[18].Item2;
            this.item5Btn.Text = itemList[19].Item1;
            this.price5 = itemList[19].Item2;
        }

        private void MainPanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g;

            g = e.Graphics;

            Pen myPen = new Pen(Color.Black, 2F);
            g.DrawLine(myPen, 1820, 20, 1820, 850);
            g.DrawLine(myPen, 700, 20, 700, 850);
            g.Dispose();
        }

        public void ConfirmItemDialog(string itemName, double itemPrice)
        {
            try
            {
                Form dialForm = new Form();
                dialForm.StartPosition = FormStartPosition.CenterScreen;
                dialForm.Size = new Size(500, 250);

                itemNameBox.Name = "ItemNameBox";
                itemNameBox.Text = itemName;
                itemNameBox.Enabled = false;
                itemNameBox.Location = new Point(20, 50);
                itemNameBox.Size = new Size(200, 50);
                itemNameBox.Font = new Font("Calibri", 18F, FontStyle.Regular);
                dialForm.Controls.Add(itemNameBox);

                itemUnitBox.Name = "ItemUnitBox";
                itemUnitBox.Location = new Point(230, 50);
                itemUnitBox.Size = new Size(150, 50);
                itemUnitBox.Font = new Font("Calibri", 18F, FontStyle.Regular);
                dialForm.Controls.Add(itemUnitBox);

                Button addItemBtn = new Button();
                addItemBtn.Name = "AddItemBtn";
                addItemBtn.Text = "Add";
                addItemBtn.Location = new Point(150, 155);
                addItemBtn.Size = new Size(150, 50);
                addItemBtn.BackColor = Color.AliceBlue;
                addItemBtn.ForeColor = Color.Black;
                addItemBtn.Font = new Font("Calibri", 18F, FontStyle.Regular);
                addItemBtn.Click += delegate {
                    AddItemToCart(Int32.Parse(itemUnitBox.Text), itemName, itemPrice);
                    //MessageBox.Show(itemUnitBox.Text);
                    itemUnitBox.Text = "";
                    dialForm.Close();
                };
                dialForm.Controls.Add(addItemBtn);

                if (dialForm.ShowDialog(this) == DialogResult.OK)
                {
                }
            }
            catch (FormatException e)
            {
                MessageBox.Show("Invalid input. Please enter a correct number");
            }
        }
    }
}
