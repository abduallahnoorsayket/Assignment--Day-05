using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentFormSayket
{
    public partial class StudentInfo : Form
    {
       // private const double V = 0.00;
        List<int> ids = new List<int> { };
        List<string> names = new List<string> { };


        List<string> mobiles = new List<string> { };
        List<int> ages = new List<int> { };
        List<string> addresss = new List<string> { };
        List<double> gpas = new List<double>{ };
        //List<string> orders = new List<string> { };
        int i;
        double max = 0.0;
        double min = 0.0;
        double total = 0.00;
        double sum = 0.00;
        double avg = 0.00;
        int id;

        int flag = -1, index = -1;

        public StudentInfo()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {

            try
            {


                if (String.IsNullOrEmpty(idTextBox.Text))
                {
                    MessageBox.Show("Please enter ID!");
                    return;
                }
                else if (String.IsNullOrEmpty(nameTextBox.Text))
                {

                    MessageBox.Show("Please  enter  Name !");
                    return;

                }


                else if (String.IsNullOrEmpty(mobileTextBox.Text))
                {

                    MessageBox.Show("Please  enter mobile  !");
                    return;

                }

                else if (String.IsNullOrEmpty(ageTextBox.Text))
                {

                    MessageBox.Show("Please  enter Age  !");
                    return;

                }

                else if (idTextBox.Text.Length != 4)
                {
                    MessageBox.Show("Id  must be 4  characters long\n");


                }


                else if (nameTextBox.Text.Length > 30)
                {
                    MessageBox.Show("Name can not more than 30 character\n");


                }

                else if (mobileTextBox.Text.Length != 11)
                {
                    MessageBox.Show("mobile  must be 11 characters long\n");


                }

               

                else if (Convert.ToDouble(gpaTextBox.Text) < 0 || Convert.ToDouble(gpaTextBox.Text) > 4)
                {
                    MessageBox.Show("gpa point must be between 0 to 4");
                }


                else
                {
                    Addinfo(Convert.ToInt32(idTextBox.Text), nameTextBox.Text, mobileTextBox.Text, Convert.ToInt32(ageTextBox.Text),
                        addressTextBox.Text, Convert.ToDouble(gpaTextBox.Text));
                }


              }

            catch(Exception exception)
            {
                MessageBox.Show(exception.Message);
            }


            ShowInfo();

        }





        private void Addinfo(int id, string name, string mobile, int age, string address, double gpa)
        {

            for (int i = 0; i < ids.Count(); i++)
            {
                if (id == ids[i])
                {
                    MessageBox.Show("  ID  already exists.");
                    return;
                }

            }

            ids.Add(id);

            names.Add(name);
            for (int i = 0; i < mobiles.Count(); i++)
            {
                if (mobile == mobiles[i])
                {
                    MessageBox.Show("Contact no. already exists.");
                    return;
                }

            }


            mobiles.Add(mobile);
            ages.Add(age);
            addresss.Add(address);
            gpas.Add(gpa);


        }





        private void ShowInfo()
        {

            for (i = 0; i < mobiles.Count(); i++)
            {
                richTextBox.Text = "";
                
                richTextBox.Text += "\n\t ID :" + ids[i] + "";
                richTextBox.Text += "\t Studnet Name :" + names[i] + "";
                richTextBox.Text += "\tContact No :" + mobiles[i] + "";
                richTextBox.Text += "\t Age :" + ages[i] + "";
                richTextBox.Text += "\tAddress :" + addresss[i] + "";
                richTextBox.Text += "\t GPA :" + gpas[i] + "";

                

                idTextBox.Text = "";
                nameTextBox.Text = "";
                mobileTextBox.Text = "";
                ageTextBox.Text = "";
                addressTextBox.Text = "";
                gpaTextBox.Text = "";
                



            }

        }

        private void ShowButton_Click(object sender, EventArgs e)
        {
            richTextBox.Text = "";
            for (i = 0; i < names.Count(); i++)
            {
               
                richTextBox.Text += "\n\t ID :" + ids[i] + "";
                richTextBox.Text += "\t Studnet Name :" + names[i] + "";
                richTextBox.Text += "\tContact No :" + mobiles[i] + "";
                richTextBox.Text += "\t Age :" + ages[i] + "";
                richTextBox.Text += "\tAddress :" + addresss[i] + "";
                richTextBox.Text += "\t GPA :" + gpas[i] + "";

                richTextBox.Text += "\n---------------------------------------------------\n";

                idTextBox.Text = "";
                nameTextBox.Text = "";
                mobileTextBox.Text = "";
                ageTextBox.Text = "";
                addressTextBox.Text = "";
                gpaTextBox.Text = "";




            }



            max = gpas.Max();

            maxTextBox.Text = Convert.ToString(max);

          
               int  a= gpas.IndexOf(max);
            maxNameTextBox.Text = names[a];

            min = gpas.Min();
            minTextBox.Text = Convert.ToString(min);
            int b = gpas.IndexOf(min);
            minNameTextBox.Text = names[b];


            sum=gpas.Sum();
            totalTextBox.Text = Convert.ToString(sum);

            avg = sum / gpas.Count();
            avgTextBox.Text = Convert.ToString(avg);


            return;
        }





        private void button1_Click(object sender, EventArgs e)
        {
           // richTextBox.Text = "";

            if (searchTextBoxForSearch.Text == "")
            {
                MessageBox.Show("Enter search value");
                return;
            }
            

            if (IdRadioButton.Checked == false && NameRadioButton.Checked==false && MobileRadioButton.Checked==false)
            {
                MessageBox.Show("Please select any button !!");
                return;
            }


          //  int flag = -1, index = -1;

            if (IdRadioButton.Checked == true)
            {
                try
                {
                    //ids.Add(id);
                     id = Convert.ToInt32(searchTextBoxForSearch.Text);
                    index = ids.IndexOf(id);
                    flag = 1;
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex + " \nEneter numeric value");
                    return;
                }


            }
            else if (NameRadioButton.Checked == true)
            {
                index = names.IndexOf(searchTextBoxForSearch.Text);
                flag = 1;
            }
            else if (MobileRadioButton.Checked == true)
            {
                index = mobiles.IndexOf(searchTextBoxForSearch.Text);
                flag = 1;
            }

            if (index >= 0 && flag == 1)
            {

                richTextBox.Text = "";


                richTextBox.Text += "\n\t ID :"  +ids[index]+ "";
                richTextBox.Text += "\t Studnet Name :" + names[index] + "";
                richTextBox.Text += "\tContact No :" + mobiles[index] + "";
                richTextBox.Text += "\t Age :" + ages[index] + "";
                richTextBox.Text += "\tAddress :" + addresss[index] + "";
                richTextBox.Text += "\t GPA :" + gpas[index] ;

                richTextBox.Text += "\n---------------------------------------------------------------------------------------------------------------\n";



                MessageBox.Show("result found");

            }
            else
            {
                MessageBox.Show("no result found");
            }


        }
    }
    }  

