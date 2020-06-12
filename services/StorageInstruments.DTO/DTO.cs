using StorageInstruments.Model;

namespace StorageInstruments.DTO
{
    public class DTO
    {
        public static Instrument DtoToInstrument(InstrumentDto instrumentDto)
        {
            return new Instrument()
            {
                Id = instrumentDto.Id,
                Name = instrumentDto.Name,
                Location = instrumentDto.Location,
                owner = instrumentDto.owner,
                Type = instrumentDto.Type
            };
        }

        public static Instrument InstrumentToDto(InstrumentDto instrumentDto)
        {
            return new Instrument()
            {
                Id = instrumentDto.Id,
                Name = instrumentDto.Name,
                Location = instrumentDto.Location,
                owner = instrumentDto.owner,
                Type = instrumentDto.Type
            };
        }

        public static User DtoToUser(UserDto userDto)
        {
            return new User()
            {
                Id = userDto.Id,
                UserName = userDto.UserName,
                Password = userDto.Password,
                UserType = userDto.UserType,
            };
        }

        public static UserDto ToDto(User user)
        {
            return new UserDto()
            {
                Id = user.Id,
                UserName = user.UserName,
                UserType = user.UserType,
                Logged = false
            };
        }
    }
}
