using Domain;

namespace Application
{
    public class UserService
    {
        private readonly IUserRepository _repo;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUserRepository repo, IUnitOfWork unitOfWork)
        {
            _repo = repo;
            _unitOfWork = unitOfWork;
        }

        public void AddUser(AddUserDto dto)
        {
            var user = User.Create(dto.Name, dto.Email);
            _repo.Add(user);
            _unitOfWork.Commit();
        }

        public void EditUser(EditUserDto dto)
        {
            var user = _repo.GetById(dto.Id);
            if (user == null)
                throw new InvalidOperationException("User not found");

            user.ChangeName(dto.Name);
            user.ChangeEmail(dto.Email);
            _repo.Update(user);
            _unitOfWork.Commit();
        }
    }
}
