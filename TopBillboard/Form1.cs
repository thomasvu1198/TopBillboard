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
using HtmlAgilityPack;
using DataHandle;


namespace TopBillboard
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            textBoxInfo.Visible = true;
            panelLyrics.Dock = DockStyle.Right;

            panelChart.Width = panelMiddle.Width / 2 - 10;
            panelLyrics.Width = panelMiddle.Width / 2;


            string urlTopArtist = "https://www.billboard.com/charts/artist-100";
            string urlTopSong = "https://www.billboard.com/charts/hot-100";
            string urlTopAlbum = "https://www.billboard.com/charts/billboard-200";

            webBrowserTopSong.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(webBrowser2_DocumentCompleted);
            webBrowserTopAlbum.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(webBrowser3_DocumentCompleted);

            
            await Task.Run(() => webBrowserTopSong.Navigate(urlTopSong));
            await Task.Run(() => webBrowserTopAlbum.Navigate(urlTopAlbum));
 
        }

        public void Internet_ready()
        {
            
            webBrowserTopArtist.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(webBrowser1_DocumentCompleted);

            webBrowserTopArtist.Navigate("https://www.google.com/");
            Task.Delay(6000);
            textBoxInfo.Text += webBrowserTopArtist.ReadyState.ToString() + "\r\n";

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
            buttonLyrics.BackColor = Color.FromArgb(42, 39, 41);
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

        // find keyword featuring, x,$
        
        // Crawling Hot 100 songs from Hot 100
        string Top100SongNames = "";
        string Top100SongsMainAritst = "";
        string Top100SongsFeaturedAritst = "";
        List<string> Top100SongArtists = new List<string>();
        public void GetTopSong()
        {
            string connection = "Server = DESKTOP-0GK7VKO; Database = TopBillboard; User Id = mydb; Password = 221198;";

            if (webBrowserTopSong.ReadyState == WebBrowserReadyState.Complete)
            {
                textBoxInfo.Clear();

                Top100SongNames = "";

                Top100SongArtists.Clear();
                int countSong = 0;
                HtmlElementCollection AllSpansSongs = webBrowserTopSong.Document.GetElementsByTagName("span");

                using (SqlConnection cnn = new SqlConnection(connection))
                {
                    cnn.Open();
                    string commandDelete = "DELETE FROM Song";

                    string commandresetid = "DBCC CHECKIDENT(Song, RESEED, 0)";

                    SqlCommand resetid = new SqlCommand(commandresetid, cnn); 
                    resetid.ExecuteNonQuery();
                    

                    SqlCommand cmddelete = new SqlCommand(commandDelete, cnn);
                    cmddelete.ExecuteNonQuery();
                    


                    foreach (HtmlElement el in AllSpansSongs)
                    {
                        if (el.GetAttribute("className") == "chart-element__information__song text--truncate color--primary")
                        {
                            Top100SongNames = Top100SongNames + " " + el.InnerText + "\r\n";

                            string commandInsert = "INSERT INTO Song(name,RankInChart) VALUES (@name, @rank) ";

                            SqlCommand cmdinsert = new SqlCommand(commandInsert, cnn);
                            cmdinsert.Parameters.AddWithValue("@name", el.InnerText);
                            cmdinsert.Parameters.AddWithValue("@rank", (countSong + 1));
                                                                                
                            cmdinsert.ExecuteNonQuery();
                           
                            countSong++;
                        }
                    }

                    // Lay ten artist
                    int countArtist = 0;
                    HtmlElementCollection AllSpansArtist = webBrowserTopSong.Document.GetElementsByTagName("span");
                    textBoxInfo.Clear();

                    string commandDeleteArtist = "DELETE FROM Artist";
                    SqlCommand CmdDeleteArtist = new SqlCommand(commandDeleteArtist,cnn);
                    CmdDeleteArtist.ExecuteNonQuery();

                    string commandresetArtistid = "DBCC CHECKIDENT(Artist, RESEED, 0)";
                    SqlCommand CmdresetArtistid = new SqlCommand(commandresetArtistid, cnn);
                    CmdresetArtistid.ExecuteNonQuery();

                    foreach (HtmlElement el in AllSpansArtist)
                    {
                        //int i = 0;
                        Top100SongsMainAritst = "";
                        Top100SongsFeaturedAritst = "";

                        if (el.GetAttribute("className") == "chart-element__information__artist text--truncate color--secondary")
                        {

                            //Top100SongArtists.Add(el.InnerText);
                            string[] NameArtist = el.InnerText.Split(' ');

                            int IndexOfFt = StringHandle.GetKeyWords(NameArtist, "featuring");

                            //int IndexofAnd = StringHandle.GetKeyWords(NameArtist, "&");

                            //int IndexofX = StringHandle.GetKeyWords(NameArtist, "x");
                            
                            //neu co featuring
                            if (IndexOfFt != 0)
                            {
                                // cut string lam 2 voi index of string("featuring") lam moc
                                //doan dau se la main artist
                                // ta luu vao db
                                
                                for (int i = 0; i < IndexOfFt; i++)
                                {
                                    Top100SongsMainAritst += NameArtist[i].ToString() + " ";
                                }
                                try
                                {
                                    string CommandInsertArtist = "INSERT INTO Artist(name) VALUES(@name)";

                                    SqlCommand cmdInsertArtist = new SqlCommand(CommandInsertArtist, cnn);

                                    cmdInsertArtist.Parameters.AddWithValue("@name", Top100SongsMainAritst);
                                                                  
                                    cmdInsertArtist.ExecuteNonQuery();
                                    
                                }
                                catch (SqlException ex)
                                {
                                    Console.Write(ex.Message);

                                }
                                //doan sau se la featured artist
                                for (int i = IndexOfFt + 1; i < NameArtist.Length; i++)
                                {
                                    Top100SongsFeaturedAritst += NameArtist[i].ToString() + " ";
                                }
                                try
                                {
                                    string CommandInsertArtist = "INSERT INTO Artist(name) VALUES(@name)";

                                    SqlCommand cmdInsertArtist = new SqlCommand(CommandInsertArtist, cnn);

                                    cmdInsertArtist.Parameters.AddWithValue("@name", Top100SongsFeaturedAritst);

                                    cmdInsertArtist.ExecuteNonQuery();
                                    
                                }
                                catch (SqlException ex)
                                {
                                    Console.Write(ex.Message);
                                }
                                
                            }

                            //khi khong co
                            else
                            {
                                for (int i = 0; i < NameArtist.Length; i++)
                                {

                                    Top100SongsMainAritst += NameArtist[i].ToString() + " ";
                                }
                            
                                try
                                {
                                    string CommandInsertArtist = "INSERT INTO Artist(name) VALUES(@name)";

                                    SqlCommand cmdInsertArtist = new SqlCommand(CommandInsertArtist, cnn);

                                    cmdInsertArtist.Parameters.AddWithValue("@name", Top100SongsMainAritst);

                                   
                                    cmdInsertArtist.ExecuteNonQuery();
                                  
                                }
                                catch(SqlException ex)
                                {
                                    Console.Write(ex.Message);
                                }
                            }
                            //MessageBox.Show(IndexofAnd.ToString());
                            //Top100SongsMainAritst += NameArtist[i].ToString();
                            //Top100SongsMainAritst += "\r\n";
                            countArtist++;

                        }
                    }
                }
                //textBoxInfo.Text += Top100SongsFeaturedAritst;
                //MessageBox.Show(Top100SongArtists[0]);

            }
            textBoxInfo.Text = Top100SongNames;

        }

        string Top100Artist = "";
        public void GetTopArtist()
        {
            var html = @"https://www.billboard.com/charts/artist-100";
   
            string connection = "Server = DESKTOP-0GK7VKO; Database = TopBillboard; User Id = mydb; Password = 221198;";

            HtmlWeb web = new HtmlWeb();

            var htmlDoc = web.Load(html);
            using (SqlConnection cnn = new SqlConnection(connection))
            {
                cnn.Open();
                var main = htmlDoc.GetElementbyId("main");

                var listNames = main.SelectNodes("//span[contains(@class, 'chart-list-item__title-text')]");
                foreach (var name in listNames)
                {
                    try
                    {
                        string InsertArtist = "INSERT INTO Artist(name) VALUES(@name)";
                        SqlCommand CmdInsArtist = new SqlCommand(InsertArtist, cnn);
                        CmdInsArtist.Parameters.AddWithValue("@name", name.InnerText);
                        textBoxInfo.Text += name.InnerText + "\r\n";
                        CmdInsArtist.ExecuteNonQuery();
                    }
                    catch(SqlException ex)
                    {
                        Console.Write(ex.Message);
                    }
                   
                }

            }
        }


        // Crawling top 200 Album in Billboard 200
        string TopAlbum = "";
        string TopAlbumArtist = "";
        public void GetTopAlbum()
        {
            
            SqlConnection cnn;
            string connection = "Server = DESKTOP-0GK7VKO; Database = myDataBase; User Id = mydb; Password = 221198;";

            if (webBrowserTopAlbum.ReadyState == WebBrowserReadyState.Complete)
            {
                textBoxInfo.Clear();
                
                //clear gia tri da luu trong string
                TopAlbum = "";
                TopAlbumArtist = "";
                int countTopAlbum = 0;
                HtmlElementCollection AllSpansAlbums = webBrowserTopAlbum.Document.GetElementsByTagName("span");
                foreach (HtmlElement el in AllSpansAlbums)
                {
                    if (el.GetAttribute("className") == "chart-element__information__song text--truncate color--primary")
                    {
                        TopAlbum = TopAlbum + (countTopAlbum + 1).ToString() + " " + el.InnerText + "\r\n";
                        countTopAlbum++;
                    }
                }

                int countTopAlbumArtist = 0;
                HtmlElementCollection AllSpansAlbumsArtist = webBrowserTopAlbum.Document.GetElementsByTagName("span");
                foreach (HtmlElement el in AllSpansAlbumsArtist)
                {
                    if (el.GetAttribute("className") == "chart-element__information__artist text--truncate color--secondary")
                    {
                        TopAlbumArtist = TopAlbumArtist + " " + el.InnerText + "\r\n";
                        countTopAlbumArtist++;
                    }
                }

                //textBoxInfo.Text = countTopAlbum.ToString();

            }
        }



        // genius button
        private void button1_Click_1(object sender, EventArgs e)
        {
            //buttonGraph.BackColor = Color.WhiteSmoke;
            //buttonWeek.BackColor = Color.WhiteSmoke;
            //buttonAlbum.BackColor = Color.WhiteSmoke;
            //buttonArtist.BackColor = Color.WhiteSmoke;

            buttonHome.BackColor = Color.FromArgb(42, 39, 41);
            buttonGenius.BackColor = Color.FromArgb(90, 97, 85);
            buttonLyrics.BackColor = Color.FromArgb(42, 39, 41);
            buttonInfo.BackColor = Color.FromArgb(42, 39, 41);

            panelLyrics.Dock = DockStyle.Right;

            dataGridView1.Visible = false;
            textBoxInfo.Visible = true;
            labelHeadingInfo.Visible = false;

            panelButtonTop1.Visible = false;

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
            buttonLyrics.BackColor = Color.FromArgb(42, 39, 41);
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
            webBrowserTopArtist.Visible = false;
        }

        //button week -> get top song in week
        private void button4_Click(object sender, EventArgs e)
        {
            buttonGraph.BackColor = Color.WhiteSmoke;
            buttonWeek.BackColor = Color.FromArgb(206,206,206);
            buttonAlbum.BackColor = Color.WhiteSmoke;
            buttonArtist.BackColor = Color.WhiteSmoke;

            textBoxInfo.Clear();
            //textBoxInfo.Text = Top100SongArtists;
        }

        //button Artist 100
        private void button5_Click(object sender, EventArgs e)
        {
            buttonGraph.BackColor = Color.WhiteSmoke;
            buttonWeek.BackColor = Color.WhiteSmoke;
            buttonAlbum.BackColor = Color.WhiteSmoke;
            buttonArtist.BackColor = Color.FromArgb(206,206,206);

            textBoxInfo.Clear();
            textBoxInfo.Text = Top100Artist;
        }

        //button Album
        private void button6_Click(object sender, EventArgs e)
        {
            buttonGraph.BackColor = Color.WhiteSmoke;
            buttonWeek.BackColor = Color.WhiteSmoke;
            buttonAlbum.BackColor = Color.FromArgb(206,206,206);
            buttonArtist.BackColor = Color.WhiteSmoke;

            textBoxInfo.Clear();
            textBoxInfo.Text = TopAlbumArtist;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
            if (WindowState == FormWindowState.Normal)
            {
                max = false;
            }
            if (WindowState == FormWindowState.Maximized)
            {
                max = true;
            }
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

        // get top artist when web1 load complete
        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (e.Url != webBrowserTopArtist.Url)
                return;
           GetTopArtist();


        }

        private void webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            //textBoxInfo.Text += webBrowserTopArtist.ReadyState.ToString() + "\r\n";
           
        }

        //get top album when web3 load complete
        private void webBrowser3_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (e.Url != webBrowserTopAlbum.Url)
                return;
           // GetTopAlbum();

        }

        //get top song when web2 load complete
        private void webBrowser2_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (e.Url.AbsolutePath != (sender as WebBrowser).Url.AbsolutePath)
            {
               
                return;
            }
            else
            {
               //GetTopSong();
                return;
            }

        }

        //button lyrics
        private void buttonLyrics_Click(object sender, EventArgs e)
        {
            buttonHome.BackColor = Color.FromArgb(42, 39, 41);
            buttonGenius.BackColor = Color.FromArgb(42, 39, 41);
            buttonLyrics.BackColor = Color.FromArgb(90, 97, 85);
            buttonInfo.BackColor = Color.FromArgb(42, 39, 41);

            //di chuyen thanh vang den button duoc chon
            panelSelect.Height = buttonLyrics.Height;
            panelSelect.Top = buttonLyrics.Top;

            
        }

        private void Form1_Activated(object sender, EventArgs e)
        {

            if (this.WindowState == FormWindowState.Minimized)
            {
                if (max == true)
                {
                    WindowState = FormWindowState.Maximized;
                    
                }

                if (max == false)
                {
                    WindowState = FormWindowState.Normal;
                   
                }
            }

        }

        private void panelColor1_MouseDown(object sender, MouseEventArgs e)
        {
            isMoving = true;
            movX = e.X;
            movY = e.Y;
        }
    }
}
