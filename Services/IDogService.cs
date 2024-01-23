using EXAMEN.Models.Dog;
using EXAMEN.Models.Dog.Dto;

namespace EXAMEN.Services
{
    public interface IDogService
    {
        Task<IEnumerable<DogDto>> GetAllDogsAsync();
        Task<Dog> CreateDogAsync(DogDto dogDto);

        Task<Dog> getDogByIdAsync(Guid id);
    }

}
