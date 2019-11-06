using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;

namespace CAntad.Helpers
{
    public static class RegexHelper
    {
        public static bool IsValidEmailAddress(string emailaddress)
        {
            try
            {
                var email = new MailAddress(emailaddress);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
        public static bool IsValidCurp(string curp)
        {
            //Regex Val = new Regex("^.*(?=.{18})(?=.*[0-9])(?=.*[A-ZÑ]).*$");
            //Regex Val = new Regex("^[A-Z]{1}[AEIOU]{1}[A-Z]{2}[0-9]{2}(0[1-9]|1[0-2])(0[1-9]|1[0-9]|2[0-9]|3[0-1])[HM]{1}(AS|BC|BS|CC|CS|CH|CL|CM|DF|DG|GT|GR|HG|JC|MC|MN|MS|NT|NL|OC|PL|QT|QR|SP|SL|SR|TC|TS|TL|VZ|YN|ZS|NE)[B-DF-HJ-NP-TV-Z]{3}[0-9A-Z]{1}[0-9]{1}$");
            Regex Val = new Regex("^[A-Z|a-z]{1}[AEIOU|aeiou]{1}[A-Z|a-z]{2}[0-9]{2}(0[1-9]|1[0-2])(0[1-9]|1[0-9]|2[0-9]|3[0-1])[HM||hm]{1}(AS|BC|BS|CC|CS|CH|CL|CM|DF|DG|GT|GR|HG|JC|MC|MN|MS|NT|NL|OC|PL|QT|QR|SP|SL|SR|TC|TS|TL|VZ|YN|ZS|NE|as|bc|bs|cc|cs|ch|cl|cm|df|dg|gt|gr|hg|jc|mc|mn|ms|nt|nl|oc|pl|qt|qr|sp|sl|sr|tc|ts|tl|vz|yn|zs|ne)[B-DF-HJ-NP-TV-Z|b-df-hj-np-tv-z]{3}[0-9A-Z|0-9a-z]{1}[0-9]{1}$");

            try
            {
                if (Val.IsMatch(curp))
                {
                    return true;
                }
                return false;
                /*if (!curp.match(/[a-zA-Z]{4,4}[0-9]{6}[a-zA-Z]{6,6}[0-9]{2}/) ){

            var cu = new MailAddress(curp);
            return true;*/
            }
            catch (FormatException)
            {
                return false;
            }
        }
        public static bool IsValidTel(string telefono)
        {
            //Regex Val = new Regex("^.*(?=.{18})(?=.*[0-9])(?=.*[A-ZÑ]).*$");
            Regex Val = new Regex(@"^{10}[0-9]+$");
            try
            {
                if (Val.IsMatch(telefono))
                {
                    return true;
                }
                return false;
                /*if (!curp.match(/[a-zA-Z]{4,4}[0-9]{6}[a-zA-Z]{6,6}[0-9]{2}/) ){

            var cu = new MailAddress(curp);
            return true;*/
            }
            catch (FormatException)
            {
                return false;
            }
        }
        public static bool IsValidCP(string cp)
        {
            //Regex Val = new Regex("^.*(?=.{18})(?=.*[0-9])(?=.*[A-ZÑ]).*$");
            Regex Val = new Regex(@"^{5}[0-9]+$");
            try
            {
                if (Val.IsMatch(cp))
                {
                    return true;
                }
                return false;
                /*if (!curp.match(/[a-zA-Z]{4,4}[0-9]{6}[a-zA-Z]{6,6}[0-9]{2}/) ){

            var cu = new MailAddress(curp);
            return true;*/
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
