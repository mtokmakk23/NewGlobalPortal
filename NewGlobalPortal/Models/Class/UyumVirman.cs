using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewGlobalPortal.Models.Class
{


    public class UyumVirmanOnaySonucu
    {
        public int statusCode { get; set; }
        public string message { get; set; }
        public int result { get; set; }
    }

    public class UyumVirmanHataSonucu
    {
        public int statusCode { get; set; }
        public string message { get; set; }
        public UyumVirmanResponseexception responseException { get; set; }
    }

    public class UyumVirmanResponseexception
    {
        public bool isError { get; set; }
        public string exceptionMessage { get; set; }
    }

    public class UyumVirman
    {
        public UyumVirmanValue value { get; set; }
        public int pageIndex { get; set; }
        public int pageSize { get; set; }
        public int totalPages { get; set; }
        public int totalCount { get; set; }
    }

    public class UyumVirmanValue
    {
        // public int receiptTypeId { get; set; }
        public string receiptTypeCode { get; set; }
        public double amtCredit { get; set; }
        //  public double amtDebit { get; set; }
        public UyumVirmanDetail[] details { get; set; }
        //  public int cardId { get; set; }
        public string cardCode { get; set; }
        //   public string cardName { get; set; }
        //   public UyumVirmanEntityinfo entityInfo { get; set; }
        //   public bool useCardIntgId { get; set; }
        //   public string cashDocTraCode { get; set; }
        //   public int cashDocTraId { get; set; }
        //   public int coId { get; set; }
        public string coCode { get; set; }
        //   public int branchId { get; set; }
        public string branchCode { get; set; }
        public DateTime docDate { get; set; }
        public string docNo { get; set; }
        //   public int docNumberDId { get; set; }
        //   public int catCode1Id { get; set; }
        //  public string catCode1 { get; set; }
        //  public int catCode2Id { get; set; }
        //   public string catCode2 { get; set; }
        public string sourceApp { get; set; }
        //   public string sourceApp2 { get; set; }
        //   public string sourceApp3 { get; set; }
        //   public int sourceMId { get; set; }
        //   public int sourceDId { get; set; }
        //   public UyumVirmanController controller { get; set; }
        //  public string note1 { get; set; }
        //   public string note2 { get; set; }
        //   public string note3 { get; set; }
        //  public int createUserId { get; set; }
        public string currencyOption { get; set; }
        //   public string entityOrderNo { get; set; }
        //   public DateTime entityOrderDate { get; set; }
        //   public int disc0Id { get; set; }
        //    public string discCode0 { get; set; }
        //    public int disc0Rate { get; set; }
        //    public int amtDisc0Tra { get; set; }
        //   public string discCalcType0 { get; set; }
    }

    public class UyumVirmanEntityinfo
    {
        public int entityId { get; set; }
        public string entityCode { get; set; }
        public string entityName { get; set; }
        public string entityNameShort { get; set; }
        public bool searchByEntityId { get; set; }
        public bool putByEntityId { get; set; }
        public bool searchByEntityCode { get; set; }
        public bool putByEntityCode { get; set; }
        public int taxOfficeId { get; set; }
        public string taxOfficeCode { get; set; }
        public string taxOfficeName { get; set; }
        public string taxNo { get; set; }
        public string tel { get; set; }
        public string tel2 { get; set; }
        public string fax { get; set; }
        public string webSite { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string address3 { get; set; }
        public int countryId { get; set; }
        public string countryName { get; set; }
        public string countryCode { get; set; }
        public int cityId { get; set; }
        public string cityName { get; set; }
        public int townId { get; set; }
        public string townName { get; set; }
        public int coId { get; set; }
        public string coCode { get; set; }
        public string entityType { get; set; }
        public string domesticForeign { get; set; }
        public bool otomaticCreateEntityCode { get; set; }
        public string cardIntgGroupCode { get; set; }
        public string accCode { get; set; }
        public string entityGrpCode { get; set; }
        public string entityGrpCode2 { get; set; }
        public string entityGrpCode3 { get; set; }
        public int categories1Id { get; set; }
        public int categories2Id { get; set; }
        public int categories20Id { get; set; }
        public string categories1Code { get; set; }
        public string categories2Code { get; set; }
        public int addDec01 { get; set; }
        public int addDec02 { get; set; }
        public int addDec03 { get; set; }
        public int addDec04 { get; set; }
        public int addDec05 { get; set; }
        public int addDec06 { get; set; }
        public int addDec07 { get; set; }
        public int addDec08 { get; set; }
        public int addDec09 { get; set; }
        public int addDec10 { get; set; }
        public string contactFirstName { get; set; }
        public string contactLastName { get; set; }
        public int contactId { get; set; }
        public string contactTel { get; set; }
        public string contactFax { get; set; }
        public string contactMail { get; set; }
        public string eInvoiceProfile { get; set; }
        public bool iseInvoiceEntity { get; set; }
        public int dueDay { get; set; }
        public string firstName { get; set; }
        public string familyName { get; set; }
        public string contactCode { get; set; }
        public int contactGrpId { get; set; }
        public string contactGrpCode { get; set; }
        public string dueDateBase { get; set; }
        public int paymentMethodId2 { get; set; }
        public string paymentMethodCode2 { get; set; }
        public string email { get; set; }
        public int salesPersonId { get; set; }
        public string salesPersonCode { get; set; }
        public int parentEntityId { get; set; }
        public string parentEntityCode { get; set; }
        public int riskGrpId { get; set; }
        public string riskGrpCode { get; set; }
        public string addString10 { get; set; }
        public string addString09 { get; set; }
        public string addString08 { get; set; }
        public bool otomaticCreateAccCode { get; set; }
        public string invDeliveryType { get; set; }
        public string mailAttachmentInf { get; set; }
        public bool ispassive { get; set; }
        public string ibanNo { get; set; }
        public int sectorId { get; set; }
        public string identifyNo { get; set; }
        public string entityB2BCode { get; set; }
        public int purchasePersonId { get; set; }
        public string purchasePersonCode { get; set; }
        public int entityPriceGrpPId { get; set; }
        public int entityPriceGrpSId { get; set; }
        public UyumVirmanEntitybanklist[] entityBankList { get; set; }
        public bool isUseGnlEnt { get; set; }
        public bool isUseGnlEntity { get; set; }
        public string gnlEntityCode { get; set; }
        public string entityPrefix { get; set; }
        public bool cashFlowInclusion { get; set; }
        public UyumVirmanEntitycontactlist[] entityContactList { get; set; }
        public UyumVirmanCoentityintegrationlist[] coEntityIntegrationList { get; set; }
        public string zipCode { get; set; }
        public string passportNo { get; set; }
        public string mobilePhone { get; set; }
    }

    public class UyumVirmanEntitybanklist
    {
        public string ibanNo { get; set; }
        public int bankId { get; set; }
        public string bankCode { get; set; }
        public int bankBranchId { get; set; }
        public string bankBranchCode { get; set; }
        public string bankAccNo { get; set; }
        public int curTraId { get; set; }
        public string curTraCode { get; set; }
        public string description { get; set; }
    }

    public class UyumVirmanEntitycontactlist
    {
        public string contactFirstName { get; set; }
        public string contactLastName { get; set; }
        public int contactId { get; set; }
        public string contactTel { get; set; }
        public string contactFax { get; set; }
        public string contactMail { get; set; }
        public string contactCode { get; set; }
        public bool isAuthorized { get; set; }
    }

    public class UyumVirmanCoentityintegrationlist
    {
        public string cardIntgCode { get; set; }
        public string accCode { get; set; }
        public string note1 { get; set; }
    }

    public class UyumVirmanController
    {
        public string register1 { get; set; }
        public string register2 { get; set; }
        public string register3 { get; set; }
        public string register4 { get; set; }
        public string generalNote1 { get; set; }
        public string generalNote2 { get; set; }
        public string generalNote3 { get; set; }
        public string generalNote4 { get; set; }
        public string generalNote5 { get; set; }
        public string generalNote6 { get; set; }
        public string generalNote7 { get; set; }
        public string generalNote8 { get; set; }
        public string generalNote9 { get; set; }
        public string generalNote10 { get; set; }
        public string noteLarge { get; set; }
    }

    public class UyumVirmanDetail
    {
        //  public int traTypeId { get; set; }
        public string traTypeCode { get; set; }
        public int finDCardId { get; set; }
        //public string cardCode { get; set; }
        //public string docNo { get; set; }
        public double amt { get; set; }
        public double amtTra { get; set; }
        //public DateTime dueDate { get; set; }
        //public UyumVirmanEntityinfo1 entityInfo { get; set; }
        //public string cardIntgCodePrefix { get; set; }
        //public int abtBudgetId { get; set; }
        //public string abtBudgetCode { get; set; }
        //public string abtActCode { get; set; }
        //public string salesPersonCode { get; set; }
        //public int salesPersonId { get; set; }
        //public string abtOperation { get; set; }
        //public int createUserId { get; set; }
        //public int formContractMId { get; set; }
        //public string formContractCode { get; set; }
        //public string cashDocTraCode { get; set; }
        //public int cashDocTraId { get; set; }
        //public int lineNo { get; set; }
        //public int curTraId { get; set; }
        public string curCode { get; set; }
        //public int curRateTypeId { get; set; }
        //public string curRateTypeCode { get; set; }
        public int curRateTra { get; set; }
        //public string note1 { get; set; }
        //public string note2 { get; set; }
        //public string note3 { get; set; }
        //public string noteLarge { get; set; }
        //public int catCode1Id { get; set; }
        //public string catCode1 { get; set; }
        //public int catCode2Id { get; set; }
        //public string catCode2 { get; set; }
        //public int sourceMId { get; set; }
        //public int sourceDId { get; set; }
        //public int sourceD3Id { get; set; }
        //public int sourceOrderMId { get; set; }
        //public int sourceOrderDId { get; set; }
        //public int costCenterId { get; set; }
        //public string costCenterCode { get; set; }
        //public int projectMId { get; set; }
        //public string projectCode { get; set; }
        //public int gainLossTypeId { get; set; }
        //public string gainLossTypeCode { get; set; }
        //public string analysisCode { get; set; }
        //public int analysisId { get; set; }
        //public string taxTemplateName { get; set; }
        //public int taxTemplateMId { get; set; }
        //public string plusMinus { get; set; }
        //public string contactName { get; set; }
        //public int contactId { get; set; }
        public string sourceApp { get; set; }
        //public string sourceApp2 { get; set; }
        //public string sourceApp3 { get; set; }
    }

    public class UyumVirmanEntityinfo1
    {
        public int entityId { get; set; }
        public string entityCode { get; set; }
        public string entityName { get; set; }
        public string entityNameShort { get; set; }
        public bool searchByEntityId { get; set; }
        public bool putByEntityId { get; set; }
        public bool searchByEntityCode { get; set; }
        public bool putByEntityCode { get; set; }
        public int taxOfficeId { get; set; }
        public string taxOfficeCode { get; set; }
        public string taxOfficeName { get; set; }
        public string taxNo { get; set; }
        public string tel { get; set; }
        public string tel2 { get; set; }
        public string fax { get; set; }
        public string webSite { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string address3 { get; set; }
        public int countryId { get; set; }
        public string countryName { get; set; }
        public string countryCode { get; set; }
        public int cityId { get; set; }
        public string cityName { get; set; }
        public int townId { get; set; }
        public string townName { get; set; }
        public int coId { get; set; }
        public string coCode { get; set; }
        public string entityType { get; set; }
        public string domesticForeign { get; set; }
        public bool otomaticCreateEntityCode { get; set; }
        public string cardIntgGroupCode { get; set; }
        public string accCode { get; set; }
        public string entityGrpCode { get; set; }
        public string entityGrpCode2 { get; set; }
        public string entityGrpCode3 { get; set; }
        public int categories1Id { get; set; }
        public int categories2Id { get; set; }
        public int categories20Id { get; set; }
        public string categories1Code { get; set; }
        public string categories2Code { get; set; }
        public int addDec01 { get; set; }
        public int addDec02 { get; set; }
        public int addDec03 { get; set; }
        public int addDec04 { get; set; }
        public int addDec05 { get; set; }
        public int addDec06 { get; set; }
        public int addDec07 { get; set; }
        public int addDec08 { get; set; }
        public int addDec09 { get; set; }
        public int addDec10 { get; set; }
        public string contactFirstName { get; set; }
        public string contactLastName { get; set; }
        public int contactId { get; set; }
        public string contactTel { get; set; }
        public string contactFax { get; set; }
        public string contactMail { get; set; }
        public string eInvoiceProfile { get; set; }
        public bool iseInvoiceEntity { get; set; }
        public int dueDay { get; set; }
        public string firstName { get; set; }
        public string familyName { get; set; }
        public string contactCode { get; set; }
        public int contactGrpId { get; set; }
        public string contactGrpCode { get; set; }
        public string dueDateBase { get; set; }
        public int paymentMethodId2 { get; set; }
        public string paymentMethodCode2 { get; set; }
        public string email { get; set; }
        public int salesPersonId { get; set; }
        public string salesPersonCode { get; set; }
        public int parentEntityId { get; set; }
        public string parentEntityCode { get; set; }
        public int riskGrpId { get; set; }
        public string riskGrpCode { get; set; }
        public string addString10 { get; set; }
        public string addString09 { get; set; }
        public string addString08 { get; set; }
        public bool otomaticCreateAccCode { get; set; }
        public string invDeliveryType { get; set; }
        public string mailAttachmentInf { get; set; }
        public bool ispassive { get; set; }
        public string ibanNo { get; set; }
        public int sectorId { get; set; }
        public string identifyNo { get; set; }
        public string entityB2BCode { get; set; }
        public int purchasePersonId { get; set; }
        public string purchasePersonCode { get; set; }
        public int entityPriceGrpPId { get; set; }
        public int entityPriceGrpSId { get; set; }
        public UyumVirmanEntitybanklist1[] entityBankList { get; set; }
        public bool isUseGnlEnt { get; set; }
        public bool isUseGnlEntity { get; set; }
        public string gnlEntityCode { get; set; }
        public string entityPrefix { get; set; }
        public bool cashFlowInclusion { get; set; }
        public UyumVirmanEntitycontactlist1[] entityContactList { get; set; }
        public UyumVirmanCoentityintegrationlist1[] coEntityIntegrationList { get; set; }
        public string zipCode { get; set; }
        public string passportNo { get; set; }
        public string mobilePhone { get; set; }
    }

    public class UyumVirmanEntitybanklist1
    {
        public string ibanNo { get; set; }
        public int bankId { get; set; }
        public string bankCode { get; set; }
        public int bankBranchId { get; set; }
        public string bankBranchCode { get; set; }
        public string bankAccNo { get; set; }
        public int curTraId { get; set; }
        public string curTraCode { get; set; }
        public string description { get; set; }
    }

    public class UyumVirmanEntitycontactlist1
    {
        public string contactFirstName { get; set; }
        public string contactLastName { get; set; }
        public int contactId { get; set; }
        public string contactTel { get; set; }
        public string contactFax { get; set; }
        public string contactMail { get; set; }
        public string contactCode { get; set; }
        public bool isAuthorized { get; set; }
    }

    public class UyumVirmanCoentityintegrationlist1
    {
        public string cardIntgCode { get; set; }
        public string accCode { get; set; }
        public string note1 { get; set; }
    }

}