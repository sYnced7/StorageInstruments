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

        public static InstrumentDto InstrumentToDto(Instrument instrument)
        {
            return new InstrumentDto()
            {
                Id = instrument.Id,
                Name = instrument.Name,
                Location = instrument.Location,
                owner = instrument.owner,
                Type = instrument.Type
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

        public static UserDto UserToDto(User user)
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
