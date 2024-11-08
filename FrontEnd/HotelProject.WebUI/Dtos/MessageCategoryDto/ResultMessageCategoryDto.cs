using HotelProject.WebUI.Dtos.ContactDto;

namespace HotelProject.WebUI.Dtos.MessageCategoryDto
{
    public class ResultMessageCategoryDto
    {
        public int MessageCategoryID { get; set; }
        public string MessageCategoryName { get; set; }
        public List<CreateContactDto> Contacts { get; set; } // ContactDto nesnesinden oluşan bir liste.Sonradan eklendi

    }
}
