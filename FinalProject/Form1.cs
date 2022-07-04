using MyClasses;
using Proj1;
using System.Collections;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace FinalProject
{
    public partial class Form1 : Form
    {
        public HashTable hashT = new HashTable();
        public string loggerAddr = "..\\..\\..\\logger.txt";
        public string file1 = "..\\..\\..\\datasets\\drugs1.txt";
        public string file2 = "..\\..\\..\\datasets\\diseases2.txt";
        public string file3 = "..\\..\\..\\datasets\\effects3.txt";
        public string file4 = "..\\..\\..\\datasets\\alergies4.txt";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {            
            Stopwatch sw = Stopwatch.StartNew();
            string drug_effects_lines = File.ReadAllText(this.file3);
            string disease_alergies_lines = File.ReadAllText(this.file4);
            string drugs_lines = File.ReadAllText(this.file1);
            string diseases_lines = File.ReadAllText(this.file2);
            string[] seperator = new string[] { "\r\n" };
            var druglinesArr = drug_effects_lines.Split(seperator, StringSplitOptions.RemoveEmptyEntries);
            var diseaselinesArr = disease_alergies_lines.Split(seperator, StringSplitOptions.RemoveEmptyEntries);
            var druglinesLeng = druglinesArr.Length;
            var diseaselinesLeng = diseaselinesArr.Length;
            this.hashT.LoadDrugs(drugs_lines);
            this.hashT.LoadDiseases(diseases_lines);
            for (int i = 0; i < druglinesLeng || i < diseaselinesLeng; i++)
            {
                if (i < druglinesLeng)
                    this.hashT.LoadEffects(druglinesArr[i]);
                if (i < diseaselinesLeng)
                    this.hashT.LoadAlergies(diseaselinesArr[i]);
            }
            var microsec = sw.Elapsed.TotalMilliseconds * 1000;
            File.AppendAllText(this.loggerAddr,"data loading to RAM. time taken in micro seconds: " + microsec.ToString("0.000")+"\n");
            MessageBox.Show("Done!");
        }

        private void DrugStorePanel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if( null != DrugStorePanel.SelectedItem )
            {
 
                string name = (string) (DrugStorePanel.SelectedItem);
                if(name.StartsWith("Dis_"))
                {
                    name = name.Split(new string[] {"Dis_"}, StringSplitOptions.RemoveEmptyEntries)[0];
                    string info = (this.hashT.diseases[name] as Disease).ToString();
                    MessageBox.Show(info);
                }
                if(name.StartsWith("Drug_"))
                {
                    name = name.Split(new String[] { "Drug_" }, StringSplitOptions.RemoveEmptyEntries)[0];
                    string info = (this.hashT.drugs[name] as Drug).ToString();
                    MessageBox.Show(info);
                }
            }
        }

        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            DrugStorePanel.Items.Clear();
            if(drugOrDiseaseCombo.Text == "Diseases" && !string.IsNullOrEmpty(searchBox.Text))
            {
                foreach(DictionaryEntry dis in this.hashT.diseases)
                {
                    if( ((string) dis.Key).StartsWith(searchBox.Text) )
                        DrugStorePanel.Items.Add("Dis_" + (string) dis.Key);
                }
            }
            if(drugOrDiseaseCombo.Text == "Drugs" && !string.IsNullOrEmpty (searchBox.Text))
            {
                foreach(DictionaryEntry drug in this.hashT.drugs)
                {
                    if ( ( (string)drug.Key ).StartsWith(searchBox.Text) )
                    {
                        DrugStorePanel.Items.Add("Drug_"+ (string)drug.Key);
                    }
                }
            }
        }

        private void checkAlergyButton_Click(object sender, EventArgs e)
        {
            if (null != DrugStorePanel.SelectedItem)
            {
                string disease = (string)(DrugStorePanel.SelectedItem);
                if (disease.StartsWith("Dis_"))
                {
                    string dis_name = disease.Split(new string[] { "Dis_" }, StringSplitOptions.RemoveEmptyEntries)[0];
                    string drug_name = checkAlergyInput.Text;
                    Disease dis = this.hashT.diseases[dis_name] as Disease;
                    MessageBox.Show(dis.drugAlergySign(drug_name));
                }
                else
                    MessageBox.Show("باید یک بیماری را انتخاب کنید ولی دارو انتخاب کرده اید");
            }
            else
                MessageBox.Show("موردی انتخاب نشده است");
        }

        private void addDiseaseButton_Click(object sender, EventArgs e)
        {
            if(addDiseaseInput.Text != null)
            {
                try
                {
                    Stopwatch sw = Stopwatch.StartNew();
                    this.hashT.AddDisease(addDiseaseInput.Text);
                    double time = sw.Elapsed.TotalMilliseconds * 1000;
                    MessageBox.Show("بیماری با موفقیت اضافه شد");
                    File.AppendAllText(this.loggerAddr, "adding disease " + addDiseaseInput.Text + " successfully. time taken in micro seconds : " + time + "\n");
                    sw.Stop();
                }
                catch (Exception ex)
                {
                    string problem = "adding disease " + addDiseaseInput.Text + " failed. Discribtion : " + ex.Message;
                    File.AppendAllText(this.loggerAddr,problem+"\n");
                    MessageBox.Show(problem);
                }
            }
        }
        private void addDrugButton_Click(object sender, EventArgs e)
        {
            Regex reg = new Regex(@"^[a-zA-Z]+ ?: ?[0-9]+$");
            if (addDrugInput.Text!=null && reg.IsMatch(addDrugInput.Text))
            {
                try
                {
                    Stopwatch sw = Stopwatch.StartNew();
                    double time;
                    this.hashT.AddDrug("Drug_" + addDrugInput.Text);
                    time = sw.Elapsed.TotalMilliseconds * 1000;
                    MessageBox.Show("دارو با موفقیت اضافه شد");
                    File.AppendAllText(this.loggerAddr, "adding drug " + addDrugInput.Text + " successfully. time taken in micro seconds : " + time + "\n");
                    sw.Stop();
                }
                catch (Exception ex)
                {
                    string problem = "adding drug " + addDrugInput.Text + " failed. Discribtion : " + ex.Message;
                    File.AppendAllText(this.loggerAddr, problem+"\n");
                    MessageBox.Show(problem);
                }
            }
            else
                MessageBox.Show("دارو به فرم درستی وارد نشد");
        }

        private void deleteItemButton_Click(object sender, EventArgs e)
        {
            string name = (string)(DrugStorePanel.SelectedItem);
            if (name.StartsWith("Dis_"))
            {
                name = name.Split(new string[] { "Dis_" }, StringSplitOptions.RemoveEmptyEntries)[0];
                try
                {
                    Stopwatch stopwatch = Stopwatch.StartNew();
                    double time;
                    if (this.hashT.DeleteDisease(name))
                    {
                        time = stopwatch.Elapsed.TotalMilliseconds * 1000;
                        MessageBox.Show("با موفقیت حذف شد");
                        File.AppendAllText(this.loggerAddr, "deleting disease " + name + " successfully. time taken in micro seconds : " + time+"\n");
                        stopwatch.Stop();
                        this.searchBox_TextChanged(sender, new EventArgs());
                    }
                }
                catch (Exception ex)
                {
                    string problem = "Deleting disease " + name + " Discribtion : " + ex.Message;
                    MessageBox.Show(problem);
                    File.AppendAllText(this.loggerAddr, problem+"\n");
                }
            }
            if (name.StartsWith("Drug_"))
            {
                Stopwatch stopwatch = Stopwatch.StartNew();
                double time;
                name = name.Split(new String[] { "Drug_" }, StringSplitOptions.RemoveEmptyEntries)[0];
                try
                {
                    if (this.hashT.DeleteDrug(name))
                    {
                        time = stopwatch.Elapsed.TotalMilliseconds * 1000;
                        MessageBox.Show("با موفقیت حذف شد");
                        File.AppendAllText(this.loggerAddr, "deleting disease " + name + " successfully. time taken in micro seconds : " + time + "\n");
                        stopwatch.Stop();
                        this.searchBox_TextChanged(sender, new EventArgs());
                    }
                }
                catch (Exception ex)
                {
                    string problem = "Deleting drug " + name +" failed. Discribtion : " + ex.Message;
                    MessageBox.Show(problem);
                    File.AppendAllText(this.loggerAddr, problem + "\n");
                }
            }
        }

        private void priceIncreaseButton_Click(object sender, EventArgs e)
        {
            double percent;
            if(double.TryParse(priceIncreaseInput.Text, out percent) )
            {
                try
                {
                    Stopwatch sw = Stopwatch.StartNew();
                    this.hashT.IncreaseByInflationRate(percent);
                    double time = sw.Elapsed.TotalMilliseconds * 1000;
                    MessageBox.Show("با موفقیت اعمال شد");
                    File.AppendAllText(this.loggerAddr, "increasing prices by inflation rate succeeded. time taken in micro seconds : " + time);
                    sw.Stop();
                }
                catch(Exception ex)
                {
                    string info = "increasing prices failes. Discribtion : " + ex.Message;
                    MessageBox.Show(info);
                    File.AppendAllText(this.loggerAddr, info + "\n");
                }
            }
            else
                MessageBox.Show("مقدار عددی وارد شود");
        }

        private void positiveDrugsInput_Click(object sender, EventArgs e)
        {
            if (null != DrugStorePanel.SelectedItem)
            {
                string disease = (string)(DrugStorePanel.SelectedItem);
                if (disease.StartsWith("Dis_"))
                {
                    string dis_name = disease.Split(new string[] { "Dis_" }, StringSplitOptions.RemoveEmptyEntries)[0];
                    string drug_name = checkAlergyInput.Text;
                    Disease dis = this.hashT.diseases[dis_name] as Disease;
                    var result = dis.getPositiveDrugs();
                    DrugStorePanel.Items.Clear();
                    if(result != null)
                        foreach(var d in result)
                            DrugStorePanel.Items.Add("Drug_" + d);
                }
                else
                    MessageBox.Show("باید یک بیماری را انتخاب کنید ولی دارو انتخاب کرده اید");
            }
            else
                MessageBox.Show("موردی انتخاب نشده است");
        }

        private void writeFilesButton_Click(object sender, EventArgs e)
        {
            try
            {
                Stopwatch sw = Stopwatch.StartNew();
                hashT.WriteToFiles(this.file1, this.file2, this.file3, this.file4);
                double time = sw.Elapsed.TotalMilliseconds * 1000;
                MessageBox.Show("Done!");
                File.AppendAllText(this.loggerAddr,"writing to files successfully. time taken in microseconds : " + time + "\n");
            }
            catch (Exception ex)
            {
                string problem = "writing to files failed. Discribtion : "+ex.Message;
                MessageBox.Show(problem);
                File.AppendAllText(this.loggerAddr, problem + "\n");
            }
        }
    }
}