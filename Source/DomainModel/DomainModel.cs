using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationModel;
using System.IO;
using System.Text.Json;

namespace DomainModel
{
    public class DomainModel
    {
        private String DataFileName = "C://Temp//Laba1.dat";

        public Dictionary<Guid, Bank> Banks { get; set; }

        private AppModel appModel = null;

        public DomainModel(AppModel app)
        {
            appModel = app;
            Banks = new Dictionary<Guid, Bank>();
        }

        public void TestDataInitialization()
        {
            appModel.WriteLog("Инициализация начата");

            for (int i = 1; i <= 3; i++)
            {
                Bank bank = new Bank();
                bank.Initialization();
                Banks.Add(bank.ID, bank);
            }

            appModel.WriteLog("Инициализация завершена");
        }

        public void LoadDataFromFile()
        {
            // Decrypting file
            byte[] MyFile = File.ReadAllBytes(DataFileName);
            byte[] NewFile = Crypt(MyFile);

            String tempDecryptedFileName = DataFileName + "temp";
            File.WriteAllBytes(tempDecryptedFileName, NewFile);

            var newjsonliststring = File.ReadAllText(tempDecryptedFileName);
            Banks = JsonSerializer.Deserialize<Dictionary<Guid,Bank>>(newjsonliststring);
            File.Delete(tempDecryptedFileName);

//            var newjsonliststring = File.ReadAllText(DataFileName);
//            Banks = JsonSerializer.Deserialize<Dictionary<Guid, Bank>>(newjsonliststring);

        }

        public void StoreDataToFile()
        {
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            var jsonString = JsonSerializer.Serialize(Banks, Banks.GetType(), options);
            File.WriteAllText(DataFileName, jsonString);

            //Encrypting
            
            byte[] MyFile = File.ReadAllBytes(DataFileName);
            byte[] NewFile = Crypt(MyFile);

            String tempEncryptedFileName = DataFileName + "temp";
            File.WriteAllBytes(tempEncryptedFileName, NewFile);

            File.Delete(DataFileName);
            File.Copy(tempEncryptedFileName, DataFileName);
            File.Delete(tempEncryptedFileName);
        }

        private void Encrypt(String filePath)
        {

        }


        private byte[] Crypt(byte[] bytes)
        {
            for (int i = 0; i < bytes.Length; i++)
                bytes[i] ^= 1;
            return bytes;
        }

        string GetNewFileName(string FileName)
        {
            return FileName.EndsWith(".crypt") ? FileName.Remove(FileName.LastIndexOf(".crypt")) : FileName + ".crypt";
        }
    }
}
    

