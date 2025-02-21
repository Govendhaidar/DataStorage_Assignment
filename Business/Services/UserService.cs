using Business.DTOs;
using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Interfaces;

namespace Data.Services;


public class UserService(IUserRepository userRepository) : IUserService
{
    private readonly IUserRepository _userRepository = userRepository;


    public async Task<User?> CreateUserAsync(UserRegistrationForm form)
    {
        var existingUser = await _userRepository.GetAsync(x => x.Email == form.Email);
        if (existingUser != null)
        {
            return null;
        }

        var userEntity = UserFactory.Create(form);
        await _userRepository.CreateAsync(userEntity!);

        return UserFactory.Create(userEntity!);
    }





    public async Task<IEnumerable<User?>> GetAllUsersAsync()
    {
        var userEntities = await _userRepository.GetAllAsync();
        return userEntities.Select(UserFactory.Create);
    }





    public async Task<User?> GetUserByIdAsync(int id)
    {
        var userEntity = await _userRepository.GetAsync(x => x.Id == id);
        return userEntity != null ? UserFactory.Create(userEntity) : null;
    }





    public async Task<bool> UpdateUserAsync(int id, UserUpdateForm form)
    {
        if (id <= 0)
        {
            return false;
        }

        var existingUser = await _userRepository.GetAsync(x => x.Id == id);
        if (existingUser != null)
        {
            existingUser.Id = form.Id;
            existingUser.FirstName = form.FirstName;
            existingUser.LastName = form.LastName;
            existingUser.Email = form.Email;

            await _userRepository.UpdateAsync(existingUser);
        }

        return true;
    }





    public  async Task<bool> DeleteUserAsync(int id)
    {
        var existingUser = await _userRepository.GetAsync(x => x.Id == id);
        if (existingUser != null)
        {
            return false;
        }

        return await _userRepository.DeleteAsync(x => x.Id == id);
    }
}
