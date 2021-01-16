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
            textBoxInfo.Visible = true;
            panelLyrics.Dock = DockStyle.Right;

            panelChart.Width = panelMiddle.Width / 2 - 10;
            panelLyrics.Width = panelMiddle.Width / 2;


            string urlTopArtist = "https://www.billboard.com/charts/artist-100";
            string urlTopSong = "https://www.billboard.com/charts/hot-100";
            string urlTopAlbum = "https://www.billboard.com/charts/billboard-200";

            webBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(webBrowser1_DocumentCompleted);
            webBrowser1.Navigate(urlTopArtist);
            

        }

        public void Internet_ready()
        {
            
            webBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(webBrowser1_DocumentCompleted);

            webBrowser1.Navigate("https://www.google.com/");
            Task.Delay(6000);
            textBoxInfo.Text += webBrowser1.ReadyState.ToString() + "\r\n";

        }
        

        // home button
        private void button1_Click(object sender, EventArgs e)
        {
            //start handling the GUI
            buttonGraph.BackColor = Color.WhiteSmoke;
            buttonWeek.BackColor = Color.WhiteSmoke;
            buttonAlbum.BackColor = Color.WhiteSmoke;
            buttonArtist.BackColor = Color.WhiteSmoke;

            buttonHome.BackColor = Color.FromArgb(90, 97, 85);
            buttonGenius.BackColor = Color.FromArgb(42, 39, 41);
            buttonInfo.BackColor = Color.FromArgb(42, 39, 41);

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


            textBoxInfo.Clear();

            // we gonna display top 100 and 1st song's lyrics in text box
            
        }

        // Crawling Hot 100 songs from Hot 100
        string Top100SongNames = "";
        string Top100SongsAritst = "";
        public void GetTop100()
        {
            string connection;
            SqlConnection cnn;
            connection = "Server = DESKTOP-0GK7VKO; Database = myDataBase; User Id = mydb; Password = 221198;";
                       
            if (webBrowser1.ReadyState == WebBrowserReadyState.Complete)
            {
                textBoxInfo.Clear();

                Top100SongNames = "";
                Top100SongsAritst = "";

                int countSong = 0;
                HtmlElementCollection AllSpansSongs = webBrowser1.Document.GetElementsByTagName("span");
                foreach (HtmlElement el in AllSpansSongs)
                {
                    if (el.GetAttribute("className") == "chart-element__information__song text--truncate color--primary")
                    {
                        Top100SongNames = Top100SongNames + " " + el.InnerText + "\r\n";
                        countSong++;
                    }
                }

                int countArtist = 0;
                HtmlElementCollection AllSpansArtist = webBrowser1.Document.GetElementsByTagName("span");
                foreach (HtmlElement el in AllSpansArtist)
                {
                    if (el.GetAttribute("className") == "chart-element__information__artist text--truncate color--secondary")
                    {
                        Top100SongsAritst = Top100SongsAritst + (countArtist + 1).ToString() +
                            " " + el.InnerText + "\r\n";
                        countArtist++;
                    }
                }

                textBoxInfo.Text = Top100SongNames;
                
            }
           

        }

        // Crawling top Artist in Artist 100 Chart
        string Top100Artist = "";
        public void GetTopArtist(string url)
        {
            string connection;
            SqlConnection cnn;
            connection = "Server = DESKTOP-0GK7VKO; Database = myDataBase; User Id = mydb; Password = 221198;";

            if (webBrowser1.ReadyState == WebBrowserReadyState.Complete)
            {
                textBoxInfo.Clear();

                Top100Artist = "";

                int countTopArtist = 0;
                HtmlElementCollection AllSpansArtists= webBrowser1.Document.GetElementsByTagName("span");
                foreach (HtmlElement el in AllSpansArtists)
                {
                    if (el.GetAttribute("className") == "chart-list-item__title-text")
                    {
                        Top100Artist = Top100Artist + " " + el.InnerText + "\r\n";
                        countTopArtist++;
                    }
                }

            }
            textBoxInfo.Text = Top100Artist;
        }

        // Crawling top 200 Album in Billboard 200
        string TopAlbum = "";
        string TopAlbumArtist = "";
        public void GetTopAlbum()
        {
            string connection;
            SqlConnection cnn;
            connection = "Server = DESKTOP-0GK7VKO; Database = myDataBase; User Id = mydb; Password = 221198;";

            if (webBrowser1.ReadyState == WebBrowserReadyState.Complete)
            {
                textBoxInfo.Clear();
                
                //clear gia tri da luu trong string
                TopAlbum = "";
                TopAlbumArtist = "";
                int countTopAlbum = 0;
                HtmlElementCollection AllSpansAlbums = webBrowser1.Document.GetElementsByTagName("span");
                foreach (HtmlElement el in AllSpansAlbums)
                {
                    if (el.GetAttribute("className") == "chart-element__information__song text--truncate color--primary")
                    {
                        TopAlbum = TopAlbum + (countTopAlbum + 1).ToString() + " " + el.InnerText + "\r\n";
                        countTopAlbum++;
                    }
                }

                int countTopAlbumArtist = 0;
                HtmlElementCollection AllSpansAlbumsArtist = webBrowser1.Document.GetElementsByTagName("span");
                foreach (HtmlElement el in AllSpansAlbumsArtist)
                {
                    if (el.GetAttribute("className") == "chart-element__information__artist text--truncate color--secondary")
                    {
                        TopAlbumArtist = TopAlbumArtist + " " + el.InnerText + "\r\n";
                        countTopAlbumArtist++;
                    }
                }

                textBoxInfo.Text = countTopAlbum.ToString();

            }
        }



        // genius button
        private void button1_Click_1(object sender, EventArgs e)
        {
            buttonGraph.BackColor = Color.WhiteSmoke;
            buttonWeek.BackColor = Color.WhiteSmoke;
            buttonAlbum.BackColor = Color.WhiteSmoke;
            buttonArtist.BackColor = Color.WhiteSmoke;

            buttonHome.BackColor = Color.FromArgb(42, 39, 41);
            buttonGenius.BackColor = Color.FromArgb(90, 97, 85);
            buttonInfo.BackColor = Color.FromArgb(42, 39, 41);

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

            textBoxInfo.Clear();
        }

        // info button
        private void button2_Click(object sender, EventArgs e)
        {
            // start handle the GUI
            dataGridView1.Visible = false;
            textBoxInfo.Visible = true;
            labelHeadingInfo.Visible = false;

            buttonHome.BackColor = Color.FromArgb(42, 39, 41);
            buttonGenius.BackColor = Color.FromArgb(42, 39, 41);
            buttonInfo.BackColor = Color.FromArgb(90, 97, 85);

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
            textBoxInfo.Text = "\r\n\r\n\r\nTop Billboard was created by Vu Thai Son to bring all songs in chart " +
                               "and their lyrics for everyone. \r\n\r\n\r\n" +
                               "Billboard Chart is displayed in Dashboard while Genius's Trending " +
                               "show top 10 trending on genius of all genres.";
            webBrowser1.Visible = false;
        }

        //button week
        private void button4_Click(object sender, EventArgs e)
        {
            buttonGraph.BackColor = Color.WhiteSmoke;
            buttonWeek.BackColor = Color.FromArgb(206,206,206);
            buttonAlbum.BackColor = Color.WhiteSmoke;
            buttonArtist.BackColor = Color.WhiteSmoke;

            //GetTop100();
        }

        //button Artist 100
        private void button5_Click(object sender, EventArgs e)
        {
            buttonGraph.BackColor = Color.WhiteSmoke;
            buttonWeek.BackColor = Color.WhiteSmoke;
            buttonAlbum.BackColor = Color.WhiteSmoke;
            buttonArtist.BackColor = Color.FromArgb(206,206,206);

            //GetTopArtist();
        }

        //button Album
        private void button6_Click(object sender, EventArgs e)
        {
            buttonGraph.BackColor = Color.WhiteSmoke;
            buttonWeek.BackColor = Color.WhiteSmoke;
            buttonAlbum.BackColor = Color.FromArgb(206,206,206);
            buttonArtist.BackColor = Color.WhiteSmoke;

           // GetTopAlbum();
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

        //button Graph
        private void buttonGraph_Click(object sender, EventArgs e)
        {
            buttonGraph.BackColor = Color.FromArgb(206,206,206);
            buttonWeek.BackColor = Color.WhiteSmoke;
            buttonAlbum.BackColor = Color.WhiteSmoke;
            buttonArtist.BackColor = Color.WhiteSmoke;

            //webBrowser1.Visible = true;

            //Internet_ready();

        }

        private void buttonExit_MouseHover(object sender, EventArgs e)
        {
            toolTipExit.Show("Close", buttonExit);
            
        }

        private void buttonResize_MouseHover(object sender, EventArgs e)
        {
            if(max == false)
            {
                toolTipResize.Show("Maximize", buttonResize);
            }
            if (max == true)
            {
                toolTipResize.Show("Restore Down", buttonResize);
            }

        }

        private void buttonMinimize_MouseHover(object sender, EventArgs e)
        {
            toolTipMini.Show("Minimize", buttonMinimize);
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (e.Url != webBrowser1.Url)
                return;



        }

        private void webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            textBoxInfo.Text += webBrowser1.ReadyState.ToString() + "\r\n";
        }

        private void panelColor1_MouseDown(object sender, MouseEventArgs e)
        {
            isMoving = true;
            movX = e.X;
            movY = e.Y;
        }
    }
}
