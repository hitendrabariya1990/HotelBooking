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
        [JsonProperty(PropertyName = "CurrencyCode")]
        public string CurrencyCode { get; set; }
        [JsonProperty(PropertyName = "RoomPrice")]
        public decimal RoomPrice { get; set; }
        [JsonProperty(PropertyName = "Tax")]
        public decimal Tax { get; set; }
        [JsonProperty(PropertyName = "ExtraGuestCharge")]
        public decimal ExtraGuestCharge { get; set; }
        [JsonProperty(PropertyName = "ChildCharge")]
        public decimal ChildCharge { get; set; }
        [JsonProperty(PropertyName = "OtherCharges")]
        public decimal OtherCharges { get; set; }
        [JsonProperty(PropertyName = "Discount")]
        public decimal Discount { get; set; }
        [JsonProperty(PropertyName = "PublishedPrice")]
        public decimal PublishedPrice { get; set; }
        [JsonProperty(PropertyName = "PublishedPriceRoundedOff")]
        public decimal PublishedPriceRoundedOff { get; set; }
        [JsonProperty(PropertyName = "OfferedPrice")]
        public decimal OfferedPrice { get; set; }
        [JsonProperty(PropertyName = "OfferedPriceRoundedOff")]
        public decimal OfferedPriceRoundedOff { get; set; }
        [JsonProperty(PropertyName = "AgentCommission")]
        public decimal AgentCommission { get; set; }
        [JsonProperty(PropertyName = "StarRating")]
        public int AgentMarkUp { get; set; }
        [JsonProperty(PropertyName = "ServiceTax")]
        public decimal ServiceTax { get; set; }
        [JsonProperty(PropertyName = "TDS")]
        public decimal TDS { get; set; }
    }

    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class HotelResult
    {
        [JsonProperty(PropertyName = "ResultIndex")]
        public int ResultIndex { get; set; }
        [JsonProperty(PropertyName = "HotelCode")]
        public string HotelCode { get; set; }
        [JsonProperty(PropertyName = "HotelName")]
        public string HotelName { get; set; }
        [JsonProperty(PropertyName = "HotelCategory")]
        public string HotelCategory { get; set; }
        [JsonProperty(PropertyName = "StarRating")]
        public int StarRating { get; set; }
        [JsonProperty(PropertyName = "HotelDescription")]
        public string HotelDescription { get; set; }
        [JsonProperty(PropertyName = "HotelPromotion")]
        public string HotelPromotion { get; set; }
        [JsonProperty(PropertyName = "HotelPolicy")]
        public string HotelPolicy { get; set; }
        [JsonProperty(PropertyName = "Price")]
        public Price Price { get; set; }
        [JsonProperty(PropertyName = "HotelPicture")]
        public string HotelPicture { get; set; }
        [JsonProperty(PropertyName = "HotelAddress")]
        public string HotelAddress { get; set; }
        [JsonProperty(PropertyName = "HotelContactNo")]
        public string HotelContactNo { get; set; }
        [JsonProperty(PropertyName = "HotelMap")]
        public object HotelMap { get; set; }
        [JsonProperty(PropertyName = "Latitude")]
        public string Latitude { get; set; }
        [JsonProperty(PropertyName = "Longitude")]
        public string Longitude { get; set; }
        [JsonProperty(PropertyName = "HotelLocation")]
        public object HotelLocation { get; set; }
        [JsonProperty(PropertyName = "SupplierPrice")]
        public object SupplierPrice { get; set; }
        [JsonProperty(PropertyName = "TripAdvisor")]
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
        [JsonProperty(PropertyName = "ResponseStatus")]
        public int ResponseStatus { get; set; }
        [JsonProperty(PropertyName = "Error")]
        public Error Error { get; set; }

        [JsonProperty(PropertyName = "TraceId")]
        public string TraceId { get; set; }

        [JsonProperty(PropertyName = "CityId")]
        public string CityId { get; set; }
        [JsonProperty(PropertyName = "CheckInDate")]
        public string CheckInDate { get; set; }
        [JsonProperty(PropertyName = "CheckOutDate")]
        public string CheckOutDate { get; set; }
        [JsonProperty(PropertyName = "PreferredCurrency")]
        public string PreferredCurrency { get; set; }
        [JsonProperty(PropertyName = "NoOfRooms")]
        public int NoOfRooms { get; set; }
        [JsonProperty(PropertyName = "RoomGuests")]
        public List<RoomGuest> RoomGuests { get; set; }
        [JsonProperty(PropertyName = "HotelResults")]
        public List<HotelResult> HotelResults { get; set; }
        [JsonProperty(PropertyName = "MarkUp")]
        public MarkUp MarkUp { get; set; }
    }
}