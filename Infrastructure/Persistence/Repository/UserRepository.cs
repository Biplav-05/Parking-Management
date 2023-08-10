using Application.UserService.Interfaces;
using Dapper;
using Domain.Model;
using Infrastructure.Persistence.Data;
using System.Data;

namespace Infrastructure.Persistence.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DapperDbContext _dbContext;
        public UserRepository(DapperDbContext dapperDb)
        {
            _dbContext = dapperDb;
        }

        public async Task<string> CreateUser(CreateUserModel model)
        {
            var user = new UserModel
            {
                id = Guid.NewGuid(),
                firstname = model.firstName,
                lastname = model.lastName,
                email = model.email,
                password = model.password,
                gender = model.gender,
                organization = model.organization,
                isactive = true,
                requirespasswordrest = true
            };

            var parameter = new DynamicParameters();
            parameter.Add("id", user.id, DbType.Guid);
            parameter.Add("firstname", user.firstname, DbType.String);
            parameter.Add("lastname", user.lastname, DbType.String);
            parameter.Add("email", user.email, DbType.String);
            parameter.Add("gender", user.gender, DbType.String);
            parameter.Add("organization", user.organization, DbType.String);
            parameter.Add("isactive", user.isactive, DbType.Boolean);
            parameter.Add("requirespasswordreset", user.requirespasswordrest, DbType.Boolean);
            parameter.Add("password", user.password, DbType.String);           
           
            string query = "Insert into Users (id,firstname,lastname,email,gender,organization,isactive,requirespasswordreset,password) values" +
                " (@id,@firstname,@lastname,@email,@gender,@organization,@isactive,@requirespasswordreset,@password)";
            using (var connection = _dbContext.CreateConnection())
            {
                int result = await connection.ExecuteAsync(query, parameter);
                if(result >0 )
                {
                    return "Pass";
                }
                return "False";
            }
        }

        public async Task<List<UserModel>> GetAllUser()
        {
            var query = "select * from Users";
            using(var connection = _dbContext.CreateConnection())
            {
                var user = await connection.QueryAsync<UserModel>(query);
                return user.ToList();
            }
        }

        public async Task<UserModel> GetUserById(Guid Id)
        {
            var query = $"select * from Users where id = '{Id}'";
            using(var connection = _dbContext.CreateConnection())
            {
                var foundUser = await connection.QuerySingleOrDefaultAsync<UserModel>(query);
                if(foundUser != null)
                {
                    return foundUser;
                }
                return new UserModel();
            }
        }

        public async Task<UserModel> UpdateUser(UserModel user)
        {
            //var query = $"update Users set firstname = '',lastname ='' , email = '', gender = '' , organization = '' , isactive= false , requirespasswordreset = false , password= '' where id='{user.id}'";
            return new UserModel();
        }
    }
}
