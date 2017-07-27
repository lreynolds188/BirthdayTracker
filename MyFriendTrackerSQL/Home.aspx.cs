using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyFriendTrackerSQL
{
    public partial class _Default : Page
    {
        private static int maxIndex;
        private static int currentIndex;
        private static bool blnNew;
        private static DataSet BirthdayData = new DataSet();
        private static DataRow BirthdayRow;

        protected void Page_Load(object sender, EventArgs e)
        {
            // what do you mean the project won't commit!
            if (IsPostBack) { return; }
            BirthdayData.Tables.Add("Name");
            BirthdayData.Tables.Add("DateOfBirth");
            BirthdayData.Tables.Add("Likes");
            BirthdayData.Tables.Add("Dislikes");
            LoadBirthdays();
        }

        private void LoadBirthdays()
        {
            BirthdayData.Clear();
            BirthdayData = Utilities.Utility.LoadBirthdays();
            maxIndex = BirthdayData.Tables[0].Rows.Count;
            DisplayIndex(currentIndex);
        }

        private void DisplayIndex(int index)
        {
            try
            {
                BirthdayRow = BirthdayData.Tables[0].Rows[index];
                txtName.Text = BirthdayRow.ItemArray.GetValue(1).ToString();
                txtDoB.Text = BirthdayRow.ItemArray.GetValue(2).ToString();
                txtLikes.Text = BirthdayRow.ItemArray.GetValue(3).ToString();
                txtDislikes.Text = BirthdayRow.ItemArray.GetValue(4).ToString();
                blnNew = false;
            }
            catch
            {

            }
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            if (currentIndex < maxIndex - 1)
            {
                currentIndex++;
                DisplayIndex(currentIndex);
            }
        }

        protected void btnPrev_Click(object sender, EventArgs e)
        {
            if (currentIndex > 0)
            {
                currentIndex--;
                DisplayIndex(currentIndex);
            }
        }

        protected void btnLast_Click(object sender, EventArgs e)
        {
            currentIndex = maxIndex - 1;
            DisplayIndex(currentIndex);
        }

        protected void btnFirst_Click(object sender, EventArgs e)
        {
            currentIndex = 0;
            DisplayIndex(currentIndex);
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            currentIndex = maxIndex;
            blnNew = true;
            txtName.Text = "";
            txtDoB.Text = "";
            txtLikes.Text = "";
            txtDislikes.Text = "";
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (blnNew)
            {
                Utilities.Utility.AddBirthday(txtName.Text, txtDoB.Text, txtLikes.Text, txtDislikes.Text);
                LoadBirthdays();
            }
            else
            {
                Utilities.Utility.UpdateBirthday(BirthdayRow.ItemArray.GetValue(1).ToString(), txtName.Text, txtDoB.Text, txtLikes.Text, txtDislikes.Text);
                LoadBirthdays();
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Utilities.Utility.DeleteBirthday(txtName.Text);
            if (currentIndex != 0)
            {
                currentIndex--;
            }
            LoadBirthdays();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            int returnedIndex = Utilities.Utility.SearchBirthday(txtSearch.Text, BirthdayData);
            if (returnedIndex != -1)
            {
                currentIndex = returnedIndex;
                DisplayIndex(currentIndex);
            }
        }
    }
}