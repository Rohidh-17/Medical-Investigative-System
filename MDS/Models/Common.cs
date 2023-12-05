using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.Configuration;
using System.IO;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.Web.WebPages.Html;
using System.Reflection;
using Newtonsoft.Json;
using System.Text;
using System.Net;


namespace MvcApplication1.Models
{
    public class Common
    {
        public string Roles { get; set; }
        SqlConnection objSqlConnection;
        SqlCommand objSqlCommand;
        SqlDataAdapter objSqlDataAdapter;
        DataSet objDataSet;
        DataTable objDataTable;

        public void SetCookie(string CookieName, string CookieValue)
        {
            var cookie = new HttpCookie(CookieName);
            cookie.Value = CookieValue;
            //cookie.Expires = DateTime.Now.AddMinutes(1);
            cookie.Expires = DateTime.Now.AddDays(1);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        public string GetCookie(string CookieName)
        {
            //return Convert.ToString(HttpContext.Current.Response.Cookies[CookieName]);
            string value = "";
            if (HttpContext.Current.Request.Cookies.AllKeys.Contains(CookieName))
            {
                value = HttpContext.Current.Request.Cookies[CookieName].Value;
            }
            return value;
        }

        public Boolean existsCookie(string CookieName)
        {
            //return Convert.ToString(HttpContext.Current.Response.Cookies[CookieName]);
            Boolean value = false;
            if (HttpContext.Current.Request.Cookies.AllKeys.Contains(CookieName))
            {
                value = true;
            }

            return value;


        }

        public string ErrList(System.Web.Mvc.ModelStateDictionary modelState)
        {
            string errList = string.Empty;
            foreach (System.Web.Mvc.ModelState model in modelState.Values)
            {
                foreach (System.Web.Mvc.ModelError error in model.Errors)
                {
                    errList += error.ErrorMessage + "</br>";
                }
            }
            return errList;
        }


        public void MessageBox(HtmlGenericControl div, Label lbl, string Msg, string ClassName)
        {
            try
            {
                div.Visible = true;
                lbl.Text = Msg;
                div.Attributes.Add("class", ClassName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ExecQuery(string str)
        {
            try
            {
                Initialize_Connection();
                objSqlCommand = new SqlCommand(str, objSqlConnection);
                objSqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (objSqlConnection.State == ConnectionState.Open)
                    objSqlConnection.Close();
            }
        }

        public DataTable objDT(string str)
        {
            try
            {
                Initialize_Connection();
                objDataTable = new DataTable();
                objSqlDataAdapter = new SqlDataAdapter(str, objSqlConnection);
                objSqlDataAdapter.Fill(objDataTable);
                return objDataTable;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (objSqlConnection.State == ConnectionState.Open)
                    objSqlConnection.Close();
            }
        }

        public DataTable objDT(string str, string ConStr)
        {
            try
            {
                Initialize_Connection(ConStr);
                objDataTable = new DataTable();
                objSqlDataAdapter = new SqlDataAdapter(str, objSqlConnection);
                objSqlDataAdapter.Fill(objDataTable);
                return objDataTable;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (objSqlConnection.State == ConnectionState.Open)
                    objSqlConnection.Close();
            }
        }

        public DataTable objDT(SqlCommand cmd)
        {
            try
            {
                objSqlDataAdapter = new SqlDataAdapter(cmd);
                objDataTable = new DataTable();
                objSqlDataAdapter.Fill(objDataTable);
                return objDataTable;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable objDT(string StoreprecedureName, SqlCommand cmd)
        {
            Common com = new Common();
            SqlConnection sqlCon = new SqlConnection();
            sqlCon = new SqlConnection(com.GetConnectionStr());

            try
            {
                sqlCon.Open();

                objSqlDataAdapter = new SqlDataAdapter(cmd);
                objDataTable = new DataTable();
                objSqlDataAdapter.Fill(objDataTable);
                return objDataTable;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public DataSet objDS(string str)
        {
            try
            {
                Initialize_Connection();
                objDataSet = new DataSet();
                objSqlDataAdapter = new SqlDataAdapter(str, objSqlConnection);
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (objSqlConnection.State == ConnectionState.Open)
                    objSqlConnection.Close();
            }
        }

        public DataSet objDS(SqlCommand cmd)
        {
            try
            {
                objSqlDataAdapter = new SqlDataAdapter(cmd);
                objDataSet = new DataSet();
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object objDScal(string str)
        {
            try
            {
                Initialize_Connection();
                SqlCommand scalarCommand = new SqlCommand(str, objSqlConnection);
                return scalarCommand.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (objSqlConnection.State == ConnectionState.Open)
                    objSqlConnection.Close();
            }
        }

        public object objDScal(string str, string ConStr)
        {
            try
            {
                Initialize_Connection(ConStr);
                SqlCommand scalarCommand = new SqlCommand(str, objSqlConnection);
                return scalarCommand.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (objSqlConnection.State == ConnectionState.Open)
                    objSqlConnection.Close();
            }
        }

        public IEnumerable<SelectListItem> objIEnumerable(string Str, string DisplayMember, string ValueMemeber, string DefaultText = "--SELECT--")
        {
            try
            {
                Common com = new Common();
                DataTable dt = com.objDT(Str);
                DataRow dr = dt.NewRow();
                dr[DisplayMember] = DefaultText;
                dr[ValueMemeber] = 0;
                dt.Rows.InsertAt(dr, 0);
                List<SelectListItem> list = new List<SelectListItem>();

                foreach (DataRow row in dt.Rows)
                {
                    list.Add(new SelectListItem
                    {
                        Text = Convert.ToString(row[DisplayMember]),
                        Value = Convert.ToString(row[ValueMemeber])
                    });
                }
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<SelectListItem> objIEnumerable(DataTable dt, string DisplayMember, string ValueMemeber, string DefaultText = "--SELECT--")
        {
            try
            {
                Common com = new Common();
                DataRow dr = dt.NewRow();
                dr[DisplayMember] = DefaultText;
                dr[ValueMemeber] = 0;
                dt.Rows.InsertAt(dr, 0);
                List<SelectListItem> list = new List<SelectListItem>();

                foreach (DataRow row in dt.Rows)
                {
                    list.Add(new SelectListItem
                    {
                        Text = Convert.ToString(row[DisplayMember]),
                        Value = Convert.ToString(row[ValueMemeber])
                    });
                }
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GetConnectionStr()
        {
            try
            {
                return ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GetConnectionStr(string ConStr)
        {
            try
            {
                return ConfigurationManager.ConnectionStrings[ConStr].ConnectionString;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SqlConnection Initialize_Connection()
        {
            try
            {
                objSqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString);
                objSqlConnection.Open();
                return objSqlConnection;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SqlConnection Initialize_Connection(string ConStr)
        {
            try
            {
                objSqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[ConStr].ConnectionString);
                objSqlConnection.Open();
                return objSqlConnection;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ddlBind(DropDownList ddl, DataTable dt, string DataTextField, string DataValueField, string DefaultText = "--SELECT--")
        {
            try
            {
                if (DefaultText != "")
                {
                    DataRow dr = dt.NewRow();
                    dr[dt.Columns[DataTextField].ColumnName] = DefaultText;
                    dr[dt.Columns[DataValueField].ColumnName] = 0;
                    dt.Rows.InsertAt(dr, 0);
                    dt.AcceptChanges();
                }
                ddl.DataSource = dt;
                ddl.DataValueField = DataValueField;
                ddl.DataTextField = DataTextField;
                ddl.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ddlBind(DropDownList ddl, string str, string DataTextField, string DataValueField, string DefaultText = "--SELECT--")
        {
            try
            {
                DataTable dt = new DataTable();
                dt = objDT(str);
                if (DefaultText != "")
                {
                    DataRow dr = dt.NewRow();
                    dr[dt.Columns[DataTextField].ColumnName] = DefaultText;
                    dr[dt.Columns[DataValueField].ColumnName] = 0;
                    dt.Rows.InsertAt(dr, 0);
                    dt.AcceptChanges();
                }
                ddl.DataSource = dt;
                ddl.DataValueField = DataValueField;
                ddl.DataTextField = DataTextField;
                ddl.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool IsDate(object Expression)
        {
            if (Expression != null)
            {
                try
                {
                    DateTime dt = Convert.ToDateTime(Expression);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            return false;
        }

        public string SetDate(object Value)
        {
            try
            {
                DateTime dt = Convert.ToDateTime(Value);
                return dt.ToString(format: "dd/MMM/yyyy");
            }
            catch (Exception)
            {
                return "";
            }
        }

        public string GetSQLDate(string Value)
        {
            try
            {
                string[] Dt;
                if (Value.ToString().Contains("-"))
                    Dt = Value.ToString().Split('-');
                else if (Value.ToString().Contains("/"))
                    Dt = Value.ToString().Split('/');
                else
                    return "";

                string dd = Dt[0].ToString();
                string mm = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(Convert.ToInt32(Dt[1].ToString()));
                string yyyy = Dt[2].ToString().Substring(0, 4);

                if (yyyy == "" || mm == "" || dd == "")
                {
                    return "";
                }
                else
                {
                    DateTime dt = Convert.ToDateTime(yyyy + "-" + mm + "-" + dd);
                    return yyyy + "-" + mm + "-" + dd;
                }

            }
            catch (Exception)
            {
                return "";
            }
        }

        public string GetDateFormat(DateTime Value)
        {
            try
            {
                //string dd = ("00" + Value.Day.ToString()).Substring(Value.Day.ToString().Length-2);
                //string mm = ("00" + Value.Month.ToString()).Substring(Value.Month.ToString().Length - 2);
                //string yyyy = Value.Year.ToString();

                string dd = ("00" + Value.Day.ToString()).Substring(("00" + Value.Day.ToString()).Length - 2);
                string mm = ("00" + Value.Month.ToString()).Substring(("00" + Value.Month.ToString()).Length - 2);
                string yyyy = Value.Year.ToString();

                if (yyyy == "" || mm == "" || dd == "")
                {
                    return "";
                }
                else
                {
                    DateTime dt = Convert.ToDateTime(yyyy + "-" + mm + "-" + dd);
                    return dd + "/" + mm + "/" + yyyy;
                }

            }
            catch (Exception)
            {
                return "";
            }
        }

        public string GetSQLDate(DateTime Value)
        {
            try
            {
                string dd = Value.Day.ToString();
                string mm = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(Value.Month);
                string yyyy = Value.Year.ToString();

                if (yyyy == "" || mm == "" || dd == "")
                {
                    return "";
                }
                else
                {
                    DateTime dt = Convert.ToDateTime(yyyy + "-" + mm + "-" + dd);
                    return yyyy + "-" + mm + "-" + dd;
                }

            }
            catch (Exception)
            {
                return "";
            }
        }

        public bool IsNumeric(string str)
        {
            Regex regex = new Regex(@"^[0-9]+$");
            try
            {
                if (String.IsNullOrWhiteSpace(str))
                {
                    return false;
                }
                if (!regex.IsMatch(str))
                {
                    return false;
                }

                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }

        public DateTime GetCurrentDateTime()
        {
            try
            {
                TimeZoneInfo usersTimeZone = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
                DateTime usersLocalTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, usersTimeZone);
                return usersLocalTime;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public string GetCurrentDateTime(string _Format)
        {
            try
            {
                TimeZoneInfo usersTimeZone = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
                DateTime usersLocalTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, usersTimeZone);
                return usersLocalTime.ToString(format: _Format);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GetFromDate(string _Date, string _Format = "yyyy-MM-dd")
        {
            try
            {
                string[] Dt = _Date.ToString().Split('-');
                string dd = Dt[0].ToString().Substring(0, 2);
                string mm = Dt[0].ToString().Substring(3, 2);
                string yyyy = Dt[0].ToString().Substring(6, 4);

                string MonthName = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(Convert.ToInt32(mm));
                DateTime dt = Convert.ToDateTime(yyyy + "-" + MonthName + "-" + dd);
                return dt.ToString(format: _Format);
            }
            catch (Exception)
            {
                return "";
            }
        }

        public string SD(string _Date)
        {
            string dd = _Date.Substring(0, 2);
            string mm = _Date.Substring(3, 2);
            string yyyy = _Date.Substring(6, 4);
            return yyyy + "-" + mm + "-" + dd;
        }

        public string SD1(string _Date)
        {
            string dd = _Date.Substring(1, 2);
            string mm = _Date.Substring(4, 2);
            string yyyy = _Date.Substring(7, 4);
            return yyyy + "-" + mm + "-" + dd;
        }

        public string GetToDate(string _Date, string _Format = "yyyy-MM-dd")
        {
            try
            {
                string[] Dt = _Date.ToString().Split('-');
                string dd = Dt[1].ToString().Substring(1, 2);
                string mm = Dt[1].ToString().Substring(4, 2);
                string yyyy = Dt[1].ToString().Substring(7, 4);

                string MonthName = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(Convert.ToInt32(mm));
                DateTime dt = Convert.ToDateTime(yyyy + "-" + MonthName + "-" + dd);
                return dt.ToString(format: _Format);
            }
            catch (Exception)
            {
                return "";
            }
        }

        public string EncryptData(string Message)
        {
            string passphrase = ConfigurationManager.AppSettings["CryptographyPassphrase"];

            byte[] Results;
            System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();
            MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
            byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(passphrase));
            TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();
            TDESAlgorithm.Key = TDESKey;
            TDESAlgorithm.Mode = CipherMode.ECB;
            TDESAlgorithm.Padding = PaddingMode.PKCS7;
            byte[] DataToEncrypt = UTF8.GetBytes(Message);
            try
            {
                ICryptoTransform Encryptor = TDESAlgorithm.CreateEncryptor();
                Results = Encryptor.TransformFinalBlock(DataToEncrypt, 0, DataToEncrypt.Length);
            }
            finally
            {
                TDESAlgorithm.Clear();
                HashProvider.Clear();
            }
            return Convert.ToBase64String(Results);
        }

        public string DecryptData(string Message)
        {
            string passphrase = ConfigurationManager.AppSettings["CryptographyPassphrase"];

            byte[] Results;
            System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();
            MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
            byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(passphrase));
            TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();
            TDESAlgorithm.Key = TDESKey;
            TDESAlgorithm.Mode = CipherMode.ECB;
            TDESAlgorithm.Padding = PaddingMode.PKCS7;
            byte[] DataToDecrypt = Convert.FromBase64String(Message);
            try
            {
                ICryptoTransform Decryptor = TDESAlgorithm.CreateDecryptor();
                Results = Decryptor.TransformFinalBlock(DataToDecrypt, 0, DataToDecrypt.Length);
            }
            finally
            {
                TDESAlgorithm.Clear();
                HashProvider.Clear();
            }
            return UTF8.GetString(Results);
        }

        public string Encode(string Value, string Password = "KOREX")
        {
            try
            {
                byte[] Results;
                System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();
                MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
                byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(Password));
                TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();

                TDESAlgorithm.Key = TDESKey;
                TDESAlgorithm.Mode = CipherMode.ECB;
                TDESAlgorithm.Padding = PaddingMode.PKCS7;
                byte[] DataToEncrypt = UTF8.GetBytes(Value);

                try
                {
                    ICryptoTransform Encryptor = TDESAlgorithm.CreateEncryptor();
                    Results = Encryptor.TransformFinalBlock(DataToEncrypt, 0, DataToEncrypt.Length);
                }
                finally
                {
                    TDESAlgorithm.Clear();
                    HashProvider.Clear();
                }
                return Convert.ToBase64String(Results);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public string Decode(string Message, string Password = "KOREX")
        {
            try
            {
                byte[] Results;
                System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();
                MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
                byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(Password));
                TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();

                TDESAlgorithm.Key = TDESKey;
                TDESAlgorithm.Mode = CipherMode.ECB;
                TDESAlgorithm.Padding = PaddingMode.PKCS7;
                byte[] DataToDecrypt = Convert.FromBase64String(Message);
                try
                {
                    ICryptoTransform Decryptor = TDESAlgorithm.CreateDecryptor();
                    Results = Decryptor.TransformFinalBlock(DataToDecrypt, 0, DataToDecrypt.Length);
                }
                finally
                {
                    TDESAlgorithm.Clear();
                    HashProvider.Clear();
                }
                return UTF8.GetString(Results);
            }
            catch (Exception ex)
            {
                return "";
            }

        }


        public string GetJson(DataTable dt)
        {
            try
            {
                List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();

                foreach (DataRow dr in dt.Rows)
                {
                    Dictionary<string, object> row = new Dictionary<string, object>();
                    foreach (DataColumn col in dt.Columns)
                    {
                        row.Add(col.ColumnName, dr[col]);
                    }
                    rows.Add(row);
                }
                System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                return serializer.Serialize(rows);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string objJSON_dTable(string str)
        {

            return JsonConvert.SerializeObject(objDT(str), Formatting.Indented);
        }

        public string objJSON_dTable(DataTable dt)
        {
            return JsonConvert.SerializeObject(dt, Formatting.Indented);
        }

        public string objJSON_dTable(SqlCommand cmd)
        {
            return JsonConvert.SerializeObject(objDT(cmd), Formatting.Indented);
        }

        public string objJSON_dSet(string str)
        {
            return JsonConvert.SerializeObject(objDS(str), Formatting.Indented);
        }

        public string objJSON_dSet(SqlCommand cmd)
        {
            return JsonConvert.SerializeObject(objDS(cmd), Formatting.Indented);
        }

        public List<T> ConvList<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }

        private T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                        pro.SetValue(obj, dr[column.ColumnName], null);
                    else
                        continue;
                }
            }
            return obj;
        }

        public string ds2json(object ds)
        {
            return JsonConvert.SerializeObject(ds, Formatting.Indented);
        }

        public string objError(string Msg)
        {
            return "<div class='alert alert-danger'>" + Msg + "</div>";
        }

        public int StringLen(string str)
        {
            return str.Length;
        }




        public string GetSQLUsDateFormat(string Value)
        {
            try
            {
                string[] Dt;
                if (Value.ToString().Contains("-"))
                    Dt = Value.ToString().Split('-');
                else if (Value.ToString().Contains("/"))
                    Dt = Value.ToString().Split('/');
                else
                    return "";

                string dd = Dt[0].ToString();
                string mm = Dt[1].ToString();
                string yyyy = Dt[2].ToString().Substring(0, 4);

                return yyyy + "-" + mm + "-" + dd;
            }
            catch (Exception)
            {
                return "";
            }
        }




        public DataSet objDSetCompanyDetails()
        {
            SqlConnection SqlCon = new SqlConnection();
            SqlCon = new SqlConnection(GetConnectionStr());
            SqlCommand objCom = new SqlCommand();
            try
            {

                DataSet objDataSet = new DataSet();
                SqlCon.Open();
                objCom = new SqlCommand("sp_CompanyDisplay_get", SqlCon);
                objCom.CommandType = System.Data.CommandType.StoredProcedure;
                objCom.Parameters.AddWithValue("@BranchCode", Convert.ToInt32(GetCookie("BranchCode").ToString()));
                objCom.Parameters.AddWithValue("@FinCode", Convert.ToInt32(GetCookie("FinCode").ToString()));
                objDataSet = objDS(objCom);
                return objDataSet;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                SqlCon.Dispose();
                objCom.Dispose();
            }
        }

        public string Base64EncodingMethod(string Data)
        {
            byte[] toEncodeAsBytes = System.Text.Encoding.UTF8.GetBytes(Data);
            string sReturnValues = System.Convert.ToBase64String(toEncodeAsBytes);
            return sReturnValues;
        }

        public string Base64DecodingMethod(string Data)
        {
            byte[] encodedDataAsBytes = System.Convert.FromBase64String(Data);
            string returnValue = System.Text.Encoding.UTF8.GetString(encodedDataAsBytes);
            return returnValue;
        }


        public List<Dictionary<string, object>> GetTableRows(DataTable dtData)
        {
            List<Dictionary<string, object>>
            lstRows = new List<Dictionary<string, object>>();
            Dictionary<string, object> dictRow = null;

            foreach (DataRow dr in dtData.Rows)
            {
                dictRow = new Dictionary<string, object>();
                foreach (DataColumn col in dtData.Columns)
                {
                    dictRow.Add(col.ColumnName, dr[col]);
                }
                lstRows.Add(dictRow);
            }
            return lstRows;
        }

        public void SendSMS(string MobileNo, string Message)
        {

            WebClient client = new WebClient();
            string baseurl = "http://123.63.33.43/blank/sms/user/urlsms.php?username=UTSPAY&pass=customer@123&senderid=PAYMAX&dest_mobileno=" + MobileNo + "&message=" + Message + "&response=Y";
            //string baseurl = "http://bulksms.webhost2let.com/api/mt/SendSMS?user=utspay&password=customer@123&senderid=PAYMAX&channel=Trans&DCS=0&flashsms=0&number=" + MobileNo + "&text=" + Message + " &route=1009";
            Stream data = client.OpenRead(baseurl);
            StreamReader reader = new StreamReader(data);
            string ResponseID = reader.ReadToEnd();
            data.Close();
            reader.Close();
        }

        public string KorexEncode(string cipherString, bool useHashing = true)
        {
            byte[] keyArray;
            //get the byte code of the string

            byte[] toEncryptArray = Convert.FromBase64String(cipherString);

            System.Configuration.AppSettingsReader settingsReader =
                                                new AppSettingsReader();
            //Get your key from config file to open the lock!
            string key = (string)settingsReader.GetValue("CryptographyPassphrase",
                                                         typeof(String));

            if (useHashing)
            {
                //if hashing was used get the hash code with regards to your key
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                //release any resource held by the MD5CryptoServiceProvider

                hashmd5.Clear();
            }
            else
            {
                //if hashing was not implemented get the byte code of the key
                keyArray = UTF8Encoding.UTF8.GetBytes(key);
            }

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            //set the secret key for the tripleDES algorithm
            tdes.Key = keyArray;
            //mode of operation. there are other 4 modes. 
            //We choose ECB(Electronic code Book)

            tdes.Mode = CipherMode.ECB;
            //padding mode(if any extra byte added)
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(
                                 toEncryptArray, 0, toEncryptArray.Length);
            //Release resources held by TripleDes Encryptor                
            tdes.Clear();
            //return the Clear decrypted TEXT
            return UTF8Encoding.UTF8.GetString(resultArray);
            /*
            byte[] Results;
            System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();
            MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
            byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(key));
            TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();
            TDESAlgorithm.Key = TDESKey;
            TDESAlgorithm.Mode = CipherMode.ECB;
            TDESAlgorithm.Padding = PaddingMode.PKCS7;
            byte[] DataToDecrypt = Convert.FromBase64String(encodedText);
            try
            {
                ICryptoTransform Decryptor = TDESAlgorithm.CreateDecryptor();
                Results = Decryptor.TransformFinalBlock(DataToDecrypt, 0, DataToDecrypt.Length);
            }
            finally
            {
                TDESAlgorithm.Clear();
                HashProvider.Clear();
            }
            return UTF8.GetString(Results);
            
            TripleDESCryptoServiceProvider desCryptoProvider = new TripleDESCryptoServiceProvider();
            MD5CryptoServiceProvider hashMD5Provider = new MD5CryptoServiceProvider();

            byte[] byteHash;
            byte[] byteBuff;

            byteHash = hashMD5Provider.ComputeHash(Encoding.UTF8.GetBytes(key));
            desCryptoProvider.Key = byteHash;
            desCryptoProvider.Mode = CipherMode.ECB; //CBC, CFB
            byteBuff = Convert.FromBase64String(encodedText);
            return System.Text.Encoding.UTF8.GetString(desCryptoProvider.CreateDecryptor().TransformFinalBlock(byteBuff, 0, byteBuff.Length)); 
            //string plaintext = Encoding.UTF8.GetString(desCryptoProvider.CreateDecryptor().TransformFinalBlock(byteBuff, 0, byteBuff.Length));
            //return plaintext;
            
            try
            {
                byte[] Results;
                System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();
                MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
                byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(Password));
                TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();

                TDESAlgorithm.Key = TDESKey;
                TDESAlgorithm.Mode = CipherMode.ECB;
                TDESAlgorithm.Padding = PaddingMode.PKCS7;
                //byte[] DataToEncrypt = UTF8.GetBytes(Value);
                byte[] DataToEncrypt = Convert.FromBase64String(Value);
                try
                {
                    ICryptoTransform Encryptor = TDESAlgorithm.CreateEncryptor();
                    Results = Encryptor.TransformFinalBlock(DataToEncrypt, 0, DataToEncrypt.Length);
                }
                finally
                {
                    TDESAlgorithm.Clear();
                    HashProvider.Clear();
                }
                return UTF8.GetString(Results);
            }
            catch (Exception ex)
            {
                throw ex;
            }
             * */
        }

        public string DecodeData(string Value, string Password = "KOREX")
        {
            try
            {
                byte[] Results;
                System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();
                MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
                byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(Password));
                TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();

                TDESAlgorithm.Key = TDESKey;
                TDESAlgorithm.Mode = CipherMode.ECB;
                TDESAlgorithm.Padding = PaddingMode.PKCS7;
                byte[] DataToEncrypt = Convert.FromBase64String(Value);

                try
                {
                    ICryptoTransform Encryptor = TDESAlgorithm.CreateDecryptor();
                    Results = Encryptor.TransformFinalBlock(DataToEncrypt, 0, DataToEncrypt.Length);
                }
                finally
                {
                    TDESAlgorithm.Clear();
                    HashProvider.Clear();
                }
                return Convert.ToBase64String(Results);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string DecodeData(string Message)
        {
            string Password = Message;
            byte[] Results;
            System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();
            MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
            byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(Password));
            TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();
            TDESAlgorithm.Key = TDESKey;
            TDESAlgorithm.Mode = CipherMode.ECB;
            TDESAlgorithm.Padding = PaddingMode.PKCS7;
            byte[] DataToDecrypt = Convert.FromBase64String(Message);
            try
            {
                ICryptoTransform Decryptor = TDESAlgorithm.CreateDecryptor();
                Results = Decryptor.TransformFinalBlock(DataToDecrypt, 0, DataToDecrypt.Length);
            }
            finally
            {
                TDESAlgorithm.Clear();
                HashProvider.Clear();
            }
            return UTF8.GetString(Results);

        }

        public DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }

    }
}