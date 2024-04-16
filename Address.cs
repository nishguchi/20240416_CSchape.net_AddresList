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

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

        }

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
            person.SetData(textBoxName.Text, textBoxMail.Text,textBoxAddress.Text,comboBox.Text, GetCheckBoxGroup());
            
            //リストにインスタンス追加
            listPerson.Add(person);

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





    }
}
