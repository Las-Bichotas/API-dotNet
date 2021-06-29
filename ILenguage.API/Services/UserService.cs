using ILenguage.API.Domain.Models;
using ILenguage.API.Domain.Persistence.Repositories;
using ILenguage.API.Domain.Repositories;
using ILenguage.API.Domain.Services;
using ILenguage.API.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;
using ILenguage.API.Settings;
using System.Text;
using System.Security.Claims;

namespace ILenguage.API.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserSubscriptionRepository _userSubscriptionRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IUserTopicRepository _userTopicRepository;
        private readonly IUserLanguageRepository _userLanguageRepository;
        private readonly IUserSessionRepository _userSessionRepository;
        private readonly AppSettings _appSettings;

        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork, IUserSubscriptionRepository userSubscriptionRepository,  IRoleRepository roleRepository, IUserTopicRepository userTopicRepository, IUserLanguageRepository userLanguageRepository, IUserSessionRepository userSessionRepository, IOptions<AppSettings> appsettings)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _userSubscriptionRepository = userSubscriptionRepository;
            _roleRepository = roleRepository;
            _userTopicRepository = userTopicRepository;
            _userLanguageRepository = userLanguageRepository;
            _userSessionRepository = userSessionRepository;
            _appSettings = appsettings.Value;
        }
        public AuthenticationResponse Authenticate(AuthenticationRequest request)
        {
            // el username va a ser comparado con el correo
            var user =_userRepository.users().SingleOrDefault(x=>
            x.Email == request.Username && 
            x.Password==request.Password);
            
            if (user == null) return null;
            var token = GenerateJwtToken(user);
            return new AuthenticationResponse(user,token);
        }
        private string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var Key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name,user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public async Task<IEnumerable<User>> ListAsync()
        {
            return await _userRepository.ListAsync();
        }
        public async Task<UserResponse> DeleteAsync(int userId)
        {
            var exitingUser = await _userRepository.FindById(userId);
            if (exitingUser == null)
                return new UserResponse("User not found");
            try
            {
                _userRepository.Remove(exitingUser);
                await _unitOfWork.CompleteAsync();
                return new UserResponse(exitingUser);
            }
            catch (Exception ex)
            {
                return new UserResponse($"and error ocurrend while deleteing user: {ex.Message}");
            }
        }

        public async Task<IEnumerable<User>> ListBySubscriptionId(int subscriptionId)
        {
            var userSubscription = await _userSubscriptionRepository.ListBySubscriptionId(subscriptionId);
            var users = userSubscription.Select(us => us.User).ToList();
            return users;
        }
        

        public async Task<UserResponse> GetByIdAsync(int userId)
        {
            var existingUser = await _userRepository.FindById(userId);
            if (existingUser == null)
                return new UserResponse("User not found");

            return new UserResponse(existingUser);
        }


        public async Task<UserResponse> SaveAsync(User user, int roleId)
        {
            var existingRole = await _roleRepository.FindById(roleId);
            if (existingRole == null)
                return new UserResponse("Role to assing User not found");
            user.Role = existingRole;
            user.RoleId = roleId;
            try
            {
                await _userRepository.AddAsync(user);
                await _unitOfWork.CompleteAsync();
                return new UserResponse(user);
            }
            catch (Exception ex)
            {
                return new UserResponse($"An error ocurred while saving the user: {ex.Message}");
            }
        }

        public async Task<UserResponse> UpdateAsync(int userId, User user)
        {
            var existingUser = await _userRepository.FindById(userId);
            if (existingUser == null)
                return new UserResponse("User not found");
            existingUser.Name = user.Name;
            existingUser.LastName = user.LastName;
            existingUser.Description = user.Description;
            existingUser.Email = user.Email;
            existingUser.Password = user.Password;
            existingUser.RelatedUsers = user.RelatedUsers;

            try
            {
                _userRepository.Update(existingUser);
                await _unitOfWork.CompleteAsync();
                return new UserResponse(existingUser);
            }
            catch (Exception ex)
            {
                return new UserResponse($"An error ocurrned while updating user: {ex.Message}");
            }
        }

        public async Task<IEnumerable<User>> ListByRoleId(int roleId)
        {
            return await _userRepository.ListUsersByRoleId(roleId);
        }

        public async Task<IEnumerable<User>> ListByRoleIdAndTopicId(int roleId, int topicId)
        {
            var userTopics = await _userTopicRepository.ListByRoleIdAndTopicId(roleId, topicId);
            var users = userTopics.Select(ut => ut.User).ToList();
            return users;
        }

        public async Task<IEnumerable<User>> ListByRoleIdAndLanguageId(int roleId, int languageId)
        {
            var userLanguages = await _userLanguageRepository.ListByRoleIdAndLanguageId(roleId, languageId);
            var users = userLanguages.Select(ul => ul.User).ToList();
            return users;
        }

        public async Task<IEnumerable<User>> ListTuthorsByLanguageIdAndTopicId(int languageId, int topicId)
        {
            var userLanguages = await _userLanguageRepository.ListByLanguageIdAsync(languageId);
            var userTopics = await _userTopicRepository.ListByTopicId(topicId);

            var users = userLanguages.Join(userTopics,
             ul => ul.UserId,
             ut => ut.UserId,
             (ul, ut) => new
             {
                 ul.User
             }).Where(u => u.User.RoleId == 2).Select(u => u.User);

            return users;
        }

        public async Task<UserResponse> GetByEmailAndPasswordAsync(string email, string password)
        {
            var existingUser = await _userRepository.FindByEmailAndPassword(email, password);
            if (existingUser == null)
                return new UserResponse("User not found");

            return new UserResponse(existingUser);
        }

        /* */
        
        public async Task<IEnumerable<User>> ListBySessionIdAsync(int sessionId)
        {
            var userSessions = await _userSessionRepository.ListBySessionIdAsync(sessionId);
            var users = userSessions.Select(pt => pt.User).ToList();
            return users;
        }


    }
}