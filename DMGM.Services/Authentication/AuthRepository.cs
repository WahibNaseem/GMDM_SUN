using DMGM.Core.Domain.User;
using DMGM.Data.DBContext;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DMGM.Services.Authentication
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DMContext _mContext;
        public AuthRepository(DMContext mContext) => this._mContext = mContext;
        public async Task<User> Login(string username, string password)
        {
            var user = await this._mContext.Users.FirstOrDefaultAsync(x => x.Username == username);

            //return if user not found
            if (user == null)
                return null;

            //Verify the password with hashpassword
            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                  return null;

            return user;
        }

        public async Task<User> Register(User user, string password)
        {
            /* Create HashPassword through current password */
            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            /* Added the user */
            await this._mContext.Users.AddAsync(user);
            await this._mContext.SaveChangesAsync();

            return user;

        }

        public async Task<bool> UserExists(string username)
        {
            if (await this._mContext.Users.AnyAsync(x => x.Username == username))
                return true;

            return false;
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                //Get the computedHash Password of the Current Password
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    //Comparing each byte of computedhash password with passwordhash from the db
                    if (computedHash[i] != passwordHash[i]) return false;
                }
            }
            return true;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }

        }
    }
}
