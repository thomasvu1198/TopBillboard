using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace TopBillboard
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBoxInfo.Visible = false;
            panelLyrics.Dock = DockStyle.Right;

            panelChart.Width = panelMiddle.Width / 2 - 10;
            panelLyrics.Width = panelMiddle.Width / 2;

        }
        

        // home button
        private void button1_Click(object sender, EventArgs e)
        {
            //start handling the GUI
            buttonGraph.BackColor = Color.FromArgb(34, 42, 56);
            buttonWeek.BackColor = Color.FromArgb(34, 42, 56);
            buttonAlbum.BackColor = Color.FromArgb(34, 42, 56);
            buttonArtist.BackColor = Color.FromArgb(34, 42, 56);

            dataGridView1.Visible = true;
            labelHeadingInfo.Visible = true;

            buttonAlbum.Visible = true;
            buttonArtist.Visible = true;
            buttonWeek.Visible = true;
            buttonGraph.Visible = true;

            panelChart.Width = panelMiddle.Width / 2 - 10;
            panelLyrics.Width = panelMiddle.Width / 2; 

            panelSelect.Height = buttonHome.Height;
            panelSelect.Top = buttonHome.Top;

            panelLyrics.Dock = DockStyle.Right;

            //Crawling Hot 100 from Billboard to database
            string connection;
            SqlConnection cnn;
            connection = "Server = DESKTOP-0GK7VKO; Database = myDataBase; User Id = mydb; Password = 221198;";

        }

        // genious button
        private void button1_Click_1(object sender, EventArgs e)
        {
            buttonGraph.BackColor = Color.FromArgb(34, 42, 56);
            buttonWeek.BackColor = Color.FromArgb(34, 42, 56);
            buttonAlbum.BackColor = Color.FromArgb(34, 42, 56);
            buttonArtist.BackColor = Color.FromArgb(34, 42, 56);

            panelLyrics.Dock = DockStyle.Right;

            dataGridView1.Visible = true;
            labelHeadingInfo.Visible = true;

            buttonAlbum.Visible = true;
            buttonArtist.Visible = true;
            buttonWeek.Visible = true;
            buttonGraph.Visible = true;

            panelChart.Width = panelMiddle.Width / 2 - 10;
            panelLyrics.Width = panelMiddle.Width / 2;

            panelSelect.Height = buttonGenius.Height;
            panelSelect.Top = buttonGenius.Top;
        }

        // info button
        private void button2_Click(object sender, EventArgs e)
        {
            // start handle the GUI
            dataGridView1.Visible = false;
            textBoxInfo.Visible = true;
            labelHeadingInfo.Visible = false;

            buttonAlbum.Visible = false;
            buttonArtist.Visible = false;
            buttonWeek.Visible = false;
            buttonGraph.Visible = false;

            //di chuyen thanh vang den button duoc chon
            panelSelect.Height = buttonInfo.Height;
            panelSelect.Top = buttonInfo.Top;

            //dich chuyen panel lyrics's dock -> left
            panelLyrics.Dock = DockStyle.Left;
           
            //panelLyrics.Location = new Point(panelChart.Location.X, panelChart.Location.Y);
            textBoxInfo.Text = "Top Billboard was created by Vu Thai Son to bring all songs in chart and their lyrics for everyone";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            buttonGraph.BackColor = Color.FromArgb(34, 42, 56);
            buttonWeek.BackColor = Color.FromArgb(42, 39, 50);
            buttonAlbum.BackColor = Color.FromArgb(34, 42, 56);
            buttonArtist.BackColor = Color.FromArgb(34, 42, 56);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            buttonGraph.BackColor = Color.FromArgb(34, 42, 56);
            buttonWeek.BackColor = Color.FromArgb(34, 42, 56);
            buttonAlbum.BackColor = Color.FromArgb(34, 42, 56);
            buttonArtist.BackColor = Color.FromArgb(42, 39, 50);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            buttonGraph.BackColor = Color.FromArgb(34, 42, 56);
            buttonWeek.BackColor = Color.FromArgb(34, 42, 56);
            buttonAlbum.BackColor = Color.FromArgb(42, 39, 50);
            buttonArtist.BackColor = Color.FromArgb(34, 42, 56);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBoxInfo_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            panelChart.Width = panelMiddle.Width / 2 - 10;
            panelLyrics.Width = panelMiddle.Width / 2;

        }

        //exit button
        private void buttonExit_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(1);
        }

        // resize button
        bool max = false;
        private void buttonMaximize_Click(object sender, EventArgs e)
        {
            
            if (max ==false)
            {
                WindowState = FormWindowState.Maximized;
                max = true;
            }
           
            else if (max == true)
            {
                WindowState = FormWindowState.Normal;
                max = false;
            }

        }

        //minimize button
        private void buttonMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        int movX, movY;
        bool isMoving;


        //moving form when holding on panelcolor1
        private void panelColor1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMoving)
            {
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);
            }
        }

        private void panelColor1_MouseUp(object sender, MouseEventArgs e)
        {
            isMoving = false;
        }

        private void buttonGraph_Click(object sender, EventArgs e)
        {
            buttonGraph.BackColor = Color.FromArgb(42, 39, 50);
            buttonWeek.BackColor = Color.FromArgb(34, 42, 56);
            buttonAlbum.BackColor = Color.FromArgb(34, 42, 56);
            buttonArtist.BackColor = Color.FromArgb(34, 42, 56);
            
        }

        private void panelColor1_MouseDown(object sender, MouseEventArgs e)
        {
            isMoving = true;
            movX = e.X;
            movY = e.Y;
        }
    }
}
