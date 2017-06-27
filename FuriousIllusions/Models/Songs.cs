using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FuriousIllusions.Models;
namespace FuriousIllusions.Models
{
		public class Song
		{
				public DataSet ds;
				private string path = @"\App_Data\playlist.xml";

				public Song()
				{
						ds = new DataSet("playlist");
						DataTable dtSongs = new DataTable("song");

						DataColumn dtId = new DataColumn("id");
						DataColumn dtArtist = new DataColumn("artist");
						DataColumn dtTitle = new DataColumn("title");
						DataColumn dtYear = new DataColumn("publication");
						DataColumn dtGenre = new DataColumn("genre");
						DataColumn dtTime = new DataColumn("duration");
						DataColumn dtLink = new DataColumn("link");

						ds.Tables.Add(dtSongs);
						dtSongs.Columns.Add(dtId);
						dtSongs.Columns.Add(dtArtist);
						dtSongs.Columns.Add(dtTitle);
						dtSongs.Columns.Add(dtYear);
						dtSongs.Columns.Add(dtGenre);
						dtSongs.Columns.Add(dtTime);
						dtSongs.Columns.Add(dtLink);

            ds.ReadXml(HttpContext.Current.Server.MapPath(path));
        }

        public DataRowCollection GetSongs()
        {
            return ds.Tables[0].Rows;
        }

        public void Create(int i)
				{
						string waarde = HttpContext.Current.Request.Form["inputelement"];
						DataRow dr = ds.Tables[0].NewRow();

						string s = HttpContext.Current.Request.Form["link"].ToString();
						string v = s.Replace("watch?v=", "embed/");

						dr["id"] = i;
						dr["artist"] = HttpContext.Current.Request.Form["artist"];
						dr["title"] = HttpContext.Current.Request.Form["title"];
						dr["publication"] = HttpContext.Current.Request.Form["publication"];
						dr["genre"] = HttpContext.Current.Request.Form["genre"];
						dr["duration"] = HttpContext.Current.Request.Form["duration"];
						dr["link"] = v + "?autoplay=1";

						if (string.IsNullOrWhiteSpace(HttpContext.Current.Request.Form["artist"]) ||
						string.IsNullOrWhiteSpace(HttpContext.Current.Request.Form["title"]) ||
						string.IsNullOrWhiteSpace(HttpContext.Current.Request.Form["publication"]) ||
						string.IsNullOrWhiteSpace(HttpContext.Current.Request.Form["genre"]) ||
						string.IsNullOrWhiteSpace(HttpContext.Current.Request.Form["duration"]) ||
						string.IsNullOrWhiteSpace(HttpContext.Current.Request.Form["link"]))
						{
								HttpContext.Current.Response.Write("<h2 style='color: red;'> Nog niet alle velden zijn ingevuld!<h2>");
						}
						else
						{
								ds.Tables[0].Rows.Add(dr);
								ds.WriteXml(HttpContext.Current.Server.MapPath("../App_Data/playlist.xml"));
								HttpContext.Current.Response.Redirect("Index");
						}
				}

				public void Delete(string id)
        {
            DataRow[] drArray = ds.Tables[0].Select("id='" + id + "'");
            drArray[0].Delete();

            save();

            HttpContext.Current.Response.Redirect("Index");
        }

				public void Edit(string id)
        {
           
            DataRow[] dr = ds.Tables[0].Select("id='" + id + "'");

            string s = dr[0]["link"].ToString();
            string v = s.Replace("watch?v=", "embed/");

            dr[0]["id"] = HttpContext.Current.Request.Form["id"];
            dr[0]["artist"] = HttpContext.Current.Request.Form["artist"];
            dr[0]["title"] = HttpContext.Current.Request.Form["title"];
            dr[0]["publication"] = HttpContext.Current.Request.Form["publication"];
            dr[0]["genre"] = HttpContext.Current.Request.Form["genre"];
            dr[0]["duration"] = HttpContext.Current.Request.Form["duration"];
            dr[0]["link"] = v + (v.IndexOf("autoplay") < 0 ? "?autoplay=1" : "");

            save();
            HttpContext.Current.Response.Redirect("Index");
        }

				public void save()
				{
						ds.WriteXml(HttpContext.Current.Server.MapPath(path));
				}
		}
}