using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Data.Common;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Xml;
using Newtonsoft.Json;

// Posert search services
// iTunes (http://www.apple.com/itunes/affiliates/resources/documentation/itunes-store-web-service-search-api.html)
// Amazon (http://docs.aws.amazon.com/AWSECommerceService/2011-08-01/DG/CHAP_ApiReference.html)
// IMDB (http://www.omdbapi.com/)

// Rotten Tomatoes API key: 3dqtf5rqa2exucjvt3gtxqbe
// TVRage API key(unused): U6CNqAMr8mpdXmgNAbr7

namespace PersonalMediaCollection
{
  public partial class frmMain : Form
  {
    string dbName = "PersonalMediaCollection.db";
    SQLiteFactory factory;
    SQLiteConnection connection;

    Stack<int> pathStack = new Stack<int>();
    bool bDeleteAfterPaste;
    Stack<int> elementsStack = new Stack<int>();
    List<byte[]> listPosters = new List<byte[]>();
    List<string> listPostersName = new List<string>();

    public class ReleaseDates
    {
      public string theater { get; set; }
      public string dvd { get; set; }
    }

    public class Ratings
    {
      public string critics_rating { get; set; }
      public int critics_score { get; set; }
      public string audience_rating { get; set; }
      public int audience_score { get; set; }
    }

    public class Posters
    {
      public string thumbnail { get; set; }
      public string profile { get; set; }
      public string detailed { get; set; }
      public string original { get; set; }
    }

    public class AbridgedCast
    {
      public string name { get; set; }
      public string id { get; set; }
      public List<string> characters { get; set; }
    }

    public class AlternateIds
    {
      public string imdb { get; set; }
    }

    public class Links
    {
      public string self { get; set; }
      public string alternate { get; set; }
      public string cast { get; set; }
      public string clips { get; set; }
      public string reviews { get; set; }
      public string similar { get; set; }
    }

    public class Movie
    {
      public string id { get; set; }
      public string title { get; set; }
      public int year { get; set; }
      public string mpaa_rating { get; set; }
      public object runtime { get; set; }
      public string critics_consensus { get; set; }
      public ReleaseDates release_dates { get; set; }
      public Ratings ratings { get; set; }
      public string synopsis { get; set; }
      public Posters posters { get; set; }
      public List<AbridgedCast> abridged_cast { get; set; }
      public AlternateIds alternate_ids { get; set; }
      public Links links { get; set; }
    }

    public class Links2
    {
      public string self { get; set; }
    }

    public class RootObject
    {
      public int total { get; set; }
      public List<Movie> movies { get; set; }
      public Links2 links { get; set; }
      public string link_template { get; set; }
    }


    public frmMain()
    {
      InitializeComponent();
    }

    private void выходToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Close();
    }

    private SQLiteDataReader getTree(int idParent)
    {      
      SQLiteCommand command = new SQLiteCommand(connection);
      command.CommandText = "select * from MainTree where ifnull(idParent, 0) = @idParent order by SortOrder, Name;";
      command.Parameters.Add("@idParent", DbType.Int32).Value = idParent;
      SQLiteDataReader reader = command.ExecuteReader();
      return reader;
    }
 
    private SQLiteDataReader getContentType()
    {
        SQLiteCommand command = new SQLiteCommand(connection);
        command.CommandText = "SELECT * FROM ContentType;";
        SQLiteDataReader reader = command.ExecuteReader();
        return reader;
    }

    private DbDataRecord GetItemInfo(int id)
    {
      SQLiteCommand command = new SQLiteCommand(connection);
      command.CommandText = "select * from MainTree where id = @id;";
      command.Parameters.Add("@id", DbType.Int32).Value = id;
      SQLiteDataReader reader = command.ExecuteReader();
      foreach (DbDataRecord record in reader)
      {
        return record;
      }
      return null;
    }

    private DbDataRecord GetAuthForSearchService(string NameService)
    {
        SQLiteCommand command = new SQLiteCommand(connection);
        command.CommandText = "select Login, Password from SearchServices where NameService = @NameService;";
        command.Parameters.Add("@NameService", DbType.String).Value = NameService;
        SQLiteDataReader reader = command.ExecuteReader();
        foreach (DbDataRecord record in reader)
        {
            return record;
        }
        return null;
    }

    private bool IsEnabledSearchService(string NameService)
    {
        SQLiteCommand command = new SQLiteCommand(connection);
        command.CommandText = "select IsEnabled from SearchServices where NameService = @NameService;";
        command.Parameters.Add("@NameService", DbType.String).Value = NameService;
        SQLiteDataReader reader = command.ExecuteReader();
        foreach (DbDataRecord record in reader)
        {
            return (record.GetBoolean(record.GetOrdinal("IsEnabled"))) ? true : false;
        }
        return false;
    }

    private bool CanPaste(int id, int idTarget)
    {
        SQLiteCommand command = new SQLiteCommand(connection);
        command.CommandText = "select cast((case when (AllowChildren = 1 and id <> @id) then 1 else 0 end) as boolean) as CanPaste from MainTree where id = @idTarget;";
        command.Parameters.Add("@id", DbType.Int32).Value = id;
        command.Parameters.Add("@idTarget", DbType.Int32).Value = idTarget;
        SQLiteDataReader reader = command.ExecuteReader();
        foreach (DbDataRecord record in reader)
        {
            if (Convert.ToInt32(record["CanPaste"].ToString()) == 1)
                return true;
            else
                return false;
        }
        return false;
    }

    private void CopyItem(int id, int idTarget)
    {
      SQLiteCommand command = new SQLiteCommand(connection);
      command.CommandText = "insert into Videos (idMediaType, idParent, idPreviousVideo, idContentType, Title, Path, isWatched, idCover) " +
                            "select " +
                            "(select case when id < 0 then abs(id) else idMediaType end from MainTree where id = @idTarget) as idMediaType, " +
                            "(select case when id < 0 then null else id end from MainTree where id = @idTarget) as idParent, " +
                            "idPreviousVideo, " +
                            "idContentType, " +
                            "Name, " +
                            "Path, " +
                            "isWatched, " +
                            "idCover " +
                            "from MainTree " +
                            "where id = @id;";
      command.Parameters.Add("@id", DbType.Int32).Value = id;
      command.Parameters.Add("@idTarget", DbType.Int32).Value = idTarget;
      command.ExecuteNonQuery();

      command = new SQLiteCommand(connection);
      command.CommandText = "select last_insert_rowid() as id;";
      SQLiteDataReader reader = command.ExecuteReader();
      int lastRowid = 0;
      foreach (DbDataRecord record in reader)
      {
        lastRowid = Convert.ToInt32(record["id"].ToString());
        break;
      }

      command = new SQLiteCommand(connection);
      command.CommandText = "select id from Videos where idParent = @id;";
      command.Parameters.Add("@id", DbType.Int32).Value = id;
      reader = command.ExecuteReader();
      foreach (DbDataRecord record in reader)
      {
        CopyItem(Convert.ToInt32(record["id"].ToString()), lastRowid);
      }
    }

    private void MoveItem (int id, int idTarget)
    {
      SQLiteCommand command = new SQLiteCommand(connection);
      command.CommandText = "update Videos " +
                            "set idMediaType = (select case when id < 0 then abs(id) else idMediaType end from MainTree where id = @idTarget), " +
                            "idParent = (select case when id < 0 then null else id end from MainTree where id = @idTarget) " +
                            "where id = @id;";
      command.Parameters.Add("@id", DbType.Int32).Value = id;
      command.Parameters.Add("@idTarget", DbType.Int32).Value = idTarget;
      command.ExecuteNonQuery();

      command = new SQLiteCommand(connection);
      command.CommandText = "select id from Videos where idParent = @id;";
      command.Parameters.Add("@id", DbType.Int32).Value = id;
      SQLiteDataReader reader = command.ExecuteReader();
      foreach(DbDataRecord record in reader)
      {
        MoveItem(Convert.ToInt32(record["id"].ToString()), id);
      }
    }

    private bool deleteItem(int id)
    {
        if (id > 0)
        {
            SQLiteCommand command = new SQLiteCommand(connection);
            command.CommandText = "select id from Videos where idParent = @id";
            command.Parameters.Add("@id", DbType.Int32).Value = id;
            SQLiteDataReader reader = command.ExecuteReader();
            foreach (DbDataRecord record in reader)
            {
              if (deleteItem(Convert.ToInt32(record["id"].ToString())) == false)
                {
                  MessageBox.Show("Произошла ошибка при удалении", "Ошибка удаления", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                  return false;
                }
            }
            command = new SQLiteCommand(connection);
            command.CommandText = "update Videos set isDeleted = 1 where id = @id;";
            command.Parameters.Add("@id", DbType.Int32).Value = id;
            command.ExecuteNonQuery();
            return true;
        }
        else
        {
            DbDataRecord item = GetItemInfo(id);
            MessageBox.Show("Нельзя удалить элемент\n" + item["Name"].ToString(), "Ошибка удаления", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return false;
        }
    }

    private void addGroupOrElement(int idParent, int ContentType)
    {
        SQLiteCommand command = new SQLiteCommand(connection);
        command.CommandText = "insert into Videos (idMediaType, idParent, idContentType, Title) " +
                              "select " +
                              "case when id < 0 then abs(id) else (select idMediaType from Videos where id = @idParent) end as idMediaType, " +
                              "case when id < 0 then null else id end                                                       as idParent, " +
                              "@ContentType                                                                                 as idContentType, " +
                              "'Введите название'                                                                           as Title " +
                              "from MainTree " +
                              "where id = @idParent;";
        command.Parameters.Add("@ContentType", DbType.Int32).Value = ContentType;
        command.Parameters.Add("@idParent", DbType.Int32).Value = idParent;
        command.ExecuteNonQuery();
    }

    private void setImage(byte[] image, int id)
    {
        SQLiteCommand command = new SQLiteCommand(connection);
        command.CommandText = "select id from Covers where Cover = @image;";
        command.Parameters.Add("@image", DbType.Object).Value = image;
        SQLiteDataReader reader = command.ExecuteReader();
        foreach (DbDataRecord record in reader)
        {
            command = new SQLiteCommand(connection);
            command.CommandText = "update Videos set idCover = @idCover where id = @id;";
            command.Parameters.Add("@idCover", DbType.Int32).Value = Convert.ToInt32(record["id"].ToString());
            command.Parameters.Add("@id", DbType.Int32).Value = id;
            command.ExecuteNonQuery();
            return;
        }
        command = new SQLiteCommand(connection);
        command.CommandText = "insert into Covers (Cover) values (@image);";
        command.Parameters.Add("@image", DbType.Object).Value = image;
        command.ExecuteNonQuery();

        command = new SQLiteCommand(connection);
        command.CommandText = "select id from Covers where Cover = @image;";
        command.Parameters.Add("@image", DbType.Object).Value = image;
        reader = command.ExecuteReader();
        foreach (DbDataRecord record in reader)
        {
            command = new SQLiteCommand(connection);
            command.CommandText = "update Videos set idCover = @idCover where id = @id;";
            command.Parameters.Add("@idCover", DbType.Int32).Value = Convert.ToInt32(record["id"].ToString());
            command.Parameters.Add("@id", DbType.Int32).Value = id;
            command.ExecuteNonQuery();
            return;
        }
    }

    private void deleteCover(int id)
    {
      SQLiteCommand command = new SQLiteCommand(connection);
      command = new SQLiteCommand(connection);
      command.CommandText = "update Videos set idCover = null where id = @id;";
      command.Parameters.Add("@id", DbType.Int32).Value = id;
      command.ExecuteNonQuery();
      return;
    }

    private void setTitle(string title, int id)
    {
        SQLiteCommand command = new SQLiteCommand(connection);
        command.CommandText = "update Videos set Title = @title where id = @id;";
        command.Parameters.Add("@title", DbType.String).Value = title;
        command.Parameters.Add("@id", DbType.Int32).Value = id;
        command.ExecuteNonQuery();
    }

    private void updateIsWatched(bool isWatched, int id)
    {
        SQLiteCommand command = new SQLiteCommand(connection);
        command.CommandText = "update Videos set isWatched = @isWatched where id = @id;";
        command.Parameters.Add("@isWatched", DbType.Boolean).Value = isWatched;
        command.Parameters.Add("@id", DbType.Int32).Value = id;
        command.ExecuteNonQuery();
    }

    private void setPath(string path, int id)
    {
        SQLiteCommand command = new SQLiteCommand(connection);
        command.CommandText = "update Videos set Path = @path where id = @id;";
        command.Parameters.Add("@path", DbType.String).Value = path;
        command.Parameters.Add("@id", DbType.Int32).Value = id;
        command.ExecuteNonQuery();
    }

    private void setCoverFromParent(int id)
    {
        SQLiteCommand command = new SQLiteCommand(connection);
        command.CommandText = "update Videos set idCover = (select idCover from Videos where id = (select idParent from Videos where id = @id)) where id = @id";
        command.Parameters.Add("@id", DbType.Int32).Value = id;
        command.ExecuteNonQuery();
    }

    private int getidCover(int id)
    {
      SQLiteCommand command = new SQLiteCommand(connection);
      command.CommandText = "select idCover from MainTree where id = @id;";
      command.Parameters.Add("@id", DbType.Int32).Value = id;
      SQLiteDataReader reader = command.ExecuteReader();
      foreach (DbDataRecord record in reader)
      {
        if (record.IsDBNull(record.GetOrdinal("idCover")) == false)
        {
          return Convert.ToInt32(record["idCover"].ToString());
        }
        else
        {
          return 0;
        }
      }
      return 0;
    }

    public void AddMassGroupOrElement(int Type, int count, bool AutoNum, int numCount, int beginFrom, string prefix, bool bParent, bool bDefault, string coverPath)
    {
      int idCover = 0;
      int idParent = 0;
      idParent = pathStack.Pop();
      pathStack.Push(idParent);
      if (bParent == true)
      {
        idCover = getidCover(idParent);
      }
      else if (bDefault == true)
      {
        idCover = 0;
      }
      else
      {
        FileStream file = new FileStream(coverPath, FileMode.Open, FileAccess.Read);
        BinaryReader binary_reader = new BinaryReader(file);
        byte[] image = binary_reader.ReadBytes((int)file.Length);
        binary_reader.Close();
        file.Close();

        SQLiteCommand command = new SQLiteCommand(connection);
        command.CommandText = "select id from Covers where Cover = @image;";
        command.Parameters.Add("@image", DbType.Object).Value = image;
        SQLiteDataReader reader = command.ExecuteReader();
        if (reader.RecordsAffected > 0)
        {
          foreach (DbDataRecord record in reader)
          {
            idCover = Convert.ToInt32(record["id"].ToString());
          }
        }
        else
        {
          command = new SQLiteCommand(connection);
          command.CommandText = "insert into Covers (Cover) values (@image);";
          command.Parameters.Add("@image", DbType.Object).Value = image;
          command.ExecuteNonQuery();

          command = new SQLiteCommand(connection);
          command.CommandText = "select id from Covers where Cover = @image;";
          command.Parameters.Add("@image", DbType.Object).Value = image;
          reader = command.ExecuteReader();

          foreach (DbDataRecord record in reader)
          {
            idCover = Convert.ToInt32(record["id"].ToString());
          }
        }
      }
      for (int i = 0; i < count; i++)
      {
        string Name;
        if (AutoNum == false)
        {
          if (prefix.Length == 0)
          {
            Name = "Введите название";
          }
          else
          {
            Name = prefix;
          }
        }
        else
        {
          int n = i + beginFrom;
          string number = Convert.ToString(n);
          for (int j = number.Length; j < numCount; j++)
          {
            number = '0' + number;
          }
          if (prefix.Length > 0)
          {
            Name = prefix + ' ' + number;
          }
          else
          {
            Name = number;
          }
        }
        SQLiteCommand command = new SQLiteCommand(connection);
        command.CommandText = "insert into Videos (idMediaType, idParent, idContentType, Title, idCover) " +
                              "select " +
                              "case when id < 0 then abs(id) else (select idMediaType from Videos where id = @idParent) end as idMediaType, " +
                              "case when id < 0 then null else id end                                                       as idParent, " +
                              "@ContentType                                                                                 as idContentType, " +
                              "@Title                                                                                       as Title, " +
                              "case when @idCover = 0 then null else @idCover end                                           as idCover " +
                              "from MainTree " +
                              "where id = @idParent;";
        command.Parameters.Add("@ContentType", DbType.Int32).Value = Type;
        command.Parameters.Add("@idParent", DbType.Int32).Value = idParent;
        command.Parameters.Add("@idCover", DbType.Int32).Value = idCover;
        command.Parameters.Add("@Title", DbType.String).Value = Name;
        command.ExecuteNonQuery();
      }
    }

    public Image getCover(bool bStandard)
    {
      int idParent = pathStack.Pop();
      pathStack.Push(idParent);
      SQLiteCommand command = new SQLiteCommand(connection);
      if (idParent > 0 && bStandard == false)
      {
        command.CommandText = "select Icon from MainTree where id = @id;";
        command.Parameters.Add("@id", DbType.Int32).Value = idParent;
      }
      else
      {
        command.CommandText = "select i.Icon from Icons as i where i.id = 12;";
      }
      SQLiteDataReader reader = command.ExecuteReader();
      Image image = null;
      foreach(DbDataRecord record in reader)
      {
        byte[] imageBytes = (System.Byte[])record["Icon"];
        MemoryStream ms = new MemoryStream(imageBytes);
        image = Image.FromStream(ms);
      }
      return image;
    }

    private void LoadMainList(int Parent)
    {
      listViewMainContent.Groups.Clear();
      foreach (DbDataRecord record in getContentType())
      {
        listViewMainContent.Groups.Add(record["id"].ToString(), record["Description"].ToString());
      }
      listViewMainContent.Clear();
      imageListView.Images.Clear();
      foreach (DbDataRecord record in getTree(Parent)) {
        byte[] imageBytes = (System.Byte[])record["Icon"];
        MemoryStream ms = new MemoryStream(imageBytes);
        Image image = Image.FromStream(ms);
        imageListView.Images.Add(record["id"].ToString(), image);
        listViewMainContent.Items.Add(record["id"].ToString(), record["Name"].ToString(), record["id"].ToString());
        listViewMainContent.Items[record["id"].ToString()].Group = listViewMainContent.Groups[record["idContentType"].ToString()];
      }
    }

    public string EncryptString(string ClearText)
    {
        byte[] clearTextBytes = Encoding.UTF8.GetBytes(ClearText);
        System.Security.Cryptography.SymmetricAlgorithm rijn = SymmetricAlgorithm.Create();
        MemoryStream ms = new MemoryStream();
        byte[] rgbIV = Encoding.ASCII.GetBytes("ryojvlzmdalyglrj");
        byte[] key = Encoding.ASCII.GetBytes("hcxilkqbbhczfeultgbskdmaunivmfuo");
        CryptoStream cs = new CryptoStream(ms, rijn.CreateEncryptor(key, rgbIV), CryptoStreamMode.Write);
        cs.Write(clearTextBytes, 0, clearTextBytes.Length);
        cs.Close();
        return Convert.ToBase64String(ms.ToArray());
    }
    public string DecryptString(string EncryptedText)
    {
        byte[] encryptedTextBytes = Convert.FromBase64String(EncryptedText);
        MemoryStream ms = new MemoryStream();
        System.Security.Cryptography.SymmetricAlgorithm rijn = SymmetricAlgorithm.Create();
        byte[] rgbIV = Encoding.ASCII.GetBytes("ryojvlzmdalyglrj");
        byte[] key = Encoding.ASCII.GetBytes("hcxilkqbbhczfeultgbskdmaunivmfuo");
        CryptoStream cs = new CryptoStream(ms, rijn.CreateDecryptor(key, rgbIV), CryptoStreamMode.Write);
        cs.Write(encryptedTextBytes, 0, encryptedTextBytes.Length);
        cs.Close();
        return Encoding.UTF8.GetString(ms.ToArray());
    }

    private void frmMain_Load(object sender, EventArgs e)
    {
      tbTitle.Visible = false;
      factory = (SQLiteFactory)DbProviderFactories.GetFactory("System.Data.SQLite");
      connection = (SQLiteConnection)factory.CreateConnection();
      connection.ConnectionString = "Data Source = " + dbName;
      connection.Open();
      pathStack.Push(0);
      LoadMainList(0);
      refreshContent(0);
    }

    private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (MessageBox.Show("Вы уверены, что хотите выйти?", "Выход", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        {
            Properties.Settings.Default.Save();
            connection.Close();
            e.Cancel = false;
        }
        else
        {
            e.Cancel = true;
        }
    }

    private void listViewMainContent_MouseDoubleClick(object sender, MouseEventArgs e)
    {
            if (listViewMainContent.SelectedItems.Count == 1 && e.Button == MouseButtons.Left)
            {
                int key = Convert.ToInt32(listViewMainContent.FocusedItem.Name);
                DbDataRecord record = GetItemInfo(key);
                if (record.GetBoolean(record.GetOrdinal("HasChildren")) == true)
                {
                    pathStack.Push(key);
                    listViewMainContent.Clear();
                    LoadMainList(key);
                    refreshContent(0);
                }
                else if (record.IsDBNull(record.GetOrdinal("Path")) == true && btnChangeInfo.Enabled == true)
                {
                  btnChangeInfo_Click(sender, e);
                }
                else if (Convert.ToInt32(record["idContentType"].ToString()) == 3)
                {
                  btnPlay_Click(sender, e);
                }
            }
    }

    private void pathBack_Click(object sender, EventArgs e)
    {
      if (pathStack.Count > 1) {
        pathStack.Pop();
        int key = pathStack.Pop();
        pathStack.Push(key);
        listViewMainContent.Clear();
        LoadMainList(key);
        refreshContent(0);
      }
    }

    private void listViewMainContent_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar == Convert.ToChar(Keys.Enter)) {
          if (listViewMainContent.SelectedItems.Count == 1)
          {
              int key = Convert.ToInt32(listViewMainContent.FocusedItem.Name);
              DbDataRecord record = GetItemInfo(key);
              if (record.GetBoolean(record.GetOrdinal("HasChildren")) == true)
              {
                  pathStack.Push(key);
                  listViewMainContent.Clear();
                  LoadMainList(key);
                  refreshContent(0);
              }
              else if (record.IsDBNull(record.GetOrdinal("Path")) == true && btnChangeInfo.Enabled == true)
              {
                btnChangeInfo_Click(sender, e);
              }
              else if (Convert.ToInt32(record["idContentType"].ToString()) == 3)
              {
                btnPlay_Click(sender, e);
              }
          }
      } else if (e.KeyChar == Convert.ToChar(Keys.Back)) {
        pathBack_Click(sender, null);
      }
    }

    private void hideInfoControls()
    {
        pictureBox.Image = null;
        lbTitle.Text = "";
        cbWatched.Checked = false;
        cbWatched.Enabled = false;
        btnPlay.Enabled = false;
        btnOpen.Enabled = false;
        btnChangeInfo.Enabled = false;
        btnFindCover.Enabled = false;
        btnDelete.Enabled = false;
        menuDelete.Enabled = false;
        MediaPath.Text = "";
    }

    private void refreshContent(int item)
    {
        lbTitle.Visible = true;
        tbTitle.Visible = false;
        if (item != 0)
        {
            DbDataRecord record = GetItemInfo(item);
            byte[] imageBytes = (System.Byte[])record["Icon"];
            MemoryStream ms = new MemoryStream(imageBytes);
            pictureBox.Image = Image.FromStream(ms);
            imageListView.Images.RemoveByKey(record["id"].ToString());
            imageListView.Images.Add(record["id"].ToString(), Image.FromStream(ms));
            listViewMainContent.Items[record["id"].ToString()].ImageKey = record["id"].ToString();
            lbTitle.Text = record["Name"].ToString();
            listViewMainContent.Items[record["id"].ToString()].Text = record["Name"].ToString();
            cbWatched.Checked = (Convert.ToInt32(record["isWatched"].ToString()) == 1) ? true : false;
            if (record.IsDBNull(record.GetOrdinal("Path")) == false)
            {
                if (File.Exists(record["Path"].ToString()))
                    MediaPath.ForeColor = Color.Black;
                else
                    MediaPath.ForeColor = Color.Red;
                MediaPath.Text = record["Path"].ToString();
            }
            else
                MediaPath.Text = "";
            if (Convert.ToInt32(record["IsReadOnly"].ToString()) == 0)
            {
                if (Convert.ToInt32(record["idContentType"].ToString()) == 3)
                {
                    btnChangeInfo.Enabled = true;
                }
                else
                {
                    btnChangeInfo.Enabled = false;
                }
                cbWatched.Enabled = true;
                btnFindCover.Enabled = true;
                btnDelete.Enabled = true;
                menuDelete.Enabled = true;
            }
            else
            {
                cbWatched.Enabled = false;
                btnChangeInfo.Enabled = false;
                btnFindCover.Enabled = false;
                btnDelete.Enabled = false;
                menuDelete.Enabled = false;
            }
            if (record.IsDBNull(record.GetOrdinal("Path")) == true || (File.Exists(record["Path"].ToString()) == false))
            {
                btnPlay.Enabled = false;
                btnOpen.Enabled = false;
            }
            else
            {
                btnPlay.Enabled = true;
                btnOpen.Enabled = true;
            }
        }
        else
        {
            hideInfoControls();
            if (pathStack.Count > 1)
            {
                int key = pathStack.Pop();
                DbDataRecord record = GetItemInfo(key);
                if (record.GetBoolean(record.GetOrdinal("AllowChildren")) == false)
                {
                    btnAddGroup.Enabled = false;
                    btnAddFile.Enabled = false;
                    menuAddGroup.Enabled = false;
                    menuAddFile.Enabled = false;
                }
                else
                {
                    btnAddGroup.Enabled = true;
                    btnAddFile.Enabled = true;
                    menuAddGroup.Enabled = true;
                    menuAddFile.Enabled = true;
                }
                pathStack.Push(key);
                LoadMainList(key);
            }
            else
            {
                btnAddGroup.Enabled = false;
                btnAddFile.Enabled = false;
                menuAddGroup.Enabled = false;
                menuAddFile.Enabled = false;
            }
        }
    }

    private void listViewMainContent_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
    {
      if (e.IsSelected == true) {
          if (listViewMainContent.SelectedItems.Count == 1)
          {
              refreshContent(Convert.ToInt32(e.Item.Name));
          }
          else
          {
              hideInfoControls();
              btnDelete.Enabled = true;
          }
      } else {
          hideInfoControls();
      }
    }

    private void btnRefresh_Click(object sender, EventArgs e)
    {
        refreshContent(0);
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
        if (MessageBox.Show("Вы уверены, что хотите удалить выбранные элементы?", "Удаление...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
        {
            foreach (ListViewItem item in listViewMainContent.SelectedItems)
            {
                deleteItem(Convert.ToInt32(item.Name));
            }
            refreshContent(0);
        }
    }

    private void btnAddGroup_Click(object sender, EventArgs e)
    {
        int idParent = pathStack.Pop();
        pathStack.Push(idParent);
        if (System.Windows.Forms.Control.ModifierKeys == Keys.Shift)
        {
          frmMassAdd wndMassAdd = new frmMassAdd(2);
          wndMassAdd.Owner = this;
          wndMassAdd.ShowDialog();
        }
        else
        {
          addGroupOrElement(idParent, 2);
        }
        refreshContent(0);
    }

    private void btnAddFile_Click(object sender, EventArgs e)
    {
        int idParent = pathStack.Pop();
        pathStack.Push(idParent);
        if (System.Windows.Forms.Control.ModifierKeys == Keys.Shift)
        {
          frmMassAdd wndMassAdd = new frmMassAdd(3);
          wndMassAdd.Owner = this;
          wndMassAdd.ShowDialog();
        }
        else
        {
          addGroupOrElement(idParent, 3);
        }
        refreshContent(0);
    }

    private void pictureBox_DoubleClick(object sender, EventArgs e)
    {
        if (listViewMainContent.SelectedItems.Count == 1)
        {
            int id = Convert.ToInt32(listViewMainContent.FocusedItem.Name);
            DbDataRecord record = GetItemInfo(id);
            if (Convert.ToInt32(record["IsReadOnly"].ToString()) == 0)
            {
                if (dlgOpenImage.ShowDialog() == DialogResult.OK)
                {
                    FileStream file = new FileStream(dlgOpenImage.FileName, FileMode.Open, FileAccess.Read);
                    BinaryReader reader = new BinaryReader(file);
                    byte[] image = reader.ReadBytes((int)file.Length);
                    reader.Close();
                    file.Close();
                    setImage(image, id);
                    refreshContent(id);
                }
            }
        }
    }

    private void lbTitle_DoubleClick(object sender, EventArgs e)
    {
        if (listViewMainContent.SelectedItems.Count == 1)
        {
            int id = Convert.ToInt32(listViewMainContent.FocusedItem.Name);
            DbDataRecord record = GetItemInfo(id);
            if (Convert.ToInt32(record["IsReadOnly"].ToString()) == 0)
            {
                tbTitle.Text = lbTitle.Text;
                tbTitle.Visible = true;
                lbTitle.Visible = false;
                tbTitle.Focus();
            }
        }
    }

    private void tbTitle_KeyDown(object sender, KeyEventArgs e)
    {
        if (listViewMainContent.SelectedItems.Count == 1)
        {
            int id = Convert.ToInt32(listViewMainContent.FocusedItem.Name);
            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.Enter)
            {
                setTitle(tbTitle.Text, id);
                refreshContent(id);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                lbTitle.Visible = true;
                tbTitle.Visible = false;
            }
        }
    }

    private void cbWatched_Click(object sender, EventArgs e)
    {
        if (listViewMainContent.SelectedItems.Count == 1)
        {
            int id = Convert.ToInt32(listViewMainContent.FocusedItem.Name);
            updateIsWatched(cbWatched.Checked, id);
            refreshContent(id);
        }
    }

    private void btnChangeInfo_Click(object sender, EventArgs e)
    {
        if (listViewMainContent.SelectedItems.Count == 1)
        {
            int id = Convert.ToInt32(listViewMainContent.FocusedItem.Name);
            if (dlgOpenFile.ShowDialog() == DialogResult.OK)
            {
                setPath(dlgOpenFile.FileName, id);
                refreshContent(id);
            }
        }
    }

    public void setSelectedImage(string PosterName)
    {
        if (listViewMainContent.SelectedItems.Count == 1)
        {
            int id = Convert.ToInt32(listViewMainContent.FocusedItem.Name);
            setImage(listPosters[Convert.ToInt32(PosterName)], id);
            refreshContent(id);
        }
    }

    private void btnFindCover_Click(object sender, EventArgs e)
    {
        frmSelectPoster wndSelectPoster = new frmSelectPoster();
        wndSelectPoster.Owner = this;
        listPosters.Clear();
        listPostersName.Clear();
        imagePoster.Images.Clear();
        wndSelectPoster.listPosters.LargeImageList = imagePoster;
        wndSelectPoster.listPosters.Items.Clear();

        if (IsEnabledSearchService("world-art.ru"))
        {
            try
            {
                if (SearchPosterWorldArtRu(wndSelectPoster)) return;
            }
            catch {}
        }
        if (IsEnabledSearchService("myanimelist.net"))
        {
            try
            {
                if (SearchPosterMyAnimeListNet(wndSelectPoster)) return;
            }
            catch {}
        }
        if (IsEnabledSearchService("tvrage.com"))
        {
          try
          {
            if (SearchPosterTVRageCom(wndSelectPoster)) return;
          }
          catch {}
        }
        if (IsEnabledSearchService("rottentomatoes.com"))
        {
          try
          {
            if (SearchPosterRottenTomatoesCom(wndSelectPoster)) return;
          }
          catch { }
        }

        if (wndSelectPoster.listPosters.Items.Count > 0)
        {
          wndSelectPoster.ShowDialog();
        }
        else
        {
            MessageBox.Show("Постеры не найдены", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        Cursor = Cursors.Default;
    }

    private bool SearchPosterRottenTomatoesCom(frmSelectPoster wndSelectPoster)
    {
      const string api_key = "3dqtf5rqa2exucjvt3gtxqbe";
      if (listViewMainContent.SelectedItems.Count > 0)
      {
        Cursor = Cursors.WaitCursor;
        int id = Convert.ToInt32(listViewMainContent.FocusedItem.Name);
        DbDataRecord record = GetItemInfo(id);
        int idMediaType = Convert.ToInt32(record["idMediaType"].ToString());
        string Title = record["Name"].ToString();
        if (idMediaType == 3 || idMediaType == 4 || idMediaType == 9)
        {
          Title = Title.Replace(" ", "+");
          WebRequest request = WebRequest.Create(new Uri(@"http://api.rottentomatoes.com/api/public/v1.0/movies.json?apikey=" + api_key + "&q=" + Title));
          WebResponse response = request.GetResponse();
          StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.Default);
          string jsoncode = reader.ReadToEnd().Trim();
          RootObject obj = JsonConvert.DeserializeObject<RootObject>(jsoncode);
          foreach (Movie movie in obj.movies)
          {
            WebClient wc = new WebClient();
            byte[] coverbyte = wc.DownloadData(new Uri(movie.posters.detailed));
            MemoryStream ms = new MemoryStream(coverbyte);
            try
            {
              Image img = Image.FromStream(ms);
              imagePoster.Images.Add(img);
              listPosters.Add(coverbyte);
              listPostersName.Add(movie.title);
            }
            catch { }
          }
          Cursor = Cursors.Default;
          if (listPosters.Count == 1)
          {
            setImage(listPosters[0], id);
            refreshContent(id);
            return true;
          }
          else
          {
            int count = wndSelectPoster.listPosters.Items.Count;
            wndSelectPoster.listPosters.Groups.Add("rottentomatoes.com", "rottentomatoes.com");
            for (int i = count; i < listPostersName.Count + count; i++)
            {
              wndSelectPoster.listPosters.Items.Add(Convert.ToString(i), listPostersName[i], i);
              wndSelectPoster.listPosters.Items[Convert.ToString(i)].Group = wndSelectPoster.listPosters.Groups["rottentomatoes.com"];
            }
            Cursor = Cursors.Default;
          }
        }
      }
      return false;
    }

    private bool SearchPosterTVRageCom(frmSelectPoster wndSelectPoster)
    {
      if (listViewMainContent.SelectedItems.Count > 0)
      {
        Cursor = Cursors.WaitCursor;
        int id = Convert.ToInt32(listViewMainContent.FocusedItem.Name);
        DbDataRecord record = GetItemInfo(id);
        int idMediaType = Convert.ToInt32(record["idMediaType"].ToString());
        string Title = record["Name"].ToString();
        if (idMediaType == 5)
        {
          Title = Title.Replace(" ", "+");
          WebRequest request = WebRequest.Create(new Uri(@"http://services.tvrage.com/feeds/search.php?show=" + Title));
          WebResponse response = request.GetResponse();
          StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.Default);
          string xmlCode = reader.ReadToEnd();
          reader.Close();
          response.Close();
          byte[] byteArray = new byte[xmlCode.Length];
          System.Text.ASCIIEncoding encoding = new
          System.Text.ASCIIEncoding();
          byteArray = encoding.GetBytes(xmlCode);
          MemoryStream stream = new MemoryStream(byteArray);
          stream.Seek(0, SeekOrigin.Begin);
          XmlDocument doc = new XmlDocument();
          doc.Load(stream);
          foreach (XmlNode entry in doc.DocumentElement.ChildNodes)
          {
            string link = "";
            if (entry.Name == "show")
            {
              foreach (XmlNode node in entry.ChildNodes)
              {
                if (node.Name == "showid")
                {
                  link = node.FirstChild.Value;
                  break;
                }
              }
              if (link.Length > 0)
              {
                request = WebRequest.Create(new Uri(@"http://services.tvrage.com/feeds/full_show_info.php?sid=" + link));
                response = request.GetResponse();
                reader = new StreamReader(response.GetResponseStream(), Encoding.Default);
                xmlCode = reader.ReadToEnd();
                reader.Close();
                response.Close();
                byteArray = new byte[xmlCode.Length];
                encoding = new System.Text.ASCIIEncoding();
                byteArray = encoding.GetBytes(xmlCode);
                stream = new MemoryStream(byteArray);
                stream.Seek(0, SeekOrigin.Begin);
                XmlDocument show = new XmlDocument();
                show.Load(stream);
                string title = "";
                string image = "";
                foreach (XmlNode show_entry in show.DocumentElement.ChildNodes)
                {
                  if (show_entry.Name == "name")
                  {
                    title = show_entry.FirstChild.Value;
                  }
                  else if (show_entry.Name == "image")
                  {
                    image = show_entry.FirstChild.Value;
                  }
                  if (title.Length > 0 && image.Length > 0)
                  {
                    break;
                  }
                }
                if (title.Length > 0 && image.Length > 0)
                {
                  WebClient wc = new WebClient();
                  byte[] coverbyte = wc.DownloadData(new Uri(image));
                  MemoryStream ms = new MemoryStream(coverbyte);
                  try
                  {
                    Image img = Image.FromStream(ms);
                    imagePoster.Images.Add(img);
                    listPosters.Add(coverbyte);
                    listPostersName.Add(title);
                  }
                  catch { }
                }
              }
            }
          }
          Cursor = Cursors.Default;
          if (listPosters.Count == 1)
          {
            setImage(listPosters[0], id);
            refreshContent(id);
            return true;
          }
          else
          {
            int count = wndSelectPoster.listPosters.Items.Count;
            wndSelectPoster.listPosters.Groups.Add("tvrage.com", "tvrage.com");
            for (int i = count; i < listPostersName.Count + count; i++)
            {
              wndSelectPoster.listPosters.Items.Add(Convert.ToString(i), listPostersName[i], i);
              wndSelectPoster.listPosters.Items[Convert.ToString(i)].Group = wndSelectPoster.listPosters.Groups["tvrage.com"];
            }
            Cursor = Cursors.Default;
          }
        }
      }
      return false;
    }

    private bool SearchPosterMyAnimeListNet(frmSelectPoster wndSelectPoster)
    {

        if (listViewMainContent.SelectedItems.Count > 0)
        {
            Cursor = Cursors.WaitCursor;
            int id = Convert.ToInt32(listViewMainContent.FocusedItem.Name);
            DbDataRecord record = GetItemInfo(id);
            int idMediaType = Convert.ToInt32(record["idMediaType"].ToString());
            string Title = record["Name"].ToString();
            if (idMediaType == 3 || idMediaType == 9)
            {
                Title = Title.Replace(" ", "+");
                WebRequest request = WebRequest.Create(new Uri(@"http://myanimelist.net/api/anime/search.xml?q=" + Title));
                DbDataRecord authRecord = GetAuthForSearchService("myanimelist.net");
                if (authRecord.IsDBNull(authRecord.GetOrdinal("Login")) == true || authRecord.IsDBNull(authRecord.GetOrdinal("Password")) == true)
                {
                    MessageBox.Show("Сервис myanimelist.net требует аутентификацию", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                string password = DecryptString(authRecord["Password"].ToString());
                request.Credentials = new NetworkCredential(authRecord["Login"].ToString(), password);
                request.PreAuthenticate = true;
                request.Method = "GET";
                WebResponse response = request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.Default);
                string xmlCode = reader.ReadToEnd();
                reader.Close();
                response.Close();
                byte[] byteArray = new byte[xmlCode.Length];
                System.Text.ASCIIEncoding encoding = new
                System.Text.ASCIIEncoding();
                byteArray = encoding.GetBytes(xmlCode);
                MemoryStream stream = new MemoryStream(byteArray);
                stream.Seek(0, SeekOrigin.Begin);
                XmlDocument doc = new XmlDocument();
                doc.Load(stream);
                foreach (XmlNode entry in doc.DocumentElement.ChildNodes)
                {
                    string image = "";
                    string title = "";
                    foreach (XmlNode node in entry.ChildNodes)
                    {
                        if (node.Name == "image")
                        {
                            image = node.FirstChild.Value;
                        }
                        else if (node.Name == "title")
                        {
                            title = node.FirstChild.Value;
                        }
                        if (image.Length > 0 && title.Length > 0)
                        {
                          break;
                        }
                    }
                    if (image.Length > 0 && title.Length > 0)
                    {
                        WebClient wc = new WebClient();
                        byte[] coverbyte = wc.DownloadData(new Uri(image));
                        MemoryStream ms = new MemoryStream(coverbyte);
                        try
                        {
                          Image img = Image.FromStream(ms);
                          imagePoster.Images.Add(img);
                          listPosters.Add(coverbyte);
                          listPostersName.Add(title);
                        }
                        catch { }
                    }
                }
                Cursor = Cursors.Default;
                if (listPosters.Count == 1)
                {
                    setImage(listPosters[0], id);
                    refreshContent(id);
                    return true;
                }
                else
                {
                  int count = wndSelectPoster.listPosters.Items.Count;
                  wndSelectPoster.listPosters.Groups.Add("myanimelist.net", "myanimelist.net");
                  for (int i = count; i < listPostersName.Count + count; i++)
                  {
                    wndSelectPoster.listPosters.Items.Add(Convert.ToString(i), listPostersName[i], i);
                    wndSelectPoster.listPosters.Items[Convert.ToString(i)].Group = wndSelectPoster.listPosters.Groups["myanimelist.net"];
                  }
                  Cursor = Cursors.Default;
                }
            }
        }
        return false;
    }

    private bool SearchPosterWorldArtRu(frmSelectPoster wndSelectPoster)
      {
          if (listViewMainContent.SelectedItems.Count > 0)
          {
              Cursor = Cursors.WaitCursor;
              int id = Convert.ToInt32(listViewMainContent.FocusedItem.Name);
              DbDataRecord record = GetItemInfo(id);
              int idMediaType = Convert.ToInt32(record["idMediaType"].ToString());
              string Title = record["Name"].ToString();
              string MediaType;
              switch (idMediaType)
              {
                  case 2:
                      MediaType = "games";
                      break;
                  case 4:
                  case 5:
                      MediaType = "cinema";
                      break;
                  case 3:
                  case 9:
                      MediaType = "animation";
                      break;
                  default:
                      MediaType = "all";
                      break;

              }
              Title = Title.Replace(" ", "+");
              WebRequest request = WebRequest.Create(new Uri(@"http://www.world-art.ru/search.php?public_search=" + Title + "&global_sector=" + MediaType));
              WebResponse response = request.GetResponse();
              StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.Default);
              string htmlCode = reader.ReadToEnd();
              reader.Close();
              response.Close();

              Regex regex = new Regex(@"(?<=<a .*?href\s*=\s*"")[^""]+(?="".*?class='estimation'>)");
              Match match = regex.Match(htmlCode);
              while (match.Success)
              {
                  string result = "http://www.world-art.ru/" + match.Value;
                  request = WebRequest.Create(new Uri(result));
                  response = request.GetResponse();
                  reader = new StreamReader(response.GetResponseStream(), Encoding.Default);
                  string htmlItemCode = reader.ReadToEnd();
                  reader.Close();
                  response.Close();

                  Regex regex_title = new Regex(@"(?<=<html><head><title>)[^""]+(?=</title>)");
                  Match match_title = regex_title.Match(htmlItemCode);
                  if (match_title.Success)
                  {
                      Regex regex_cover = new Regex(@"(?<=<img .*?src\s*=\s*')[^']+(?='.*?poster.php.*?>)");
                      Match match_cover = regex_cover.Match(htmlItemCode);
                      if (match_cover.Success)
                      {
                          string coverpath = "http://www.world-art.ru/" + MediaType + "/" + match_cover.Value;
                          WebClient wc = new WebClient();
                          byte[] coverbyte = wc.DownloadData(new Uri(coverpath));
                          MemoryStream ms = new MemoryStream(coverbyte);
                          listPosters.Add(coverbyte);
                          listPostersName.Add(match_title.Value);
                          Image image = Image.FromStream(ms);
                          imagePoster.Images.Add(image);
                      }
                      else
                      {
                          regex_cover = new Regex(@"(?<=<img .*?src\s*=\s*')[img//0-9.jpg]+(?='.*?>)");
                          match_cover = regex_cover.Match(htmlItemCode);
                          if (match_cover.Success)
                          {
                              string coverpath = "http://www.world-art.ru/" + MediaType + "/" + match_cover.Value;
                              WebClient wc = new WebClient();
                              byte[] coverbyte = wc.DownloadData(new Uri(coverpath));
                              MemoryStream ms = new MemoryStream(coverbyte);
                              listPosters.Add(coverbyte);
                              listPostersName.Add(match_title.Value);
                              Image image = Image.FromStream(ms);
                              imagePoster.Images.Add(image);
                          }
                          else
                          {
                              regex_cover = new Regex(@"(?<=<img .*?src\s*=\s*'http://www.world-art.ru/" + MediaType + "/img/)[/0-9.jpg]+(?='.*?>)");
                              match_cover = regex_cover.Match(htmlItemCode);
                              if (match_cover.Success)
                              {
                                  string coverpath = "http://www.world-art.ru/" + MediaType + "/img/" + match_cover.Value;
                                  WebClient wc = new WebClient();
                                  byte[] coverbyte = wc.DownloadData(new Uri(coverpath));
                                  MemoryStream ms = new MemoryStream(coverbyte);
                                  listPosters.Add(coverbyte);
                                  listPostersName.Add(match_title.Value);
                                  Image image = Image.FromStream(ms);
                                  imagePoster.Images.Add(image);
                              }
                          }
                      }
                  }
                  match = match.NextMatch();
              }
              if (listPosters.Count == 0)
              {
                  regex = new Regex(@"(?<=<meta http-equiv='Refresh'.*?url\s*=\s*)[^']+(?='>)");
                  match = regex.Match(htmlCode);
                  if (match.Success)
                  {
                      string result = "http://www.world-art.ru/" + match.Value;
                      request = WebRequest.Create(new Uri(result));
                      response = request.GetResponse();
                      reader = new StreamReader(response.GetResponseStream(), Encoding.Default);
                      string htmlItemCode = reader.ReadToEnd();
                      reader.Close();
                      response.Close();
                      Regex regex_title = new Regex(@"(?<=<html><head><title>)[^""]+(?=</title>)");
                      Match match_title = regex_title.Match(htmlItemCode);
                      if (match_title.Success)
                      {
                          Regex regex_cover = new Regex(@"(?<=<img .*?src\s*=\s*')[^']+(?='.*?poster.php.*?>)");
                          Match match_cover = regex_cover.Match(htmlItemCode);
                          if (match_cover.Success)
                          {
                              string coverpath = "http://www.world-art.ru/" + MediaType + "/" + match_cover.Value;
                              WebClient wc = new WebClient();
                              byte[] coverbyte = wc.DownloadData(new Uri(coverpath));
                              MemoryStream ms = new MemoryStream(coverbyte);
                              listPosters.Add(coverbyte);
                              listPostersName.Add(match_title.Value);
                              Image image = Image.FromStream(ms);
                              imagePoster.Images.Add(image);
                          }
                          else
                          {
                              regex_cover = new Regex(@"(?<=<img .*?src\s*=\s*')[img//0-9.jpg]+(?='.*?>)");
                              match_cover = regex_cover.Match(htmlItemCode);
                              if (match_cover.Success)
                              {
                                  string coverpath = "http://www.world-art.ru/" + MediaType + "/" + match_cover.Value;
                                  WebClient wc = new WebClient();
                                  byte[] coverbyte = wc.DownloadData(new Uri(coverpath));
                                  MemoryStream ms = new MemoryStream(coverbyte);
                                  listPosters.Add(coverbyte);
                                  listPostersName.Add(match_title.Value);
                                  Image image = Image.FromStream(ms);
                                  imagePoster.Images.Add(image);
                              }
                              else
                              {
                                  regex_cover = new Regex(@"(?<=<img .*?src\s*=\s*'http://www.world-art.ru/" + MediaType + "/img/)[/0-9.jpg]+(?='.*?>)");
                                  match_cover = regex_cover.Match(htmlItemCode);
                                  if (match_cover.Success)
                                  {
                                      string coverpath = "http://www.world-art.ru/" + MediaType + "/img/" + match_cover.Value;
                                      WebClient wc = new WebClient();
                                      byte[] coverbyte = wc.DownloadData(new Uri(coverpath));
                                      MemoryStream ms = new MemoryStream(coverbyte);
                                      listPosters.Add(coverbyte);
                                      listPostersName.Add(match_title.Value);
                                      Image image = Image.FromStream(ms);
                                      imagePoster.Images.Add(image);
                                  }
                              }
                          }
                      }
                  }
              }
              Cursor = Cursors.Default;
              if (listPosters.Count == 1)
              {
                  setImage(listPosters[0], id);
                  refreshContent(id);
                  return true;
              }
              else
              {
                  int count = wndSelectPoster.listPosters.Items.Count;
                  wndSelectPoster.listPosters.Groups.Add("world-art.ru", "world-art.ru");
                  for (int i = count; i < listPostersName.Count + count; i++)
                  {
                      wndSelectPoster.listPosters.Items.Add(Convert.ToString(i), listPostersName[i], i);
                      wndSelectPoster.listPosters.Items[Convert.ToString(i)].Group = wndSelectPoster.listPosters.Groups["world-art.ru"];
                  }
                  Cursor = Cursors.Default;
              }
          }
          return false;
      }

      private void menuPoster_Opening(object sender, CancelEventArgs e)
      {
          if (listViewMainContent.SelectedItems.Count == 1)
          {
                int id = Convert.ToInt32(listViewMainContent.FocusedItem.Name);
                DbDataRecord record = GetItemInfo(id);
                if (record.IsDBNull(record.GetOrdinal("idParent")) == true)
                    e.Cancel = true;
                else
                {
                    int parent = Convert.ToInt32(record["idParent"].ToString());
                    if (parent <= 0)
                    {
                      mSetPosterFromParent.Enabled = false;
                    }
                    else
                    {
                      mSetPosterFromParent.Enabled = true;
                    }
                }
          }
          else
          {
              e.Cancel = true;
          }
      }

      private void mSetPosterFromParent_Click(object sender, EventArgs e)
      {
          if (listViewMainContent.SelectedItems.Count > 0)
          {
              foreach (ListViewItem item in listViewMainContent.SelectedItems)
              {
                  int id = Convert.ToInt32(item.Name);
                  setCoverFromParent(id);
                  if (listViewMainContent.SelectedItems.Count == 1)
                  {
                      refreshContent(id);
                      return;
                  }
              }
              refreshContent(0);
          }
      }

      private void menuSearchServices_Click(object sender, EventArgs e)
      {
          frmSearchServices wndSearchServices = new frmSearchServices(connection);
          wndSearchServices.Owner = this;          

          wndSearchServices.ShowDialog();
      }

      private void menuMainList_Opening(object sender, CancelEventArgs e)
      {
          menuMainListAddGroup.Enabled = false;
          menuMainListAddElement.Enabled = false;
          menuMainListCut.Enabled = false;
          menuMainListCopy.Enabled = false;
          menuMainListPaste.Enabled = false;
          menuMainListDelete.Enabled = false;
          menuMainListSetCoverFromParent.Enabled = false;
          if (listViewMainContent.SelectedItems.Count > 0)
          {
              DbDataRecord record = GetItemInfo(Convert.ToInt32(listViewMainContent.FocusedItem.Name));
              if (Convert.ToInt32(record["id"].ToString()) > 0)
              {
                   menuMainListCut.Enabled = true;
                   menuMainListCopy.Enabled = true;
                   menuMainListDelete.Enabled = true;
                   menuMainListSetCoverFromParent.Enabled = true;
              }
              if (elementsStack.Count > 0 && listViewMainContent.SelectedItems.Count == 1)
              {
                   menuMainListPaste.Enabled = true;
              }
          }
          else if (pathStack.Count > 1)
          {
              int key = pathStack.Pop();
              DbDataRecord record = GetItemInfo(key);
              if (record.GetBoolean(record.GetOrdinal("AllowChildren")) == true)
              {
                  menuMainListAddGroup.Enabled = true;
                  menuMainListAddElement.Enabled = true;
                  if (elementsStack.Count > 0)
                  {
                      menuMainListPaste.Enabled = true;
                  }
              }
              pathStack.Push(key);
          }
      }

      private void menuMainListCut_Click(object sender, EventArgs e)
      {
          if (listViewMainContent.SelectedItems.Count > 0)
          {
              if (elementsStack.Count > 0)
              {
                  elementsStack.Clear();
              }
              foreach(ListViewItem item in listViewMainContent.SelectedItems)
              {
                  elementsStack.Push(Convert.ToInt32(item.Name));
              }
              bDeleteAfterPaste = true;
          }
      }

      private void menuMainListCopy_Click(object sender, EventArgs e)
      {
          if (listViewMainContent.SelectedItems.Count > 0)
          {
              if (elementsStack.Count > 0)
              {
                  elementsStack.Clear();
              }
              foreach (ListViewItem item in listViewMainContent.SelectedItems)
              {
                  elementsStack.Push(Convert.ToInt32(item.Name));
              }
              bDeleteAfterPaste = false;
          }
      }

      private void menuMainListPaste_Click(object sender, EventArgs e)
      {
          if (elementsStack.Count > 0)
          {
              int idTarget = 0;
              if (listViewMainContent.SelectedItems.Count == 1)
              {
                  idTarget = Convert.ToInt32(listViewMainContent.FocusedItem.Name);
              }
              else if(pathStack.Count > 1)
              {
                  idTarget = pathStack.Pop();
                  pathStack.Push(idTarget);
              }
              if (idTarget != 0)
              {
                  int id;
                  while (elementsStack.Count > 0)
                  {
                      id = elementsStack.Pop();
                      if (CanPaste(id, idTarget) == false)
                      {
                          DbDataRecord item = GetItemInfo(id);
                          MessageBox.Show("Невозможно вставить объект:\n" + item["Name"].ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                          return;
                      }
                      else
                      {
                          if (bDeleteAfterPaste == false)
                          {
                            CopyItem(id, idTarget);
                          }
                          else
                          {
                            MoveItem(id, idTarget);
                          }
                          refreshContent(0);
                      }
                  }
              }
          }
      }

      private void menuSetCoverFromClipboard_Click(object sender, EventArgs e)
      {
        if (listViewMainContent.SelectedItems.Count > 0)
        {
          foreach (ListViewItem item in listViewMainContent.SelectedItems)
          {
            int id = Convert.ToInt32(item.Name);
            DbDataRecord record = GetItemInfo(id);
            if (Convert.ToInt32(record["IsReadOnly"].ToString()) == 0)
            {
              if (Clipboard.ContainsImage())
              {
                Image image = Clipboard.GetImage();
                MemoryStream ms = new MemoryStream();
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] bytes = ms.ToArray();
                setImage(bytes, id);
                if (listViewMainContent.SelectedItems.Count == 1)
                {
                  refreshContent(id);
                  return;
                }
              }
            }
          }
          refreshContent(0);
        }
      }

      private void menuDeletePoster_Click(object sender, EventArgs e)
      {
        if (listViewMainContent.SelectedItems.Count > 0)
        {
          foreach (ListViewItem item in listViewMainContent.SelectedItems)
          {
            int id = Convert.ToInt32(item.Name);
            deleteCover(id);
            if (listViewMainContent.SelectedItems.Count == 1)
            {
              refreshContent(id);
              return;
            }
          }
        }
        refreshContent(0);
      }

      private void btnPlay_Click(object sender, EventArgs e)
      {
        if (MediaPath.Text.Length > 0 && MediaPath.ForeColor == Color.Black)
        {
          System.Diagnostics.Process.Start(MediaPath.Text);
        }
      }
  }
}
