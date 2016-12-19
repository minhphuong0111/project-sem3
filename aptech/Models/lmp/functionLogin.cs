using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace aptech.Models.lmp
{
    public class functionLogin
    {
        string ktramd5 = "cghcg";
        public string getktra()
        {
            return ktramd5;
        }


        public bool checkDB(bool isGV, string usr, string pwd)
        {
            
                using (var dbContext = new StudentManagementEntities())
                {
                    if(isGV)
                    {       
                        var taikhoan = (from p in dbContext.GiangViens
                                        where p.gvID == usr
                                        select p).ToList();
                        if(taikhoan.Count >0)
                        {
                            string hashpwd = hashMD5(pwd);
                            ktramd5 = hashpwd;
                            bool check = hashCompare(hashpwd, taikhoan[0].gvMatKhau);
                            if(check)  return true;
                        }
                    }
                    else
                    {
                        var taikhoan = (from p in dbContext.Quanlies
                                        where p.qlyID == usr
                                        select p).ToList();
                        if (taikhoan.Count > 0)
                        {
                            if (taikhoan.Count > 0)
                            {
                                string hashpwd = hashMD5(pwd);
                                ktramd5 = hashpwd;
                                bool check = hashCompare(hashpwd, taikhoan[0].qlyMatKhau);
                                if (check) return true;
                            }
                        }
                    }
            }
            
            return false;
        }

        public string hashMD5(string plainttext)
        {
            string hashed = "";
            using(MD5 md5hash = MD5.Create())
            {
                hashed = getMD5Hash(md5hash, plainttext);
            }

            return hashed;
        }

        public bool hashCompare(string input, string matkhau)
        {
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(input, matkhau))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private string getMD5Hash( MD5 md5hash, string input)
        {
            byte[] data = md5hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                builder.Append(data[i].ToString("x2"));
            }

            
            return builder.ToString();
        }
    }
}