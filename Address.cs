using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C_App7
{
    public partial class Address : Form
    {
        BindingList<Person> listPerson = new BindingList<Person>();
        public Address()
        {
            InitializeComponent();

            comboBox.Items.Add("株式会社 A");
            comboBox.Items.Add("株式会社 B");

            //データグリッドヘッダ、インスタンスメンバで作成
            dataGridViewAll.DataSource = listPerson;
        }

        /*        private void checkBox3_CheckedChanged(object sender, EventArgs e)
                {

                }

                private void checkBox4_CheckedChanged(object sender, EventArgs e)
                {


                }

                private void dataGridViewAll_Click(object sender, DataGridViewCellEventArgs e)
                {

                }
         
         */



        private void EndButton_Click(object sender, EventArgs e)
        {
            //終了ボタン押下
            //アプリ終了
            Application.Exit();
        }

        private void addButton_Click(object sender, EventArgs e)
        {

            //コンボボックスの値空でないか判定
            SetComboBoxCompany(comboBox.Text);

            //ボタン押下毎
            //住所を入れるインスタンス（オブジェクト）生成
            Person person = new Person();

            //データセット
            //チェックリスト列挙メソッドGetCheckBoxGroup()
            person.SetData(textBoxName.Text, textBoxMail.Text,textBoxAddress.Text,comboBox.Text, GetCheckBoxGroup());
            
            //リストにインスタンス追加
            listPerson.Add(person);

            ClearInputControl();

        }

        private void SetComboBoxCompany(string company)
        {
            //コンボボックスの値空でないか判定
            if (!comboBox.Items.Contains(company))
            {
                comboBox.Items.Add (company);
            }
        }


        private List<Person.GroupType> GetCheckBoxGroup()
        {
            List<Person.GroupType> listGroup = new List<Person.GroupType>();

            if (checkWork.Checked) listGroup.Add(Person.GroupType.仕事);
            if (checkClinic.Checked) listGroup.Add(Person.GroupType.病院);
            if (checkStore.Checked) listGroup.Add(Person.GroupType.お店);
            if (checkOther.Checked) listGroup.Add(Person.GroupType.その他);

            return listGroup;
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            //更新ボタン押下
            

        }
        private void deleteButton_Click(object sender, EventArgs e)
        {
            //削除ボタン押下
             dataGridViewAll.Rows.Remove(dataGridViewAll.CurrentRow);
        }

  

        private void ClearInputControl()
        {
            textBoxName.Clear();
            textBoxMail.Clear();
            textBoxAddress.Clear();

            comboBox.Text = "";

            checkWork.Checked = false;
            checkClinic.Checked = false;
            checkStore.Checked = false;
            checkOther.Checked = false;

        }

        private void dataGridViewAll_Click(object sender, EventArgs e)
        {
            Person selectPerson = listPerson[dataGridViewAll.CurrentRow.Index];
            textBoxName.Text = selectPerson.Name;
            textBoxMail.Text = selectPerson.Mail;
            textBoxAddress.Text = selectPerson.Address;
            comboBox.Text = selectPerson.Company;


            foreach (Person.GroupType groupType in selectPerson.ListGroup)
            {
                switch (groupType)
                {
                    case Person.GroupType.仕事:
                        checkWork.Checked = true;
                    break;

                    case Person.GroupType.お店:
                        checkStore.Checked = true;
                    break;

                    case Person.GroupType.病院:
                        checkClinic.Checked = true;
                    break;
                    case Person.GroupType.その他:
                        checkOther.Checked = true;
                    break;
                }
            }


        }
    }
}
