using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using MyClasses;
namespace Proj1
{
    public class HashTable
    {
        public Hashtable drugs = new Hashtable();
        public Hashtable diseases = new Hashtable();
        Random rnd = new Random();
        public Drug FindDrug(string drug)
        {
            if(!this.drugs.ContainsKey(drug))
                return null;
            Drug foundDrug = this.drugs[drug] as Drug;
            return foundDrug;
        }
        public Disease FindDisease(string disease)
        {
            if(!this.diseases.ContainsKey(disease))
                return null;
            Disease foundDisease = this.diseases[disease] as Disease;
            return foundDisease;
        }
        public void AddDisease(string name) // <Disease name>
        {
            if(this.diseases.ContainsKey(name))
            {
                System.Console.WriteLine("Oops, this disease is already there.");
                throw new Exception("the disease " + name + " is already in table");
            }
            this.diseases.Add(name, new Disease("Dis_" + name));
            string[] drugs = new string[this.drugs.Count];
            this.drugs.Keys.CopyTo(drugs, 0);
            var result = this.get_random_items(drugs);
            AppendAlergiesForDisease(result, name);
        }
        public bool AddDrug(string drug) // Drug_<Drug name> : <Drug price>
        {
            var nameAndPrice = drug.Split(new char[] {':'});
            string name = nameAndPrice[0].Split(new char[] {'_'})[1].Trim();
            string price = nameAndPrice[1].Trim();
            if(this.drugs.ContainsKey(name))
            {
                System.Console.WriteLine("Oops, this drug is already there.");
                throw new InvalidOperationException("Adding drug "+drug+ "failed because it is already in table");
            }
            try
            {
                Drug newDrug = new Drug(name, price);
                this.drugs.Add(name, newDrug);
                var drugs = new string[this.drugs.Count];
                this.drugs.Keys.CopyTo(drugs, 0);
                var result = get_random_items(drugs);
                string str = "abcdefghijklmnopqrstuvwxyz";
                string effect;
                string effects = "";
                for (int j = 0; j < result.Length; j++)
                {
                    effect = "Eff_";
                    for (int i = 0; i < 6; i++)
                    {
                        var ind = rnd.Next(0, 26);
                        effect += str[ind];
                    }
                    (this.drugs[result[j]] as Drug).AddOwnEffect(name, effect);
                    effects += "(" + "Drug_" + result[j] + "," + effect + ")";
                    if (j != result.Length - 1) effects += " ; ";
                }
                Drug value = this.drugs[name] as Drug;
                value.effects = effects;
                string[] diseases = new string[this.diseases.Count];
                this.diseases.Keys.CopyTo(diseases, 0);
                var result1 = get_random_items(diseases);
                AppendAlergiesForDrug(result1, name);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Adding drug failed: Discribtion: " + ex.Message);
            }
        }
        public bool DeleteDisease(string name)
        {
            if(this.diseases.ContainsKey(name))
            {
                var drugNames = (this.diseases[name] as Disease).getDrugsAlergies();
                if(drugNames != null)
                    foreach(var drug in drugNames)
                        (this.drugs[drug] as Drug).DeleteAlergies(name);
                this.diseases.Remove(name);
                return true;
            }
            return false;
        }
        public bool DeleteDrug(string name)
        {
            if(this.drugs.ContainsKey(name))
            {
                var result = (this.drugs[name] as Drug).getAlergies();
                if(result != null)
                    foreach (var alergy in result)
                        (this.diseases[alergy] as Disease).removeDrugAlergy(name);
                this.drugs.Remove(name);
                return true;
            }
            return false;
        }
        public void AppendAlergiesForDisease(string[] drugs, string disease)
        {
            Disease dis = this.diseases[disease] as Disease;
            for(int i=0; i< drugs.Length; i++)
            {
                char c = rnd.Next(0,2)==0 ? '-' : '+';
                if(this.drugs.ContainsKey(drugs[i]))
                {
                    Drug value = this.drugs[drugs[i]] as Drug;
                    if(i != 0)
                        dis.drugsAlergies += " ; ";
                    dis.drugsAlergies += "(Drug_" + drugs[i] + "," + c + ")";
                    value.diseaseAlergies += " " + disease + "," + c;
                }
            }
        }
        public void AppendAlergiesForDrug(string[] diseases, string drug)
        {
            for(int i=0; i< diseases.Length; i++)
            {
                char c = rnd.Next(0,2)==0 ? '-' : '+';
                if(this.diseases.ContainsKey(diseases[i]))
                {
                    Disease value = this.diseases[diseases[i]] as Disease;
                    if(value.drugsAlergies != null) value.drugsAlergies += " ; ";
                    value.drugsAlergies += "(" + "Drug_" + drug + "," + c + ")";
                }
                (this.drugs[drug] as Drug).diseaseAlergies += " " + diseases[i] + "," + c;
            }
            
        }
        public string[] get_random_items(string[] items)
        {
            var index = rnd.Next(0, items.Length-7);
            var num_of_drugs = rnd.Next(1, 6);
            string[] result = new string[num_of_drugs];
            for(int i=0; i< num_of_drugs; i++)
            {
                var name = items[index];
                result[i] = name;
                index++;
            }
            return result;
        }
        public void LoadDrugs(string lines)
        {
            string[] seperator = new string[] {"\r\n"};
            var items = lines.Split(seperator, StringSplitOptions.RemoveEmptyEntries);
            string[] nameAndPrice = new string[2];
            string name, price;
            foreach(var item in items)
            {
                nameAndPrice = item.Split(new char[] {':'});
                name = nameAndPrice[0].Split(new char[] {'_'})[1].Trim();
                price = nameAndPrice[1].Trim();
                Drug drug = new Drug(name, price);
                this.drugs.Add(name, drug);
            }
        }
        public void LoadDiseases(string lines)
        {
            string[] seperator = new string[] {"\r\n"};
            var items = lines.Split(seperator, StringSplitOptions.RemoveEmptyEntries);
            string name;
            foreach(var item in items)
            {
                name = item.Split(new char[] {'_'})[1];
                Disease disease = new Disease(item); // without Dis_
                this.diseases.Add(name, disease);
            }
        }
        public void LoadEffects(string item)
        {
            var drugAndEffects = item.Split(new char[] {':'});
            string drug = drugAndEffects[0].Split(new char[] {'_'})[1].Trim();
            string effects = drugAndEffects[1].Trim();
            if(this.drugs.ContainsKey(drug))
            {
                Drug value = this.drugs[drug] as Drug;
                value.effects = effects;
            }
            string[] seperators = new string[] {"(Drug_",",",")"};
            var result = effects.Split(new char[] {';'}).Select(x => x.Trim())
                .Select(x => x.Split(seperators, StringSplitOptions.RemoveEmptyEntries)).ToArray();
            foreach(var res in result)
                if(this.drugs.ContainsKey(res[0]))
                    (this.drugs[res[0]] as Drug).AddOwnEffect(drug, res[1]);
        }
        public void LoadAlergies(string item)
        {
            var diseaseAndAlergies = item.Split(new char[] {':'});
            string disease = diseaseAndAlergies[0].Split(new char[] {'_'})[1].Trim();
            string alergies = diseaseAndAlergies[1].Trim();
            string[] seperators = new string[] {"(Drug_", ")"};
            var drugs = alergies.Split(new char[] {';'}).Select(x => x.Trim())
                .Select(x => x.Split(seperators, StringSplitOptions.RemoveEmptyEntries)[0].Split(new char[] {','}))
                .ToArray();
            foreach (var drug in drugs)
            {
                if(this.diseases.ContainsKey(disease) && this.drugs.ContainsKey(drug[0]))
                {
                    Drug value = this.drugs[drug[0]] as Drug;
                    value.diseaseAlergies += disease + "," + drug[1] + " ";
                }
            }
            if(this.diseases.ContainsKey(disease))
            {
                Disease value = this.diseases[disease] as Disease;
                value.drugsAlergies = alergies;
            }
        }
        public void IncreaseByInflationRate(double percent)
        {
            double coefficient = (percent*0.01) + 1;
            foreach(DictionaryEntry entry in this.drugs)
            {
                double newPrice = double.Parse( (entry.Value as Drug).price) * coefficient;
                (entry.Value as Drug).price = newPrice.ToString("0.000");
            }
        }
        public void WriteToFiles(string file1, string file2, string file3, string file4)
        {
            File.Delete(file1);
            File.Delete(file2);
            File.Delete(file3);
            File.Delete(file4);
            using(StreamWriter writer = File.AppendText(file1))
            {
                foreach(DictionaryEntry entry in this.drugs)
                {
                    Drug drug = (entry.Value as Drug);
                    writer.WriteLine("Drug_" + drug.name + " : " + drug.price);
                }
            }
            using(StreamWriter writer = File.AppendText(file3))
            {
                foreach(DictionaryEntry entry in this.drugs)
                {
                    Drug drug = (entry.Value as Drug);
                    if(drug.effects != null && drug.effects != "")
                        writer.WriteLine("Drug_" + drug.name + " : " + drug.effects);
                }
            }
            using(StreamWriter writer = File.AppendText(file2))
            {
                foreach(DictionaryEntry entry in this.diseases)
                {
                    Disease dis = entry.Value as Disease;
                    writer.WriteLine(dis.name);
                }
            }
            using(StreamWriter writer = File.AppendText(file4))
            {
                foreach(DictionaryEntry entry in this.diseases)
                {
                    Disease dis = entry.Value as Disease;
                    if(dis.drugsAlergies != null && dis.drugsAlergies != "")
                        writer.WriteLine(dis.name + " : " + dis.drugsAlergies);
                }
            }
        }

    }
}