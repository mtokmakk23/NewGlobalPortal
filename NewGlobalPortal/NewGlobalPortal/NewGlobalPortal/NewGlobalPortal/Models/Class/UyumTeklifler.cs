using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewGlobalPortal.Models.Class
{

    public class UyumTekliflerSonuc
    {
        public int statusCode { get; set; }
        public string message { get; set; }
        public string result { get; set; }
        public int pageIndex { get; set; }
        public int pageSize { get; set; }
        public int totalPages { get; set; }
        public int totalCount { get; set; }
    }





    public class UyumTeklifler
    {
        public Xml xml { get; set; }
        public Uyumcollection UyumCollection { get; set; }
    }

    public class Xml
    {
        public string version { get; set; }
        public string encoding { get; set; }
    }
    public class TeklifResult
    {
        public UyumTeklifMaster[] UyumMaster { get; set; }
        public UyumTeklifDetay[] UyumDetay { get; set; }
    }
    public class Uyumcollection
    {
        public UyumTeklifMaster[] Uyum { get; set; }
       
    }

    public class UyumTeklifMaster
    {
        public string ExpireDate { get; set; }
        public string OpenAccLimit { get; set; }
        public string FullCheckLimit { get; set; }
        public string EndorserCheckLimit { get; set; }
        public string SelfCheckLimit { get; set; }
        public string UnpaidCadLimit { get; set; }
        public string DraftLimit { get; set; }
        public string MaxLimit { get; set; }
        public string DTSLimit { get; set; }
        public string TASLimit { get; set; }
        public string OpenAccRisk { get; set; }
        public string FullCheckRisk { get; set; }
        public string EndorserCheckRisk { get; set; }
        public string SelfCheckRisk { get; set; }
        public string UnpaidCadRisk { get; set; }
        public string DraftRisk { get; set; }
        public string MaxRisk { get; set; }
        public string DTSRisk { get; set; }
        public string TASRisk { get; set; }
        public string OpenAccDiff { get; set; }
        public string MaxDiff { get; set; }
        public string FullCheckDiff { get; set; }
        public string EndorserCheckDiff { get; set; }
        public string SelfCheckDiff { get; set; }
        public string UnpaidCadDiff { get; set; }
        public string DraftDiff { get; set; }
        public string DTSDiff { get; set; }
        public string TASDiff { get; set; }
        public string IsSalesPackageLot { get; set; }
        public string CoId { get; set; }
        public string EntityId { get; set; }
        public string EntityName { get; set; }
        public string CurTraId { get; set; }
        public string Id { get; set; }
        public string OfferStatus { get; set; }
        public string PurchaseSales { get; set; }
        public string BranchId { get; set; }
        public string ActualRiskDifferance { get; set; }
        public string CurrencyOption { get; set; }
        public string CoDesc { get; set; }
        public string CountryCode { get; set; }
        public string IsoCountryCode { get; set; }
        public string CurTraDesc { get; set; }
        public string CurTraCode { get; set; }
        public object UyumDetailItem { get; set; }
        public string CreateUserId { get; set; }
        public string UpdateUserId { get; set; }
        public string CreateDate { get; set; }
        public string UpdateDate { get; set; }
        public string Amt { get; set; }
        public string AmtDisc0 { get; set; }
        public string AmtDisc0Tra { get; set; }
        public string AmtDiscTotal { get; set; }
        public string AmtDiscTotalTra { get; set; }
        public string AmtOtv { get; set; }
        public string AmtOtvTra { get; set; }
        public string AmtReceipt { get; set; }
        public string AmtReceiptTra { get; set; }
        public string AmtRound { get; set; }
        public string AmtRoundTra { get; set; }
        public string AmtTra { get; set; }
        public string AmtVat { get; set; }
        public string AmtVatDisc { get; set; }
        public string AmtVatDiscTra { get; set; }
        public string AmtVatTra { get; set; }
        public string AmtOtherTax { get; set; }
        public string AmtOtherTaxTra { get; set; }
        public string BranchCode { get; set; }
        public string BranchDesc { get; set; }
        public string CountryId { get; set; }
        public string CountryName { get; set; }
        public string IsoCurTraCode { get; set; }
        public string CurRateTra { get; set; }
        public string Disc0Rate { get; set; }
        public string Disc1Rate { get; set; }
        public string Disc2Rate { get; set; }
        public string Disc3Rate { get; set; }
        public string DocDate { get; set; }
        public string DocNo { get; set; }
        public string IsPrinted { get; set; }
        public string Note1 { get; set; }
        public string SourceApp { get; set; }
        public string VatDiscRate { get; set; }
        public string DocTraId { get; set; }
        public string DocTraCode { get; set; }
        public string InventoryStatus { get; set; }
        public string InvoiceType { get; set; }
        public string DocTraDesc { get; set; }
        public string EbookDocumentType { get; set; }
        public string EntityCode { get; set; }
        public string CoCode { get; set; }
        public string CoCurId { get; set; }
        public string PurchaseSalesVal { get; set; }
        public string AmtOiv { get; set; }
        public string AmtOivTra { get; set; }
        public string BrCountryId { get; set; }
        public string HasBrCountry { get; set; }
        public string PaymentMethodId { get; set; }
        public string PaymentMethodCode { get; set; }
        public string PaymentMethodType { get; set; }
        public string PaymentMethodDesc { get; set; }
        public string ShortCardName { get; set; }
        public string Address1 { get; set; }
        public string CityId { get; set; }
        public string CityName { get; set; }
        public string TownId { get; set; }
        public string TownName { get; set; }
        public string DueDay { get; set; }
        public string EntityEmail { get; set; }
    }


   

    public class UyumTeklifDetay
    {
        public string Id { get; set; }
        public string EntityOfferDate { get; set; }
        public string OfferMId { get; set; }
        public string OfferStatus { get; set; }
        public string PurchaseSales { get; set; }
        public string Qty { get; set; }
        public string QtyDemand { get; set; }
        public string QtyRejected { get; set; }
        public string QtyReserved { get; set; }
        public string QtyShipping { get; set; }
        public string BranchCode { get; set; }
        public string CurTraDesc { get; set; }
        public string DiscDesc1 { get; set; }
        public string VatDesc { get; set; }
        public string UnitDesc { get; set; }
        public string IsoUnitCode { get; set; }
        public string WhouseCode { get; set; }
        public string WhouseDesc { get; set; }
        public string DocNo { get; set; }
        public string EntityId { get; set; }
        public string EntityCode { get; set; }
        public string EntityName { get; set; }
        public string CurrencyOption { get; set; }
        public string DefaultAsortMode { get; set; }
        public string ReservationType { get; set; }
        public string ProdPackageQty { get; set; }
        public string ProdPackageInQty { get; set; }
        public string ProdPackageWeight { get; set; }
        public string CountryId { get; set; }
        public string CountryName { get; set; }
        public string CreateUserId { get; set; }
        public string UpdateUserId { get; set; }
        public string CreateDate { get; set; }
        public string UpdateDate { get; set; }
        public string Amt { get; set; }
        public string AmtDisc0 { get; set; }
        public string AmtDisc { get; set; }
        public string AmtWithDisc { get; set; }
        public string AmtDisc1 { get; set; }
        public string AmtDisc2 { get; set; }
        public string AmtDisc3 { get; set; }
        public string AmtDisc4 { get; set; }
        public string AmtDisc5 { get; set; }
        public string AmtDisc6 { get; set; }
        public string AmtMaktuOtv { get; set; }
        public string AmtOtv { get; set; }
        public string AmtOiv { get; set; }
        public string AmtTra { get; set; }
        public string AmtVat { get; set; }
        public string AmtVatDisc { get; set; }
        public string CurTraCode { get; set; }
        public string CurRateTra { get; set; }
        public string CurTraId { get; set; }
        public string Disc1Id { get; set; }
        public string Disc1Rate { get; set; }
        public string Disc2Rate { get; set; }
        public string Disc3Rate { get; set; }
        public string DiscCode1 { get; set; }
        public string DiscDescription1 { get; set; }
        public string QtyFreePrm { get; set; }
        public string QtyFreeSec { get; set; }
        public string QtyPrm { get; set; }
        public string VatCode { get; set; }
        public string VatName { get; set; }
        public string VatRate { get; set; }
        public string OtvRate { get; set; }
        public string OivRate { get; set; }
        public string UnitPrice { get; set; }
        public string UnitPriceTra { get; set; }
        public string VatDiscRate { get; set; }
        public string VatId { get; set; }
        public string VatStatus { get; set; }
        public string LineType { get; set; }
        public string DocDate { get; set; }
        public string BranchDesc { get; set; }
        public string BranchId { get; set; }
        public string BwhDesc { get; set; }
        public string CoId { get; set; }
        public string DcardId { get; set; }
        public string DcardCode { get; set; }
        public string DcardName { get; set; }
        public string IsEnabled1Id { get; set; }
        public string DiscCalcType1 { get; set; }
        public string ItemId { get; set; }
        public string LineNo { get; set; }
        public string SourceApp { get; set; }
        public string UnitId { get; set; }
        public string UnitCode { get; set; }
        public string WhouseId { get; set; }
        public string AmtDisc0Tra { get; set; }
        public string AmtDisc1Tra { get; set; }
        public string AmtDisc2Tra { get; set; }
        public string AmtDisc3Tra { get; set; }
        public string AmtDisc4Tra { get; set; }
        public string AmtDisc5Tra { get; set; }
        public string AmtDisc6Tra { get; set; }
        public string AmtDiscTra { get; set; }
        public string AmtWithDiscTra { get; set; }
        public string AmtWithDiscTraForUnit { get; set; }
        public string UnitPriceTra0 { get; set; }
    }

    public class UyunTeklifValue
    {
        public UyumTeklifOlustur value { get; set; }
    }
    public class UyumTeklifOlustur
    {
        public int entityId { get; set; }
        public string entityCode { get; set; }
        public bool isApproveByMaster { get; set; }
        public int formContractMId { get; set; }
        public string orderStatus { get; set; }
        public TeklifDetail[] details { get; set; }
        public DateTime entityRequestDate { get; set; }
        public int docTraId { get; set; }
        public string docTraCode { get; set; }
        public int amtVatTra { get; set; }
        public int amtVat { get; set; }
        public int amtTra { get; set; }
        public int amt { get; set; }
        public int amtReceiptTra { get; set; }
        public int amtReceipt { get; set; }
        public int amtRoundTra { get; set; }
        public int amtRound { get; set; }
        public int curTra { get; set; }
        public string curCode { get; set; }
        public int curId { get; set; }
        public int curRateTypeId { get; set; }
        public string curRateTypeCode { get; set; }
        public DateTime dueDate { get; set; }
        public int dueDay { get; set; }
        public DateTime shippingDate { get; set; }
        public DateTime deliveryDate { get; set; }
        public string salesPersonCode { get; set; }
        public int salesPersonId { get; set; }
        public int paymentPlanMId { get; set; }
        public string paymentPlanCode { get; set; }
        public string transportTypeCode { get; set; }
        public int transportTypeId { get; set; }
        public string transporterCode { get; set; }
        public int transporterId { get; set; }
        public int incotermsId { get; set; }
        public string incotermsName { get; set; }
        public int paymentMethodId { get; set; }
        public string paymentMethodCode { get; set; }
        public string gnlNote1 { get; set; }
        public string gnlNote2 { get; set; }
        public string gnlNote3 { get; set; }
        public string gnlNote4 { get; set; }
        public string gnlNote5 { get; set; }
        public string gnlNote6 { get; set; }
        public string gnlNote7 { get; set; }
        public string gnlNote8 { get; set; }
        public string gnlNote9 { get; set; }
        public string gnlNote10 { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string address3 { get; set; }
        public int cityId { get; set; }
        public int townId { get; set; }
        public int countyId { get; set; }
        public string shippingAddress1 { get; set; }
        public string shippingAddress2 { get; set; }
        public string shippingAddress3 { get; set; }
        public int shippingCityId { get; set; }
        public int shippingTownId { get; set; }
        public int shippingCountyId { get; set; }
        public string shippingEntityCode { get; set; }
        public int shippingEntityId { get; set; }
        public string addressTypeCode { get; set; }
        public bool isShippingAddressType { get; set; }
        public string webAddress { get; set; }
        public string firstName { get; set; }
        public string familyName { get; set; }
        public string email { get; set; }
        public bool isDocDifferentCur { get; set; }
        public string zipCode { get; set; }
        public string shippingZipCode { get; set; }
        public string vehicleCode { get; set; }
        public int vehicleId { get; set; }
        public string driverIdentifyNo { get; set; }
        public string driverGsmNo { get; set; }
        public string shippingDesc1 { get; set; }
        public string transportEquipment { get; set; }
        public string driverFamilyName { get; set; }
        public string licencePlate { get; set; }
        public bool isTCMB { get; set; }
        public bool isLocalCurAction { get; set; }
        public int coId { get; set; }
        public string coCode { get; set; }
        public int branchId { get; set; }
        public string branchCode { get; set; }
        public DateTime docDate { get; set; }
        public DateTime expireDate { get; set; }
        public string docNo { get; set; }
        public int docNumberDId { get; set; }
        public int catCode1Id { get; set; }
        public string catCode1 { get; set; }
        public int catCode2Id { get; set; }
        public string catCode2 { get; set; }
        public string sourceApp { get; set; }
        public string sourceApp2 { get; set; }
        public string sourceApp3 { get; set; }
        public int sourceMId { get; set; }
        public int sourceDId { get; set; }
        public TeklifController controller { get; set; }
        public string note1 { get; set; }
        public string note2 { get; set; }
        public string note3 { get; set; }
        public int createUserId { get; set; }
        public string currencyOption { get; set; }
        public string entityOrderNo { get; set; }
        public DateTime entityOrderDate { get; set; }
        public int disc0Id { get; set; }
        public string discCode0 { get; set; }
        public int disc0Rate { get; set; }
        public int amtDisc0Tra { get; set; }
        public string discCalcType0 { get; set; }
    }

    public class TeklifController
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

    public class TeklifDetail
    {
        public int colorId { get; set; }
        public string colorCode { get; set; }
        public string packageTypeCode { get; set; }
        public int packageTypeId { get; set; }
        public int itemId { get; set; }
        public int expenseId { get; set; }
        public DateTime deliveryDate { get; set; }
        public DateTime shippingDate { get; set; }
        public DateTime entityRequestDate { get; set; }
        public string lineType { get; set; }
        public int dcardId { get; set; }
        public string dcardCode { get; set; }
        public int unitId { get; set; }
        public string unitCode { get; set; }
        public int qty { get; set; }
        public int qtyPrm { get; set; }
        public int qtyFreePrm { get; set; }
        public int qtyFreeSec { get; set; }
        public int dueDay { get; set; }
        public int campaignId { get; set; }
        public double unitPriceTra { get; set; }
        public double unitPrice { get; set; }
        public string vatStatus { get; set; }
        public int vatId { get; set; }
        public string vatCode { get; set; }
        public double vatRate { get; set; }
        public double amtVat { get; set; }
        public string abtActCode { get; set; }
        public int abtActId { get; set; }
        public int abtBudgetId { get; set; }
        public string abtBudgetCode { get; set; }
        public string otvCode { get; set; }
        public string oivCode { get; set; }
        public string vatDiscCode { get; set; }
        public string priceListCode { get; set; }
        public int priceListId { get; set; }
        public int priceListDId { get; set; }
        public int whouseId { get; set; }
        public string whouseCode { get; set; }
        public int abtBudgetD2Id { get; set; }
        public int disc1Id { get; set; }
        public string disc1Code { get; set; }
        public int disc1Rate { get; set; }
        public double amtDisc1 { get; set; }
        public double amtDisc1Tra { get; set; }
        public int disc2Id { get; set; }
        public string disc2Code { get; set; }
        public int disc2Rate { get; set; }
        public int amtDisc2 { get; set; }
        public int amtDisc2Tra { get; set; }
        public int disc3Id { get; set; }
        public string disc3Code { get; set; }
        public int disc3Rate { get; set; }
        public int amtDisc3 { get; set; }
        public int amtDisc3Tra { get; set; }
        public int amtDisc { get; set; }
        public int amtWithDisc { get; set; }
        public int amt { get; set; }
        public int amtTra { get; set; }
        public int formContractMId { get; set; }
        public string formContractCode { get; set; }
        public int itemAttribute1Id { get; set; }
        public string itemAttributeCode1 { get; set; }
        public int itemAttribute2Id { get; set; }
        public string itemAttributeCode2 { get; set; }
        public int itemAttribute3Id { get; set; }
        public string itemAttributeCode3 { get; set; }
        public int itemGnlAttribute1Id { get; set; }
        public string itemGnlAttributeCode1 { get; set; }
        public int itemGnlAttribute2Id { get; set; }
        public string itemGnlAttributeCode2 { get; set; }
        public int itemGnlAttribute3Id { get; set; }
        public string itemGnlAttributeCode3 { get; set; }
        public string discCalcType1 { get; set; }
        public string discCalcType2 { get; set; }
        public string discCalcType3 { get; set; }
        public string referanceDocNo { get; set; }
        public int lotId { get; set; }
        public string lotCode { get; set; }
        public int qualityId { get; set; }
        public string qualityCode { get; set; }
        public string barcode { get; set; }
        public string itemNameManual { get; set; }
        public int salesPersonId { get; set; }
        public bool isItemAttribute { get; set; }
        public int registerId { get; set; }
        public string registerFullName { get; set; }
        public int lineNo { get; set; }
        public int curTraId { get; set; }
        public string curCode { get; set; }
        public int curRateTypeId { get; set; }
        public string curRateTypeCode { get; set; }
        public int curRateTra { get; set; }
        public string note1 { get; set; }
        public string note2 { get; set; }
        public string note3 { get; set; }
        public string noteLarge { get; set; }
        public int catCode1Id { get; set; }
        public string catCode1 { get; set; }
        public int catCode2Id { get; set; }
        public string catCode2 { get; set; }
        public int sourceMId { get; set; }
        public int sourceDId { get; set; }
        public int sourceD3Id { get; set; }
        public int sourceOrderMId { get; set; }
        public int sourceOrderDId { get; set; }
        public int costCenterId { get; set; }
        public string costCenterCode { get; set; }
        public int projectMId { get; set; }
        public string projectCode { get; set; }
        public int gainLossTypeId { get; set; }
        public string gainLossTypeCode { get; set; }
        public string analysisCode { get; set; }
        public int analysisId { get; set; }
        public string taxTemplateName { get; set; }
        public int taxTemplateMId { get; set; }
        public string plusMinus { get; set; }
        public string contactName { get; set; }
        public int contactId { get; set; }
        public string sourceApp { get; set; }
        public string sourceApp2 { get; set; }
        public string sourceApp3 { get; set; }
    }

}