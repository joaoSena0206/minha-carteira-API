using back_end.Data;

namespace back_end.Services;

public class UserService
{
    private readonly UserRepository _userRepository;

    public UserService(UserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task DeleteUser(string username)
    {
        await _userRepository.DeleteUser(username);
    }
}