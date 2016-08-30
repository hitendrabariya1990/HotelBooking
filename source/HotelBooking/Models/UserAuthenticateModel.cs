using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace HotelBooking.Models
{
    public class UserAuthenticateModel
    {
        private string m_endUserIp = HttpContext.Current.Request.UserHostAddress;
        [Required]
        public string EndUserIp
        {
            get
            {
                return "192.168.0.100";
            }
            set
            {
                value = m_endUserIp;
            }
        }

        private static string m_memberMobileNo = "7405007979";
        [Required]
        public string MemberMobileNo
        {
            get { return m_memberMobileNo; }
            set { value = m_memberMobileNo; }
        }

        private static string m_memberMobilePin = "1021";
        [Required]
        public string MemberMobilePin
        {
            get { return m_memberMobilePin; }
            set { value = m_memberMobilePin; }
        }

        [JsonProperty(PropertyName = "TokenId")]
        public string TokenId { get; set; }
    }

    public class UserAuthenticateRequest : UserAuthenticateModel
    {
        
    }

    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class UserAuthenticateResponse : UserAuthenticateModel
    {
        [JsonProperty(PropertyName = "Status")]
        public int Status { get; set; }

        [JsonProperty(PropertyName = "Error")]
        public Error Error { get; set; }

    }

    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class BindCountryRequest  : UserAuthenticateModel
    {
       
    }

    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class  BindCountryResponse : UserAuthenticateModel
    {
        [JsonProperty(PropertyName = "Country")]
        public string Country { get; set; }
        [JsonProperty(PropertyName = "Countrycode")]
        public string Countrycode { get; set; }

        [JsonProperty(PropertyName = "Status")]
        public int Status { get; set; }

        [JsonProperty(PropertyName = "Error")]
        public Error Error { get; set; }

    }
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class BindCityResponse : UserAuthenticateModel
    {
        [JsonProperty(PropertyName = "Country")]
        public string Destination { get; set; }
        [JsonProperty(PropertyName = "City")]
        public int Cityid { get; set; }

        //[JsonProperty(PropertyName = "Status")]
        //public int Status { get; set; }

        //[JsonProperty(PropertyName = "Error")]
        //public Error Error { get; set; }

    }

    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class Error
    {
        [JsonProperty(PropertyName = "ErrorCode")]
        public int ErrorCode { get; set; }

        [JsonProperty(PropertyName = "ErrorMessage")]
        public string ErrorMessage { get; set; }
    }

    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class RoomGuest
    {
        public int NoOfAdults { get; set; }
        public int NoOfChild { get; set; }
        public List<int> ChildAge { get; set; }
    }

    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class HotelSearchRequest : UserAuthenticateModel
    {
        public int BookingMode { get; set; }
        public string CheckInDate { get; set; }
        public int NoOfNights { get; set; }
        public string CountryCode { get; set; }
        public string CityId { get; set; }
        public string PreferredCurrency { get; set; }
        public string GuestNationality { get; set; }
        public int NoOfRooms { get; set; }
        public int MaxRating { get; set; }
        public int MinRating { get; set; }

        public List<RoomGuest> RoomGuests { get; set; }
        public int OrderBy { get; set; }
        public int SortBy { get; set; }
        public int ResultCount { get; set; }

    }

    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class Price
    {
        public string CurrencyCode { get; set; }
        public double RoomPrice { get; set; }
        public int Tax { get; set; }
        public int ExtraGuestCharge { get; set; }
        public int ChildCharge { get; set; }
        public int OtherCharges { get; set; }
        public int Discount { get; set; }
        public double PublishedPrice { get; set; }
        public double PublishedPriceRoundedOff { get; set; }
        public double OfferedPrice { get; set; }
        public double OfferedPriceRoundedOff { get; set; }
        public int AgentCommission { get; set; }
        public int AgentMarkUp { get; set; }
        public int ServiceTax { get; set; }
        public int TDS { get; set; }
    }

    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class HotelResult
    {
        public int ResultIndex { get; set; }
        public string HotelCode { get; set; }
        public string HotelName { get; set; }
        public string HotelCategory { get; set; }
        public int StarRating { get; set; }
        public string HotelDescription { get; set; }
        public string HotelPromotion { get; set; }
        public string HotelPolicy { get; set; }
        public Price Price { get; set; }
        public string HotelPicture { get; set; }
        public string HotelAddress { get; set; }
        public string HotelContactNo { get; set; }
        public object HotelMap { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public object HotelLocation { get; set; }
        public object SupplierPrice { get; set; }
        public object TripAdvisor { get; set; }
    }

    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class MarkUp
    {
        public int MarkupType { get; set; }
        public int value { get; set; }
        public bool IsNegative { get; set; }
        public int CancelMarkUp { get; set; }
        public int ItemID { get; set; }
        public object ServiceID { get; set; }
        public object ServiceProviderID { get; set; }
    }

    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class HotelSearchResponse
    {
        public int ResponseStatus { get; set; }
        public Error Error { get; set; }
        public string TraceId { get; set; }
        public string CityId { get; set; }
        public string CheckInDate { get; set; }
        public string CheckOutDate { get; set; }
        public string PreferredCurrency { get; set; }
        public int NoOfRooms { get; set; }
        public List<RoomGuest> RoomGuests { get; set; }
        public List<HotelResult> HotelResults { get; set; }
        public MarkUp MarkUp { get; set; }
    }
}