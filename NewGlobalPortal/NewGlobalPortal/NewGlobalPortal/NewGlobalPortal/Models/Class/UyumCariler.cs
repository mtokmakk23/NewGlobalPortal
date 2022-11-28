using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewGlobalPortal.Models.Class
{

   

    public class UyumCariler
    {
        public int statusCode { get; set; }
        public string message { get; set; }
        public UyumCarilerResult result { get; set; }
        public int pageIndex { get; set; }
        public int pageSize { get; set; }
        public int totalPages { get; set; }
        public int totalCount { get; set; }
    }

    public class UyumCarilerResult
    {
        public Entity_M[] entitY_M { get; set; }
        public object[] entitY_BANK { get; set; }
        public Entity_ALIAS[] entitY_ALIAS { get; set; }
        public object[] entitY_ADDRESS { get; set; }
    }

    public class Entity_M
    {
        public string firstName { get; set; }
        public string familyName { get; set; }
        public string id { get; set; }
        public string createUserId { get; set; }
        public string createUsername { get; set; }
        public string updateUserId { get; set; }
        public string updateUsername { get; set; }
        public string createDate { get; set; }
        public string updateDate { get; set; }
        public string eInvoiceProfile { get; set; }
        public string invDeliveryType { get; set; }
        public string fax2 { get; set; }
        public string iseInvoiceEntity { get; set; }
        public string eInvoiceStartDate { get; set; }
        public string iseDespatchEntity { get; set; }
        public string eDespatchStartDate { get; set; }
        public string entityCode { get; set; }
        public string entityName { get; set; }
        public string entityNameShort { get; set; }
        public string capital { get; set; }
        public string enterpriceDate { get; set; }
        public string address3 { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string cityId { get; set; }
        public string townId { get; set; }
        public string zipCode { get; set; }
        public string fax { get; set; }
        public string tel1 { get; set; }
        public string tel2 { get; set; }
        public string email { get; set; }
        public string webSite { get; set; }
        public string taxOfficeId { get; set; }
        public string taxNo { get; set; }
        public string sectorId { get; set; }
        public string countryId { get; set; }
        public string identifyNo { get; set; }
        public string sectorCode { get; set; }
        public string cityName { get; set; }
        public string townName { get; set; }
        public string countryCode { get; set; }
        public string isoCountryCode { get; set; }
        public string countryName { get; set; }
        public string taxOfficeCode { get; set; }
        public string mobileTel { get; set; }
        public string taxOfficeName { get; set; }
        public string sectorName { get; set; }
        public string latitude { get; set; }
        public string passportNo { get; set; }
        public string longitude { get; set; }
        public string declarationAdressNo { get; set; }
        public string entityNote { get; set; }
        public string langCode { get; set; }
        public string langDesc { get; set; }
        public string langId { get; set; }
        public string addDate01 { get; set; }
        public string addDate02 { get; set; }
        public string addDate03 { get; set; }
        public string addDate04 { get; set; }
        public string addDate05 { get; set; }
        public string addDate06 { get; set; }
        public string addDate07 { get; set; }
        public string addDate08 { get; set; }
        public string addDate09 { get; set; }
        public string addDate10 { get; set; }
        public string addDec01 { get; set; }
        public string addDec02 { get; set; }
        public string addDec03 { get; set; }
        public string addDec04 { get; set; }
        public string addDec05 { get; set; }
        public string addDec06 { get; set; }
        public string addDec07 { get; set; }
        public string addDec08 { get; set; }
        public string addDec09 { get; set; }
        public string addDec10 { get; set; }
        public string addString01 { get; set; }
        public string addString02 { get; set; }
        public string addString03 { get; set; }
        public string addString04 { get; set; }
        public string addString05 { get; set; }
        public string addString06 { get; set; }
        public string addString07 { get; set; }
        public string addString08 { get; set; }
        public string addString09 { get; set; }
        public string addString10 { get; set; }
        public string addressType { get; set; }
        public string shippingMethodId { get; set; }
        public string shippingMethodCode { get; set; }
        public string freightTermsId { get; set; }
        public string freightTermsCode { get; set; }
        public string addressTypeId { get; set; }
        public string addressTypeCode { get; set; }
        public string entityCategory { get; set; }
        public string amtAnnualRevenue { get; set; }
        public string parentEntityName { get; set; }
        public string entityNumber { get; set; }
        public string entityType { get; set; }
        public string freightTerms { get; set; }
        public string ispassive { get; set; }
        public string isEmail { get; set; }
        public string isFax { get; set; }
        public string isLetter { get; set; }
        public string isTel { get; set; }
        public string leadId { get; set; }
        public string leadName { get; set; }
        public string noteLarge { get; set; }
        public string ownerUserId { get; set; }
        public string ownerUserCode { get; set; }
        public string ownerUserName { get; set; }
        public string ownerUserSurname { get; set; }
        public string parentEntityId { get; set; }
        public string preferred { get; set; }
        public string primaryContactId { get; set; }
        public string primaryContactName { get; set; }
        public string primaryContactCode { get; set; }
        public string qtyEmployee { get; set; }
        public string regionCode { get; set; }
        public string regionName { get; set; }
        public string regionId { get; set; }
        public string passiveReasonId { get; set; }
        public string salutation { get; set; }
        public string shippingMethod { get; set; }
        public string mailAttachmentInf { get; set; }
        public string isPublic { get; set; }
        public string isSms { get; set; }
        public string isVariousEntity { get; set; }
        public string categories10Id { get; set; }
        public string categories11Id { get; set; }
        public string categories12Id { get; set; }
        public string categories13Id { get; set; }
        public string categories14Id { get; set; }
        public string categories15Id { get; set; }
        public string categories16Id { get; set; }
        public string categories17Id { get; set; }
        public string categories18Id { get; set; }
        public string categories19Id { get; set; }
        public string categories1Id { get; set; }
        public string categories20Id { get; set; }
        public string categories2Id { get; set; }
        public string categories3Id { get; set; }
        public string categories4Id { get; set; }
        public string categories5Id { get; set; }
        public string categories6Id { get; set; }
        public string categories7Id { get; set; }
        public string categories8Id { get; set; }
        public string categories9Id { get; set; }
        public string categories10Code { get; set; }
        public string categories11Code { get; set; }
        public string categories12Code { get; set; }
        public string categories13Code { get; set; }
        public string categories14Code { get; set; }
        public string categories15Code { get; set; }
        public string categories16Code { get; set; }
        public string categories17Code { get; set; }
        public string categories18Code { get; set; }
        public string categories19Code { get; set; }
        public string categories1Code { get; set; }
        public string categories20Code { get; set; }
        public string categories2Code { get; set; }
        public string categories3Code { get; set; }
        public string categories4Code { get; set; }
        public string categories5Code { get; set; }
        public string categories6Code { get; set; }
        public string categories7Code { get; set; }
        public string categories8Code { get; set; }
        public string categories9Code { get; set; }
        public string categories10Desc { get; set; }
        public string categories11Desc { get; set; }
        public string categories12Desc { get; set; }
        public string categories13Desc { get; set; }
        public string categories14Desc { get; set; }
        public string categories15Desc { get; set; }
        public string categories16Desc { get; set; }
        public string categories17Desc { get; set; }
        public string categories18Desc { get; set; }
        public string categories19Desc { get; set; }
        public string categories1Desc { get; set; }
        public string categories20Desc { get; set; }
        public string categories2Desc { get; set; }
        public string categories3Desc { get; set; }
        public string categories4Desc { get; set; }
        public string categories5Desc { get; set; }
        public string categories6Desc { get; set; }
        public string categories7Desc { get; set; }
        public string categories8Desc { get; set; }
        public string categories9Desc { get; set; }
        public string radius { get; set; }
        public string naceCodeId { get; set; }
        public string naceActCode { get; set; }
        public string naceDescription { get; set; }
        public string isBatchUpdateEntity { get; set; }
        public string entityBankCollection { get; set; }
        public string entityItemCollection { get; set; }
        public string entityLangCollection { get; set; }
        public string entityAliasCollection { get; set; }
        public string coEntityCollection { get; set; }
        public string entityDespatchAliasCollection { get; set; }
        public string entityAdressCollection { get; set; }
        public string coEntityContactCollection { get; set; }
        public string coEntityIntgCollection { get; set; }
        public string coEntityDiscCollection { get; set; }
        public string eInvoicePartyIdentificationCollection { get; set; }
        public string modified { get; set; }
        public string senarioMod { get; set; }
        public string promptValue { get; set; }
        public string promptValues { get; set; }
        public string justUpdate { get; set; }
        public object controlProperties { get; set; }
        public object uyumObjectContainerCollection { get; set; }
        public string parent { get; set; }
        public string dynamicValues { get; set; }
        public string guid { get; set; }
        public string extendedObjects { get; set; }
    }

    public class Entity_ALIAS
    {
        public string id { get; set; }
        public string createUserId { get; set; }
        public string updateUserId { get; set; }
        public string createDate { get; set; }
        public string updateDate { get; set; }
        public string eAlias { get; set; }
        public string description { get; set; }
        public string entityId { get; set; }
        public string entityCode { get; set; }
        public string entityName { get; set; }
        public string isDefaultAlias { get; set; }
        public string modified { get; set; }
        public string senarioMod { get; set; }
        public string promptValue { get; set; }
        public string promptValues { get; set; }
        public string justUpdate { get; set; }
        public object controlProperties { get; set; }
        public object uyumObjectContainerCollection { get; set; }
        public string parent { get; set; }
        public string dynamicValues { get; set; }
        public string guid { get; set; }
        public string extendedObjects { get; set; }
    }


}