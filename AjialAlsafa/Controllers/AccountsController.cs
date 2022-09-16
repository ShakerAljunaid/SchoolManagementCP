using AjialAlsafa.Models;
using AjialAlsafa.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace AjialAlsafa.Controllers
{
    public class AccountsController : Controller
    {
        AccountsDBOperations db = new AccountsDBOperations();
        // GET: Accounts
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List(int typeId)
        {
            string json = JsonConvert.SerializeObject(db.GetAllAccounts(1, typeId), Formatting.Indented);
            return Content(json, "application/json");
        }
        public ActionResult Verify(Account account)
        {
            account.password = Decrypt(account.password);

            string json = JsonConvert.SerializeObject(db.VerifyAccount(account), Formatting.Indented);
            return Content(json, "application/json");
        }

        public int Create(Account account)
        {
            account.password = Decrypt(account.password);
            return db.Create(account)  ;
        }
        public int Edit(Account account, int id)
        {
            return db.Edit(account) ? 1 : 0; ;
        }
        public int Delete(int id)
        {
            return db.DeleteAccount(id); ;
        }
        public string Decrypt(string clearText)
        {
            string EncryptionKey = "ABCDEFGHIJKLMNOPQRSTUVWXYZ123456789";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }
    }
}