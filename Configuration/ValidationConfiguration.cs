/*
* Description:
*  Configuration file with four fields which will be 
*  adjusted in the appsettings.json file.
**********************************
*/


namespace ivanStojk_CRUD_API.Configuration
{
    public class ValidationConfiguration
    {
        public int HotelIdMaxCharacters { get; set; }
        public int FirstNameMaxCharacters { get; set; }
        public int LastNameMaxCharacters { get; set; }
        public int RoomNumberMaxCharacters { get; set; }

        public int RoomNumberMaxValue { get; set; }

        public string HotelRegex { get; set; }
    }
}