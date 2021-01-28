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
using SQLHandle;

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
            //webBrowserTopAlbum.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(webBrowser3_DocumentCompleted);

            
            await Task.Run(() => webBrowserTopSong.Navigate(urlTopSong));
            //await Task.Run(() => webBrowserTopAlbum.Navigate(urlTopAlbum));
 
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

            buttonPrint.Visible = false;
            //buttonPreview.Visible = false;
            textBoxInfo.Clear();

            // we gonna display top 100 and 1st song's lyrics in text box
            
        }
        public void GetAll()
        {
            Sqlhandle.ClearData();
            string Top100SongNames = "";
            string Top100SongsMainAritst = "";
            string Top100SongsFeaturedAritst = "";
            List<string> Top100SongArtists = new List<string>();
            string connection = "Server = DESKTOP-0GK7VKO; Database = TopBillboard; User Id = mydb; Password = 221198;";

            //textBoxInfo.Clear();

            Top100SongNames = "";

            Top100SongArtists.Clear();
            int countSong = 0;
            HtmlElementCollection AllSpansSongs = webBrowserTopSong.Document.GetElementsByTagName("span");

            using (SqlConnection cnn = new SqlConnection(connection))
            {
                cnn.Open();

                foreach (HtmlElement el in AllSpansSongs)
                {
                    if (el.GetAttribute("className") == "chart-element__information__song text--truncate color--primary")
                    {
                        Top100SongNames = Top100SongNames + " " + el.InnerText + "\r\n";

                        string commandInsert = "INSERT INTO Song(name,RankInChart) VALUES (@name, @rank) ";

                        SqlCommand cmdinsert = new SqlCommand(commandInsert, cnn);
                        cmdinsert.Parameters.AddWithValue("@name", StringHandle.RemoveFirstWhiteSpace(el.InnerText));
                        cmdinsert.Parameters.AddWithValue("@rank", (countSong + 1));

                        cmdinsert.ExecuteNonQuery();

                        countSong++;
                    }
                }

                // Lay ten artist
                int countArtist = 0;
                HtmlElementCollection AllSpansArtist = webBrowserTopSong.Document.GetElementsByTagName("span");
                int rank = 1;
                foreach (HtmlElement el in AllSpansArtist)
                {
                    
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

                                cmdInsertArtist.Parameters.AddWithValue("@name", StringHandle.RemoveFirstWhiteSpace(Top100SongsMainAritst));

                                cmdInsertArtist.ExecuteNonQuery();

                            }
                            catch (SqlException ex)
                            {
                                Console.Write(ex.Message);

                            }
                            //luu vao bang main artist
                            string FindMainSongID = "SELECT id from Song WHERE RankInChart = @val";

                            using (SqlCommand CmdFindSongID = new SqlCommand(FindMainSongID, cnn))
                            {
                                CmdFindSongID.Parameters.AddWithValue("@val", rank);
                                Int32 ID = (Int32)CmdFindSongID.ExecuteScalar();

                                string AddID = "INSERT INTO MainArtistInSong(SongID) VALUES(@val)";
                                using (SqlCommand CmdAddSongID = new SqlCommand(AddID, cnn))
                                {
                                    CmdAddSongID.Parameters.AddWithValue("@val", ID);
                                    CmdAddSongID.ExecuteNonQuery();

                                    string FindMainArtID = "SELECT id from Artist WHERE name = @val";
                                    
                                    using (SqlCommand CmdFindArtID = new SqlCommand(FindMainArtID, cnn))
                                    {
                                        CmdFindArtID.Parameters.AddWithValue("@val", StringHandle.RemoveFirstWhiteSpace(Top100SongsMainAritst));
                                        Int32 ArtID = (Int32)CmdFindArtID.ExecuteScalar();
                                        string AddArtID = "UPDATE MainArtistInSong SET main_artistID = @val WHERE SongID = @val1";
                                        SqlCommand CmdAddArtID = new SqlCommand(AddArtID, cnn);
                                        CmdAddArtID.Parameters.AddWithValue("@val", ArtID);
                                        CmdAddArtID.Parameters.AddWithValue("@val1", ID);
                                        CmdAddArtID.ExecuteNonQuery();
                                    }
                                }
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

                                cmdInsertArtist.Parameters.AddWithValue("@name", StringHandle.RemoveFirstWhiteSpace(Top100SongsFeaturedAritst));

                                cmdInsertArtist.ExecuteNonQuery();

                            }
                            catch (SqlException ex)
                            {
                                Console.Write(ex.Message);
                            }

                            string FindFTSongID = "SELECT id from Song WHERE RankInChart = @val";

                            using (SqlCommand CmdFindSongID = new SqlCommand(FindFTSongID, cnn))
                            {
                                CmdFindSongID.Parameters.AddWithValue("@val", rank);
                                Int32 ID = (Int32)CmdFindSongID.ExecuteScalar();

                                string AddID = "INSERT INTO FeaturedArtistInSong(SongID) VALUES(@val)";
                                using (SqlCommand CmdAddSongID = new SqlCommand(AddID, cnn))
                                {
                                    CmdAddSongID.Parameters.AddWithValue("@val", ID);
                                    CmdAddSongID.ExecuteNonQuery();

                                    string FindFTArtID = "SELECT id from Artist WHERE name = @val";

                                    using (SqlCommand CmdFindArtID = new SqlCommand(FindFTArtID, cnn))
                                    {
                                        CmdFindArtID.Parameters.AddWithValue("@val", StringHandle.RemoveFirstWhiteSpace(Top100SongsFeaturedAritst));
                                        Int32 ArtID = (Int32)CmdFindArtID.ExecuteScalar();
                                        string AddArtID = "UPDATE FeaturedArtistInSong SET featured_artistID = @val WHERE SongID = @val1";
                                        SqlCommand CmdAddArtID = new SqlCommand(AddArtID, cnn);
                                        CmdAddArtID.Parameters.AddWithValue("@val", ArtID);
                                        CmdAddArtID.Parameters.AddWithValue("@val1", ID);
                                        CmdAddArtID.ExecuteNonQuery();
                                    }
                                }
                            }

                        }

                        //khi khong co
                        else
                        {
                            try
                            {
                                string CommandInsertArtist = "INSERT INTO Artist(name) VALUES(@name)";

                                SqlCommand cmdInsertArtist = new SqlCommand(CommandInsertArtist, cnn);

                                cmdInsertArtist.Parameters.AddWithValue("@name", StringHandle.RemoveFirstWhiteSpace(el.InnerText));
                                cmdInsertArtist.ExecuteNonQuery();

                            }
                            catch (SqlException ex)
                            {
                                Console.Write(ex.Message);
                            }
                            string FindMainSongID = "SELECT id from Song WHERE RankInChart = @val";

                            using (SqlCommand CmdFindSongID = new SqlCommand(FindMainSongID, cnn))
                            {
                                CmdFindSongID.Parameters.AddWithValue("@val", rank);
                                Int32 ID = (Int32)CmdFindSongID.ExecuteScalar();

                                string AddID = "INSERT INTO MainArtistInSong(SongID) VALUES(@val)";
                                using (SqlCommand CmdAddSongID = new SqlCommand(AddID, cnn))
                                {
                                    CmdAddSongID.Parameters.AddWithValue("@val", ID);
                                    CmdAddSongID.ExecuteNonQuery();

                                    string FindMainArtID = "SELECT id from Artist WHERE name = @val";

                                    using (SqlCommand CmdFindArtID = new SqlCommand(FindMainArtID, cnn))
                                    {
                                        CmdFindArtID.Parameters.AddWithValue("@val", StringHandle.RemoveFirstWhiteSpace(el.InnerText));
                                        Int32 ArtID = (Int32)CmdFindArtID.ExecuteScalar();
                                        string AddArtID = "UPDATE MainArtistInSong SET main_artistID = @val WHERE SongID = @val1";
                                        SqlCommand CmdAddArtID = new SqlCommand(AddArtID, cnn);
                                        CmdAddArtID.Parameters.AddWithValue("@val", ArtID);
                                        CmdAddArtID.Parameters.AddWithValue("@val1", ID);
                                        CmdAddArtID.ExecuteNonQuery();
                                    }
                                }
                            }
                        }

                        rank++;
                        countArtist++;

                    }
                }
            }

            Sqlhandle.GetTopArtist();

            Sqlhandle.GetTopAlbum();


        }
        // find keyword featuring, x,$

        // Crawling Hot 100 songs from Hot 100
        //string Top100SongNames = "";
        //string Top100SongsMainAritst = "";
        //string Top100SongsFeaturedAritst = "";
        //List<string> Top100SongArtists = new List<string>();
        //public void GetAll()
        //{
        //    Sqlhandle.ClearData();
        //    string connection = "Server = DESKTOP-0GK7VKO; Database = TopBillboard; User Id = mydb; Password = 221198;";
        //    if (webBrowserTopSong.ReadyState == WebBrowserReadyState.Complete)
        //    {
        //        //textBoxInfo.Clear();

        //        Top100SongNames = "";

        //        Top100SongArtists.Clear();
        //        int countSong = 0;
        //        HtmlElementCollection AllSpansSongs = webBrowserTopSong.Document.GetElementsByTagName("span");

        //        using (SqlConnection cnn = new SqlConnection(connection))
        //        {
        //            cnn.Open();

        //            foreach (HtmlElement el in AllSpansSongs)
        //            {
        //                if (el.GetAttribute("className") == "chart-element__information__song text--truncate color--primary")
        //                {
        //                    Top100SongNames = Top100SongNames + " " + el.InnerText + "\r\n";

        //                    string commandInsert = "INSERT INTO Song(name,RankInChart) VALUES (@name, @rank) ";

        //                    SqlCommand cmdinsert = new SqlCommand(commandInsert, cnn);
        //                    cmdinsert.Parameters.AddWithValue("@name", StringHandle.RemoveFirstWhiteSpace(el.InnerText));
        //                    cmdinsert.Parameters.AddWithValue("@rank", (countSong + 1));

        //                    cmdinsert.ExecuteNonQuery();

        //                    countSong++;
        //                }
        //            }

        //            // Lay ten artist
        //            int countArtist = 0;
        //            HtmlElementCollection AllSpansArtist = webBrowserTopSong.Document.GetElementsByTagName("span");
        //            //textBoxInfo.Clear();

        //            //string commandDeleteArtist = "DELETE FROM Artist";
        //            //SqlCommand CmdDeleteArtist = new SqlCommand(commandDeleteArtist,cnn);
        //            //CmdDeleteArtist.ExecuteNonQuery();

        //            //string commandresetArtistid = "DBCC CHECKIDENT(Artist, RESEED, 0)";
        //            //SqlCommand CmdresetArtistid = new SqlCommand(commandresetArtistid, cnn);
        //            //CmdresetArtistid.ExecuteNonQuery();

        //            foreach (HtmlElement el in AllSpansArtist)
        //            {
        //                //int i = 0;
        //                Top100SongsMainAritst = "";
        //                Top100SongsFeaturedAritst = "";

        //                if (el.GetAttribute("className") == "chart-element__information__artist text--truncate color--secondary")
        //                {

        //                    //Top100SongArtists.Add(el.InnerText);
        //                    string[] NameArtist = el.InnerText.Split(' ');

        //                    int IndexOfFt = StringHandle.GetKeyWords(NameArtist, "featuring");

        //                    //int IndexofAnd = StringHandle.GetKeyWords(NameArtist, "&");

        //                    //int IndexofX = StringHandle.GetKeyWords(NameArtist, "x");

        //                    //neu co featuring
        //                    if (IndexOfFt != 0)
        //                    {
        //                        // cut string lam 2 voi index of string("featuring") lam moc
        //                        //doan dau se la main artist
        //                        // ta luu vao db

        //                        for (int i = 0; i < IndexOfFt; i++)
        //                        {
        //                            Top100SongsMainAritst += NameArtist[i].ToString() + " ";
        //                        }
        //                        try
        //                        {
        //                            string CommandInsertArtist = "INSERT INTO Artist(name) VALUES(@name)";

        //                            SqlCommand cmdInsertArtist = new SqlCommand(CommandInsertArtist, cnn);

        //                            cmdInsertArtist.Parameters.AddWithValue("@name", StringHandle.RemoveFirstWhiteSpace(Top100SongsMainAritst));

        //                            cmdInsertArtist.ExecuteNonQuery();

        //                        }
        //                        catch (SqlException ex)
        //                        {
        //                            Console.Write(ex.Message);

        //                        }
        //                        //doan sau se la featured artist
        //                        for (int i = IndexOfFt + 1; i < NameArtist.Length; i++)
        //                        {
        //                            Top100SongsFeaturedAritst += NameArtist[i].ToString() + " ";
        //                        }
        //                        try
        //                        {
        //                            string CommandInsertArtist = "INSERT INTO Artist(name) VALUES(@name)";

        //                            SqlCommand cmdInsertArtist = new SqlCommand(CommandInsertArtist, cnn);

        //                            cmdInsertArtist.Parameters.AddWithValue("@name", StringHandle.RemoveFirstWhiteSpace(Top100SongsFeaturedAritst));

        //                            cmdInsertArtist.ExecuteNonQuery();

        //                        }
        //                        catch (SqlException ex)
        //                        {
        //                            Console.Write(ex.Message);
        //                        }

        //                    }

        //                    //khi khong co
        //                    else
        //                    {
        //                        try
        //                        {
        //                            string CommandInsertArtist = "INSERT INTO Artist(name) VALUES(@name)";

        //                            SqlCommand cmdInsertArtist = new SqlCommand(CommandInsertArtist, cnn);

        //                            cmdInsertArtist.Parameters.AddWithValue("@name", StringHandle.RemoveFirstWhiteSpace(el.InnerText));
        //                            cmdInsertArtist.ExecuteNonQuery();

        //                        }
        //                        catch(SqlException ex)
        //                        {
        //                            Console.Write(ex.Message);
        //                        }
        //                    }
        //                    //MessageBox.Show(IndexofAnd.ToString());
        //                    //Top100SongsMainAritst += NameArtist[i].ToString();
        //                    //Top100SongsMainAritst += "\r\n";
        //                    countArtist++;

        //                }
        //            }
        //        }
        //        //textBoxInfo.Text += Top100SongsFeaturedAritst;
        //        //MessageBox.Show(Top100SongArtists[0]);
        //        GetTopArtist();
        //        GetTopAlbum();
        //    }


        //}

        //string Top100Artist = "";
        //public void GetTopArtist()
        //{
        //    var html = @"https://www.billboard.com/charts/artist-100";

        //    string connection = "Server = DESKTOP-0GK7VKO; Database = TopBillboard; User Id = mydb; Password = 221198;";

        //    HtmlWeb web = new HtmlWeb();

        //    var htmlDoc = web.Load(html);
        //    using (SqlConnection cnn = new SqlConnection(connection))
        //    {
        //        cnn.Open();
        //        int rank = 1;

        //        var main = htmlDoc.GetElementbyId("main");



        //        var listNames = main.SelectNodes("//span[contains(@class, 'chart-list-item__title-text')]");
        //        foreach (var name in listNames)
        //        {
        //            try
        //            {
        //                string InsertArtist = "INSERT INTO Artist(name) VALUES(@name)";
        //                SqlCommand CmdInsArtist = new SqlCommand(InsertArtist, cnn);
        //                CmdInsArtist.Parameters.AddWithValue("@name", StringHandle.RemoveFirstWhiteSpace(name.InnerText));
        //                //textBoxInfo.Text += name.InnerText + "\r\n";
        //                CmdInsArtist.ExecuteNonQuery();


        //            }
        //            catch(SqlException ex)
        //            {
        //                Console.Write(ex.Message);
        //            }
        //            //string Update = "UPDATE TopArtist SET artistID = @id, RankInChart = @val WHERE ";

        //        }
        //        foreach (var name in listNames)
        //        {

        //            string findArtist = "SELECT id from Artist WHERE name = @value";
        //            using (SqlCommand CmdFind = new SqlCommand(findArtist, cnn))
        //            {
        //                CmdFind.Parameters.AddWithValue("@value", StringHandle.RemoveFirstWhiteSpace(name.InnerText));
        //                Int32 ID = (Int32)CmdFind.ExecuteScalar();


        //                string InsertRank = "INSERT INTO TopArtist(RankInChart, artistID) VALUES(@rank, @id)";
        //                SqlCommand CmdInsRank = new SqlCommand(InsertRank, cnn);
        //                CmdInsRank.Parameters.AddWithValue("@rank", rank);
        //                CmdInsRank.Parameters.AddWithValue("@id", ID);
        //                CmdInsRank.ExecuteNonQuery();

        //                textBoxInfo.Text += rank.ToString() + name.InnerText + ": " + ID.ToString() + "." + "\r\n";

        //                rank++;
        //            }
        //        }

        //    }
        //    //lay ten artist cua top 200 album 
        //    using (SqlConnection cnn = new SqlConnection(connection))
        //    {
        //        cnn.Open();

        //        //textBoxInfo.Clear();

        //        var html1 = @"https://www.billboard.com/charts/billboard-200";

        //        HtmlWeb web1 = new HtmlWeb();

        //        var htmlDoc1 = web1.Load(html1);

        //        var main1 = htmlDoc1.GetElementbyId("main");

        //        var listNames2 = main1.SelectNodes("//span[contains(@class, 'chart-element__information__artist text--truncate color--secondary')]");
        //        foreach (var name in listNames2)
        //        {
        //            try
        //            {
        //                string InsertArtist = "INSERT INTO Artist(name) VALUES(@name)";


        //                SqlCommand CmdInsArtist = new SqlCommand(InsertArtist, cnn);
        //                CmdInsArtist.Parameters.AddWithValue("@name", StringHandle.RemoveFirstWhiteSpace(name.InnerText));
        //                textBoxInfo.Text += name.InnerText + "\r\n";
        //                CmdInsArtist.ExecuteNonQuery();

        //            }
        //            catch (SqlException ex)
        //            {
        //                Console.Write(ex.Message);
        //            }
        //        }

        //    }
        //}


        //// Crawling top 200 Album in Billboard 200
        //string TopAlbum = "";
        //string TopAlbumArtist = "";
        //public void GetTopAlbum()
        //{

        //    string connection = "Server = DESKTOP-0GK7VKO; Database = TopBillboard; User Id = mydb; Password = 221198;";
        //    var html = @"https://www.billboard.com/charts/billboard-200";

        //    HtmlWeb web = new HtmlWeb();

        //    var htmlDoc = web.Load(html);

        //    var main = htmlDoc.GetElementbyId("main");

        //    using (SqlConnection cnn = new SqlConnection(connection))
        //    {
        //        cnn.Open();
        //        //clear gia tri da luu trong string va db
        //        TopAlbum = "";
        //        TopAlbumArtist = "";
        //        int countTopAlbum = 0;



        //        //lay ten album
        //        var listNames1 = main.SelectNodes("//span[contains(@class, 'chart-element__information__song text--truncate color--primary')]");
        //        foreach (var name in listNames1)
        //        {

        //            string insertalbumName = "INSERT INTO Album(name, Album_rank) VALUES(@name, @rank)";

        //            using (SqlCommand CmdAlbumInsert = new SqlCommand(insertalbumName, cnn))
        //            {
        //                CmdAlbumInsert.Parameters.AddWithValue("@name", StringHandle.RemoveFirstWhiteSpace(name.InnerText));
        //                CmdAlbumInsert.Parameters.AddWithValue("@rank", countTopAlbum + 1);

        //                CmdAlbumInsert.ExecuteNonQuery();

        //                TopAlbum = TopAlbum + (countTopAlbum + 1).ToString() + " " + name.InnerText + "\r\n";
        //                countTopAlbum++;
        //            }

        //        }
        //        //cnn.Close();
        //    }

        //    using (SqlConnection cnn = new SqlConnection(connection))
        //    {
        //        //dien vao table Album
        //        cnn.Open();
        //        int countrank = 1;
        //        var listNames2 = main.SelectNodes("//span[contains(@class, 'chart-element__information__artist text--truncate color--secondary')]");
        //        foreach (var name in listNames2)
        //        {
        //            string findArtist = "SELECT id from Artist WHERE name = @value";
        //            using (SqlCommand CmdFind = new SqlCommand(findArtist, cnn))
        //            {
        //                CmdFind.Parameters.AddWithValue("@value", StringHandle.RemoveFirstWhiteSpace(name.InnerText));
        //                Int32 IDArtists = (Int32)CmdFind.ExecuteScalar();


        //                //textBoxInfo.Text += countrank.ToString() + name.InnerText + ": " + IDArtists.ToString() + "\r\n";
        //                string insert = "UPDATE Album SET artistID = @value WHERE id = @id";
        //                SqlCommand CmdInsert = new SqlCommand(insert, cnn);

        //                CmdInsert.Parameters.AddWithValue("@value", IDArtists);
        //                CmdInsert.Parameters.AddWithValue("@id", countrank);

        //                CmdInsert.ExecuteNonQuery();
        //                countrank++;  

        //            }

        //        }
        //        //
        //    }
        //}



        // genius button
        private void button1_Click_1(object sender, EventArgs e)
        {
            //buttonGraph.BackColor = Color.WhiteSmoke;
            //buttonWeek.BackColor = Color.WhiteSmoke;
            //buttonAlbum.BackColor = Color.WhiteSmoke;
            //buttonArtist.BackColor = Color.WhiteSmoke;

            buttonPrint.Visible = false;
            //buttonPreview.Visible = false;

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
            string cl ="PageGridFull-idpot7-0 jeWXO";
            var html1 = @"https://genius.com/#top-songs";

            HtmlWeb web1 = new HtmlWeb();

            var htmlDoc1 = web1.Load(html1);

            var main1 = htmlDoc1.GetElementbyId("application");
            var listNames2 = main1.SelectNodes("//div[contains(@class, 'PageGridFull-idpot7-0 jeWXO')]");
            foreach (var name in listNames2)
            {
                textBoxInfo.Text += name.InnerText + "\r\n";
            }
        }

        // info button
        private void button2_Click(object sender, EventArgs e)
        {
            // start handle the GUI

            buttonPrint.Visible = false;
            //buttonPreview.Visible = false;

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
           
        }

        //button week -> get top song in week
        private void button4_Click(object sender, EventArgs e)
        {
            buttonGraph.BackColor = Color.WhiteSmoke;
            buttonWeek.BackColor = Color.FromArgb(206, 206, 206);
            buttonAlbum.BackColor = Color.WhiteSmoke;
            buttonArtist.BackColor = Color.WhiteSmoke;
            dataGridView1.Visible = true;

            textBoxInfo.Clear();
            string connection = "Server = DESKTOP-0GK7VKO; Database = TopBillboard; User Id = mydb; Password = 221198;";
            using (SqlConnection cnn = new SqlConnection(connection))
            {
                cnn.Open();
                string displayAllSong = "SELECT name, RankInChart FROM Song";
                using (SqlDataAdapter dataAdapter = new SqlDataAdapter(displayAllSong, cnn))
                {
                    DataTable dtRecord = new DataTable();
                    dataAdapter.Fill(dtRecord);
                    dataGridView1.DataSource = dtRecord;
                }

                  
            }
            buttonPrint.Visible = true;
            //buttonPreview.Visible = true;
        }

        //button Artist 100
        private void button5_Click(object sender, EventArgs e)
        {
            buttonGraph.BackColor = Color.WhiteSmoke;
            buttonWeek.BackColor = Color.WhiteSmoke;
            buttonAlbum.BackColor = Color.WhiteSmoke;
            buttonArtist.BackColor = Color.FromArgb(206,206,206);

            textBoxInfo.Clear();
            //textBoxInfo.Text = Top100Artist;
        }

        //button Album
        private void button6_Click(object sender, EventArgs e)
        {
            buttonGraph.BackColor = Color.WhiteSmoke;
            buttonWeek.BackColor = Color.WhiteSmoke;
            buttonAlbum.BackColor = Color.FromArgb(206,206,206);
            buttonArtist.BackColor = Color.WhiteSmoke;

            textBoxInfo.Clear();
            string connection = "Server = DESKTOP-0GK7VKO; Database = TopBillboard; User Id = mydb; Password = 221198;";
            using (SqlConnection cnn = new SqlConnection(connection))
            {
                cnn.Open();
                string displayAllSlbum = "SELECT * FROM Album";
                using (SqlDataAdapter dataAdapter = new SqlDataAdapter(displayAllSlbum, cnn))
                {
                    DataTable dtRecord = new DataTable();
                    dataAdapter.Fill(dtRecord);
                    dataGridView1.DataSource = dtRecord;
                }

            }
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

        

        private void webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            //textBoxInfo.Text += webBrowserTopArtist.ReadyState.ToString() + "\r\n";
           
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
                GetAll();
                //GetTopAlbum();
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


            buttonPrint.Visible = false;
           // buttonPreview.Visible = false;
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

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            printDocument1.Print();
        }

        private void buttonPreview_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Activate();
        }

        private void buttonPrint_Click_1(object sender, EventArgs e)
        {
            int height = dataGridView1.Height;
            dataGridView1.Height = dataGridView1.RowCount * dataGridView1.RowTemplate.Height * 2;
            Bitmap bmp = new Bitmap(dataGridView1.Width, dataGridView1.Height);
            dataGridView1.DrawToBitmap(bmp, new Rectangle(0, 0, dataGridView1.Width, dataGridView1.Height));
            dataGridView1.Height = height;
           
            DialogResult result = printPreviewDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                    printDocument1.Print();
                //private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
               // {
                //    e.Graphics.DrawImage(bmp, 0, 0);
                //}
            }
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {
           
        }

        private void panelColor1_MouseDown(object sender, MouseEventArgs e)
        {
            isMoving = true;
            movX = e.X;
            movY = e.Y;
        }
    }
}
