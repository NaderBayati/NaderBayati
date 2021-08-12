using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Http;
using System.Text.RegularExpressions;
using Domains;
using System.Net;
using System.Configuration;
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;
using System.Text;

namespace System
{
    public enum ErrorType
    {
        InvalidCodemeli,
        EmptyCodemeli,
        InvalidMobile,
        EmptyMobile,
        GeneralError,
        NotFound,
        InvalidPassword,
        InvalidRepeatPassword,
        SameCodeMeli,
        SameMobile,
        InvalidVerify,
        ImageCouldntUpload,
        ImageInvalidSize,
        ImageInvalidType,
        InvalidCurrentPassword
    }
    public static class ExtentionsClass
    {
        public static string ToPersian(this DateTime date)
        {
            PersianCalendar persian = new PersianCalendar();
            int year = persian.GetYear(date);
            int day = persian.GetDayOfMonth(date);
            int month = persian.GetMonth(date);

            return year + "/" + month + "/" + day;
        }
        public static string ToPersianDayOfWeek(this string day)
        {
            string PersianDay;
            switch (day)
            {
                case "Sunday":
                    PersianDay = "یکشنبه";
                    break;
                case "Monday":
                    PersianDay = "دوشنبه";
                    break;
                case "Tuesday":
                    PersianDay = "سه شنبه";
                    break;
                case "Wednesday":
                    PersianDay = "چهارشنبه";
                    break;
                case "Thursday":
                    PersianDay = "پنجشنبه";
                    break;
                case "Friday":
                    PersianDay = "جمعه";
                    break;
                case "Saturday":
                    PersianDay = "شنبه";
                    break;
                default:
                    PersianDay = "روز تشخیص داده نشد";
                    break;
            }
            return PersianDay;
        }
        public static DateTime ToMiladi(this DateTime date)
        {
            int year = date.Year;
            int month = date.Month;
            int day = date.Day;
            PersianCalendar persian = new PersianCalendar();
            DateTime dt = persian.ToDateTime(year, month, day, 0, 0, 0, 0);
            return dt;
        }
        public static int GetShamsiYear(this DateTime date)
        {
            PersianCalendar persian = new PersianCalendar();
            int Year = persian.GetYear(date);
            return Year;
        }
        public static bool IsAjaxRequest(this HttpRequest request)
        {
            string RequestedWithHeader = "X-Requested-With";
            string XmlHttpRequest = "XMLHttpRequest";
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }

            if (request.Headers != null)
            {
                return request.Headers[RequestedWithHeader] == XmlHttpRequest;
            }

            return false;
        }
        public static bool CheckID(this int ID)
        {
            if (ID != 0 && ID > 0)
                return true;
            else
                return false;
        }
        public static bool CheackMobile(this string Mobile)
        {
            Regex regex = new Regex("[0]{1}[9]{1}[0-9]{9}");
            return regex.IsMatch(Mobile);
        }
        public static bool CheckCodeMeli(this string nationalCode)
        {
            var allDigitEqual = new[] { "0000000000", "1111111111", "2222222222", "3333333333", "4444444444", "5555555555", "6666666666", "7777777777", "8888888888", "9999999999" };
            if (allDigitEqual.Contains(nationalCode)) return false;
            var chArray = nationalCode.ToCharArray();
            var num0 = Convert.ToInt32(chArray[0].ToString()) * 10;
            var num2 = Convert.ToInt32(chArray[1].ToString()) * 9;
            var num3 = Convert.ToInt32(chArray[2].ToString()) * 8;
            var num4 = Convert.ToInt32(chArray[3].ToString()) * 7;
            var num5 = Convert.ToInt32(chArray[4].ToString()) * 6;
            var num6 = Convert.ToInt32(chArray[5].ToString()) * 5;
            var num7 = Convert.ToInt32(chArray[6].ToString()) * 4;
            var num8 = Convert.ToInt32(chArray[7].ToString()) * 3;
            var num9 = Convert.ToInt32(chArray[8].ToString()) * 2;
            var a = Convert.ToInt32(chArray[9].ToString());
            var b = (((((((num0 + num2) + num3) + num4) + num5) + num6) + num7) + num8) + num9;
            var c = b % 11;
            return (((c < 2) && (a == c)) || ((c >= 2) && ((11 - c) == a)));
        }

        public static ModelStateDictionary CreateError(this ModelStateDictionary Modelstate, ErrorType Key)
        {
            if (Key == ErrorType.EmptyCodemeli)
            {
                Modelstate.AddModelError("", "کد ملی را وارد کنید");
            }
            if (Key == ErrorType.InvalidCodemeli)
            {
                Modelstate.AddModelError("", "کد ملی وارد شده معتبر نیست");
            }
            if (Key == ErrorType.EmptyMobile)
            {
                Modelstate.AddModelError("", "تلفن همراه را وارد کنید");
            }
            if (Key == ErrorType.InvalidMobile)
            {
                Modelstate.AddModelError("", "شماره موبایل وارد شده معتبر نیست");
            }
            if (Key == ErrorType.GeneralError)
            {
                Modelstate.AddModelError("", "مشکلی به وجود آمده است");
            }
            if (Key == ErrorType.NotFound)
            {
                Modelstate.AddModelError("", "موردی یافت نشد");
            }
            if (Key == ErrorType.InvalidPassword)
            {
                Modelstate.AddModelError("", "کلمه عبور وارد شده معتبر نیست");
            }
            if (Key == ErrorType.InvalidRepeatPassword)
            {
                Modelstate.AddModelError("", "کلمه عبور وارد شده با تکرار آن مغایرت ندارد");
            }
            if (Key == ErrorType.SameCodeMeli)
            {
                Modelstate.AddModelError("", "کد ملی وارد شده در سیستم موجود می باشد");
            }
            if (Key == ErrorType.SameMobile)
            {
                Modelstate.AddModelError("", "تلفن همراه وارد شده در سیتسم موجو.د می باشد");
            }
            if (Key == ErrorType.InvalidVerify)
            {
                Modelstate.AddModelError("", "کد تایید وارد شده معتبر نیست");
            }
            if (Key == ErrorType.ImageCouldntUpload)
            {
                Modelstate.AddModelError("", "عکس بارگزاری نشد");
            }
            if (Key == ErrorType.ImageInvalidType)
            {
                Modelstate.AddModelError("", "فایل انتخابی معتبر نمی باشد");
            }
            if (Key == ErrorType.ImageInvalidSize)
            {
                Modelstate.AddModelError("", "حجم فایل انتخابی معتبر نمی باشد");
            }
            if (Key == ErrorType.InvalidCurrentPassword)
            {
                Modelstate.AddModelError("", "کلمه عبور وارد شده  اشتباه است");
            }
            return Modelstate;
        }
        public static string DeCodeBase64String(this string EnCodeed)
        {
            return System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(EnCodeed));
        }
        public static string EnCodeToBase64String(this string Value)
        {
            return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(Value));
        }
        public static bool CheckFileContains(this IFormFile file, string Key)
        {
            return (file.ContentType.Contains(Key)) ? true : false;
        }
        public static bool CheckFileLength(this IFormFile file, long MinSize, long MaxSize)
        {
            return (file.Length >= MinSize && file.Length <= MaxSize) ? true : false;
        }
        public static string ConvertDayName(this string Day)
        {
            string PersianDay = "";
            switch (Day)
            {
                case "Saturday":
                    PersianDay = "شنبه";
                    break;
                case "Sunday":
                    PersianDay = "یکشنبه";
                    break;
                case "Monday":
                    PersianDay = "دوشنبه";
                    break;
                case "Tuesday":
                    PersianDay = "سه شنبه";
                    break;
                case "Wednesday":
                    PersianDay = "چهارشنبه";
                    break;
                case "Thursday":
                    PersianDay = "پنج شنبه";
                    break;
                case "Friday":
                    PersianDay = "جمعه";
                    break;
                default:
                    PersianDay = "روز تشخیص داده نشد";
                    break;
            }
            return PersianDay;
        }
    }
    public class UtilityController : Controller
    {
        public IActionResult RetErrors(ModelStateDictionary modelstate)
        {
            var errors = modelstate.Select(p => p.Value.Errors).Where(p => p.Count > 0).ToList();
            return Json(errors);
        }
    }
    public class SmsService
    {
        public async Task SmsSender(string Subject, string Msg, List<string> ToNumbers)
        {
            string url = "http://185.4.28.100/class/sms/restful/sendSms_OneToMany.php";
            string username = "doctormatab";
            string password = "M1234567890";
            string number = "+985000238328";
            HttpMessageHandler handler = new HttpClientHandler();
            var httpClient = new HttpClient(handler)
            {
                BaseAddress = new Uri(url),
                Timeout = new TimeSpan(0, 2, 0)
            };
            httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(username + ":" + password);
            string val = System.Convert.ToBase64String(plainTextBytes);
            httpClient.DefaultRequestHeaders.Add("Authorization", "Basic " + val);
            SmsPrincpleToOne providerss = new SmsPrincpleToOne
            {
                uname = username,
                pass = password,
                from = number,
                to = ToNumbers,
                msg = Msg,
            };
            var method = new HttpMethod("GET");
            string strPayload = JsonConvert.SerializeObject(providerss);
            HttpContent c = new StringContent(strPayload, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.PostAsync(url, c).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                var customerJsonString = await response.Content.ReadAsStringAsync();

            }
        }
    }

    public class Result
    {
        public string status { get; set; }
        public string statusId { get; set; }
    }

    public class SmsResponse
    {
        public int errCode { get; set; }
        public Result result { get; set; }
    }
    public class SmsPrincpleToOne
    {
        public string uname { get; set; }
        public string pass { get; set; }
        public string from { get; set; }
        public string msg { get; set; }
        public List<string> to { get; set; }
    }

    public class GetStatus
    {
        public string uname { get; set; }
        public string pass { get; set; }
        public string uniqueID { get; set; }
        public string ManyToMany { get; set; }
    }
    public class SmsPrincpleToMany
    {
        public string uname { get; set; }
        public string pass { get; set; }
        public string from { get; set; }

        public ManyToManySmsNumberAndMsg content { get; set; }
    }

    public class ManyToManySmsNumberAndMsg
    {
        public List<string> to { get; set; }
        public List<string> msg { get; set; }
    }
    public class ErrorMsg
    {
        public int errCode { get; set; }
        public IList<string> result { get; set; }
        public int msgId { get; set; }

    }
}