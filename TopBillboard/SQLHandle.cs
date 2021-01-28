using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using HtmlAgilityPack;
using DataHandle;
namespace SQLHandle
{
    class Sqlhandle
    {
        public static void ClearData()
        {
            string connection = "Server = DESKTOP-0GK7VKO; Database = TopBillboard; User Id = mydb; Password = 221198;";
            using (SqlConnection cnn = new SqlConnection(connection))
            {
                cnn.Open();
                //clear main artist table
                try
                {
                    string commandDeleteMain = "DELETE FROM MainArtistInSong";
                    SqlCommand cmddeleteMain = new SqlCommand(commandDeleteMain, cnn);
                    cmddeleteMain.ExecuteNonQuery();
                }
                catch(SqlException ex)
                {
                    Console.Write(ex.Message);
                }

                //clear main featured table
                string commandDeleteft = "DELETE FROM FeaturedArtistInSong";
                SqlCommand cmddeleteft = new SqlCommand(commandDeleteft, cnn);
                cmddeleteft.ExecuteNonQuery();

                //clear Song
                string commandDelete = "DELETE FROM Song";
                SqlCommand cmddelete = new SqlCommand(commandDelete, cnn);
                cmddelete.ExecuteNonQuery();

                string commandresetid = "DBCC CHECKIDENT(Song, RESEED, 0)";
                SqlCommand resetid = new SqlCommand(commandresetid, cnn);
                resetid.ExecuteNonQuery();

                //clear TopArtist
                string resetArtistRank = "DELETE FROM TopArtist";
                SqlCommand CmdresetArtistRanklete = new SqlCommand(resetArtistRank, cnn);
                CmdresetArtistRanklete.ExecuteNonQuery();

                string commandresetTopid = "DBCC CHECKIDENT(TopArtist, RESEED, 0)";
                SqlCommand resetTopid = new SqlCommand(commandresetTopid, cnn);
                resetTopid.ExecuteNonQuery();

                //clear Album
                string resetAlbum = "DELETE FROM Album";
                SqlCommand CmdAlbumDelete = new SqlCommand(resetAlbum, cnn);
                CmdAlbumDelete.ExecuteNonQuery();

                string commandresetalbumid = "DBCC CHECKIDENT(Album, RESEED, 0)";
                SqlCommand resetalnumid = new SqlCommand(commandresetalbumid, cnn);
                resetalnumid.ExecuteNonQuery();

                //clear Artist
                string resetArtist = "DELETE FROM Artist";
                SqlCommand CmdArtistDelete = new SqlCommand(resetArtist, cnn);
                CmdArtistDelete.ExecuteNonQuery();

                string commandresetidartist = "DBCC CHECKIDENT(Artist, RESEED, 0)";
                SqlCommand resetidartist = new SqlCommand(commandresetidartist, cnn);
                resetidartist.ExecuteNonQuery();
               
            }
        }
       
  

        string Top100Artist = "";
        public static void GetTopArtist()
        {
            var html = @"https://www.billboard.com/charts/artist-100";

            string connection = "Server = DESKTOP-0GK7VKO; Database = TopBillboard; User Id = mydb; Password = 221198;";

            HtmlWeb web = new HtmlWeb();

            var htmlDoc = web.Load(html);
            using (SqlConnection cnn = new SqlConnection(connection))
            {
                cnn.Open();
                int rank = 1;

                var main = htmlDoc.GetElementbyId("main");



                var listNames = main.SelectNodes("//span[contains(@class, 'chart-list-item__title-text')]");
                foreach (var name in listNames)
                {
                    try
                    {
                        string InsertArtist = "INSERT INTO Artist(name) VALUES(@name)";
                        SqlCommand CmdInsArtist = new SqlCommand(InsertArtist, cnn);
                        CmdInsArtist.Parameters.AddWithValue("@name", StringHandle.RemoveFirstWhiteSpace(name.InnerText));
                        //textBoxInfo.Text += name.InnerText + "\r\n";
                        CmdInsArtist.ExecuteNonQuery();


                    }
                    catch (SqlException ex)
                    {
                        Console.Write(ex.Message);
                    }
                    //string Update = "UPDATE TopArtist SET artistID = @id, RankInChart = @val WHERE ";

                }
                foreach (var name in listNames)
                {

                    string findArtist = "SELECT id from Artist WHERE name = @value";
                    using (SqlCommand CmdFind = new SqlCommand(findArtist, cnn))
                    {
                        CmdFind.Parameters.AddWithValue("@value", StringHandle.RemoveFirstWhiteSpace(name.InnerText));
                        Int32 ID = (Int32)CmdFind.ExecuteScalar();


                        string InsertRank = "INSERT INTO TopArtist(RankInChart, artistID) VALUES(@rank, @id)";
                        SqlCommand CmdInsRank = new SqlCommand(InsertRank, cnn);
                        CmdInsRank.Parameters.AddWithValue("@rank", rank);
                        CmdInsRank.Parameters.AddWithValue("@id", ID);
                        CmdInsRank.ExecuteNonQuery();

                       // textBoxInfo.Text += rank.ToString() + name.InnerText + ": " + ID.ToString() + "." + "\r\n";

                        rank++;
                    }
                }

            }
            //lay ten artist cua top 200 album 
            using (SqlConnection cnn = new SqlConnection(connection))
            {
                cnn.Open();


                var html1 = @"https://www.billboard.com/charts/billboard-200";

                HtmlWeb web1 = new HtmlWeb();

                var htmlDoc1 = web1.Load(html1);

                var main1 = htmlDoc1.GetElementbyId("main");

                var listNames2 = main1.SelectNodes("//span[contains(@class, 'chart-element__information__artist text--truncate color--secondary')]");
                foreach (var name in listNames2)
                {
                    try
                    {
                        string InsertArtist = "INSERT INTO Artist(name) VALUES(@name)";


                        SqlCommand CmdInsArtist = new SqlCommand(InsertArtist, cnn);
                        CmdInsArtist.Parameters.AddWithValue("@name", StringHandle.RemoveFirstWhiteSpace(name.InnerText));
                        //textBoxInfo.Text += name.InnerText + "\r\n";
                        CmdInsArtist.ExecuteNonQuery();

                    }
                    catch (SqlException ex)
                    {
                        Console.Write(ex.Message);
                    }
                }

            }
        }


        // Crawling top 200 Album in Billboard 200
        public static void GetTopAlbum()
        {

            string connection = "Server = DESKTOP-0GK7VKO; Database = TopBillboard; User Id = mydb; Password = 221198;";
            var html = @"https://www.billboard.com/charts/billboard-200";

            HtmlWeb web = new HtmlWeb();

            var htmlDoc = web.Load(html);

            var main = htmlDoc.GetElementbyId("main");

            using (SqlConnection cnn = new SqlConnection(connection))
            {
                cnn.Open();
                //clear gia tri da luu trong string va db
                //TopAlbum = "";
                //TopAlbumArtist = "";
                int countTopAlbum = 0;



                //lay ten album
                var listNames1 = main.SelectNodes("//span[contains(@class, 'chart-element__information__song text--truncate color--primary')]");
                foreach (var name in listNames1)
                {

                    string insertalbumName = "INSERT INTO Album(name, Album_rank) VALUES(@name, @rank)";

                    using (SqlCommand CmdAlbumInsert = new SqlCommand(insertalbumName, cnn))
                    {
                        CmdAlbumInsert.Parameters.AddWithValue("@name", StringHandle.RemoveFirstWhiteSpace(name.InnerText));
                        CmdAlbumInsert.Parameters.AddWithValue("@rank", countTopAlbum + 1);

                        CmdAlbumInsert.ExecuteNonQuery();

                       // TopAlbum = TopAlbum + (countTopAlbum + 1).ToString() + " " + name.InnerText + "\r\n";
                        countTopAlbum++;
                    }

                }
               
            }

            using (SqlConnection cnn = new SqlConnection(connection))
            {
                //dien vao table Album
                cnn.Open();
                int countrank = 1;
                var listNames2 = main.SelectNodes("//span[contains(@class, 'chart-element__information__artist text--truncate color--secondary')]");
                foreach (var name in listNames2)
                {
                    string findArtist = "SELECT id from Artist WHERE name = @value";
                    using (SqlCommand CmdFind = new SqlCommand(findArtist, cnn))
                    {
                        CmdFind.Parameters.AddWithValue("@value", StringHandle.RemoveFirstWhiteSpace(name.InnerText));
                        Int32 IDArtists = (Int32)CmdFind.ExecuteScalar();


                        //textBoxInfo.Text += countrank.ToString() + name.InnerText + ": " + IDArtists.ToString() + "\r\n";
                        string insert = "UPDATE Album SET artistID = @value WHERE id = @id";
                        SqlCommand CmdInsert = new SqlCommand(insert, cnn);

                        CmdInsert.Parameters.AddWithValue("@value", IDArtists);
                        CmdInsert.Parameters.AddWithValue("@id", countrank);

                        CmdInsert.ExecuteNonQuery();
                        countrank++;

                    }

                }
               
            }
        }

    }
}
