using System;
using System.Linq;
using System.Web.Security;
using faktury.Models.Modele;
using System.Security.Cryptography;

namespace faktury.Models
{
    public class MojMembershipProvider : MembershipProvider
    {
        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            
            throw new NotImplementedException();
        }

        public static MembershipUser CreateUser(Uzytkownicy u, int kodPocztowy, int Rola, out MembershipCreateStatus status)
        {
            Uzytkownicy uzytkownikIstnieje = UzytkownikModel.PobierzUzytkownikaPoLoginie(u.Login);
            if (uzytkownikIstnieje != null)
            {
                status = MembershipCreateStatus.DuplicateUserName;
                return null;
            }
            u.KodPocztowyID = kodPocztowy;
            u.RolaID = Rola;
            UzytkownikModel.DodajUzytkownika(u);
            status = MembershipCreateStatus.Success;
            return null;
        }

        internal static MembershipUser CreateUser(Uzytkownicy u, int Rola, out MembershipCreateStatus status)
        {
            Uzytkownicy uzytkownikIstnieje = UzytkownikModel.PobierzUzytkownikaPoLoginie(u.Login);
            if (uzytkownikIstnieje != null)
            {
                status = MembershipCreateStatus.DuplicateUserName;
                return null;
            }
            u.RolaID = Rola;
            UzytkownikModel.DodajUzytkownika(u);
            status = MembershipCreateStatus.Success;
            return null;
        }
        //
        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            throw new NotImplementedException();
        }

        public override bool EnablePasswordReset
        {
            get { throw new NotImplementedException(); }
        }

        public override bool EnablePasswordRetrieval
        {
            get { throw new NotImplementedException(); }
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override int GetNumberOfUsersOnline()
        {
            throw new NotImplementedException();
        }

        public override string GetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(string username, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override string GetUserNameByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public override int MaxInvalidPasswordAttempts
        {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredNonAlphanumericCharacters
        {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredPasswordLength
        {
            get { throw new NotImplementedException(); }
        }

        public override int PasswordAttemptWindow
        {
            get { throw new NotImplementedException(); }
        }

        public override MembershipPasswordFormat PasswordFormat
        {
            get { throw new NotImplementedException(); }
        }

        public override string PasswordStrengthRegularExpression
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresQuestionAndAnswer
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresUniqueEmail
        {
            get { throw new NotImplementedException(); }
        }

        public override string ResetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override bool UnlockUser(string userName)
        {
            throw new NotImplementedException();
        }

        public override void UpdateUser(MembershipUser user)
        {
            throw new NotImplementedException();
        }


        public override bool ValidateUser(string login, string password)
        {
            using (FakturyDBEntitiess db = new FakturyDBEntitiess())
            {
                var uzytkownik = from u in db.Uzytkownicy where (u.Login == login) select u;

                if (uzytkownik != null && uzytkownik.Count() != 0)
                {
                    var dbuser = uzytkownik.First();

                    if (dbuser.Haslo == StworzHaslo(password, dbuser.HasloSzum))
                        return true;
                    else
                        return false;
                }
                else
                {
                    return false;
                }
            }
        }

        private static string StworzSol()
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] buff = new byte[32];
            rng.GetBytes(buff);

            return Convert.ToBase64String(buff);
        }

        private static string StworzHaslo(string pwd, string salt)
        {
            string saltAndPwd = String.Concat(pwd, salt);
            string hashedPwd =
                    FormsAuthentication.HashPasswordForStoringInConfigFile(saltAndPwd, "sha1");
            return hashedPwd;
        }
    }
}