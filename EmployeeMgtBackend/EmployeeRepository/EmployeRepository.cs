using EmployeeModel;
using EmployeeModelLayer;
using EmployeeRepositoryLayer;
using EmployeeRepositoryLayer.IRepository;
using System;
using System.Linq;
using System.Text;

namespace EmployeeRepository
{
    public class EmployeRepository : IEmployeeRepository
    {
        private readonly EmployeeDBContext employeeContext;

        //Constructor of the Class
        public EmployeRepository(EmployeeDBContext employeeContext)
        {
            this.employeeContext = employeeContext;
        }

        /// <summary>
        /// Encrypting Password
        /// </summary>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        /// <exception cref="Exception">Error in Base64Encode" + e.Message</exception>
        
        public string PasswordEncryption(string password)
        {
            try
            {
                byte[] encData_byte = new byte[password.Length];
                encData_byte = Encoding.UTF8.GetBytes(password);
                string encodedPassword = Convert.ToBase64String(encData_byte);
                return encodedPassword;
            }
            catch (Exception e)
            {
                throw new Exception("Error in Base64Encode" + e.Message);
            }
        }

        /// <summary>
        /// Decrypting Password
        /// </summary>
        /// <param name="encryptPwd">The encrypt password.</param>
        /// <returns></returns>

        public static string DecryptPassword(string encryptPwd)
        {
            string decryptPwd = string.Empty;
            UTF8Encoding encodedPwd = new UTF8Encoding();
            Decoder Decode = encodedPwd.GetDecoder();
            byte[] toDecode_byte = Convert.FromBase64String(encryptPwd);
            int charCount = Decode.GetCharCount(toDecode_byte, 0, toDecode_byte.Length);
            char[] decoded_Char = new char[charCount];
            Decode.GetChars(toDecode_byte, 0, toDecode_byte.Length, decoded_Char, 0);
            decryptPwd = new String(decoded_Char);
            return decryptPwd;
        }

        /// <summary>
        /// Login User 
        /// </summary>
        /// <param name="login">The login.</param>
        /// <returns></returns>
        /// <exception cref="Exception">Error While Login " + e.Message</exception>
        
        public EmployeeModels LoginUser(LoginModel login)
        {
            try
            {
                var Result = employeeContext.EmployeeTable.Where<EmployeeModels>(e => e.Email == login.Email).FirstOrDefault();
                if (Result != null)
                {
                    string decryptPass = DecryptPassword(Result.Password);
                    if (login.Password == decryptPass)
                    {
                        return Result;
                    }
                }
                return null;
            }
            catch (Exception e)
            {
                throw new Exception("Error While Login " + e.Message);
            }
        }

        public EmployeeModels CreateEmployee(EmployeeModels add)
        {
            throw new NotImplementedException();
        }
    }
}
